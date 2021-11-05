using MalikTraders.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MalikTraders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalaticsController : ControllerBase
    {
        MTDbContext _context;
        public AnalaticsController(MTDbContext mTDbContext)
        {
            _context = mTDbContext;
        }

        [HttpGet("[action]")]
        public IActionResult GetTodayRecovery()
        {
            try
            {
               
                var myList = from AD in _context.AccDetails.ToList()
                             join Acc in _context.Accounts.ToList() on AD.AccId equals Acc.id
                             join MTS in _context.MTServices.ToList() on Acc.MTServiceId equals MTS.id
                             join u in _context.Users.ToList() on Acc.Userid equals u.id
                             join ud in _context.userDetails.ToList() on u.UserDetail.id equals ud.id
                             where(AD.PayingDate.Date == DateTime.Now.Date)
                             select new
                             {
                                 AccId = Acc.id,
                                 Name = ud.Name,
                                 Phone = ud.PhoneNumber,
                                 Scheme = MTS.Name,
                                 Payed_Amount = AD.payedAmount,
                                 Pay_Time = AD.PayingDate.ToShortTimeString()
                             };
                             

                return Ok(myList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("[action]")]
        public IActionResult GetRemainingRecoveryCurrentMonth()
        {
            try
            {
                var dataList = from acc in _context.Accounts
                               join AccD in _context.AccDetails
                               on acc.id equals AccD.AccId
                               into unpayed_Acc
                               from unPayed in unpayed_Acc.DefaultIfEmpty()
                               where unPayed.PayingDate.Month == DateTime.Now.Month
                               select acc;

                List<Account> accounts = _context.Accounts.ToList();
                List<Account> UnPayedList = _context.Accounts.ToList();
                foreach (Account data in dataList)
                {
                    foreach (Account account in accounts)
                    {
                        if (data.id == account.id)
                        {
                            UnPayedList.Remove(account);
                        }
                    }
                }

                var detailsAboutUnPayed = from Acc in UnPayedList
                                          join U in _context.Users on Acc.Userid equals U.id
                                          join UD in _context.userDetails on U.UserDetail.id equals UD.id
                                          join MTS in _context.MTServices on Acc.MTServiceId equals MTS.id
                                          select new
                                          {
                                              AccId = Acc.id,
                                              Name = UD.Name,
                                              Phone = UD.PhoneNumber,
                                              Scheme = MTS.Name,
                                          };


                return Ok(detailsAboutUnPayed);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("[action]/{date}")]
        public IActionResult GetRemainingRecoveryGivenMonth(DateTime date)
        {
            try
            {
                var dataList = from acc in _context.Accounts
                               join AccD in _context.AccDetails
                               on acc.id equals AccD.AccId
                               into unpayed_Acc
                               from unPayed in unpayed_Acc.DefaultIfEmpty()
                               where unPayed.PayingDate.Month == date.Month
                               select acc;

                List<Account> accounts = _context.Accounts.ToList();
                List<Account> UnPayedList = _context.Accounts.ToList();
                foreach (Account data in dataList)
                {
                    foreach (Account account in accounts)
                    {
                        if (data.id == account.id)
                        {
                            UnPayedList.Remove(account);
                        }
                    }
                }

                var detailsAboutUnPayed = from Acc in UnPayedList
                                          join U in _context.Users on Acc.Userid equals U.id
                                          join UD in _context.userDetails on U.UserDetail.id equals UD.id
                                          join MTS in _context.MTServices on Acc.MTServiceId equals MTS.id
                                          select new
                                          {
                                              AccId = Acc.id,
                                              Name = UD.Name,
                                              Phone = UD.PhoneNumber,
                                              Scheme = MTS.Name,
                                          };


                return Ok(detailsAboutUnPayed);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("[action]")]
        public IActionResult GetPaidAndUnpaidCustomerReportOfScheme(DateTime StartMonth, DateTime EndtartMonth, int SchemeId,bool WithCloseAcc)
        {
            try
            {
                if (StartMonth > EndtartMonth) BadRequest("Please Check Date we have find you start and end Date conflict thank you");
                int TotalSchemeCustomers = _context.Accounts.Count(x => x.MTServiceId == SchemeId && x.isAccClosed == WithCloseAcc);
                
                List<object> list = new List<object>();
                while (StartMonth <= EndtartMonth)
                {
                    object AnalyticDataPerMonth = new
                    {
                        Month = StartMonth,
                        TotalPaidCustomer = (from Acc in _context.Accounts.Where(x => x.MTServiceId == SchemeId && x.isAccClosed == WithCloseAcc).ToList()
                                             join AccD in _context.AccDetails.Where(x => x.PayingDate.Month == StartMonth.Month && x.PayingDate.Year == StartMonth.Year).ToList()
                                             on Acc.id equals AccD.AccId
                                             select AccD).Count(),
                        TotalPaidAmount = (from Acc in _context.Accounts.Where(x => x.MTServiceId == SchemeId && x.isAccClosed == WithCloseAcc).ToList()
                                           join AccD in _context.AccDetails.Where(x => x.PayingDate.Month == StartMonth.Month && x.PayingDate.Year == StartMonth.Year).ToList()
                                           on Acc.id equals AccD.AccId
                                           select AccD).Sum(x=>x.payedAmount),
                    };
                    list.Add(AnalyticDataPerMonth);
                    StartMonth = StartMonth.AddMonths(1);
                }
                var data = new
                {
                    TotalCustomer = TotalSchemeCustomers,
                    Data = list
                };
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("[action]/{UserId}")]
        public IActionResult GetUserAllInfo(int UserId)
        {
            try
            {
                User user = _context.Users.Find(UserId);
                user.UserDetail = _context.userDetails.FirstOrDefault(x => x.UserId == UserId);
                user.SchemeAccounts = _context.Accounts.Where(x => x.Userid == UserId).ToList();
                user.UserShopAccount = _context.ShopAccount.FirstOrDefault(x => x.UserId == UserId);
                if(user.UserShopAccount != null) 
                user.UserShopAccount.ShopAccountPayments = _context.ShopAccountPaymentHistory.Where(x => x.ShopAccountId == user.UserShopAccount.Id).ToList();

                for (int i=0; i < user.SchemeAccounts.Count; i++)
                {
                    user.SchemeAccounts[i].AccPaymentDetails = _context.AccDetails.Where(x => x.AccId == user.SchemeAccounts[i].id).ToList();
                }
                if (user.UserShopAccount != null)
                    user.UserShopAccount.ShopAccUser = null;
                user.Password = null;
                return Ok(user);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
