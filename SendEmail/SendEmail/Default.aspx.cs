using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Xml;
using System.IO;
using Microsoft.AspNet.Identity;


namespace SendEmail
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        public void SendEmail_Click(Object sender,
                           EventArgs e)
        {
            //inout from text boxes - email subject, content and the address of the recipient
            string Subject = SubjectBox.Text;
            string Content = ContentBox.Text;
            string Recipient = RecipientBox.Text;

            //the account you are using to send the mail
            //enter your email
            var SenderAddress = new MailAddress("Test@testmail.com");

            //Verifiying that the recipient mail entered is in email format
            var RecipientEmail = new MailAddress("A@A.com");
            IsValidEmail(Recipient);
            Boolean RecipientBool = IsValidEmail(Recipient);
            if (RecipientBool == true)
            {
                RecipientEmail = new MailAddress(Recipient);
            }
            
            //email password
            //add your email password
            string SenderPassword = "YourPassword";
            var MySMTP = new SmtpClient
            {
                //The host string is dependant on the sender email 
               // look up the smtp for your sender email address here
                //https://www.arclab.com/en/kb/email/list-of-smtp-and-pop3-servers-mailserver-list.html
                Host = "smtp.live.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(SenderAddress.Address, SenderPassword)
            };
            using (var mail = new MailMessage(SenderAddress, RecipientEmail)
            {
                Subject = Subject,
                Body = Content,
            })
                if ((Content != null) && (Subject != null) && (Recipient != null) && (RecipientEmail != null) && (SenderAddress != null) && (SenderPassword != null))
                {
                    try
                    {
                        MySMTP.Send(mail);
                    }
                    catch (Exception myexception)
                    {
                    }
                }
                else
                {
                    String ErrorMessage = "Error! Null fields!";

                    Console.WriteLine(ErrorMessage);




                }

        }





        //method to check mail address is valid
        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}