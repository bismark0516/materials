﻿using Microsoft.AspNetCore.Mvc;
using PetInfoServer.DAO;
using PetInfoServer.Exceptions;
using PetInfoServer.Models;
using PetInfoServer.Security;

namespace PetInfoServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ITokenGenerator tokenGenerator;
        private readonly IPasswordHasher passwordHasher;
        private readonly IUserDao userDao;

        public LoginController(ITokenGenerator tokenGenerator, IPasswordHasher passwordHasher, IUserDao userDao)
        {
            this.tokenGenerator = tokenGenerator;
            this.passwordHasher = passwordHasher;
            this.userDao = userDao;
        }

        //GET /
        [HttpGet("/")]
        public ActionResult<string> Ready()
        {
            return Ok("Server is ready!");
        }

        //GET /whoami
        [HttpGet("/whoami")]
        public ActionResult<string> WhoAmI()
        {
            string result = User.Identity.Name;
            if (result == null)
            {
                return "No token provided.";
            }
            else
            {
                return result;
            }
        }

        // POST /login
        [HttpPost]
        public IActionResult Authenticate(LoginUser userParam)
        {
            // Default to bad username/password message
            IActionResult result = Unauthorized(new { message = "Username or password is incorrect." });

            User user;
            // Get the user by username
            try
            {
                user = userDao.GetUserByUsername(userParam.Username);
            }
            catch (DaoException)
            {
                // return default Unauthorized message instead of indicating a specific error
                return result;
            }

            // If we found a user and the password hash matches
            if (user != null && passwordHasher.VerifyHashMatch(user.PasswordHash, userParam.Password, user.Salt))
            {
                // Create an authentication token
                string token = tokenGenerator.GenerateToken(user.UserId, user.Username);

                // Create a ReturnUser object to return to the client
                ReturnUser retUser = new ReturnUser() { UserId = user.UserId, Username = user.Username, Token = token };

                // Switch to 200 OK
                result = Ok(retUser);
            }

            return result;
        }

        // POST /login/register
        [HttpPost("register")]
        public IActionResult Register(LoginUser userParam)
        {
            // Default generic error message
            const string ErrorMessage = "An error occurred and user was not created.";

            IActionResult result = BadRequest(new { message = ErrorMessage });

            // is username already taken?
            try
            {
                User existingUser = userDao.GetUserByUsername(userParam.Username);
                if (existingUser != null)
                {
                    return Conflict(new { message = "Username already taken. Please choose a different username." });
                }
            }
            catch (DaoException ex )
            {
                return StatusCode(500, ErrorMessage);
            }

            // create new user
            User newUser;
            try
            {
                newUser = userDao.CreateUser(userParam.Username, userParam.Password);
            }
            catch (DaoException)
            {
                return StatusCode(500, ErrorMessage);
            }

            if (newUser != null)
            {
                // Create a ReturnUser object to return to the client
                ReturnUser returnUser = new ReturnUser() { UserId = newUser.UserId, Username = newUser.Username };

                result = Created("/login", returnUser);
            }

            return result;
        }
    }
}
