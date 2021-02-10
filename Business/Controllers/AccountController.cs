using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Business.Models;
using DAL;
using DAL.ApiContext;
using Newtonsoft.Json;
using BLL.Entities;
using DAL.Repositories;
using DAL.Models;

namespace Business.Controllers
{
    public class AccountController : Controller
    {
        private ProfileRepository profilerepository;
        // GET: Account  
        public AccountController()
        {
            profilerepository = new ProfileRepository();
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login(string ReturnUrl = "")
        {
            if (User.Identity.IsAuthenticated)
            {
                return LogOut();
            }
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            var isvalid = false; 
            //Checking the state of model passed as parameter.
            if (ModelState.IsValid)
            {
                var users = profilerepository.GetAll();
                //Validating the user, whether the user is valid or not.
                Profile user =users.Where(query => query.Email.Equals(model.Email) && query.Password.Equals(model.Password)).SingleOrDefault();
                if (user != null)
                {
                    isvalid = true; 
                }
                else
                {
                    isvalid = false;
                }
                //If user is valid & present in database, we are redirecting it to Welcome page.
                if (isvalid == true)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, false);
                    Console.WriteLine("user connecté !!");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    //If the username and password combination is not present in DB then error message is shown.
                    ModelState.AddModelError("Failure", "Wrong Username and password combination !");
                    return View();
                }
            }
            else
            {
                Console.WriteLine("user non connecté !!");

                //If model state is not valid, the model with error message is returned to the View.
                return RedirectToAction("Login","Account");
            }
        }


        //[HttpPost]
        //public ActionResult Login(LoginView loginView, string ReturnUrl = "")
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //if (Membership.ValidateUser(loginView.Email, loginView.Password))
        //        //{
        //        //    var user = (CustomMembershipUser)Membership.GetUser(loginView.Email, false);
        //            //if (user != null)
        //            //{
        //            //    CustomSerializeModel userModel = new Models.CustomSerializeModel()
        //            //    {
        //            //        UserId = user.UserId,
        //            //        FirstName = user.FirstName,
        //            //        LastName = user.LastName,
        //            //        RoleName = user.Roles.Select(r => r.RoleName).ToList()
        //            //    };

        //            //    string userData = JsonConvert.SerializeObject(userModel);
        //            //    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket
        //            //        (
        //            //        1, loginView.Email, DateTime.Now, DateTime.Now.AddMinutes(15), false, userData
        //            //        );

        //            //    string enTicket = FormsAuthentication.Encrypt(authTicket);
        //            //    HttpCookie faCookie = new HttpCookie("Cookie1", enTicket);
        //            //    Response.Cookies.Add(faCookie);
        //            //}

        //            if (Url.IsLocalUrl(ReturnUrl))
        //            {
        //                return Redirect(ReturnUrl);
        //            }
        //            else
        //            {
        //                return RedirectToAction("Index","Home");
        //            }
        //    //    }
        //    }
        //    ModelState.AddModelError("", "Something Wrong : Username or Password invalid ^_^ ");
        //    return View(loginView);
        //}

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(RegisterModel registrationView)
        {
            bool statusRegistration = false;
            string messageRegistration = string.Empty;

            if (ModelState.IsValid)
            {
                // Email Verification  
                string userName = Membership.GetUserNameByEmail(registrationView.Email);
                if (!string.IsNullOrEmpty(userName))
                {
                    ModelState.AddModelError("Warning Email", "Sorry: Email already Exists");
                    return View(registrationView);
                }

                //Save User Data   
              
                    var user = new Profile()
                    {
                        FirstName = registrationView.FirstName,
                        LastName = registrationView.LastName,
                        Email = registrationView.Email,
                        Password = registrationView.Password,
                        ConfirmPassword = registrationView.ConfirmPassword,
                        ActivationCode = Guid.NewGuid(),
                    };

                   
                //var url = string.Format("/Account/ActivationAccount/{0}", user.ActivationCode);
                //var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, url);

                //var fromEmail = new MailAddress("naes.imen1@gmail.com"/*, "Activation Account-AKKA"*/);
                //var toEmail = new MailAddress(user.Email);

                //var fromEmailPassword = "!Imen6067%&";
                //string subject = "Activation Account !";

                //string body = "<br/> Please click on the following link in order to activate your account" + "<br/><a href='" + link + "'> Activation Account ! </a>";

                //var smtp = new SmtpClient
                //{
                //    Host = "smtp.gmail.com",
                //    Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword),
                //    Port = 587,
                //    EnableSsl = true,
                //    Timeout = 10000,
                //    DeliveryMethod = SmtpDeliveryMethod.Network,
                //    UseDefaultCredentials = false
                //};

                //using (var message = new MailMessage(fromEmail, toEmail)
                //{
                //    Subject = subject,
                //    Body = body,
                //    IsBodyHtml = true

                //})

               //     smtp.Send(message);
               //// VerificationEmail(registrationView.Email, user.ActivationCode.ToString());
               // messageRegistration = "Your account has been created successfully. ^_^";
               // statusRegistration = true;
                profilerepository.Save(user);
            }
            else
            {
                messageRegistration = "Something Wrong!";
            }
            ViewBag.Message = messageRegistration;
            ViewBag.Status = statusRegistration;

            return View(registrationView);
        }

        [HttpGet]
        public ActionResult ActivationAccount(string id)
        {
            //bool statusAccount = false;           
            //    var userAccount = dbContext.Users.Where(u => u.ActivationCode.ToString().Equals(id)).FirstOrDefault();

            //    if (userAccount != null)
            //    {
            //        userAccount.IsActive = true;
            //        dbContext.SaveChanges();
            //        statusAccount = true;
            //    }
            //    else
            //    {
            //        ViewBag.Message = "Something Wrong !!";
            //    }   
            bool result = profilerepository.Activationcode(id);
            ViewBag.Status = result;
            return View();
        }

        public ActionResult LogOut()
        {
            HttpCookie cookie = new HttpCookie("Cookie1", "");
            cookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie);

            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account", null);
        }

        [NonAction]
        public void VerificationEmail(string email, string activationCode)
        {
            var url = string.Format("/Account/ActivationAccount/{0}", activationCode);
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, url);

            var fromEmail = new MailAddress("naes.imen1@gmail.com", "Activation Account-AKKA");
            var toEmail = new MailAddress(email);

            var fromEmailPassword = "!Imen6067%&";
            string subject = "Activation Account !";

            string body = "<br/> Please click on the following link in order to activate your account" + "<br/><a href='" + link + "'> Activation Account ! </a>";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword),
                Port = 587,
                EnableSsl = true,
                Timeout = 10000,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true

            })

                smtp.Send(message);

        }
    }
}