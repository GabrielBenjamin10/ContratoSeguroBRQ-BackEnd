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
        public static bool EnviarEmail(string _emailDestino, string _nomeUsuario, string _assuntoEmail, string _tituloEmail, string _mensagem, string _object)
        {
            try
            {
                MailMessage _message = new MailMessage();
                _message.From = new MailAddress("attackondev@gmail.com");

                //Email de destino
                _message.CC.Add(_emailDestino);

                //Conteudo do email
                _message.Subject = _assuntoEmail;

                //Definindo o corpo do email
                _message.IsBodyHtml = true;

                //Conteudo do corpo do email
                _message.Body = (_object == null ?
                                                    $"<b>{_nomeUsuario}, {_tituloEmail}</b><p>{_mensagem}</p>"
                                                 :
                                                    $"<b>{_nomeUsuario}, {_tituloEmail}</b><p>{_mensagem} <strong>{_object}</strong></p>"
                                );

                //Configurando a porta smtp
                SmtpClient _smtpClient = new SmtpClient("smtp.gmail.com", Convert.ToInt32("587"));

                //Defininfo o uso de credenciais para o envio de email
                _smtpClient.UseDefaultCredentials = false;

                //Definindo as credenciais de envio
                _smtpClient.Credentials = new NetworkCredential("attackondev@gmail.com", "*Attackondev123*");

                //Configurando a configuração do ssl
                _smtpClient.EnableSsl = true;

                //Enviando o email
                _smtpClient.Send(_message);

                //retornando sucesso
                return true;

            }
            catch (Exception a)
            {
                throw a ;
            }
        }
    }
}
