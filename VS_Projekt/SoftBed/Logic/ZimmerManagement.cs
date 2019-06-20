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


        public bool PatientenTransfer(string versNr, string room)
        {
            DatabaseManagement dbm = DatabaseManagement.GetInstance();
            Patient p = dbm.GetPatient(versNr);

            var subs = room.Split('-');
            string station = subs[0];

            bool result = false;

            if (p != null)
            {
                switch (station)
                {
                    case "IM":
                        p.Station = "Innere Medizin";
                        break;
                    case "G":
                        p.Station = "Gynäkologie";
                        break;
                    case "On":
                        p.Station = "Onkologie";
                        break;
                    case "Or":
                        p.Station = "Orthopädie";
                        break;
                    case "P":
                        p.Station = "Pädiatrie";
                        break;
                    case "Is":
                        p.Station = "Intensivstation";
                        break;
                    default:
                        return false;
                }

                p.ZimmerNr = subs[1];
                p.Bett = subs[2];

                result = dbm.PatientAendern(p);
            }
            return result;
        }


        /**
         * searches bed for patient
         * @return string of bed
         */
        public string suchePassendesBett(Patient patient)
        {
            string bett = "NULL"; //DatabaseManagement.GetInstance().GetPassendesBett(patient.Station, patient);
            
            if (patient.Station.Equals("Pädiatrie") &&
                (UpdateManagement.GetInstance().GetCurrentBettenbelegung().Paediatrie < 50))
            {
                //suche bett in Paediatrie
                bett = DatabaseManagement.GetInstance().GetPassendesBett("Pädiatrie", patient);
                
            }
            else if (patient.Station.Equals("Gynäkologie") &&
                (UpdateManagement.GetInstance().GetCurrentBettenbelegung().Gynaekologie < 50))
            {
                //suche bett in Gynäkologie
                bett = DatabaseManagement.GetInstance().GetPassendesBett("Gynäkologie", patient);
             
            }
            else if(patient.Station.Equals("Innere Medizin") &&
                    (UpdateManagement.GetInstance().GetCurrentBettenbelegung().Innere < 50))
            {
                //suche bett in Innere Medizin
                bett = DatabaseManagement.GetInstance().GetPassendesBett("Innere Medizin", patient);
               
            }
            else if(patient.Station.Equals("Onkologie") &&
                    (UpdateManagement.GetInstance().GetCurrentBettenbelegung().Onkologie < 50))
            {
                //suche bett in Onkologie
                bett = DatabaseManagement.GetInstance().GetPassendesBett("Onkologie", patient);
                
            }
            else if(patient.Station.Equals("Orthopädie") &&
                    (UpdateManagement.GetInstance().GetCurrentBettenbelegung().Orthopaedie < 50))
            {
                //suche bett in Orthopädie
                bett = DatabaseManagement.GetInstance().GetPassendesBett("Orthopädie", patient);
              
            }
            else if(patient.Station.Equals("Intensivstation") &&
                    (UpdateManagement.GetInstance().GetCurrentBettenbelegung().Intensiv < 10))
            {
                // suche bett in Intensivstation
                bett = DatabaseManagement.GetInstance().GetPassendesBett("Intensivstation", patient);
                
            }

            if (bett == "NULL")
            {
                if (patient.SollStation.Equals(""))
                {
                    patient.SollStation = patient.Station;
                    DatabaseManagement.GetInstance().PatientAendern(patient);
                }
                   

                bett = SucheBettAufAndererStation(patient);
            }
            
            
            return bett;
        }

        public void DeleteMemberTransferliste(string vorname, string nachname)
        {
            DatabaseManagement.GetInstance().DeleteMemberTransferliste(vorname, nachname);
        }


        /**
         * sendet eine E-Mail an umliegende Krankenhaeuser
         * @return true, wenn E-Mail erfolgreich gesendet wurde und false, wenn das Senden nicht erfolgreich war
         */
        public bool KHFastVoll()
        {
            Bettenbelegung belegung = UpdateManagement.GetInstance().GetCurrentBettenbelegung();

            if (belegung.Gesamt() >= 225)
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

        private string SucheBettAufAndererStation(Patient patient)
        {
            bool found = false;
            int count = 4;
            string bett = "NULL";

            while (!found && (count >= 0))
            {
                if (UpdateManagement.GetInstance().GetCurrentBettenbelegung().Innere < 50)
                {
                    bett = DatabaseManagement.GetInstance().GetPassendesBett("Innere Medizin", patient);
                    //suche bett in innere, wenn patient nicht in eigene station kann
                    
                }

                // patient auf station mit größter freier kapaziät unterbringen
                if (bett == "NULL")
                {
                    bett = DatabaseManagement.GetInstance().GetPassendesBett(UpdateManagement.GetInstance().GetBettenbelegungSortiert(UpdateManagement.GetInstance().GetCurrentBettenbelegung())[count], patient);
                    if (bett != "NULL")
                    {
                        found = true;
                    }
                    
                }

                count--;
            }

            return bett;
        }
        

        public bool ITSVoll()
        {
            Bettenbelegung belegung = UpdateManagement.GetInstance().GetCurrentBettenbelegung();

            if (belegung.Intensiv == 10)
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

                    mail.Subject = "Die Kapazizäten unserer Intensivstation sind erschöpft!";
                    mail.Body = "Sehr geehrte Kolleginnen und Kollegen,\n" +
                                "die Betten auf unserer Intensivstationen sind vollständig belegt.\n" +
                                "Dies ist eine Anfrage, Patienten an sie zu transferieren, da keine Kapaziäten mehr auf unserer Intensivstation vorhanden sind.\n" +
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
