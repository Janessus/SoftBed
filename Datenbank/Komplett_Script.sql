drop database IF EXISTS SoftBedDB;
create database IF NOT EXISTS SoftBedDB;
use SoftBedDB;

create table IF NOT EXISTS Person
(
	PersonID int UNIQUE AUTO_INCREMENT,
    Vorname varchar(40),
    Nachname varchar(40),
    Adresse varchar(255),
    Geschlecht varchar(40),
    Geburtsdatum Date,

    PRIMARY KEY (Vorname, Nachname)
);

create table IF NOT EXISTS Mitarbeiter
(
	MitarbeiterID int AUTO_INCREMENT,
    PersonID int,
    Rechte varchar(255),
    
    PRIMARY KEY(MitarbeiterID),
    FOREIGN KEY(PersonID) REFERENCES Person(PersonID) on delete cascade
);

create table IF NOT EXISTS Station
(
    Bezeichnung varchar(40),
	
    PRIMARY KEY(Bezeichnung)
);

create table IF NOT EXISTS Zimmer
(
	ZimmerNr int,
    StationsBezeichnung varchar(40),
    
    PRIMARY KEY(ZimmerNr, StationsBezeichnung),
    FOREIGN KEY(StationsBezeichnung) REFERENCES Station(Bezeichnung) on delete cascade
);

create table IF NOT EXISTS Patient
(
	VersicherungsNr int,
	PersonID int,
    ZimmerNr int,
    StationsBezeichnung varchar(40),
    Bett varchar(1),
    Beschwerde varchar(255),
    Aufnahmedatum Timestamp DEFAULT current_timestamp,
    
    
    PRIMARY KEY(VersicherungsNr),
    FOREIGN KEY(PersonID) REFERENCES Person(PersonID) on delete cascade,
    FOREIGN KEY(ZimmerNr) REFERENCES Zimmer(ZimmerNr) on delete cascade,
    FOREIGN KEY(StationsBezeichnung) REFERENCES Station(Bezeichnung) on delete cascade
);

create table IF NOT EXISTS TransferListe
(
	PersonID int AUTO_INCREMENT,
	Von Varchar(10),
    Nach varchar(10),
    Stempel Timestamp DEFAULT current_timestamp,

    PRIMARY KEY (PersonID, Stempel)
);

create table IF NOT EXISTS Users
(
	Benutzername Varchar(40) PRIMARY KEY,
    PersonID int,
    Rechte Varchar(40),
    Passwort Varchar(40),
    
    FOREIGN KEY(PersonID) REFERENCES Person(PersonID) on delete cascade
);


/* ------------------------------------------------------------- Test Daten -------------------------------------------------------------------- */
/* ------------------------------------------------ Reihenfolge bei den Inserts einhalten! ----------------------------------------------------- */

INSERT INTO Station(Bezeichnung) VALUES("Innere Medizin");
INSERT INTO Station(Bezeichnung) VALUES("Gynäkologie");
INSERT INTO Station(Bezeichnung) VALUES("Onkologie");
INSERT INTO Station(Bezeichnung) VALUES("Orthopädie");
INSERT INTO Station(Bezeichnung) VALUES("Pädiatrie");

INSERT INTO Zimmer(ZimmerNr, StationsBezeichnung) VALUES(0, "Innere Medizin");
INSERT INTO Zimmer(ZimmerNr, StationsBezeichnung) VALUES(0, "Gynäkologie");
INSERT INTO Zimmer(ZimmerNr, StationsBezeichnung) VALUES(0, "Onkologie");
INSERT INTO Zimmer(ZimmerNr, StationsBezeichnung) VALUES(0, "Orthopädie");
INSERT INTO Zimmer(ZimmerNr, StationsBezeichnung) VALUES(0, "Pädiatrie");
INSERT INTO Zimmer(ZimmerNr, StationsBezeichnung) VALUES(1, "Innere Medizin");
INSERT INTO Zimmer(ZimmerNr, StationsBezeichnung) VALUES(2, "Innere Medizin");

INSERT INTO Person(Vorname, Nachname, Adresse, Geschlecht, Geburtsdatum) VALUES("Janes", "Heuberger", "Schutterwald", "M", DATE("1994-09-01"));
INSERT INTO Patient(VersicherungsNr, PersonID, ZimmerNr, StationsBezeichnung, Bett, Beschwerde) VALUES(12345, (Select Person.PersonID From Person WHERE Vorname = "Janes" AND Nachname = "Heuberger"), 2, "Innere Medizin", "F", "Gebrochenes Bein");
INSERT INTO Mitarbeiter(PersonID, Rechte) VALUES((SELECT PersonID FROM Person WHERE Vorname = "Janes" AND Nachname = "Heuberger"), "Admin of Admins");
INSERT INTO TransferListe(PersonID, Von, Nach) VALUES((SELECT PersonID FROM Person WHERE Vorname = "Janes" AND Nachname = "Heuberger"), "IM-2-F", "IM-2-T");
INSERT INTO Users(PersonID, Benutzername, Rechte, Passwort) VALUES((Select PersonID FROM Person WHERE Vorname = "Janes" AND Nachname = "Heuberger"), "Janessus", "Admin", "password");



commit;