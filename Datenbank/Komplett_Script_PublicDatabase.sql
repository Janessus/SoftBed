/*
drop database IF EXISTS SoftBedDB;
create database IF NOT EXISTS SoftBedDB;
use SoftBedDB;
*/
drop table if exists Users;
drop table if exists TransferListe;
drop table if exists Patient;
drop table if exists Zimmer;
drop table if exists Station;
drop table if exists Mitarbeiter;
drop table if exists Person;


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
	VersicherungsNr varchar(40) unique,
	PersonID int,
    ZimmerNr int,
    StationsBezeichnung varchar(40),
    Bett varchar(1),
    Sollstation varchar(255),
    Aufnahmedatum Timestamp DEFAULT current_timestamp,
    
    
    PRIMARY KEY(VersicherungsNr),
    FOREIGN KEY(PersonID) REFERENCES Person(PersonID) on delete cascade,
    FOREIGN KEY(ZimmerNr) REFERENCES Zimmer(ZimmerNr) on delete set null,
    FOREIGN KEY(StationsBezeichnung) REFERENCES Station(Bezeichnung) on delete set null
);


create table IF NOT EXISTS TransferListe
(
	PersonID int,
	Von Varchar(10),
    Nach varchar(10),
    Stempel Timestamp DEFAULT current_timestamp,
	
    FOREIGN KEY(PersonID) REFERENCES Patient(PersonID) on delete cascade,
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

/*
INSERT INTO Station(Bezeichnung) VALUES("Innere Medizin");
INSERT INTO Station(Bezeichnung) VALUES("Gynäkologie");
INSERT INTO Station(Bezeichnung) VALUES("Onkologie");
INSERT INTO Station(Bezeichnung) VALUES("Orthopädie");
INSERT INTO Station(Bezeichnung) VALUES("Pädiatrie");
INSERT INTO Station(Bezeichnung) VALUES("Intensivstation");

commit;