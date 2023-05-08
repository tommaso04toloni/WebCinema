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


-- Dumping database structure for cinema_toloni_tommasoa
CREATE DATABASE IF NOT EXISTS `cinema_toloni_tommasoa` /*!40100 DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci */;
USE `cinema_toloni_tommasoa`;

-- Dumping structure for table cinema_toloni_tommasoa.aspnetroleclaims
CREATE TABLE IF NOT EXISTS `aspnetroleclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `RoleId` varchar(255) NOT NULL,
  `ClaimType` longtext DEFAULT NULL,
  `ClaimValue` longtext DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Dumping data for table cinema_toloni_tommasoa.aspnetroleclaims: ~0 rows (approximately)
DELETE FROM `aspnetroleclaims`;

-- Dumping structure for table cinema_toloni_tommasoa.aspnetroles
CREATE TABLE IF NOT EXISTS `aspnetroles` (
  `Id` varchar(255) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` longtext DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RoleNameIndex` (`NormalizedName`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Dumping data for table cinema_toloni_tommasoa.aspnetroles: ~0 rows (approximately)
DELETE FROM `aspnetroles`;

-- Dumping structure for table cinema_toloni_tommasoa.aspnetuserclaims
CREATE TABLE IF NOT EXISTS `aspnetuserclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` varchar(255) NOT NULL,
  `ClaimType` longtext DEFAULT NULL,
  `ClaimValue` longtext DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetUserClaims_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Dumping data for table cinema_toloni_tommasoa.aspnetuserclaims: ~0 rows (approximately)
DELETE FROM `aspnetuserclaims`;

-- Dumping structure for table cinema_toloni_tommasoa.aspnetuserlogins
CREATE TABLE IF NOT EXISTS `aspnetuserlogins` (
  `LoginProvider` varchar(128) NOT NULL,
  `ProviderKey` varchar(128) NOT NULL,
  `ProviderDisplayName` longtext DEFAULT NULL,
  `UserId` varchar(255) NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `IX_AspNetUserLogins_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Dumping data for table cinema_toloni_tommasoa.aspnetuserlogins: ~0 rows (approximately)
DELETE FROM `aspnetuserlogins`;

