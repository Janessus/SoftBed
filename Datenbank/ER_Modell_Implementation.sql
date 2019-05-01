create database IF NOT EXISTS SoftBedDB;
use SoftBedDB;

create table IF NOT EXISTS Person
(
	PersonID int AUTO_INCREMENT,
    Vorname varchar(40),
    Nachname varchar(40),
    Adresse varchar(255),
    Geschlecht varchar(40),
    Geburtsdatum Date,

    PRIMARY KEY (PersonID)
);

create table IF NOT EXISTS Mitarbeiter
(
	MitarbeiterID int AUTO_INCREMENT,
    PersonID int,
    Rechte varchar(255),
    
    PRIMARY KEY(MitarbeiterID),
    FOREIGN KEY(PersonID) REFERENCES Person(PersonID)
);

create table IF NOT EXISTS Station
(
	StationsID int AUTO_INCREMENT,
    Bezeichnung varchar(255),
	
    PRIMARY KEY(StationsID)
);

create table IF NOT EXISTS Zimmer
(
	ZimmerNr int,
    StationsID int,
    
    PRIMARY KEY(ZimmerNr),
    FOREIGN KEY(StationsID) REFERENCES Station(StationsID)
);

create table IF NOT EXISTS Patient
(
	VersicherungsNr int,
	PersonID int,
    ZimmerNr int,
    StationsID int,
    Bett varchar(1),
    Beschwerde varchar(255),
    
    PRIMARY KEY(VersicherungsNr),
    FOREIGN KEY(PersonID) REFERENCES Person(PersonID),
    FOREIGN KEY(ZimmerNr) REFERENCES Zimmer(ZimmerNr),
    FOREIGN KEY(StationsID) REFERENCES Station(StationsID)
);

INSERT INTO Station(Bezeichnung) VALUES("Innere Medizin");
INSERT INTO Station(Bezeichnung) VALUES("Gynäkologie");
INSERT INTO Station(Bezeichnung) VALUES("Onkologie");
INSERT INTO Station(Bezeichnung) VALUES("Orthopädie");
INSERT INTO Station(Bezeichnung) VALUES("Pädiatrie");

commit;