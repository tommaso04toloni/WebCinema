-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               10.11.2-MariaDB-log - mariadb.org binary distribution
-- Server OS:                    Win64
-- HeidiSQL Version:             12.1.0.6537
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Dumping database structure for cinema_toloni_tommasol
CREATE DATABASE IF NOT EXISTS `cinema_toloni_tommasol` /*!40100 DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci */;
USE `cinema_toloni_tommasol`;

-- Dumping structure for table cinema_toloni_tommasol.aspnetroleclaims
CREATE TABLE IF NOT EXISTS `aspnetroleclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `RoleId` varchar(255) NOT NULL,
  `ClaimType` longtext DEFAULT NULL,
  `ClaimValue` longtext DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Dumping data for table cinema_toloni_tommasol.aspnetroleclaims: ~0 rows (approximately)
DELETE FROM `aspnetroleclaims`;

-- Dumping structure for table cinema_toloni_tommasol.aspnetroles
CREATE TABLE IF NOT EXISTS `aspnetroles` (
  `Id` varchar(255) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` longtext DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RoleNameIndex` (`NormalizedName`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Dumping data for table cinema_toloni_tommasol.aspnetroles: ~0 rows (approximately)
DELETE FROM `aspnetroles`;

-- Dumping structure for table cinema_toloni_tommasol.aspnetuserclaims
CREATE TABLE IF NOT EXISTS `aspnetuserclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` varchar(255) NOT NULL,
  `ClaimType` longtext DEFAULT NULL,
  `ClaimValue` longtext DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetUserClaims_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Dumping data for table cinema_toloni_tommasol.aspnetuserclaims: ~0 rows (approximately)
DELETE FROM `aspnetuserclaims`;

-- Dumping structure for table cinema_toloni_tommasol.aspnetuserlogins
CREATE TABLE IF NOT EXISTS `aspnetuserlogins` (
  `LoginProvider` varchar(255) NOT NULL,
  `ProviderKey` varchar(255) NOT NULL,
  `ProviderDisplayName` longtext DEFAULT NULL,
  `UserId` varchar(255) NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `IX_AspNetUserLogins_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Dumping data for table cinema_toloni_tommasol.aspnetuserlogins: ~0 rows (approximately)
DELETE FROM `aspnetuserlogins`;