-- Dumping structure for table cinema_toloni_tommasoa.aspnetuserroles
CREATE TABLE IF NOT EXISTS `aspnetuserroles` (
  `UserId` varchar(255) NOT NULL,
  `RoleId` varchar(255) NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_AspNetUserRoles_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Dumping data for table cinema_toloni_tommasoa.aspnetuserroles: ~0 rows (approximately)
DELETE FROM `aspnetuserroles`;

-- Dumping structure for table cinema_toloni_tommasoa.aspnetusers
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

-- Dumping data for table cinema_toloni_tommasoa.aspnetusers: ~0 rows (approximately)
DELETE FROM `aspnetusers`;

-- Dumping structure for table cinema_toloni_tommasoa.aspnetusertokens
CREATE TABLE IF NOT EXISTS `aspnetusertokens` (
  `UserId` varchar(255) NOT NULL,
  `LoginProvider` varchar(128) NOT NULL,
  `Name` varchar(128) NOT NULL,
  `Value` longtext DEFAULT NULL,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`),
  CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Dumping data for table cinema_toloni_tommasoa.aspnetusertokens: ~0 rows (approximately)
DELETE FROM `aspnetusertokens`;

-- Dumping structure for table cinema_toloni_tommasoa.film
CREATE TABLE IF NOT EXISTS `film` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Titolo` varchar(100) NOT NULL,
  `Genere` varchar(50) NOT NULL,
  `Descrizione` varchar(500) NOT NULL,
  `Durata` int(11) NOT NULL,
  `AnnoProduzione` int(11) NOT NULL,
  `Immagine` varchar(200) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Dumping data for table cinema_toloni_tommasoa.film: ~3 rows (approximately)
DELETE FROM `film`;
INSERT INTO `film` (`ID`, `Titolo`, `Genere`, `Descrizione`, `Durata`, `AnnoProduzione`, `Immagine`) VALUES
	(9, 'Ritorno al futuro', 'Azione', '<p>ponzi ponzi</p>', 300, 2016, '\\images\\films\\34af22f0-fb9a-48c9-9360-a39768d39b6a.webp'),
	(10, 'American Psycho', 'Fantascienza', '<p>madonna santa</p>', 128, 2014, '\\images\\films\\9fe5cc0a-c711-4f34-8cef-d3b8f6398bda.webp'),
	(11, 'The imitation Game', 'Fantascienza', '<p>un film al passato</p>', 78, 2004, '\\images\\films\\74013a76-79d8-48c2-a50b-4172275b5e71.webp');

-- Dumping structure for table cinema_toloni_tommasoa.posti
CREATE TABLE IF NOT EXISTS `posti` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `IDSala` int(10) unsigned NOT NULL,
  `Fila` int(11) NOT NULL,
  `Numero` int(11) NOT NULL,
  `Costo` decimal(5,2) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `IDSala` (`IDSala`),
  CONSTRAINT `posti_ibfk_1` FOREIGN KEY (`IDSala`) REFERENCES `sale` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Dumping data for table cinema_toloni_tommasoa.posti: ~0 rows (approximately)
DELETE FROM `posti`;

-- Dumping structure for table cinema_toloni_tommasoa.prenotazioni
CREATE TABLE IF NOT EXISTS `prenotazioni` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `IDUtente` int(10) unsigned NOT NULL,
  `IDSpettacolo` int(10) unsigned NOT NULL,
  `IDPosto` int(10) unsigned NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `IDPosto` (`IDPosto`),
  KEY `IDSpettacolo` (`IDSpettacolo`),
  KEY `IDUtente` (`IDUtente`),
  CONSTRAINT `prenotazioni_ibfk_1` FOREIGN KEY (`IDUtente`) REFERENCES `utenti` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `prenotazioni_ibfk_2` FOREIGN KEY (`IDSpettacolo`) REFERENCES `spettacoli` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `prenotazioni_ibfk_3` FOREIGN KEY (`IDPosto`) REFERENCES `posti` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Dumping data for table cinema_toloni_tommasoa.prenotazioni: ~0 rows (approximately)
DELETE FROM `prenotazioni`;

-- Dumping structure for table cinema_toloni_tommasoa.sale
CREATE TABLE IF NOT EXISTS `sale` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `NumeroSala` int(11) NOT NULL,
  `PostiDisponibili` int(11) NOT NULL,
  `IsSense` bit(1) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Dumping data for table cinema_toloni_tommasoa.sale: ~1 rows (approximately)
DELETE FROM `sale`;
INSERT INTO `sale` (`ID`, `NumeroSala`, `PostiDisponibili`, `IsSense`) VALUES
	(4, 1, 30, b'0');

-- Dumping structure for table cinema_toloni_tommasoa.spettacoli
CREATE TABLE IF NOT EXISTS `spettacoli` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `IDFilm` int(10) unsigned NOT NULL,
  `IDSala` int(10) unsigned NOT NULL,
  `DataOra` datetime NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `IDFilm1` (`IDFilm`),
  KEY `IDSala1` (`IDSala`),
  CONSTRAINT `spettacoli_ibfk_1` FOREIGN KEY (`IDFilm`) REFERENCES `film` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `spettacoli_ibfk_2` FOREIGN KEY (`IDSala`) REFERENCES `sale` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Dumping data for table cinema_toloni_tommasoa.spettacoli: ~0 rows (approximately)
DELETE FROM `spettacoli`;

-- Dumping structure for table cinema_toloni_tommasoa.utenti
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

-- Dumping data for table cinema_toloni_tommasoa.utenti: ~0 rows (approximately)
DELETE FROM `utenti`;

-- Dumping structure for table cinema_toloni_tommasoa.valutazioni
CREATE TABLE IF NOT EXISTS `valutazioni` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `IDUtente` int(10) unsigned NOT NULL,
  `IDFilm` int(10) unsigned NOT NULL,
  `Voto` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `IDFilm2` (`IDFilm`),
  KEY `IDUtente1` (`IDUtente`),
  CONSTRAINT `valutazioni_ibfk_1` FOREIGN KEY (`IDUtente`) REFERENCES `utenti` (`ID`),
  CONSTRAINT `valutazioni_ibfk_2` FOREIGN KEY (`IDFilm`) REFERENCES `film` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- Dumping data for table cinema_toloni_tommasoa.valutazioni: ~0 rows (approximately)
DELETE FROM `valutazioni`;

-- Dumping structure for table cinema_toloni_tommasoa.__efmigrationshistory
CREATE TABLE IF NOT EXISTS `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Dumping data for table cinema_toloni_tommasoa.__efmigrationshistory: ~0 rows (approximately)
DELETE FROM `__efmigrationshistory`;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
