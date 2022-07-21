Create table user(
id int NOT NULL AUTO_INCREMENT,
Nom varchar(25) NOT NULL,
prenom varchar(25) NOT NULL,
nomutilisateur varchar(25) not null,
courriel varchar(30) not null,
motdepasse varchar(500) not null,
confirmation varchar(500) not null,
statut varchar(20)not null,
primary Key (id)
);

