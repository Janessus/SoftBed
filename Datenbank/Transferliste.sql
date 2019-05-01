use SoftBedDB;

create table IF NOT EXISTS TransferListe
(
	PersonID int AUTO_INCREMENT,
	VonBett Varchar(10),
    NachBett varchar(10),
    Stempel Timestamp,

    PRIMARY KEY (PersonID, Stempel)
);

commit;