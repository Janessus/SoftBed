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
    Beschwerde varchar(255),
    Aufnahmedatum Timestamp DEFAULT current_timestamp,
    
    
    PRIMARY KEY(VersicherungsNr),
    FOREIGN KEY(PersonID) REFERENCES Person(PersonID) on delete cascade,
    FOREIGN KEY(ZimmerNr) REFERENCES Zimmer(ZimmerNr) on delete set null,
    FOREIGN KEY(StationsBezeichnung) REFERENCES Station(Bezeichnung) on delete set null
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

/*
INSERT INTO Station(Bezeichnung) VALUES("Innere Medizin");
INSERT INTO Station(Bezeichnung) VALUES("Gynäkologie");
INSERT INTO Station(Bezeichnung) VALUES("Onkologie");
INSERT INTO Station(Bezeichnung) VALUES("Orthopädie");
INSERT INTO Station(Bezeichnung) VALUES("Pädiatrie");
INSERT INTO Station(Bezeichnung) VALUES("Intensivstation");


INSERT INTO Person(Vorname, Nachname, Adresse, Geschlecht, Geburtsdatum) 
	VALUES("Klaus", "Arendt", "Ohlsbach", "m", DATE("1991-05-03")),
	("Joachim", "Adam", "Offenburg", "m", DATE("1992-04-03")),
	("Thomas", "Adolf", "Freiburg", "m", DATE("1997-02-04")),
	("Liliane", "Bauer", "Freiburg", "w", DATE("1984-05-05")),
	("Lukas", "Brau", "Offenburg", "m", DATE("1964-09-06")),
	("Samuel", "Burg", "Waldkirch", "m", DATE("1962-08-07")),
	("Matthias", "Bruggmoser", "Waldkirch", "m", DATE("1959-07-08")),
	("Arianna", "Adari", "Offenburg", "w", DATE("1950-09-12")),
	("Arion", "Cern", "Freiburg", "m", DATE("1954-11-30")),
	("Brigitte", "Dahlmann", "Lahr", "w", DATE("1953-10-29")),
	("Bruno", "Danner", "Waldkirch", "m", DATE("1958-11-15")),
	("Doreen", "Dannecker", "Offenburg", "w", DATE("1957-09-19")),
	("Dan", "Erdmann", "Freiburg", "m", DATE("1991-07-11")),
	("Elena", "Emmenecker", "Waldkirch", "w", DATE("1990-07-21")),
	("Irina", "Freud", "Achern", "w", DATE("1981-06-04")),
	("Siena", "Fuhrmann", "Freiburg", "w", DATE("1984-07-06")),
	("Julia", "Fink", "Lahr", "w", DATE("1985-08-05")),
	("Joseph", "Fischer", "Emmendingen", "m", DATE("1987-06-17")),
	("Alina", "Gans", "Waldkirch", "w", DATE("1986-05-15")),
	("Gerhard", "Göppert", "Freiburg", "m", DATE("1971-09-23")),
	("Philipp", "Groß", "Emmendingen", "m", DATE("1972-07-24")),
	("Katharina", "Gabriel", "Achern", "w", DATE("1970-11-23")),
	("Selina", "Dabanli", "Emmendingen", "w", DATE("1964-12-25")),
	("Oleg", "Hofer", "Offenburg", "m", DATE("1973-06-01")),
	("Layla", "Hefler", "Waldkirch", "w", DATE("1942-01-27")),
	("Rico", "Hemmer", "Lahr", "m", DATE("1935-01-08")),
	("Leonard", "Haubeil", "Emmendingen", "m", DATE("1948-02-09")),
	("Larissa", "Inntal", "Offenburg", "w", DATE("1949-03-11")),
	("Ludwig", "Jäger", "Waldkirch", "m", DATE("1951-04-21")),
	("Patricia", "Jobel", "Schutterwald", "w", DATE("1968-09-22")),
	("Janette", "Josephus", "Freiburg", "w", DATE("1997-02-28")),
	("Mirco", "Kammerdiener", "Offenburg", "m", DATE("1999-09-26")),
	("Günther", "Kross", "Lahr", "m", DATE("1951-02-08")),
	("Efraim", "Klein", "Lahr", "m", DATE("1966-01-29")),
	("Can", "Kind", "Achern", "m", DATE("1977-03-31")),
	("Simona", "Kunkel", "Freiburg", "w", DATE("1988-05-21")),
	("Tim", "Lehmann", "Schutterwald", "m", DATE("1999-07-29")),
	("Anita", "Lohrmann", "Offenburg", "w", DATE("1955-08-23")),
	("Anna", "Lahm", "Achern", "w", DATE("1967-10-16")),
	("Theodora", "Leber", "Emmendingen", "w", DATE("1962-12-17")),
	("Inge", "Lachmann", "Freiburg", "w", DATE("1983-04-18")),
	("Julia", "Merettig", "Offenburg", "w", DATE("1997-05-23")),
	("Hannes", "Huber", "Ohlsbach", "m", DATE("1998-01-02")),
	("Dora", "Mann", "Freiburg", "w", DATE("1996-08-06")),
	("Sarah", "Mogler", "Freiburg", "w", DATE("1974-08-09")),
	("Anna", "Michels", "Freiburg", "w", DATE("1954-07-13")),
	("Friedrich", "Schmidt", "Lahr", "m", DATE("1964-01-07")),
	("Lisa", "Neubert", "Waldkirch", "w", DATE("1962-06-13")),
	("Lena", "Nugen", "Lahr", "w", DATE("1953-02-05")),
	("John", "Opel", "Freiburg", "m", DATE("1953-03-14")),
	("Sophie", "Oragne", "Offenburg", "w", DATE("1962-03-14")),
	("Richard", "Ober", "Freiburg", "m", DATE("1978-03-14")),
	("Dania", "Polsko", "Offenburg", "w", DATE("1989-03-14")),
	("Daria", "Podolski", "Freiburg", "w", DATE("1997-03-14")),
	("Zoe", "Popolus", "Lahr", "w", DATE("1955-03-14")),
	("Athene", "Protz", "Offenburg", "w", DATE("1964-03-14")),
	("Christoph", "Portz", "Emmendingen", "m", DATE("1963-03-14")),
	("Christofer", "Postmann", "Offenburg", "m", DATE("1961-03-14")),
	("Alexander", "Rotmann", "Offenburg", "m", DATE("1953-03-14")),
	("Raphaela", "Ragen", "Offenburg", "w", DATE("1945-03-14")),
	("Tatjana", "Roggen", "Lahr", "w", DATE("1946-03-14")),
	("Alisa", "Reber", "Offenburg", "w", DATE("1947-03-14")),
	("Audrey", "Rupps", "Waldkirch", "w", DATE("1958-03-14")),
	("Lea", "Rupps", "Offenburg", "w", DATE("1969-03-14")),
	("Alina", "Lehmann", "Emmendingen", "w", DATE("1940-03-14")),
	("Raphael", "Rotweiler", "Offenburg", "m", DATE("1936-03-14")),
	("Jakob", "Rastätter", "Waldkirch", "m", DATE("1934-03-14")),
	("Josef", "Sillmann", "Freiburg", "m", DATE("1945-03-14")),
	("Maria", "Schmidt", "Emmendingen", "w", DATE("1952-03-14")),
	("Tom", "Schmidt", "Offenburg", "m", DATE("1964-03-14")),
	("Lina", "Schmitt", "Lahr", "w", DATE("1975-03-14")),
	("Luke", "Schmieder", "Offenburg", "m", DATE("2002-03-14")),
	("Simon", "Schmuggler", "Freiburg", "m", DATE("2003-03-14")),
	("Olivia", "Stiefel", "Emmendingen", "w", DATE("2000-03-14")),
	("Tabea", "Singer", "Waldkirch", "w", DATE("2000-03-14")),
	("Beatrice", "Sauer", "Freiburg", "w", DATE("2005-03-14")),
	("Tobias", "Sauter", "Lahr", "m", DATE("2006-03-14")),
	("Savanna", "Turm", "Lahr", "w", DATE("2010-03-14")),
	("Stella", "Trost", "Lahr", "w", DATE("2012-03-14")),
	("Florian", "Tummler", "Freiburg", "m", DATE("2004-03-14")),
	("Armin", "Treuer", "Offenburg", "m", DATE("2005-03-14")),
	("Brandon", "Tilsitter", "Offenburg", "m", DATE("2009-03-14")),
	("Niklas", "Ullmann", "Offenburg", "m", DATE("2008-03-14")),
	("Erika", "Urs", "Emmendingen", "w", DATE("2007-03-14")),
	("Bojan", "Ungrau", "Freiburg", "m", DATE("1944-03-14")),
	("Marcel", "Uhl", "Offenburg", "m", DATE("1955-03-14")),
	("Timo", "Uhrmacher", "Offenburg", "m", DATE("1956-03-14")),
	("Tino", "Vallis", "Offenburg", "m", DATE("1967-03-14")),
	("Rosalie", "Vadung", "Offenburg", "w", DATE("1958-03-14")),
	("Lars", "Weber", "Lahr", "m", DATE("1949-03-14")),
	("Johann", "Wöhner", "Offenburg", "m", DATE("1950-03-14")),
	("Stephan", "Wegner", "Freiburg", "m", DATE("1939-03-14")),
	("Stefanie", "Waber", "Lahr", "w", DATE("1945-03-14")),
	("Sabrina", "Wagner", "Offenburg", "w", DATE("1946-03-14")),
	("Anna", "Wagner", "Offenburg", "w", DATE("1955-03-14")),
	("Alena", "Yang", "Offenburg", "w", DATE("1958-03-14")),
	("Maria", "Zimmermann", "Emmendingen", "w", DATE("1967-03-14"));
    
    
INSERT INTO Users(PersonID, Benutzername, Rechte, Passwort) 
	VALUES((Select PersonID FROM Person WHERE Vorname = "Hannes" AND Nachname = "Huber"), "Buma11", "Admin", "123456"),
	((Select PersonID FROM Person WHERE Vorname = "Julia" AND Nachname = "Merettig"), "Schokokeks", "Admin", "schokolade"),
	((Select PersonID FROM Person WHERE Vorname = "Friedrich" AND Nachname = "Schmidt"), "Zett94", "Admin", "keineahnung"),
	((Select PersonID FROM Person WHERE Vorname = "Klaus" AND Nachname = "Arendt"), "Klausimausi", "Standard", "bestespw"),
	((Select PersonID FROM Person WHERE Vorname = "Joachim" AND Nachname = "Adam"), "TheLegend27", "Standard", "TheLegend27"),
	((Select PersonID FROM Person WHERE Vorname = "Thomas" AND Nachname = "Adolf"), "ForeverAfd", "Standard", "kriegisbest"),
	((Select PersonID FROM Person WHERE Vorname = "Liliane" AND Nachname = "Bauer"), "LandlebenFTW", "Standard", "Traktor6"),
	((Select PersonID FROM Person WHERE Vorname = "Lukas" AND Nachname = "Brau"), "BierLover66", "Standard", "Urquell"),
	((Select PersonID FROM Person WHERE Vorname = "Samuel" AND Nachname = "Burg"), "Lancelot", "Standard", "Arthurftw"),
	((Select PersonID FROM Person WHERE Vorname = "Matthias" AND Nachname = "Bruggmoser"), "TheBeast", "Standard", "sicherespw"),
	((Select PersonID FROM Person WHERE Vorname = "Arianna" AND Nachname = "Adari"), "PingPongShowMaster", "Standard", "Atariftw"),
	((Select PersonID FROM Person WHERE Vorname = "Arion" AND Nachname = "Cern"), "TeilchenMaster", "Standard", "LHCisthebest"),
	((Select PersonID FROM Person WHERE Vorname = "Brigitte" AND Nachname = "Dahlmann"), "Kittielover", "Standard", "Nicenstein"),
	((Select PersonID FROM Person WHERE Vorname = "Bruno" AND Nachname = "Danner"), "BlackDragon", "Standard", "DannerSwag"),
	((Select PersonID FROM Person WHERE Vorname = "Doreen" AND Nachname = "Dannecker"), "RefrendaryLive", "Standard", "badGrades"),
	((Select PersonID FROM Person WHERE Vorname = "Dan" AND Nachname = "Erdmann"), "Maulwurf72", "Standard", "DerWühler"),
	((Select PersonID FROM Person WHERE Vorname = "Elena" AND Nachname = "Emmenecker"), "Leichtathletikfreak", "Standard", "Hürdenmaster"),
	((Select PersonID FROM Person WHERE Vorname = "Irina" AND Nachname = "Freud"), "Psychomaster", "Standard", "PenisNeid"),
	((Select PersonID FROM Person WHERE Vorname = "Siena" AND Nachname = "Fuhrmann"), "PastaFetisch", "Standard", "PizzaLove"),
	((Select PersonID FROM Person WHERE Vorname = "Julia" AND Nachname = "Fink"), "Vogelbaby", "Standard", "Eierleger"),
	((Select PersonID FROM Person WHERE Vorname = "Joseph" AND Nachname = "Fischer"), "JavaHater", "Standard", "CMasterrace"),
	((Select PersonID FROM Person WHERE Vorname = "Alina" AND Nachname = "Gans"), "Federkleid", "Standard", "Schnabel21"),
	((Select PersonID FROM Person WHERE Vorname = "Gerhard" AND Nachname = "Göppert"), "GrowThatShit", "Standard", "420"),
	((Select PersonID FROM Person WHERE Vorname = "Philipp" AND Nachname = "Groß"), "ThormundGiantsbane", "Standard", "MilkIsLove"),
	((Select PersonID FROM Person WHERE Vorname = "Katharina" AND Nachname = "Gabriel"), "Archangel", "Standard", "DadIsGod"),
	((Select PersonID FROM Person WHERE Vorname = "Selina" AND Nachname = "Dabanli"), "Hottie47", "Standard", "LoveMe"),
	((Select PersonID FROM Person WHERE Vorname = "Oleg" AND Nachname = "Hofer"), "Viking1", "Standard", "OdinIsBest"),
	((Select PersonID FROM Person WHERE Vorname = "Layla" AND Nachname = "Hefler"), "BunnyFreak", "Standard", "Playboymaster"),
	((Select PersonID FROM Person WHERE Vorname = "Rico" AND Nachname = "Hemmer"), "NailsBow", "Standard", "IPunch"),
	((Select PersonID FROM Person WHERE Vorname = "Leonard" AND Nachname = "Haubeil"), "AxesUnite", "Standard", "ChopTheTrees"),
	((Select PersonID FROM Person WHERE Vorname = "Larissa" AND Nachname = "Inntal"), "BadGirl26", "Standard", "IWreckYou"),
	((Select PersonID FROM Person WHERE Vorname = "Ludwig" AND Nachname = "Jäger"), "GunsAreLife", "Standard", "Intervention"),
	((Select PersonID FROM Person WHERE Vorname = "Patricia" AND Nachname = "Jobel"), "FreiburgBest", "Standard", "StuttgartWorst"),
	((Select PersonID FROM Person WHERE Vorname = "Janette" AND Nachname = "Josephus"), "Jesus2873", "Standard", "BowBeforeHim"),
	((Select PersonID FROM Person WHERE Vorname = "Mirco" AND Nachname = "Kammerdiener"), "TheSlave", "Standard", "Shackles");
	

	INSERT INTO Zimmer(StationsBezeichnung, ZimmerNr)
	VALUES("Gynäkologie", 1),
	("Gynäkologie", 2),
	("Gynäkologie", 3),
	("Gynäkologie", 4),
	("Gynäkologie", 5),
	("Gynäkologie", 6),
	("Gynäkologie", 7),
	("Gynäkologie", 8),
	("Gynäkologie", 9),
	("Gynäkologie", 10),
	("Gynäkologie", 11),
	("Gynäkologie", 12),
	("Gynäkologie", 13),
	("Gynäkologie", 14),
	("Gynäkologie", 15),
	("Gynäkologie", 16),
	("Gynäkologie", 17),
	("Gynäkologie", 18),
	("Gynäkologie", 19),
	("Gynäkologie", 20),
	("Gynäkologie", 21),
	("Gynäkologie", 22),
	("Gynäkologie", 23),
	("Gynäkologie", 24),
	("Gynäkologie", 25),
	("Innere Medizin", 1),
	("Innere Medizin", 2),
	("Innere Medizin", 3),
	("Innere Medizin", 4),
	("Innere Medizin", 5),
	("Innere Medizin", 6),
	("Innere Medizin", 7),
	("Innere Medizin", 8),
	("Innere Medizin", 9),
	("Innere Medizin", 10),
	("Innere Medizin", 11),
	("Innere Medizin", 12),
	("Innere Medizin", 13),
	("Innere Medizin", 14),
	("Innere Medizin", 15),
	("Innere Medizin", 16),
	("Innere Medizin", 17),
	("Innere Medizin", 18),
	("Innere Medizin", 19),
	("Innere Medizin", 20),
	("Innere Medizin", 21),
	("Innere Medizin", 22),
	("Innere Medizin", 23),
	("Innere Medizin", 24),
	("Innere Medizin", 25),
	("Onkologie", 1),
	("Onkologie", 2),
	("Onkologie", 3),
	("Onkologie", 4),
	("Onkologie", 5),
	("Onkologie", 6),
	("Onkologie", 7),
	("Onkologie", 8),
	("Onkologie", 9),
	("Onkologie", 10),
	("Onkologie", 11),
	("Onkologie", 12),
	("Onkologie", 13),
	("Onkologie", 14),
	("Onkologie", 15),
	("Onkologie", 16),
	("Onkologie", 17),
	("Onkologie", 18),
	("Onkologie", 19),
	("Onkologie", 20),
	("Onkologie", 21),
	("Onkologie", 22),
	("Onkologie", 23),
	("Onkologie", 24),
	("Onkologie", 25),
	("Orthopädie", 1),
	("Orthopädie", 2),
	("Orthopädie", 3),
	("Orthopädie", 4),
	("Orthopädie", 5),
	("Orthopädie", 6),
	("Orthopädie", 7),
	("Orthopädie", 8),
	("Orthopädie", 9),
	("Orthopädie", 10),
	("Orthopädie", 11),
	("Orthopädie", 12),
	("Orthopädie", 13),
	("Orthopädie", 14),
	("Orthopädie", 15),
	("Orthopädie", 16),
	("Orthopädie", 17),
	("Orthopädie", 18),
	("Orthopädie", 19),
	("Orthopädie", 20),
	("Orthopädie", 21),
	("Orthopädie", 22),
	("Orthopädie", 23),
	("Orthopädie", 24),
	("Orthopädie", 25),
	("Pädiatrie", 1),
	("Pädiatrie", 2),
	("Pädiatrie", 3),
	("Pädiatrie", 4),
	("Pädiatrie", 5),
	("Pädiatrie", 6),
	("Pädiatrie", 7),
	("Pädiatrie", 8),
	("Pädiatrie", 9),
	("Pädiatrie", 10),
	("Pädiatrie", 11),
	("Pädiatrie", 12),
	("Pädiatrie", 13),
	("Pädiatrie", 14),
	("Pädiatrie", 15),
	("Pädiatrie", 16),
	("Pädiatrie", 17),
	("Pädiatrie", 18),
	("Pädiatrie", 19),
	("Pädiatrie", 20),
	("Pädiatrie", 21),
	("Pädiatrie", 22),
	("Pädiatrie", 23),
	("Pädiatrie", 24),
	("Pädiatrie", 25),
	("Intensivstation", 1),
	("Intensivstation", 2),
	("Intensivstation", 3),
	("Intensivstation", 4),
	("Intensivstation", 5),
	("Intensivstation", 6),
	("Intensivstation", 7),
	("Intensivstation", 8),
	("Intensivstation", 9),
	("Intensivstation", 10);
    


INSERT INTO Patient(VersicherungsNr, PersonID, ZimmerNr, StationsBezeichnung, Bett, Beschwerde) VALUES(12345, (Select Person.PersonID From Person WHERE Vorname = "Janes" AND Nachname = "Heuberger"), 2, "Innere Medizin", "F", "Gebrochenes Bein");
INSERT INTO Mitarbeiter(PersonID, Rechte) VALUES((SELECT PersonID FROM Person WHERE Vorname = "Janes" AND Nachname = "Heuberger"), "Admin of Admins");
INSERT INTO TransferListe(PersonID, Von, Nach) VALUES((SELECT PersonID FROM Person WHERE Vorname = "Janes" AND Nachname = "Heuberger"), "IM-2-F", "IM-2-T");
INSERT INTO Users(PersonID, Benutzername, Rechte, Passwort) VALUES((Select PersonID FROM Person WHERE Vorname = "Janes" AND Nachname = "Heuberger"), "Janessus", "Admin", "password");
*/
commit;