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


            if (patient.Station.Equals("Gynäkologie") && 
                UpdateManagement.GetInstance().GetCurrentBettenbelegung().Paediatrie < 50)
            {
            }
            else if (patient.Station.Equals("Gynäkologie") &&
                (UpdateManagement.GetInstance().GetCurrentBettenbelegung().Gynaekologie < 50))
            {
                //suche bett in Gynäkologie
            }
            else if(patient.Station.Equals("innere Medizin") &&
                    (UpdateManagement.GetInstance().GetCurrentBettenbelegung().Innere < 50))
            {
                //suche bett in gynäkologie
            }
            else if(patient.Station.Equals("Onkologie") &&
                    (UpdateManagement.GetInstance().GetCurrentBettenbelegung().Onkologie < 50))
            { 
                //suche bett in Onkologie
            }
            else if(patient.Station.Equals("Orthopädie") &&
                    (UpdateManagement.GetInstance().GetCurrentBettenbelegung().Orthopaedie < 50))
            {
                //suche bett in Orthopädie
            }
            else if(patient.Station.Equals("Intensiv") &&
                    (UpdateManagement.GetInstance().GetCurrentBettenbelegung().Intensiv < 10))
            {
                // suche bett in Intensivstation
            }
            else if (UpdateManagement.GetInstance().GetCurrentBettenbelegung().Innere < 50)
            {
                //suche bett in innere, wenn patient nicht in eigene station kann
            }
            else
            {

                // patient auf station mit größter freier kapaziät unterbringen


            }

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
        private int KHFülle()
        {
            Bettenbelegung belegung = UpdateManagement.GetInstance().GetCurrentBettenbelegung();

            int gesAuslast = belegung.Gesamt();

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
