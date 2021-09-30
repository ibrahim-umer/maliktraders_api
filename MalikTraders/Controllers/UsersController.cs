﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MalikTraders.Models;

namespace MalikTraders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MTDbContext _context;

        public UsersController(MTDbContext context)
        {
            _context = context;
        }

        [HttpPost("[action]/{Uid}")]
        public async Task<IActionResult> GetUserDatailsId(int Uid)
        {
            try
            {
                
                var ud = from user in await _context.Users.ToListAsync()
                         join userD in await _context.userDetails.ToListAsync()
                         on user.userDetails.id equals userD.id
                         where user.id == Uid
                         select userD;
                int udID = 0;
                foreach(UserDetails userDetails in ud)
                {
                    udID = userDetails.id;
                }
                return Ok(udID);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            try
            {
                var users = from user in await _context.Users.ToListAsync()
                            join userD in await _context.userDetails.ToListAsync()
                            on user.userDetails.id equals userD.id
                            select new 
                            { 
                                user.id, 
                                userD.Name,
                                user.UserName,
                                user.Role,
                                userD.PhoneNumber,
                                userD.Registration_Date,
                                userD.Gender,
                                userD.LastLogin,
                                userD.Address,
                                userD.CNIC,
                                user.email
                            };
                
                return Ok(users);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("[action]/{CNIC}")]
        public async Task<ActionResult<IEnumerable<User>>> SearchUserbyCNIC(string CNIC)
        {
            try
            {
                var users = from user in await _context.Users.ToListAsync()
                            join userD in await _context.userDetails.ToListAsync()
                            on user.userDetails.id equals userD.id
                            where userD.CNIC.Contains(CNIC)
                            select new
                            {
                                user.id,
                                userD.Name,
                                user.UserName,
                                user.Role,
                                userD.PhoneNumber,
                                userD.Registration_Date,
                                userD.Gender,
                                userD.LastLogin,
                                userD.Address,
                                userD.CNIC,
                                user.email
                            };
                
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]/{Name}")]
        public async Task<ActionResult<IEnumerable<User>>> SearchUserbyName(string Name)
        {
            try
            {
                var users = from user in await _context.Users.ToListAsync()
                            join userD in await _context.userDetails.ToListAsync()
                            on user.userDetails.id equals userD.id
                            where userD.Name.ToLower().Contains(Name.ToLower()) 
                            select new
                            {
                                user.id,
                                userD.Name,
                                user.UserName,
                                user.Role,
                                userD.PhoneNumber,
                                userD.Registration_Date,
                                userD.Gender,
                                userD.LastLogin,
                                userD.Address,
                                userD.CNIC,
                                user.email
                            };
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            user.userDetails.Registration_Date = DateTime.Now;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.id }, user);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<User>> LoginUser(string  UserName, string Password)
        {
            try
            {
                User _user = await _context.Users.FirstAsync(x => x.Password == Password && x.UserName == UserName);
                return Ok(_user);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.id == id);
        }
    }
}
