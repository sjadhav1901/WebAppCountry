using Contracts.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApp.Country.Helpers;
using WebApp.Country.Repositories;

namespace WebApp.Country.Controllers
{
    public class AuthenticationController : Controller
    {
        private IUserRepository _userRepository;
        private IPasswordHasher<string> _passwordHasher;
        private IActivityHelper _activityHelper;
        public AuthenticationController(IUserRepository userRepository, IPasswordHasher<string> passwordHasher, IActivityHelper activityHelper)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _activityHelper = activityHelper;
        }
        public IActionResult SignIn()
        {
            return View();
        }

        [Route("resetpassword/{alt}")]
        public IActionResult ResetPassword(Guid altId)
        {
            return View();
        }

        [Route("userprofile")]
        public IActionResult UserProfile()
        {
            return View();
        }

        [Route("forgotpassword")]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [Route("register")]
        public IActionResult Register()
        {
            return View();
        }

        [Route("changepassword")]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [Route("api/authenticate")]
        public User ValidateSignIn([FromBody] User model)
        {
            try
            {
                Contracts.DataModels.User loggedUserByEmail = _userRepository.GetByEmail(model.Email);
                User user = AutoMapper.Mapper.Map<User>(loggedUserByEmail);
                if ((_passwordHasher.VerifyHashedPassword(model.Email, user.Password, model.Password) ==
                        PasswordVerificationResult.Success))
                {
                    user.Password = model.Password;
                    _activityHelper.SaveActivity("Sign In", "You have signed into your account on " + DateTime.Now.ToString("ddd, dd MMM yyy HH:mm:ss"), user.AltId);
                    return user;
                }
            }
            catch (Exception ex)
            { 
            }
            return new User();
        }

        [HttpGet]
        [Route("api/forgotpassword/{email}")]
        public User ForgotPassword(string email)
        {
            try
            {
                Contracts.DataModels.User user = _userRepository.GetByEmail(email);
                return AutoMapper.Mapper.Map<User>(user);
            }
            catch (Exception)
            {
                return new User();
            }
        }

        [HttpPost]
        [Route("api/resetpassword")]
        public User ResetPassword([FromBody] User model)
        {
            try
            {
                var passwordHash = _passwordHasher.HashPassword(model.Email, model.Password);
                Contracts.DataModels.User user = AutoMapper.Mapper.Map<Contracts.DataModels.User>(_userRepository.GetByAltId(model.AltId));
                if (user != null)
                {
                    user.Password = passwordHash;
                    user.UpdatedUtc = DateTime.UtcNow;
                    user.UpdatedBy = model.AltId;
                    var loggedUserByEmail = _userRepository.Save(user);
                    _activityHelper.SaveActivity("Reset Password", "You have successfully reseted your password on " + DateTime.Now.ToString("ddd, dd MMM yyy HH:mm:ss"), user.AltId);
                    return AutoMapper.Mapper.Map<User>(user);
                }
            }
            catch (Exception ex)
            { 
            }
            return new User();
        }

        [HttpPost]
        [Route("api/register")]
        public User Register([FromBody] User model)
        {
            try
            {
                var user = _userRepository.GetByEmail(model.Email);
                if (user == null)
                {
                    var passwordHash = _passwordHasher.HashPassword(model.Email, model.Password);
                    Guid guid = Guid.NewGuid();
                    user = _userRepository.Save(new Contracts.DataModels.User
                    {
                        AltId = guid,
                        RoleId = Contracts.Enums.Role.User,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        Password = passwordHash,
                        IsEnabled = true,
                        CreatedUtc = DateTime.UtcNow,
                        CreatedBy = guid
                    });
                }
                _activityHelper.SaveActivity("Sign up", "You have completed registartion with an email id " + model.Email + " on " + DateTime.Now.ToString("ddd, dd MMM yyy HH:mm:ss"), user.AltId);
                return AutoMapper.Mapper.Map<User>(user);
            }
            catch (Exception ex)
            {
                return new User();
            }
        }

        [HttpPost]
        [Route("api/changepassword")]
        public User ChangePassword([FromBody] User model)
        {
            try
            {
                var passwordHash = _passwordHasher.HashPassword(model.Email, model.Password);
                Contracts.DataModels.User user = AutoMapper.Mapper.Map<Contracts.DataModels.User>(_userRepository.GetByAltId(model.AltId));
                if (user != null)
                {
                    user.Password = passwordHash;
                    user.UpdatedUtc = DateTime.UtcNow;
                    user.UpdatedBy = model.AltId;
                    var loggedUserByEmail = _userRepository.Save(user);
                    _activityHelper.SaveActivity("Change Password", "You have successfully chnaged your password on " + DateTime.Now.ToString("ddd, dd MMM yyy HH:mm:ss"), user.AltId);
                    return AutoMapper.Mapper.Map<User>(user);
                }
            }
            catch (Exception ex)
            {
            }
            return new User();
        }
    }
}