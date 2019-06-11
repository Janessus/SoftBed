﻿using System;
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

            bool result = false;
            if (p != null)
            {
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
            string bett;

            
            if (patient.Station.Equals("Pädiatrie") &&
                (UpdateManagement.GetInstance().GetCurrentBettenbelegung().Gynaekologie < 50))
            {
                //suche bett in Gynäkologie
                bett = DatabaseManagement.GetInstance().GetPassendesBett("Pädiatrie", patient);
                if (bett == null)
                {
                    bett = SucheBettAufAndererStation(patient);
                }
            }
            else if (patient.Station.Equals("Gynäkologie") &&
                (UpdateManagement.GetInstance().GetCurrentBettenbelegung().Gynaekologie < 50))
            {
                //suche bett in Gynäkologie
                bett = DatabaseManagement.GetInstance().GetPassendesBett("Gynäkologie", patient);
                if(bett == null)
                {
                    bett = SucheBettAufAndererStation(patient);
                }
            }
            else if(patient.Station.Equals("Innere Medizin") &&
                    (UpdateManagement.GetInstance().GetCurrentBettenbelegung().Innere < 50))
            {
                //suche bett in Innere Medizin
                bett = DatabaseManagement.GetInstance().GetPassendesBett("Innere Medizin", patient);
                if (bett == null)
                {
                    bett = SucheBettAufAndererStation(patient);
                }
            }
            else if(patient.Station.Equals("Onkologie") &&
                    (UpdateManagement.GetInstance().GetCurrentBettenbelegung().Onkologie < 50))
            {
                //suche bett in Onkologie
                bett = DatabaseManagement.GetInstance().GetPassendesBett("Onkologie", patient);
                if (bett == null)
                {
                    bett = SucheBettAufAndererStation(patient);
                }
            }
            else if(patient.Station.Equals("Orthopädie") &&
                    (UpdateManagement.GetInstance().GetCurrentBettenbelegung().Orthopaedie < 50))
            {
                //suche bett in Orthopädie
                bett = DatabaseManagement.GetInstance().GetPassendesBett("Orthopädie", patient);
                if (bett == null)
                {
                    bett = SucheBettAufAndererStation(patient);
                }
            }
            else if(patient.Station.Equals("Intensivstation") &&
                    (UpdateManagement.GetInstance().GetCurrentBettenbelegung().Intensiv < 10))
            {
                // suche bett in Intensivstation
                bett = DatabaseManagement.GetInstance().GetPassendesBett("Intensivstation", patient);
                if (bett == null)
                {
                    bett = SucheBettAufAndererStation(patient);
                }
            }
            else
            {
                // patient auf station mit größter freier kapaziät unterbringen
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
            if (UpdateManagement.GetInstance().GetCurrentBettenbelegung().Innere < 50)
            {
                string bett = DatabaseManagement.GetInstance().GetPassendesBett("Innere Medizin", patient);
                //suche bett in innere, wenn patient nicht in eigene station kann
                if (bett == null)
                {
                    // patient auf station mit größter freier kapaziät unterbringen
                    return DatabaseManagement.GetInstance().GetPassendesBett(UpdateManagement.GetInstance().GetBettenbelegungSortiert(UpdateManagement.GetInstance().GetCurrentBettenbelegung())[0], patient);
                }
                else
                {
                    return bett;
                }
            }

            
            // patient auf station mit größter freier kapaziät unterbringen
            return DatabaseManagement.GetInstance().GetPassendesBett(UpdateManagement.GetInstance().GetBettenbelegungSortiert(UpdateManagement.GetInstance().GetCurrentBettenbelegung())[0], patient);
        }
    }
}