-- Dumping structure for table cinema_toloni_tommasol.aspnetuserroles
CREATE TABLE IF NOT EXISTS `aspnetuserroles` (
  `UserId` varchar(255) NOT NULL,
  `RoleId` varchar(255) NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_AspNetUserRoles_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Dumping data for table cinema_toloni_tommasol.aspnetuserroles: ~0 rows (approximately)
DELETE FROM `aspnetuserroles`;

-- Dumping structure for table cinema_toloni_tommasol.aspnetusers
CREATE TABLE IF NOT EXISTS `aspnetusers` (
  `Id` varchar(255) NOT NULL,
  `Discriminator` longtext NOT NULL,
  `Name` longtext DEFAULT NULL,
  `StreetAddress` longtext DEFAULT NULL,
  `City` longtext DEFAULT NULL,
  `State` longtext DEFAULT NULL,
  `PostalCode` longtext DEFAULT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext DEFAULT NULL,
  `SecurityStamp` longtext DEFAULT NULL,
  `ConcurrencyStamp` longtext DEFAULT NULL,
  `PhoneNumber` longtext DEFAULT NULL,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  KEY `EmailIndex` (`NormalizedEmail`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Dumping data for table cinema_toloni_tommasol.aspnetusers: ~0 rows (approximately)
DELETE FROM `aspnetusers`;

-- Dumping structure for table cinema_toloni_tommasol.aspnetusertokens
CREATE TABLE IF NOT EXISTS `aspnetusertokens` (
  `UserId` varchar(255) NOT NULL,
  `LoginProvider` varchar(255) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Value` longtext DEFAULT NULL,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`),
  CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Dumping data for table cinema_toloni_tommasol.aspnetusertokens: ~0 rows (approximately)
DELETE FROM `aspnetusertokens`;

-- Dumping structure for table cinema_toloni_tommasol.film
CREATE TABLE IF NOT EXISTS `film` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Titolo` varchar(100) NOT NULL,
  `Genere` varchar(50) NOT NULL,
  `Descrizione` varchar(500) NOT NULL,
  `Durata` int(11) NOT NULL,
  `AnnoProduzione` int(11) NOT NULL,
  `Immagine` varchar(200) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Dumping data for table cinema_toloni_tommasol.film: ~0 rows (approximately)
DELETE FROM `film`;

-- Dumping structure for table cinema_toloni_tommasol.ordinebiglietti
CREATE TABLE IF NOT EXISTS `ordinebiglietti` (
  `Id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `SpettacoloId` int(10) unsigned NOT NULL,
  `numeroPosti` int(11) NOT NULL,
  `ApplicationUserId` varchar(255) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_OrdineBiglietti_ApplicationUserId` (`ApplicationUserId`),
  KEY `IX_OrdineBiglietti_SpettacoloId` (`SpettacoloId`),
  CONSTRAINT `FK_OrdineBiglietti_AspNetUsers_ApplicationUserId` FOREIGN KEY (`ApplicationUserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_OrdineBiglietti_spettacoli_SpettacoloId` FOREIGN KEY (`SpettacoloId`) REFERENCES `spettacoli` (`ID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Dumping data for table cinema_toloni_tommasol.ordinebiglietti: ~0 rows (approximately)
DELETE FROM `ordinebiglietti`;

-- Dumping structure for table cinema_toloni_tommasol.posti
CREATE TABLE IF NOT EXISTS `posti` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `IDSala` int(10) unsigned NOT NULL,
  `Fila` int(11) NOT NULL,
  `Numero` int(11) NOT NULL,
  `Costo` decimal(5,2) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `IDSala` (`IDSala`),
  CONSTRAINT `posti_ibfk_1` FOREIGN KEY (`IDSala`) REFERENCES `sale` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Dumping data for table cinema_toloni_tommasol.posti: ~0 rows (approximately)
DELETE FROM `posti`;

-- Dumping structure for table cinema_toloni_tommasol.prenotazioni
CREATE TABLE IF NOT EXISTS `prenotazioni` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `IDUtente` int(10) unsigned NOT NULL,
  `IDSpettacolo` int(10) unsigned NOT NULL,
  `IDPosto` int(10) unsigned NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `IDPosto` (`IDPosto`),
  KEY `IDSpettacolo` (`IDSpettacolo`),
  KEY `IDUtente` (`IDUtente`),
  CONSTRAINT `prenotazioni_ibfk_1` FOREIGN KEY (`IDUtente`) REFERENCES `utenti` (`ID`),
  CONSTRAINT `prenotazioni_ibfk_2` FOREIGN KEY (`IDSpettacolo`) REFERENCES `spettacoli` (`ID`),
  CONSTRAINT `prenotazioni_ibfk_3` FOREIGN KEY (`IDPosto`) REFERENCES `posti` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Dumping data for table cinema_toloni_tommasol.prenotazioni: ~0 rows (approximately)
DELETE FROM `prenotazioni`;

-- Dumping structure for table cinema_toloni_tommasol.sale
CREATE TABLE IF NOT EXISTS `sale` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `NumeroSala` int(11) NOT NULL,
  `PostiDisponibili` int(11) NOT NULL,
  `IsSense` bit(1) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Dumping data for table cinema_toloni_tommasol.sale: ~0 rows (approximately)
DELETE FROM `sale`;

-- Dumping structure for table cinema_toloni_tommasol.spettacoli
CREATE TABLE IF NOT EXISTS `spettacoli` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `IDFilm` int(10) unsigned NOT NULL,
  `IDSala` int(10) unsigned NOT NULL,
  `DataOra` datetime NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `IDFilm` (`IDFilm`),
  KEY `IDSala1` (`IDSala`),
  CONSTRAINT `spettacoli_ibfk_1` FOREIGN KEY (`IDFilm`) REFERENCES `film` (`ID`),
  CONSTRAINT `spettacoli_ibfk_2` FOREIGN KEY (`IDSala`) REFERENCES `sale` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Dumping data for table cinema_toloni_tommasol.spettacoli: ~0 rows (approximately)
DELETE FROM `spettacoli`;

-- Dumping structure for table cinema_toloni_tommasol.utenti
CREATE TABLE IF NOT EXISTS `utenti` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Cognome` varchar(50) NOT NULL,
  `Nome` varchar(50) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `Password` varchar(100) NOT NULL,
  `Sesso` char(1) NOT NULL,
  `DataNascita` date NOT NULL,
  `ComuneResidenza` varchar(100) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Dumping data for table cinema_toloni_tommasol.utenti: ~0 rows (approximately)
DELETE FROM `utenti`;

-- Dumping structure for table cinema_toloni_tommasol.valutazioni
CREATE TABLE IF NOT EXISTS `valutazioni` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `IDUtente` int(10) unsigned NOT NULL,
  `IDFilm` int(10) unsigned NOT NULL,
  `Voto` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `IDFilm1` (`IDFilm`),
  KEY `IDUtente1` (`IDUtente`),
  CONSTRAINT `valutazioni_ibfk_1` FOREIGN KEY (`IDUtente`) REFERENCES `utenti` (`ID`),
  CONSTRAINT `valutazioni_ibfk_2` FOREIGN KEY (`IDFilm`) REFERENCES `film` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Dumping data for table cinema_toloni_tommasol.valutazioni: ~0 rows (approximately)
DELETE FROM `valutazioni`;

-- Dumping structure for table cinema_toloni_tommasol.__efmigrationshistory
CREATE TABLE IF NOT EXISTS `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Dumping data for table cinema_toloni_tommasol.__efmigrationshistory: ~2 rows (approximately)
DELETE FROM `__efmigrationshistory`;
INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
	('20230508144458_pippone', '7.0.5'),
	('20230508144743_melc', '7.0.5');

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
