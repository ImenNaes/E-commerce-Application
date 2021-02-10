using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using BLL.Entities;
using DAL.Repositories;
using System.Net.Mail;
using System.Configuration;
using System.Net;
using Microsoft.Ajax.Utilities;
using System.Text;
using System.Threading;

namespace Business.Controllers
{
    public class ContactUsController : Controller
    {
        private ContactsRepository contactsRepository;
        public ContactUsController()
        {
            contactsRepository = new ContactsRepository();
        }
        // GET: ContactUs
        public ActionResult Index()
        {            
            return View();
        }
      
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(ContactSMS contactUs)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (User.Identity.IsAuthenticated)
                        contactUs.FromEmail = User.Identity.Name;
                    var result = contactsRepository.Add(contactUs);
                    if (result > 0)
                    {
                        ViewBag.successmsg = "Sent";
                        return View("Index");
                    }
                }
                return View("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ExceptionMessage = ex;
               return View("Error", ex.Message);
            }
        }


        public ActionResult Error(string ex)
        {
            return View(ex);
        }

        //public void SendEmail(string toAddress, string fromAddress,
        //               string subject, string message)
        //{
        //    try
        //    {
        //        var msg = new MailMessage();
        //        msg.To.Add(new MailAddress(toAddress));
        //        msg.From = new MailAddress(fromAddress);
        //        msg.Subject = subject;
        //        msg.IsBodyHtml = true;
        //        msg.Body = HttpUtility.HtmlDecode(message);
        //        //using (var mail = new MailMessage())
        //        //{

        //        //     string email = fromAddress.ToString();
        //        //     //string password = "!Imen6067";

        //        //        var loginInfo = new NetworkCredential(email, );


        //        //    mail.From = new MailAddress(fromAddress);
        //        //    mail.To.Add(new MailAddress(toAddress));
        //        //    mail.Subject = subject;
        //        //    mail.Body = message;
        //        //    mail.IsBodyHtml = true;

        //        try
        //        {
        //            using (var smtpClient = new SmtpClient(
        //                //"smtp.mail.yahoo.com", 465))
        //                "smtp.gmail.com", 25))
        //            {
        //                smtpClient.EnableSsl = true;
        //                smtpClient.UseDefaultCredentials = true;
        //                //smtpClient.Credentials = loginInfo;
        //                smtpClient.Send(msg);
        //            }

        //        }

        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //            //dispose the client
        //            //  mail.Dispose();
        //        }


        //    }
        //    catch (SmtpFailedRecipientsException ex)
        //    {
        //        foreach (SmtpFailedRecipientException t in ex.InnerExceptions)
        //        {
        //            var status = t.StatusCode;
        //            if (status == SmtpStatusCode.MailboxBusy ||
        //                status == SmtpStatusCode.MailboxUnavailable)
        //            {
        //                Response.Write("Delivery failed - retrying in 5 seconds.");
        //                System.Threading.Thread.Sleep(5000);
        //                //resend
        //                //smtpClient.Send(message);
        //            }
        //            else
        //            {
        //                Console.WriteLine("Failed to deliver message to {0}",
        //                                  t.FailedRecipient);
        //            }
        //        }
        //    }
        //    catch (SmtpException Se)
        //    {
        //        // handle exception here
        //        Response.Write(Se.ToString());
        //    }

        //    catch (Exception ex)
        //    {
        //        Response.Write(ex.ToString());
        //    }

        //}

        //[ValidateAntiForgeryToken]
        //[HttpPost]
        //public ActionResult Index(ContactSMS contact)
        //{
        //    if (ModelState.IsValid)
        //    { 

        //        //prepare email
        //        var toAddress = "ahmednaes25@gmail.com";
        //        var fromAddress = contact.FromEmail.ToString();
        //        var subject = "Test enquiry from " + contact.Name;
        //        var message = new StringBuilder();
        //        message.Append("Name: " + contact.Name + "\n");
        //        message.Append("Email: " + contact.Subject + "\n");
        //        message.Append("Telephone: " + contact.Message + "\n\n");
        //        message.Append(contact.Message);

        //        //start email Thread
        //        var tEmail = new Thread(() =>
        //       SendEmail(toAddress, fromAddress, subject, message.ToString()));
        //        tEmail.Start();
        //    }
        //    return View();
            
        //    //try
        //    //{
        //    //    var from = "ahmedennaes@hotmail.com";
        //    //    var sendTo = "naes.imen1@gmail.com";
        //    //    const string pwd = "!Imen6067%";
        //    //    string mailsubject = contact.Subject;
        //    //    string mailmessage = contact.Message.ToString();
        //    //   var smtp = new SmtpClient();
        //    //    {
        //    //        smtp.Host = "smtp.gmail.com";
        //    //        smtp.Port = 587;
        //    //        smtp.EnableSsl = true;
        //    //        smtp.UseDefaultCredentials= true;
        //    //        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        //    //        smtp.Credentials = new NetworkCredential(from, pwd);
        //    //        smtp.Timeout = 20000;
        //    //    }
        //    //smtp.Send(from, sendTo, mailsubject, mailmessage);


        //    //ViewBag.message = "Merci ! Votre message a bien été envoyée.";
        //    //}
        //    //catch (Exception e)
        //    //{
        //    //  ViewBag.message = e.Message;
        //    //  return View();
        //    //}
        //    //return RedirectToAction("Index");
        //}

        //catch (Exception ex)
        //{
        //    Console.WriteLine(ex);
        //}
        //}



    }
}