CREATE TABLE Condominio(
	Id INT IDENTITY(1,1),
	Nome VARCHAR (60) NOT NULL,
	Bairro VARCHAR(100) NOT NULL,

	CONSTRAINT Id_Condominio PRIMARY KEY (Id)
)

CREATE TABLE Familia(
	Id  INT IDENTITY(1,1),
	Nome VARCHAR (60) NOT NULL,
	Id_Condominio INT  NOT NULL,
	Apto INT  NOT NULL

	CONSTRAINT Id_Familia PRIMARY KEY (Id),
	CONSTRAINT FK_Id_Condominio FOREIGN KEY (Id_Condominio)
		REFERENCES Condominio (Id)
)

INSERT INTO Condominio VALUES ('Serra Negra ','Vila Nova')
INSERT INTO Condominio VALUES ('Casa Branca ','Moema')
INSERT INTO Condominio VALUES ('Bom Recanto ','Vila Guarani')
INSERT INTO Condominio VALUES ('Imaré ','Capuava')
INSERT INTO Condominio VALUES ('Andorinha ','Jardim América')
SELECT*FROM Condominio

INSERT INTO Familia VALUES ('Silva ',1,'10')
INSERT INTO Familia VALUES ('Novaes ',3,'45')
INSERT INTO Familia VALUES ('Nobrega ',2,'52')
INSERT INTO Familia VALUES ('Campineli ',1,'75')
INSERT INTO Familia VALUES ('Souza ',2,'12')
SELECT*FROM Familia

INSERT INTO Morador VALUES (1,'Valmir','65')
INSERT INTO Morador VALUES (3,'Lúcia','27')
INSERT INTO Morador VALUES (2,'Marcelo','35')
INSERT INTO Morador VALUES (2,'Irene','78')
INSERT INTO Morador VALUES (5,'Marta','31')
INSERT INTO Morador VALUES (11,'Alberto','56')
INSERT INTO Morador VALUES (8,'Lucas','10')
INSERT INTO Morador VALUES (4,'Maria','5')
INSERT INTO Morador VALUES (9,'Mateus','9')
INSERT INTO Morador VALUES (10,'Julia','2')
INSERT INTO Morador VALUES (5,'Bernardo','18')
INSERT INTO Morador VALUES (7,'Rosa','23')
INSERT INTO Morador VALUES (3,'Helena','2')
INSERT INTO Morador VALUES (1,'Willian','18')
INSERT INTO Morador VALUES (1,'José','23')
INSERT INTO Morador VALUES (3,'Priscila','15')
INSERT INTO Morador VALUES (7,'Amanda','42')
INSERT INTO Morador VALUES (5,'Guilherme','13')
INSERT INTO Morador VALUES (4,'Roberta','29')
INSERT INTO Morador VALUES (4,'Ricardo','22')
INSERT INTO Morador VALUES (6,'Giovane','2')
INSERT INTO Morador VALUES (6,'Flavia','30')
INSERT INTO Morador VALUES (11,'Ricardo','81')
INSERT INTO Morador VALUES (8,'Fabiana','43')
INSERT INTO Morador VALUES (7,'Marcio','20')
INSERT INTO Morador VALUES (9,'Roberto','1')
INSERT INTO Morador VALUES (4,'Marcos','4')
INSERT INTO Morador VALUES (10,'Rafael','3')
SELECT*FROM Morador

SELECT Condominio.Nome as Condominio, Morador.Idade as Pessoasmaisde50anos FROM Condominio 
INNER JOIN Familia on Familia.Id_Condominio = Condominio.Id
INNER JOIN Morador on Morador.Id_Familia = Familia.Id
where Morador.Idade > 50

SELECT Morador.Nome as Pessoas, Familia.Nome as Familia, Condominio.Nome as Condominio FROM Condominio 
INNER JOIN Familia on Familia.Id_Condominio = Condominio.Id
INNER JOIN Morador on Morador.Id_Familia = Familia.Id 

SELECT Condominio.Bairro as Bairro, Morador.Idade as MediaIdade FROM Condominio 
INNER JOIN Morador on Condominio.Id = Morador.Id_Familia   

SELECT f.Bairro, AVG(AT.Idade) as Media_Idade
 from Morador AT
	INNER JOIN dbo.Condominio f on f.Id=at.Idade
	INNER JOIN dbo.Morador m on m.Id=at.Id
GROUP BY f.Bairro