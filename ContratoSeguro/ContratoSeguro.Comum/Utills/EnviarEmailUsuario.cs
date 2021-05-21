using ContratoSeguro.Comum.Commands;
using ContratoSeguro.Comum.Handlers;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ContratoSeguro.Comum.Utills
{
    public class EnviarEmailUsuario 
    {
        public interface IMailService
        {
            Task SendEmailAsync(string toEmail, string subject, string content );
            Task SendEmailAsyncCompany(string toEmail, string subject, string content);
            Task SendEmailAsyncEmployee(string toEmail, string subject, string content);
            Task SendEmailAsyncRecruted(string toEmail,  string subject,  string content);

        }
        public class SendGridMailService : IMailService
        {
            private IConfiguration _configuration;

            public SendGridMailService(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task SendEmailAsync(string toEmail, string subject, string content )
            {
                var apiKey = "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";
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("contratoseguro@gmail.com", "Contrato Seguro");
                var to = new EmailAddress("recrutadoteste003@gmail.com", "Gustavo Silva");
                var msg = MailHelper.CreateSingleEmail(from, to, subject, content, null);
                var response = await client.SendEmailAsync(msg);
            }
            //Empresa
            public async Task SendEmailAsyncCompany(string toEmail, string subject, string content)
            {
                var apiKey = "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";
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("contratoseguro@gmail.com", "Contrato Seguro");
                var to = new EmailAddress("empresateste001@gmail.com", "Senai Informática 132");
                var msg = MailHelper.CreateSingleEmail(from, to, subject, content, null);
                var response = await client.SendEmailAsync(msg);
            }

            //Funcionario
            public async Task SendEmailAsyncEmployee(string toEmail, string subject, string content )
            {
                var apiKey = "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";
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("contratoseguro@gmail.com", "Contrato Seguro");
                var to = new EmailAddress("funcionarioTeste001@gmail.com", "Eduardo Silva");
                var msg = MailHelper.CreateSingleEmail(from, to, subject, content, null);
                var response = await client.SendEmailAsync(msg);
            }

            //Recrutado
            public async Task SendEmailAsyncRecruted(string toEmail, string subject ,string content)
            {  
                var apiKey = "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";
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("contratoseguro@gmail.com", "Contrato Seguro");
                var to = new EmailAddress("recrutadoteste003@gmail.com", "Kaua Deja");
                var msg = MailHelper.CreateSingleEmail(from, to, subject, content, null);
                var response = await client.SendEmailAsync(msg);
            }

        }
    }
}

