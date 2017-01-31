using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace RandomHacksBh.Github.Api
{
    public static class Surpresa
    {
        const string _email = "meetuprandomhacks@gmail.com";
        const string _senha = "jeuouteghcrzugzr";

        public static void Participar(string email,string nomecompleto)
        {
            try
            {
                var assunto = $"[Sorteio-Meetup] - {email} - {nomecompleto}";
                var corpoDaMensagem = $"O usuário:{nomecompleto}, com o e-mail: {email} estará participando do sorteio. ";

                var clienteSmtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(_email, _senha),
                    Timeout = 10000,
                };

                var mensagem = new MailMessage(_email, _email, assunto, corpoDaMensagem);
                mensagem.CC.Add(email);
                
                clienteSmtp.Send(mensagem);
            }
            catch (Exception e)
            {
                throw;
            }

        }
    }
}
