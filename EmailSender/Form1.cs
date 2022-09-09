using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmailSender
{
    public partial class Form1 : Form
    {
        MailMessage message;
        SmtpClient smtp;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try

            {

                btnSend.Enabled = false; 

                message = new MailMessage();

                message.To.Add(txtTo.Text); 
               // message.CC.Add(txtCC.Text);
                message.Subject = txtSubject.Text;

                message.From = new MailAddress("fkiprotich845@gmail.com");

                message.Body = txtBody.Text;
                message.IsBodyHtml = checkBox1.Checked ? true : false;
                //if (IsValidEmail(txtTo.Text))

                //{

                //    message.To.Add(txtTo.Text);

                //}



                //if (IsValidEmail(txtCC.Text))

                //{

                //    message.CC.Add(txtCC.Text);

                //}

                //message.Subject = txtSubject.Text;

                //message.From = new MailAddress("deepak.sharma009@gmail.com");

                //message.Body = txtBody.Text;

                //if (lblAttachment.Text.Length > 0)

                //{

                //    if (System.IO.File.Exists(lblAttachment.Text))

                //    {

                //        message.Attachments.Add(new Attachment(lblAttachment.Text));

                //    }

                //}



                // set smtp details

                smtp = new SmtpClient("smtp.gmail.com");
                smtp.UseDefaultCredentials = true;
                smtp.Port = 587; 
                smtp.Credentials = new NetworkCredential("fkiprotich845@gmail.com", "woinyickutgdicsj"); 
                smtp.EnableSsl = true; 
                smtp.SendAsync(message, message.Subject);

                smtp.SendCompleted += new SendCompletedEventHandler(smtp_SendCompleted);

            }

            catch (Exception ex)

            {

                MessageBox.Show(ex.Message); 

                btnSend.Enabled = true;

            }
        }
        void smtp_SendCompleted(object sender, AsyncCompletedEventArgs e)

        {

            if (e.Cancelled == true)

            {

                MessageBox.Show("Email sending cancelled!");

            }

            else if (e.Error != null)

            {

                MessageBox.Show(e.Error.Message);

            }

            else

            {

                MessageBox.Show("Email sent sucessfully!");

            }

             

            btnSend.Enabled = true;

        }
         
        private void btnCancel_Click(object sender, EventArgs e)

        {

            smtp.SendAsyncCancel();

            MessageBox.Show("Email sending cancelled!");

        }
        private void lnkAttachFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

        {

        //    if (openFileDialog1.ShowDialog() != DialogResult.Cancel)

        //    {

        //        lblAttachment.Text = openFileDialog1.FileName;

        //        lblAttachment.Visible = true;

        //        lnkAttachFile.Visible = false;

        //    }

        }
    }
}
