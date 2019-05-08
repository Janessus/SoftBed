using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using Wrapperklassen;

namespace Logic
{
    public class ZimmerManagement : LogicController
    {
        private static ZimmerManagement _instance = null;

        private ZimmerManagement()
        {

        }

        /**
         * legt ein Singleton-Objekt an und gibt eins zurueck, wenn bereits vorhanden
         * @return ein Singleton-Objekt
         */
        public static ZimmerManagement GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ZimmerManagement();
            }

            return _instance;
        }

        public bool PatientenTransfer(string versNr)
        {
            //TODO
            return false;
        }

        public string suchePassendesBett(Patient patient)
        {
            //TODO
            return null;
        }

        public void DeleteMemberTransferliste(string vorname, string nachname)
        {
            //TODO
        }

        /**
         * errechnet die Gesamtauslastung des Krankenhauses
         * @return Anazahl der belegten Betten im gesamten KH
         */
        public int KHFülle()
        {
            Bettenbelegung belegung = UpdateManagement.GetInstance().GetCurrentBettenbelegung();

            int gesAuslast = belegung.Gynaekologie + belegung.Innere + belegung.Intensiv + belegung.Onkologie +
                             belegung.Orthopaedie + belegung.Paediatrie;

            return gesAuslast;
        }


        /**
         * sendet eine E-Mail an umliegende Krankenhaeuser
         * @return true, wenn E-Mail erfolgreich gesendet wurde und false, wenn das Senden nicht erfolgreich war
         */
        public bool KHFastVoll()
        {
            if (KHFülle() >= 225)
            {   
                try
                {
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("krankenhausverteiler@gmail.com"); //Absender 
                    SmtpClient smtp = new SmtpClient();
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("krankenhausverteiler@gmail.com", "SoftBedProject"); //Adresse und Passwort
                    smtp.Host = "smtp.gmail.com";
                    mail.To.Add("krankenhausverteiler@gmail.com"); //Empfänger 

                    mail.Subject = "Die Kapazizäten unseres Krankehauses sind erschöpft!";
                    mail.Body = "Sehr geehrte Kolleginnen und Kollegen,\n" +
                                "die Betten auf unseren Stationen sind fast vollständig belegt.\n" +
                                "Dies ist eine Anfrage, Patienten an sie zu transferieren, wenn keine Kapaziäten mehr vorhanden sind.\n" +
                                "Mit freundlichen Grüßen";
                    smtp.Send(mail);

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Fehler beim Senden der E-Mail\n\n{0}", ex.Message);
                }
            }

            return false;
        }
    }
}
