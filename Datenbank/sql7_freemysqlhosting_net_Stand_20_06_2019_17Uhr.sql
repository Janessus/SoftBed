-- phpMyAdmin SQL Dump
-- version 4.7.1
-- https://www.phpmyadmin.net/
--
-- Host: sql7.freemysqlhosting.net
-- Generation Time: Jun 20, 2019 at 03:11 PM
-- Server version: 5.5.58-0ubuntu0.14.04.1
-- PHP Version: 7.0.33-0ubuntu0.16.04.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `sql7294766`
--
CREATE DATABASE IF NOT EXISTS `sql7294766` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `sql7294766`;

-- --------------------------------------------------------

drop table if exists Users;
drop table if exists TransferListe;
drop table if exists Patient;
drop table if exists Zimmer;
drop table if exists Station;
drop table if exists Person;

--
-- Table structure for table `Patient`
--

CREATE TABLE `Patient` (
  `VersicherungsNr` varchar(40) NOT NULL DEFAULT '',
  `PersonID` int(11) DEFAULT NULL,
  `ZimmerNr` int(11) DEFAULT NULL,
  `StationsBezeichnung` varchar(40) DEFAULT NULL,
  `Bett` varchar(1) DEFAULT NULL,
  `Sollstation` varchar(255) DEFAULT NULL,
  `Aufnahmedatum` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `Patient`
--

INSERT INTO `Patient` (`VersicherungsNr`, `PersonID`, `ZimmerNr`, `StationsBezeichnung`, `Bett`, `Sollstation`, `Aufnahmedatum`) VALUES
('123456ertzui', 348, 1, 'Intensivstation', 'F', '', '2019-06-20 14:53:52'),
('123456ertzui45', 349, 2, 'Intensivstation', 'F', '', '2019-06-20 14:54:11'),
('A239870002', 356, 15, 'Orthopädie', 'F', '', '2019-06-20 15:03:31'),
('A394204234', 299, 12, 'Innere Medizin', 'F', '', '2019-06-11 11:00:54'),
('A455002282', 35, 2, 'Onkologie', 'T', '', '2019-06-07 10:36:40'),
('ASDF45654', 351, 4, 'Intensivstation', 'F', '', '2019-06-20 14:55:12'),
('B329876983', 346, 16, 'Orthopädie', 'F', '', '2019-06-20 14:37:00'),
('B337711929', 321, 18, 'Innere Medizin', 'T', '', '2019-06-11 14:45:16'),
('B347463728', 225, 22, 'Onkologie', 'F', '', '2019-06-11 09:58:05'),
('B373711092', 320, 18, 'Innere Medizin', 'F', '', '2019-06-11 14:44:29'),
('B463319283', 157, 14, 'Onkologie', 'F', '', '2019-06-11 08:25:19'),
('B463372819', 159, 8, 'Innere Medizin', 'F', '', '2019-06-11 08:35:53'),
('B463551118', 294, 25, 'Gynäkologie', 'T', '', '2019-06-11 10:35:31'),
('B464622273', 335, 15, 'Gynäkologie', 'F', '', '2019-06-12 11:48:56'),
('B465574638', 222, 21, 'Onkologie', 'F', '', '2019-06-11 09:57:16'),
('B475644738', 214, 15, 'Onkologie', 'T', '', '2019-06-11 09:54:38'),
('B613600598', 67, 5, 'Orthopädie', 'T', '', '2019-06-07 10:36:40'),
('B737366615', 357, 10, 'Gynäkologie', 'T', '', '2019-06-20 15:06:33'),
('B797576463', 90, 7, 'Orthopädie', 'T', '', '2019-06-07 10:36:40'),
('B873831212', 333, 18, 'Gynäkologie', 'T', '', '2019-06-11 14:51:08'),
('C136116913', 34, 2, 'Onkologie', 'F', '', '2019-06-07 10:36:40'),
('C177216257', 68, 5, 'Innere Medizin', 'F', '', '2019-06-07 10:36:40'),
('C448591791', 208, 10, 'Pädiatrie', 'T', '', '2019-06-11 09:53:08'),
('c5v6b7n8m9', 340, 4, 'Orthopädie', 'T', '', '2019-06-20 14:09:23'),
('C733834423', 334, 20, 'Gynäkologie', 'F', '', '2019-06-11 14:51:27'),
('C736664781', 360, 23, 'Orthopädie', 'F', '', '2019-06-20 15:11:16'),
('D282273647', 132, 16, 'Orthopädie', 'T', '', '2019-06-10 15:27:53'),
('D372681927', 162, 9, 'Innere Medizin', 'F', '', '2019-06-11 08:39:48'),
('D387991740', 84, 2, 'Pädiatrie', 'T', '', '2019-06-07 10:36:40'),
('D736333211', 300, 12, 'Innere Medizin', 'T', '', '2019-06-11 11:04:06'),
('D746422918', 282, 19, 'Gynäkologie', 'T', '', '2019-06-11 10:24:14'),
('D900370230', 256, 23, 'Pädiatrie', 'F', '', '2019-06-11 10:09:26'),
('E186797945', 92, 7, 'Onkologie', 'T', '', '2019-06-07 10:36:40'),
('F123746238', 122, 12, 'Orthopädie', 'F', '', '2019-06-10 15:19:37'),
('F236873846', 237, 14, 'Pädiatrie', 'F', '', '2019-06-11 10:03:54'),
('F237336472', 146, 9, 'Onkologie', 'F', '', '2019-06-11 08:20:17'),
('F238032003', 354, 4, 'Innere Medizin', 'F', '', '2019-06-20 15:01:19'),
('F330023981', 78, 1, 'Pädiatrie', 'F', '', '2019-06-07 10:36:40'),
('F371222983', 123, 13, 'Orthopädie', 'F', '', '2019-06-10 15:20:40'),
('F374461928', 167, 21, 'Orthopädie', 'T', '', '2019-06-11 08:50:32'),
('F383811729', 316, 16, 'Innere Medizin', 'F', '', '2019-06-11 14:41:48'),
('F439732032', 287, 22, 'Gynäkologie', 'F', '', '2019-06-11 10:26:07'),
('F473661252', 250, 18, 'Pädiatrie', 'T', '', '2019-06-11 10:07:58'),
('F474381162', 183, 10, 'Innere Medizin', 'F', '', '2019-06-11 09:10:23'),
('F474381723', 182, 8, 'Innere Medizin', 'T', '', '2019-06-11 09:10:02'),
('F475564829', 176, 9, 'Innere Medizin', 'T', '', '2019-06-11 08:57:20'),
('F569918774', 52, 3, 'Orthopädie', 'F', '', '2019-06-07 10:36:40'),
('F884813391', 40, 2, 'Orthopädie', 'F', '', '2019-06-07 10:36:40'),
('G172260987', 127, 14, 'Orthopädie', 'T', '', '2019-06-10 15:22:55'),
('G213435346', 289, 23, 'Gynäkologie', 'F', '', '2019-06-11 10:27:56'),
('G374628333', 203, 10, 'Pädiatrie', 'F', '', '2019-06-11 09:48:39'),
('G436447339', 145, 8, 'Onkologie', 'T', '', '2019-06-11 08:19:52'),
('G463371928', 161, 23, 'Orthopädie', 'T', '', '2019-06-11 08:38:54'),
('G463371929', 236, 14, 'Pädiatrie', 'T', '', '2019-06-11 10:04:07'),
('G475564734', 211, 18, 'Onkologie', 'F', '', '2019-06-11 09:53:59'),
('G475661119', 280, 18, 'Gynäkologie', 'F', '', '2019-06-11 10:22:22'),
('G635434187', 303, 9, 'Gynäkologie', 'T', '', '2019-06-11 11:06:44'),
('G745062417', 64, 5, 'Gynäkologie', 'T', '', '2019-06-07 10:36:40'),
('H273364897', 133, 18, 'Orthopädie', 'F', '', '2019-06-10 15:28:13'),
('H357872619', 63, 5, 'Gynäkologie', 'F', '', '2019-06-07 10:36:40'),
('H382911028', 315, 13, 'Innere Medizin', 'T', '', '2019-06-11 14:41:12'),
('H463372819', 168, 8, 'Orthopädie', 'F', '', '2019-06-11 08:51:02'),
('H473362819', 171, 9, 'Orthopädie', 'F', '', '2019-06-11 08:53:31'),
('H475564738', 212, 18, 'Onkologie', 'T', '', '2019-06-11 09:54:20'),
('H478639021', 245, 16, 'Pädiatrie', 'T', '', '2019-06-11 10:06:05'),
('H550247948', 31, 1, 'Gynäkologie', 'F', '', '2019-06-07 10:36:40'),
('H574611987', 293, 25, 'Gynäkologie', 'F', '', '2019-06-11 10:31:12'),
('H575757111', 295, 24, 'Orthopädie', 'T', '', '2019-06-11 10:36:41'),
('H732293970', 345, 17, 'Orthopädie', 'T', '', '2019-06-20 14:34:40'),
('H744322263', 235, 25, 'Onkologie', 'T', '', '2019-06-11 10:01:48'),
('I274465474', 209, 17, 'Onkologie', 'F', '', '2019-06-11 09:53:21'),
('I592724450', 77, 3, 'Pädiatrie', 'F', '', '2019-06-07 10:36:40'),
('I733644283', 131, 17, 'Orthopädie', 'F', '', '2019-06-10 15:27:25'),
('I803109599', 28, 2, 'Innere Medizin', 'T', '', '2019-06-07 10:36:40'),
('I926583802', 95, 7, 'Gynäkologie', 'T', '', '2019-06-07 10:36:40'),
('J003546236', 202, 7, 'Pädiatrie', 'T', '', '2019-06-11 09:47:05'),
('J272901112', 89, 6, 'Orthopädie', 'T', '', '2019-06-07 10:36:40'),
('J345034032', 290, 23, 'Gynäkologie', 'T', '', '2019-06-11 10:28:39'),
('J463371982', 158, 14, 'Onkologie', 'T', '', '2019-06-11 08:25:34'),
('J734663526', 232, 25, 'Onkologie', 'F', '', '2019-06-11 10:00:39'),
('J737936747', 37, 1, 'Orthopädie', 'F', '', '2019-06-07 10:36:40'),
('J837446578', 227, 23, 'Onkologie', 'F', '', '2019-06-11 09:58:48'),
('K123456789', 291, 24, 'Gynäkologie', 'F', '', '2019-06-11 10:29:50'),
('K243546379', 74, 6, 'Gynäkologie', 'F', '', '2019-06-07 10:36:40'),
('K283376525', 118, 9, 'Orthopädie', 'T', '', '2019-06-10 15:17:36'),
('K463371821', 169, 8, 'Orthopädie', 'T', '', '2019-06-11 08:52:28'),
('K463551726', 254, 22, 'Pädiatrie', 'F', '', '2019-06-11 10:08:59'),
('K474192783', 314, 15, 'Innere Medizin', 'T', '', '2019-06-11 14:40:22'),
('K474423783', 151, 11, 'Onkologie', 'T', '', '2019-06-11 08:22:47'),
('K574461110', 229, 24, 'Onkologie', 'F', '', '2019-06-11 09:59:35'),
('K578076968', 59, 4, 'Innere Medizin', 'T', '', '2019-06-07 10:36:40'),
('K655744833', 217, 19, 'Onkologie', 'T', '', '2019-06-11 09:55:57'),
('K7446511928', 231, 24, 'Onkologie', 'T', '', '2019-06-11 09:59:57'),
('K822642901', 120, 11, 'Orthopädie', 'F', '', '2019-06-10 15:18:42'),
('K837410293', 139, 20, 'Orthopädie', 'T', '', '2019-06-10 15:31:17'),
('K968961191', 45, 3, 'Gynäkologie', 'F', '', '2019-06-07 10:36:40'),
('L275122398', 121, 11, 'Orthopädie', 'T', '', '2019-06-10 15:19:06'),
('L283734643', 135, 19, 'Orthopädie', 'F', '', '2019-06-10 15:29:07'),
('L347511999', 288, 22, 'Gynäkologie', 'T', '', '2019-06-11 10:26:18'),
('L372923982', 259, 23, 'Pädiatrie', 'T', '', '2019-06-11 10:10:15'),
('L373346578', 137, 18, 'Orthopädie', 'T', '', '2019-06-10 15:30:01'),
('L373362819', 129, 15, 'Orthopädie', 'T', '', '2019-06-10 15:24:09'),
('L463772817', 240, 15, 'Pädiatrie', 'T', '', '2019-06-11 10:04:47'),
('L465510101', 228, 23, 'Onkologie', 'T', '', '2019-06-11 09:59:07'),
('L473661117', 277, 17, 'Gynäkologie', 'T', '', '2019-06-11 10:20:33'),
('L475466287', 274, 16, 'Gynäkologie', 'F', '', '2019-06-11 10:19:38'),
('L475564837', 210, 17, 'Onkologie', 'T', '', '2019-06-11 09:53:37'),
('L687905826', 83, 2, 'Pädiatrie', 'F', '', '2019-06-07 10:36:40'),
('L778635577', 88, 7, 'Orthopädie', 'F', '', '2019-06-07 10:36:40'),
('L824049419', 36, 1, 'Gynäkologie', 'T', '', '2019-06-07 10:36:40'),
('L834736271', 220, 20, 'Onkologie', 'T', '', '2019-06-11 09:56:38'),
('L843711726', 336, 24, 'Gynäkologie', 'T', '', '2019-06-12 11:49:24'),
('M179715172', 62, 4, 'Gynäkologie', 'T', '', '2019-06-07 10:36:40'),
('M226863567', 44, 3, 'Innere Medizin', 'T', '', '2019-06-07 10:36:40'),
('M273661152', 301, 10, 'Innere Medizin', 'T', '', '2019-06-11 11:06:00'),
('M277363481', 119, 10, 'Orthopädie', 'T', '', '2019-06-10 15:18:17'),
('M373238112', 323, 19, 'Innere Medizin', 'T', '', '2019-06-11 14:46:38'),
('M445327373', 177, 5, 'Pädiatrie', 'F', '', '2019-06-11 09:06:48'),
('M473829182', 160, 15, 'Onkologie', 'F', '', '2019-06-11 08:38:14'),
('M474711827', 310, 13, 'Innere Medizin', 'F', '', '2019-06-11 14:38:22'),
('M475564837', 206, 16, 'Onkologie', 'F', '', '2019-06-11 09:52:30'),
('M475655887', 226, 22, 'Onkologie', 'T', '', '2019-06-11 09:58:27'),
('M574487657', 86, 7, 'Innere Medizin', 'F', '', '2019-06-07 10:36:40'),
('M746661526', 352, 3, 'Onkologie', 'T', '', '2019-06-20 14:58:47'),
('N032790845', 223, 12, 'Pädiatrie', 'T', '', '2019-06-11 09:57:35'),
('N194702969', 85, 6, 'Onkologie', 'T', '', '2019-06-07 10:36:40'),
('N300322214', 30, 2, 'Innere Medizin', 'F', '', '2019-06-07 10:36:40'),
('N374645654', 136, 19, 'Orthopädie', 'T', '', '2019-06-10 15:29:34'),
('O278669394', 80, 6, 'Innere Medizin', 'T', '', '2019-06-07 10:36:40'),
('O337113833', 330, 23, 'Innere Medizin', 'T', '', '2019-06-11 14:49:25'),
('O369230490', 91, 7, 'Onkologie', 'F', '', '2019-06-07 10:36:40'),
('O410118968', 27, 1, 'Innere Medizin', 'F', '', '2019-06-07 10:36:40'),
('O436317821', 326, 21, 'Innere Medizin', 'T', '', '2019-06-11 14:47:51'),
('O475561928', 239, 15, 'Pädiatrie', 'F', '', '2019-06-11 10:04:26'),
('O733812632', 329, 23, 'Innere Medizin', 'F', '', '2019-06-11 14:49:07'),
('O746499283', 142, 22, 'Orthopädie', 'T', '', '2019-06-10 15:33:28'),
('P347318273', 173, 25, 'Orthopädie', 'F', '', '2019-06-11 08:54:30'),
('P373731182', 325, 21, 'Innere Medizin', 'F', '', '2019-06-11 14:47:28'),
('P463354623', 219, 20, 'Onkologie', 'F', '', '2019-06-11 09:56:20'),
('P463551928', 257, 22, 'Pädiatrie', 'T', '', '2019-06-11 10:09:34'),
('P465771118', 281, 19, 'Gynäkologie', 'F', '', '2019-06-11 10:23:08'),
('P837366615', 347, 17, 'Innere Medizin', 'F', '', '2019-06-20 14:40:54'),
('Q227703405', 57, 3, 'Orthopädie', 'T', '', '2019-06-07 10:36:40'),
('Q686841481', 81, 6, 'Onkologie', 'F', '', '2019-06-07 10:36:40'),
('R238973009', 355, 1, 'Orthopädie', 'T', '', '2019-06-20 15:02:11'),
('R273710525', 96, 8, 'Gynäkologie', 'F', '', '2019-06-07 10:36:40'),
('R374888765', 140, 21, 'Orthopädie', 'F', '', '2019-06-10 15:32:13'),
('R437211282', 331, 24, 'Innere Medizin', 'F', '', '2019-06-11 14:49:58'),
('R453361928', 163, 4, 'Pädiatrie', 'F', '', '2019-06-11 08:40:36'),
('R475563913', 174, 25, 'Orthopädie', 'T', '', '2019-06-11 08:55:11'),
('R924539244', 61, 4, 'Gynäkologie', 'F', '', '2019-06-07 10:36:40'),
('S200233733', 284, 20, 'Gynäkologie', 'T', '', '2019-06-11 10:25:21'),
('S273364987', 144, 8, 'Onkologie', 'F', '', '2019-06-11 08:19:27'),
('S283366715', 126, 14, 'Orthopädie', 'F', '', '2019-06-10 15:22:33'),
('S283376253', 125, 12, 'Orthopädie', 'T', '', '2019-06-10 15:21:30'),
('S373221629', 319, 17, 'Innere Medizin', 'T', '', '2019-06-11 14:43:55'),
('S374644192', 246, 18, 'Pädiatrie', 'F', '', '2019-06-11 10:06:29'),
('S473362819', 170, 24, 'Orthopädie', 'F', '', '2019-06-11 08:53:13'),
('S647500098', 285, 21, 'Gynäkologie', 'F', '', '2019-06-11 10:25:24'),
('S647500099', 286, 21, 'Gynäkologie', 'T', '', '2019-06-11 10:25:58'),
('S736444871', 305, 15, 'Gynäkologie', 'T', '', '2019-06-11 11:07:48'),
('S803953398', 75, 6, 'Gynäkologie', 'T', '', '2019-06-07 10:36:40'),
('S845598351', 46, 3, 'Gynäkologie', 'T', '', '2019-06-07 10:36:40'),
('T198887623', 358, 11, 'Innere Medizin', 'F', '', '2019-06-20 15:06:57'),
('T405304674', 38, 2, 'Gynäkologie', 'F', '', '2019-06-07 10:36:40'),
('T408383418', 97, 8, 'Gynäkologie', 'T', '', '2019-06-07 10:36:40'),
('T463374682', 147, 9, 'Onkologie', 'T', '', '2019-06-11 08:21:18'),
('T463423713', 327, 22, 'Innere Medizin', 'F', '', '2019-06-11 14:48:20'),
('T465574638', 207, 16, 'Onkologie', 'T', '', '2019-06-11 09:52:54'),
('T498541053', 66, 5, 'Orthopädie', 'F', '', '2019-06-07 10:36:40'),
('T575888172', 359, 10, 'Gynäkologie', 'F', '', '2019-06-20 15:08:50'),
('U102567296', 73, 6, 'Innere Medizin', 'F', '', '2019-06-07 10:36:40'),
('U474933289', 252, 20, 'Pädiatrie', 'T', '', '2019-06-11 10:08:20'),
('V101010101', 342, 24, 'Innere Medizin', 'T', '', '2019-06-20 14:23:41'),
('V129854545', 141, 22, 'Orthopädie', 'F', '', '2019-06-10 15:32:34'),
('V269371273', 179, 4, 'Pädiatrie', 'T', '', '2019-06-11 09:08:46'),
('V303674775', 82, 3, 'Pädiatrie', 'T', '', '2019-06-07 10:36:40'),
('V934555555', 343, 3, 'Onkologie', 'F', '', '2019-06-20 14:25:14'),
('W098712345', 181, 6, 'Pädiatrie', 'F', '', '2019-06-11 09:09:49'),
('W124293763', 195, 7, 'Pädiatrie', 'F', '', '2019-06-11 09:27:05'),
('W192878343', 322, 19, 'Innere Medizin', 'F', '', '2019-06-11 14:46:05'),
('W345678219', 184, 5, 'Pädiatrie', 'T', '', '2019-06-11 09:13:22'),
('W373811928', 317, 16, 'Innere Medizin', 'T', '', '2019-06-11 14:42:31'),
('W374462719', 155, 13, 'Onkologie', 'T', '', '2019-06-11 08:24:16'),
('W383811192', 313, 15, 'Innere Medizin', 'F', '', '2019-06-11 14:39:38'),
('W471603762', 70, 5, 'Innere Medizin', 'T', '', '2019-06-07 10:36:40'),
('W736440091', 224, 21, 'Onkologie', 'T', '', '2019-06-11 09:57:42'),
('W736664532', 353, 13, 'Orthopädie', 'T', '', '2019-06-20 14:59:49'),
('W738447733', 276, 17, 'Gynäkologie', 'F', '', '2019-06-11 10:20:13'),
('W746650987', 138, 20, 'Orthopädie', 'F', '', '2019-06-10 15:30:28'),
('W837446362', 215, 19, 'Onkologie', 'F', '', '2019-06-11 09:54:58'),
('W962939658', 87, 7, 'Innere Medizin', 'T', '', '2019-06-07 10:36:40'),
('X123654789', 192, 6, 'Pädiatrie', 'T', '', '2019-06-11 09:24:25'),
('X275356840', 39, 2, 'Gynäkologie', 'T', '', '2019-06-07 10:36:40'),
('X473441827', 164, 9, 'Gynäkologie', 'F', '', '2019-06-11 08:41:19'),
('X553703850', 94, 7, 'Gynäkologie', 'F', '', '2019-06-07 10:36:40'),
('Y106009645', 79, 1, 'Pädiatrie', 'T', '', '2019-06-07 10:36:40'),
('Y387900233', 241, 16, 'Pädiatrie', 'F', '', '2019-06-11 10:05:04'),
('Y567953011', 29, 1, 'Innere Medizin', 'T', '', '2019-06-07 10:36:40'),
('Y731282103', 56, 4, 'Orthopädie', 'F', '', '2019-06-07 10:36:40'),
('Z239472346', 275, 16, 'Gynäkologie', 'T', '', '2019-06-11 10:19:49'),
('Z3274637281', 175, 10, 'Orthopädie', 'F', '', '2019-06-11 09:39:05'),
('Z362511726', 249, 20, 'Pädiatrie', 'F', '', '2019-06-11 10:07:26'),
('Z541029313', 221, 12, 'Pädiatrie', 'F', '', '2019-06-11 09:56:42'),
('Z543540514', 76, 6, 'Orthopädie', 'F', '', '2019-06-07 10:36:40'),
('Z733721616', 328, 22, 'Innere Medizin', 'T', '', '2019-06-11 14:48:38'),
('Z861031584', 41, 2, 'Orthopädie', 'T', '', '2019-06-07 10:36:40');

-- --------------------------------------------------------

--
-- Table structure for table `Person`
--

CREATE TABLE `Person` (
  `PersonID` int(11) NOT NULL,
  `Vorname` varchar(40) NOT NULL DEFAULT '',
  `Nachname` varchar(40) NOT NULL DEFAULT '',
  `Adresse` varchar(255) DEFAULT NULL,
  `Geschlecht` varchar(40) DEFAULT NULL,
  `Geburtsdatum` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `Person`
--

INSERT INTO `Person` (`PersonID`, `Vorname`, `Nachname`, `Adresse`, `Geschlecht`, `Geburtsdatum`) VALUES
(108, 'aaron', 'müller', NULL, 'm', '1984-06-09'),
(251, 'Adrian', 'Anemone', NULL, 'm', '2016-06-11'),
(190, 'Adrian', 'Gegg', NULL, 'm', '1999-06-11'),
(323, 'Adrian', 'Meier', NULL, 'm', '1995-06-11'),
(324, 'Adriane', 'Meier', NULL, 'w', '1995-06-11'),
(96, 'Alena', 'Yang', 'Offenburg', 'w', '1958-03-14'),
(59, 'Alexander', 'Rotmann', 'Offenburg', 'm', '1953-03-14'),
(226, 'Alicia', 'Möschle', NULL, 'w', '1999-06-11'),
(19, 'Alina', 'Gans', 'Waldkirch', 'w', '1986-05-15'),
(65, 'Alina', 'Lehmann', 'Emmendingen', 'w', '1940-03-14'),
(62, 'Alisa', 'Reber', 'Offenburg', 'w', '1947-03-14'),
(316, 'Amy', 'Fowler', NULL, 'w', '1986-06-11'),
(154, 'Anastasia', 'Arendt', NULL, 'w', '1981-06-11'),
(284, 'Andrea', 'Metzger', NULL, 'w', '1999-06-01'),
(198, 'Anita', 'Anmeier', NULL, 'w', '1998-06-11'),
(38, 'Anita', 'Lohrmann', 'Offenburg', 'w', '1955-08-23'),
(225, 'Anna', 'Bischoff', NULL, 'w', '1987-06-11'),
(39, 'Anna', 'Lahm', 'Achern', 'w', '1967-10-16'),
(46, 'Anna', 'Michels', 'Freiburg', 'w', '1954-07-13'),
(95, 'Anna', 'Wagner', 'Offenburg', 'w', '1955-03-14'),
(228, 'Anna-Sophie', 'Lang', NULL, 'w', '1999-06-11'),
(134, 'Anne', 'Arent', NULL, 'w', '1985-06-10'),
(267, 'Anne', 'Hiegel', NULL, 'w', '1998-06-11'),
(273, 'Antje', 'Apfel', NULL, 'w', '1998-06-11'),
(272, 'Antje', 'Böhm', NULL, 'w', '1989-10-13'),
(353, 'Anton', 'Wussler', NULL, 'm', '1965-06-20'),
(8, 'Arianna', 'Adari', 'Offenburg', 'w', '1950-09-12'),
(9, 'Arion', 'Cern', 'Freiburg', 'm', '1954-11-30'),
(81, 'Armin', 'Treuer', 'Offenburg', 'm', '2005-03-14'),
(285, 'Arya', 'Stark', NULL, 'w', '1998-06-11'),
(56, 'Athene', 'Protz', 'Offenburg', 'w', '1964-03-14'),
(63, 'Audrey', 'Rupps', 'Waldkirch', 'w', '1958-03-14'),
(76, 'Beatrice', 'Sauer', 'Freiburg', 'w', '2005-03-14'),
(229, 'Benjamin', 'Klinkebiel', NULL, 'w', '1976-06-11'),
(317, 'Bernadette', 'Wolowitz', NULL, 'w', '1989-06-11'),
(159, 'Bernd', 'Braun', NULL, 'm', '1949-06-11'),
(357, 'Berta', 'Balkon', NULL, 'w', '1987-06-20'),
(294, 'Bettina', 'Bucher', NULL, 'w', '1997-06-11'),
(157, 'Bianca', 'Bischler', NULL, 'w', '1948-06-11'),
(230, 'Boffin', 'Bellisima', NULL, 'w', '2016-07-02'),
(85, 'Bojan', 'Ungrau', 'Freiburg', 'm', '1944-03-14'),
(82, 'Brandon', 'Tilsitter', 'Offenburg', 'm', '2009-03-14'),
(10, 'Brigitte', 'Dahlmann', 'Lahr', 'w', '1953-10-29'),
(11, 'Bruno', 'Danner', 'Waldkirch', 'm', '1958-11-15'),
(341, 'Buddy', 'Fisherman', NULL, 'm', '2019-06-20'),
(243, 'Bärbel', 'Beathalter', NULL, 'w', '2018-06-11'),
(152, 'Bärbel', 'Bischler', NULL, 'w', '1955-06-11'),
(35, 'Can', 'Kind', 'Achern', 'm', '1977-03-31'),
(151, 'Carina', 'Kuvik', NULL, 'w', '1997-06-11'),
(173, 'Carissima', 'Pietsch', NULL, 'w', '1995-06-11'),
(288, 'Cersei', 'Lennister', NULL, 'w', '1967-06-11'),
(130, 'Charles', 'Xavier', NULL, 'm', '1938-06-10'),
(307, 'Chiquita', 'Rastätter ', NULL, 'w', '1998-06-11'),
(216, 'Chou', 'You', NULL, 'm', '2007-02-14'),
(146, 'Christian', 'Federer', NULL, 'm', '1993-06-11'),
(58, 'Christofer', 'Postmann', 'Offenburg', 'm', '1961-03-14'),
(57, 'Christoph', 'Portz', 'Emmendingen', 'm', '1963-03-14'),
(98, 'Chuck', 'Norris', NULL, 'w', '2000-06-07'),
(99, 'Chuck2', 'Norris2', NULL, 'w', '2000-06-07'),
(100, 'Chuck3', 'Norris3', NULL, 'w', '2000-06-07'),
(184, 'Clabuster', 'Carolin', NULL, 'm', '2010-12-18'),
(287, 'Claudia', 'Fischer', NULL, 'w', '1973-08-26'),
(266, 'Corinna', 'Leutner', NULL, 'w', '1996-06-11'),
(334, 'Cristina', 'Christophersen', NULL, 'w', '1997-06-11'),
(13, 'Dan', 'Erdmann', 'Freiburg', 'm', '1991-07-11'),
(53, 'Dania', 'Polsko', 'Offenburg', 'w', '1989-03-14'),
(132, 'Daniel', 'Dachs', NULL, 'm', '1997-06-10'),
(300, 'Daniel', 'Dübel', NULL, 'm', '1998-06-11'),
(217, 'Daniel', 'Kälble', NULL, 'm', '1944-06-11'),
(162, 'Daniela', 'Dachs', NULL, 'w', '1947-06-11'),
(280, 'Daniela', 'Gilberer', NULL, 'w', '1999-06-11'),
(54, 'Daria', 'Podolski', 'Freiburg', 'w', '1997-03-14'),
(202, 'Dauerhübsch', 'Desiree', NULL, 'w', '2016-04-15'),
(187, 'David', 'Hain', NULL, 'm', '1993-06-11'),
(207, 'David', 'Teufel', NULL, 'm', '1967-06-11'),
(204, 'Dean', 'Dario', NULL, 'm', '2009-06-05'),
(359, 'Donalda', 'Trump', NULL, 'w', '1966-06-20'),
(44, 'Dora', 'Mann', 'Freiburg', 'w', '1996-08-06'),
(292, 'Doreen', 'Ackermann', NULL, 'w', '1937-04-17'),
(12, 'Doreen', 'Dannecker', 'Offenburg', 'w', '1957-09-19'),
(351, 'Edgar', 'Behringer', NULL, 'w', '2000-06-20'),
(34, 'Efraim', 'Klein', 'Lahr', 'm', '1966-01-29'),
(14, 'Elena', 'Emmenecker', 'Waldkirch', 'w', '1990-07-21'),
(168, 'Enrico', 'Höfler', NULL, 'm', '1997-06-11'),
(143, 'Erich', 'Eckstein', NULL, 'w', '2000-06-10'),
(129, 'Erik', 'Lensherr', NULL, 'm', '1937-06-10'),
(128, 'Erik', 'Range', NULL, 'm', '1979-06-10'),
(270, 'Erika', 'Eckstein', NULL, 'w', '1945-06-11'),
(84, 'Erika', 'Urs', 'Emmendingen', 'w', '2007-03-14'),
(245, 'Esko', 'Pasanen', NULL, 'm', '2012-05-14'),
(260, 'Felix', 'Schmitt', NULL, 'm', '2016-09-21'),
(174, 'Fiona', 'Rumpel', NULL, 'w', '1999-06-11'),
(321, 'Florian', 'Bischler', NULL, 'm', '1998-06-11'),
(80, 'Florian', 'Tummler', 'Freiburg', 'm', '2004-03-14'),
(299, 'Frank', 'Papst', NULL, 'm', '2008-02-17'),
(102, 'Franz', 'Hose', NULL, 'm', '1969-02-28'),
(119, 'Franz', 'Maier', NULL, 'm', '1980-06-10'),
(147, 'Franz', 'Tischler', NULL, 'm', '1985-06-11'),
(263, 'Franziska', 'Fischer', NULL, 'w', '1997-06-11'),
(268, 'Franziska', 'Keller', NULL, 'w', '1980-07-18'),
(250, 'Frida', 'Frettchen', NULL, 'w', '2016-06-11'),
(47, 'Friedrich', 'Schmidt', 'Lahr', 'm', '1964-01-07'),
(352, 'Fritz', 'Maier', NULL, 'm', '1976-06-20'),
(333, 'Gabi', 'Bruder', NULL, 'w', '1997-06-11'),
(346, 'Gerbert', 'Junker', NULL, 'm', '1957-06-03'),
(236, 'Gerda', 'Gruber', NULL, 'w', '2017-06-11'),
(20, 'Gerhard', 'Göppert', 'Freiburg', 'm', '1971-09-23'),
(293, 'Gertrud', 'Huber', NULL, 'w', '1956-06-11'),
(304, 'Gisela', 'Ganter', NULL, 'w', '1976-06-11'),
(161, 'Gundula', 'Grießhaber', NULL, 'w', '1943-06-11'),
(345, 'Gundula', 'Knoblauch', NULL, 'w', '1960-09-10'),
(33, 'Günther', 'Kross', 'Lahr', 'm', '1951-02-08'),
(199, 'Hanf', 'Rudi', NULL, 'm', '2016-12-01'),
(43, 'Hannes', 'Huber', 'Ohlsbach', 'm', '1998-01-02'),
(325, 'Hannes', 'Pfeiffer', NULL, 'm', '1976-06-11'),
(354, 'Hans', 'Felhauer', NULL, 'm', '1973-10-03'),
(349, 'Hans', 'Kanns', NULL, 'w', '2000-06-20'),
(350, 'Hans2', 'Kanns2', NULL, 'w', '2000-06-20'),
(235, 'Harald', 'Huber', NULL, 'm', '1944-06-11'),
(222, 'Hasiba', 'Belkhir', NULL, 'w', '1987-06-11'),
(262, 'Heike', 'Bauer', NULL, 'w', '2014-07-07'),
(290, 'Heike', 'Berg', NULL, 'w', '1935-10-21'),
(107, 'heinz', 'simmens', NULL, 'm', '1984-06-09'),
(335, 'Henrietta', 'Basler', NULL, 'w', '1978-06-12'),
(328, 'Herkules', 'Zeus', NULL, 'm', '1997-06-11'),
(133, 'Holger', 'Hirte', NULL, 'm', '1965-06-10'),
(313, 'Howard', 'Wolowitz', NULL, 'm', '1986-06-11'),
(131, 'Igritte', 'Igel', NULL, 'w', '1999-06-10'),
(41, 'Inge', 'Lachmann', 'Freiburg', 'w', '1983-04-18'),
(348, 'Intensiver', 'Patient', NULL, 'w', '2000-06-20'),
(15, 'Irina', 'Freud', 'Achern', 'w', '1981-06-04'),
(282, 'Irmgard', 'Dorsner', NULL, 'w', '1953-06-11'),
(182, 'Ivan', 'Filatov', NULL, 'm', '1997-06-11'),
(331, 'Ivar', 'Ragnarsson', NULL, 'm', '1945-06-11'),
(308, 'Jakob', 'Huber', NULL, 'm', '1998-06-11'),
(67, 'Jakob', 'Rastätter', 'Waldkirch', 'm', '1934-03-14'),
(342, 'James', 'Gosling', NULL, 'm', '1955-05-19'),
(124, 'Jan', 'Richter', NULL, 'm', '1995-06-10'),
(281, 'Jana', 'Pfeiffer', NULL, 'w', '1976-06-11'),
(232, 'Janes', 'Junker', NULL, 'm', '1996-06-11'),
(31, 'Janette', 'Josephus', 'Freiburg', 'w', '1997-02-28'),
(214, 'Janine', 'Bosca', NULL, 'w', '1999-06-11'),
(301, 'Janine', 'Müller', NULL, 'w', '2019-06-11'),
(319, 'Jasmin', 'Scherer', NULL, 'w', '1986-06-11'),
(318, 'Jennifer', 'Schneider', NULL, 'w', '1998-06-11'),
(261, 'Jessica', 'Biermann', NULL, 'w', '2013-01-09'),
(2, 'Joachim', 'Adam', 'Offenburg', 'm', '1992-04-03'),
(91, 'Johann', 'Wöhner', 'Offenburg', 'm', '1950-03-14'),
(50, 'John', 'Opel', 'Freiburg', 'm', '1953-03-14'),
(295, 'Joschua', 'Häberle', NULL, 'm', '1998-06-11'),
(322, 'Joschua', 'Wussler', NULL, 'm', '1998-06-11'),
(158, 'Josef', 'Junker', NULL, 'w', '1963-06-11'),
(68, 'Josef', 'Sillmann', 'Freiburg', 'm', '1945-03-14'),
(18, 'Joseph', 'Fischer', 'Emmendingen', 'm', '1987-06-17'),
(17, 'Julia', 'Fink', 'Lahr', 'w', '1985-08-05'),
(42, 'Julia', 'Merettig', 'Offenburg', 'w', '1997-05-23'),
(175, 'Julius', 'Zolg', NULL, 'w', '1995-06-11'),
(210, 'Justin', 'Lir', NULL, 'm', '1986-06-11'),
(296, 'Justus', 'Dalmeier', NULL, 'm', '2017-06-11'),
(145, 'Jürgen', 'Großhans', NULL, 'm', '1988-06-11'),
(254, 'Kai', 'Knoblauch', NULL, 'm', '2016-06-11'),
(22, 'Katharina', 'Gabriel', 'Achern', 'w', '1970-11-23'),
(264, 'Katharina', 'Klauser', NULL, 'w', '1956-06-11'),
(275, 'Katrin', 'Weismüller', NULL, 'w', '1970-04-22'),
(1, 'Klaus', 'Arendt', 'Ohlsbach', 'm', '1991-05-03'),
(258, 'Klaus', 'Kohl', NULL, 'm', '2010-06-11'),
(156, 'Klaus', 'Kohler', NULL, 'w', '1952-06-11'),
(139, 'Klaus', 'Köhler', NULL, 'm', '1999-06-10'),
(298, 'Klaus', 'Körtig', NULL, 'm', '2008-08-17'),
(291, 'Klimmantha', 'Klimmzug', NULL, 'w', '1998-06-11'),
(196, 'Kristiane', 'Kohler', NULL, 'w', '1998-06-11'),
(237, 'L\'Tava', 'Quark', NULL, 'w', '2018-02-27'),
(176, 'Lara', 'Freudenreich', NULL, 'w', '1998-06-11'),
(277, 'Lara', 'Lippelt', NULL, 'w', '1988-06-11'),
(28, 'Larissa', 'Inntal', 'Offenburg', 'w', '1949-03-11'),
(90, 'Lars', 'Weber', 'Lahr', 'm', '1949-03-14'),
(25, 'Layla', 'Hefler', 'Waldkirch', 'w', '1942-01-27'),
(64, 'Lea', 'Rupps', 'Offenburg', 'w', '1969-03-14'),
(265, 'Lea', 'Vogt', NULL, 'w', '1965-09-15'),
(122, 'Lena', 'Fritsch', NULL, 'w', '1994-06-10'),
(303, 'Lena', 'Kristmann', NULL, 'w', '1998-06-11'),
(135, 'Lena', 'Lorenz', NULL, 'w', '1977-06-10'),
(240, 'Lena', 'Luft', NULL, 'w', '2015-06-11'),
(49, 'Lena', 'Nugen', 'Lahr', 'w', '1953-02-05'),
(114, 'lena', 'simmens', NULL, 'm', '1996-06-09'),
(27, 'Leonard', 'Haubeil', 'Emmendingen', 'm', '1948-02-09'),
(311, 'Leonard', 'Hofstadter', NULL, 'm', '1987-06-11'),
(137, 'Leopold', 'Lochner', NULL, 'm', '2000-06-10'),
(242, 'Lia', 'Huber', NULL, 'w', '2015-06-11'),
(4, 'Liliane', 'Bauer', 'Freiburg', 'w', '1984-05-05'),
(71, 'Lina', 'Schmitt', 'Lahr', 'w', '1975-03-14'),
(48, 'Lisa', 'Neubert', 'Waldkirch', 'w', '1962-06-13'),
(330, 'Loki', 'Odinsson', NULL, 'm', '1934-06-11'),
(29, 'Ludwig', 'Jäger', 'Waldkirch', 'm', '1951-04-21'),
(5, 'Lukas', 'Brau', 'Offenburg', 'm', '1964-09-06'),
(212, 'Lukas', 'Hugel', NULL, 'm', '1976-06-11'),
(170, 'Lukas', 'Springmann', NULL, 'm', '1967-06-11'),
(215, 'Lukas', 'Wild', NULL, 'm', '1965-06-11'),
(72, 'Luke', 'Schmieder', 'Offenburg', 'm', '2002-03-14'),
(320, 'Manuel', 'Bruder', NULL, 'm', '1986-06-11'),
(123, 'Manuel', 'Fischer', NULL, 'm', '1983-06-10'),
(206, 'Manuel', 'Müller', NULL, 'm', '1956-06-11'),
(160, 'Manuela', 'Meier', NULL, 'w', '1948-06-11'),
(86, 'Marcel', 'Uhl', 'Offenburg', 'm', '1955-03-14'),
(227, 'Mareika', 'Jockers', NULL, 'w', '1967-06-11'),
(276, 'Margot', 'Wussler', NULL, 'w', '1976-06-11'),
(256, 'Maria', 'Frankfurter', NULL, 'w', '2014-10-20'),
(69, 'Maria', 'Schmidt', 'Emmendingen', 'w', '1952-03-14'),
(97, 'Maria', 'Zimmermann', 'Emmendingen', 'w', '1967-03-14'),
(332, 'Marie', 'Huber', NULL, 'w', '1998-06-11'),
(191, 'Marius', 'Bross', NULL, 'm', '1999-06-11'),
(112, 'marius', 'simmens', NULL, 'm', '1996-06-09'),
(144, 'Mark', 'Sieverding', NULL, 'm', '1997-06-11'),
(209, 'Mathis', 'Isenmann', NULL, 'm', '1978-06-11'),
(7, 'Matthias', 'Bruggmoser', 'Waldkirch', 'm', '1959-07-08'),
(177, 'Maus', 'Mini', NULL, 'w', '2013-05-22'),
(195, 'McGonagall', 'Minerva ', NULL, 'w', '2009-06-11'),
(208, 'Meadows', 'Tammie', NULL, 'w', '2011-03-10'),
(148, 'Michael', 'Arent', NULL, 'm', '1999-06-11'),
(149, 'Michaela', 'Loffl', NULL, 'w', '1991-06-11'),
(269, 'Michelle', 'Böttcher', NULL, 'w', '1967-06-11'),
(117, 'Mike', 'Bauer', NULL, 'm', '1988-06-10'),
(32, 'Mirco', 'Kammerdiener', 'Offenburg', 'm', '1999-09-26'),
(231, 'Mona', 'Köhl', NULL, 'w', '1999-06-11'),
(189, 'Monika', 'Schillig', NULL, 'w', '1999-06-11'),
(297, 'Moritz', 'Maier', NULL, 'm', '2017-06-11'),
(194, 'Moritz', 'Vergin', NULL, 'm', '1987-06-11'),
(181, 'Munter', 'Manfred', NULL, 'm', '2014-12-01'),
(192, 'Muser', 'Mike', NULL, 'm', '2009-06-11'),
(200, 'Mutig', 'Mirella', NULL, 'm', '2009-12-01'),
(110, 'natalie', 'simmens', NULL, 'w', '1996-06-09'),
(167, 'Nic', 'Fruttiger', NULL, 'm', '1997-06-11'),
(205, 'Niclas', 'Klauser', NULL, 'm', '1947-06-11'),
(211, 'Niklas', 'Gohr', NULL, 'm', '1998-06-11'),
(120, 'Niklas', 'Klauser', NULL, 'm', '1955-06-10'),
(83, 'Niklas', 'Ullmann', 'Offenburg', 'm', '2008-03-14'),
(136, 'Nils', 'Nielssen', NULL, 'w', '2000-06-10'),
(213, 'Ohara', 'Anthony', NULL, 'm', '2007-03-22'),
(179, 'Oktober', 'Otto', NULL, 'm', '2017-10-05'),
(24, 'Oleg', 'Hofer', 'Offenburg', 'm', '1973-06-01'),
(326, 'Oleg', 'Ortlieb', NULL, 'm', '1997-06-11'),
(239, 'Olga', 'Ober', NULL, 'w', '2016-06-11'),
(142, 'Olivia', 'Orgel', NULL, 'w', '1983-06-10'),
(74, 'Olivia', 'Stiefel', 'Emmendingen', 'w', '2000-03-14'),
(221, 'Pan', 'Donglu', NULL, 'w', '2012-10-07'),
(30, 'Patricia', 'Jobel', 'Schutterwald', 'w', '1968-09-22'),
(248, 'Patrick', 'Schuster', NULL, 'm', '2018-12-18'),
(356, 'Paul', 'Gratenhauer', NULL, 'm', '1980-04-04'),
(347, 'Paula', 'Pink', NULL, 'w', '1987-06-20'),
(315, 'Penny', 'Hofstadter', NULL, 'w', '1990-06-11'),
(257, 'Phil', 'Pfeffer', NULL, 'm', '2016-06-11'),
(21, 'Philipp', 'Groß', 'Emmendingen', 'm', '1972-07-24'),
(234, 'Pimpernel', 'Bolger-Baggins', NULL, 'w', '2011-11-01'),
(193, 'Ragda', 'Kheder', NULL, 'w', '1999-06-11'),
(314, 'Rajesh', 'Koothrappali', NULL, 'm', '1990-06-11'),
(252, 'Ralf', 'Kappel', NULL, 'm', '2018-01-29'),
(247, 'Ralf', 'Radieschen', NULL, 'm', '2016-06-11'),
(126, 'Ralf', 'Sauer', NULL, 'm', '1968-06-10'),
(66, 'Raphael', 'Rotweiler', 'Offenburg', 'm', '1936-03-14'),
(60, 'Raphaela', 'Ragen', 'Offenburg', 'w', '1945-03-14'),
(125, 'Rebecca', 'Sommerfeld', NULL, 'w', '1995-06-10'),
(344, 'received', 'message', NULL, 'w', '1998-06-20'),
(52, 'Richard', 'Ober', 'Freiburg', 'm', '1978-03-14'),
(26, 'Rico', 'Hemmer', 'Lahr', 'm', '1935-01-08'),
(140, 'Roderik', 'Radler', NULL, 'm', '1945-06-10'),
(163, 'Roland', 'Remmerich', NULL, 'm', '2015-06-11'),
(127, 'Roman', 'Gerber', NULL, 'm', '1994-06-10'),
(89, 'Rosalie', 'Vadung', 'Offenburg', 'w', '1958-03-14'),
(253, 'Rosmarie', 'Rose', NULL, 'w', '2016-06-11'),
(233, 'Roswita', 'Rastätter', NULL, 'w', '1956-06-11'),
(169, 'Ruben', 'Kimmig', NULL, 'm', '1997-06-11'),
(106, 'rüdiger', 'fritsch', NULL, 'm', '1984-06-09'),
(94, 'Sabrina', 'Wagner', 'Offenburg', 'w', '1946-03-14'),
(6, 'Samuel', 'Burg', 'Waldkirch', 'm', '1962-08-07'),
(171, 'Sancha', 'Heid', NULL, 'w', '1967-06-11'),
(219, 'Sanja', 'Petrovic', NULL, 'w', '1994-06-11'),
(286, 'Sansa', 'Stark', NULL, 'w', '1998-06-11'),
(279, 'Sara', 'Ackermann', NULL, 'w', '2950-12-11'),
(259, 'Sarah', 'Friedmann', NULL, 'w', '2013-12-09'),
(45, 'Sarah', 'Mogler', 'Freiburg', 'w', '1974-08-09'),
(78, 'Savanna', 'Turm', 'Lahr', 'w', '2010-03-14'),
(278, 'Sebastian', 'Büttinger', NULL, 'w', '1967-06-11'),
(23, 'Selina', 'Dabanli', 'Emmendingen', 'w', '1964-12-25'),
(336, 'Serena', 'Lohfink', NULL, 'w', '1998-06-12'),
(312, 'Sheldon', 'Cooper', NULL, 'm', '1985-06-11'),
(16, 'Siena', 'Fuhrmann', 'Freiburg', 'w', '1984-07-06'),
(121, 'Simon', 'Leiermann', NULL, 'm', '1999-06-10'),
(309, 'Simon', 'Rudolf', NULL, 'm', '1998-06-11'),
(178, 'Simon', 'Rufolf', NULL, 'm', '1997-06-11'),
(73, 'Simon', 'Schmuggler', 'Freiburg', 'm', '2003-03-14'),
(36, 'Simona', 'Kunkel', 'Freiburg', 'w', '1988-05-21'),
(150, 'Simone', 'Adler', NULL, 'w', '1977-06-11'),
(310, 'Simone', 'Maier', NULL, 'w', '1987-06-11'),
(246, 'Simone', 'Schnittlauch', NULL, 'w', '2016-06-11'),
(271, 'Sonia', 'Eriksen', NULL, 'w', '1976-06-11'),
(289, 'Sophia', 'Freeh', NULL, 'w', '1944-05-22'),
(51, 'Sophie', 'Oragne', 'Offenburg', 'w', '1962-03-14'),
(172, 'Srah', 'Basler', NULL, 'w', '1995-06-11'),
(93, 'Stefanie', 'Waber', 'Lahr', 'w', '1945-03-14'),
(79, 'Stella', 'Trost', 'Lahr', 'w', '2012-03-14'),
(92, 'Stephan', 'Wegner', 'Freiburg', 'm', '1939-03-14'),
(165, 'Sven', 'Schulte', NULL, 'w', '1946-06-11'),
(274, 'Svenja', 'Luchner', NULL, 'w', '1976-06-11'),
(118, 'Sybille', 'Kohler', NULL, 'w', '1996-06-10'),
(305, 'Sybille', 'Schuster', NULL, 'w', '1976-06-11'),
(75, 'Tabea', 'Singer', 'Waldkirch', 'w', '2000-03-14'),
(224, 'Tanya', 'Worrell', NULL, 'w', '1956-06-11'),
(61, 'Tatjana', 'Roggen', 'Lahr', 'w', '1946-03-14'),
(220, 'Teresa', 'Link', NULL, 'w', '1956-06-11'),
(340, 'Testus', 'Testerix', NULL, 'w', '2000-06-20'),
(337, 'Testus1', 'Tester1', NULL, 'w', '2000-06-20'),
(338, 'Testus2', 'Tester2', NULL, 'w', '2000-06-20'),
(339, 'Testus3', 'Tester3', NULL, 'w', '2000-06-20'),
(40, 'Theodora', 'Leber', 'Emmendingen', 'w', '1962-12-17'),
(3, 'Thomas', 'Adolf', 'Freiburg', 'm', '1997-02-04'),
(358, 'Thomas', 'Tischler', NULL, 'm', '1998-06-20'),
(329, 'Thor', 'Odinsson', NULL, 'm', '1934-06-11'),
(355, 'Thorsten', 'Tannenbaum', NULL, 'm', '1956-06-20'),
(203, 'Tieffrost', 'Elsa', NULL, 'w', '2008-07-04'),
(37, 'Tim', 'Lehmann', 'Schutterwald', 'm', '1999-07-29'),
(180, 'Tim', 'Schnepf', NULL, 'm', '1997-06-11'),
(87, 'Timo', 'Uhrmacher', 'Offenburg', 'm', '1956-03-14'),
(88, 'Tino', 'Vallis', 'Offenburg', 'm', '1967-03-14'),
(77, 'Tobias', 'Sauter', 'Lahr', 'm', '2006-03-14'),
(327, 'Tobias', 'Tarantel', NULL, 'm', '1997-06-11'),
(70, 'Tom', 'Schmidt', 'Offenburg', 'm', '1964-03-14'),
(223, 'Tsou', 'Lixue', NULL, 'w', '2013-07-17'),
(241, 'Tuomas', 'Rannikko', NULL, 'm', '2013-10-07'),
(255, 'Vanessa', 'Vanille', NULL, 'w', '2016-06-11'),
(153, 'Vanessa', 'Vogel', NULL, 'w', '1997-06-11'),
(141, 'Vanessa', 'Völkl', NULL, 'w', '1945-06-10'),
(201, 'Vierrad', 'Ulrich', NULL, 'm', '2011-11-15'),
(183, 'Violetta', 'Filatov', NULL, 'w', '2000-06-11'),
(343, 'Winni', 'Chocolatier', NULL, 'm', '1920-07-23'),
(155, 'Wolfgang', 'Weigert', NULL, 'w', '1954-06-11'),
(138, 'Wolfgang', 'Wächter', NULL, 'm', '1969-06-10'),
(164, 'Xena', 'Xeraphim', NULL, 'w', '1946-06-11'),
(283, 'Ygritte', 'Asbach', NULL, 'w', '1987-06-11'),
(360, 'You', 'Chou', NULL, 'w', '1988-06-20'),
(166, 'Zachariah', 'Zähringer', NULL, 'm', '1946-06-11'),
(249, 'Zara', 'Zwiebel', NULL, 'm', '2016-06-11'),
(55, 'Zoe', 'Popolus', 'Lahr', 'w', '1955-03-14');

-- --------------------------------------------------------

--
-- Table structure for table `Station`
--

CREATE TABLE `Station` (
  `Bezeichnung` varchar(40) NOT NULL DEFAULT ''
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `Station`
--

INSERT INTO `Station` (`Bezeichnung`) VALUES
('Gynäkologie'),
('Innere Medizin'),
('Intensivstation'),
('Onkologie'),
('Orthopädie'),
('Pädiatrie');

-- --------------------------------------------------------

--
-- Table structure for table `TransferListe`
--

CREATE TABLE `TransferListe` (
  `PersonID` int(11) NOT NULL DEFAULT '0',
  `Von` varchar(10) NOT NULL DEFAULT '',
  `Nach` varchar(10) NOT NULL DEFAULT '',
  `Stempel` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `Users`
--

CREATE TABLE `Users` (
  `Benutzername` varchar(40) NOT NULL,
  `PersonID` int(11) DEFAULT NULL,
  `Rechte` varchar(40) DEFAULT NULL,
  `Passwort` varchar(40) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `Users`
--

INSERT INTO `Users` (`Benutzername`, `PersonID`, `Rechte`, `Passwort`) VALUES
('Archangel', 22, 'Standard', 'DadIsGod'),
('AxesUnite', 27, 'Standard', 'ChopTheTrees'),
('BadGirl26', 28, 'Standard', 'IWreckYou'),
('BierLover66', 5, 'Standard', 'Urquell'),
('BlackDragon', 11, 'Standard', 'DannerSwag'),
('Buma11', 43, 'Standard', '123456'),
('BunnyFreak', 25, 'Standard', 'Playboymaster'),
('Federkleid', 19, 'Standard', 'Schnabel21'),
('ForeverAfd', 3, 'Standard', 'kriegisbest'),
('FreiburgBest', 30, 'Standard', 'StuttgartWorst'),
('GrowThatShit', 20, 'Standard', '420'),
('GunsAreLife', 29, 'Standard', 'Intervention'),
('Hottie47', 23, 'Standard', 'LoveMe'),
('JavaHater', 18, 'Standard', 'CMasterrace'),
('Jesus2873', 31, 'Standard', 'BowBeforeHim'),
('Kittielover', 10, 'Standard', 'Nicenstein'),
('Klausimausi', 1, 'Standard', 'bestespw'),
('Lancelot', 6, 'Standard', 'Arthurftw'),
('LandlebenFTW', 4, 'Standard', 'Traktor6'),
('Leichtathletikfreak', 14, 'Standard', 'Hürdenmaster'),
('Maulwurf72', 13, 'Standard', 'DerWühler'),
('NailsBow', 26, 'Standard', 'IPunch'),
('PastaFetisch', 16, 'Standard', 'PizzaLove'),
('PingPongShowMaster', 8, 'Standard', 'Atariftw'),
('Psychomaster', 15, 'Standard', 'PenisNeid'),
('RefrendaryLive', 12, 'Standard', 'badGrades'),
('Schokokeks', 42, 'Standard', 'schokolade'),
('TeilchenMaster', 9, 'Standard', 'LHCisthebest'),
('TheBeast', 7, 'Standard', 'sicherespw'),
('TheLegend27', 2, 'Standard', 'TheLegend27'),
('TheSlave', 32, 'Standard', 'Shackles'),
('ThormundGiantsbane', 21, 'Standard', 'MilkIsLove'),
('Viking1', 24, 'Standard', 'OdinIsBest'),
('Vogelbaby', 17, 'Standard', 'Eierleger'),
('Zett94', 47, 'Standard', 'keineahnung');

-- --------------------------------------------------------

--
-- Table structure for table `Zimmer`
--

CREATE TABLE `Zimmer` (
  `ZimmerNr` int(11) NOT NULL DEFAULT '0',
  `StationsBezeichnung` varchar(40) NOT NULL DEFAULT ''
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `Zimmer`
--

INSERT INTO `Zimmer` (`ZimmerNr`, `StationsBezeichnung`) VALUES
(1, 'Gynäkologie'),
(2, 'Gynäkologie'),
(3, 'Gynäkologie'),
(4, 'Gynäkologie'),
(5, 'Gynäkologie'),
(6, 'Gynäkologie'),
(7, 'Gynäkologie'),
(8, 'Gynäkologie'),
(9, 'Gynäkologie'),
(10, 'Gynäkologie'),
(11, 'Gynäkologie'),
(12, 'Gynäkologie'),
(13, 'Gynäkologie'),
(14, 'Gynäkologie'),
(15, 'Gynäkologie'),
(16, 'Gynäkologie'),
(17, 'Gynäkologie'),
(18, 'Gynäkologie'),
(19, 'Gynäkologie'),
(20, 'Gynäkologie'),
(21, 'Gynäkologie'),
(22, 'Gynäkologie'),
(23, 'Gynäkologie'),
(24, 'Gynäkologie'),
(25, 'Gynäkologie'),
(1, 'Innere Medizin'),
(2, 'Innere Medizin'),
(3, 'Innere Medizin'),
(4, 'Innere Medizin'),
(5, 'Innere Medizin'),
(6, 'Innere Medizin'),
(7, 'Innere Medizin'),
(8, 'Innere Medizin'),
(9, 'Innere Medizin'),
(10, 'Innere Medizin'),
(11, 'Innere Medizin'),
(12, 'Innere Medizin'),
(13, 'Innere Medizin'),
(14, 'Innere Medizin'),
(15, 'Innere Medizin'),
(16, 'Innere Medizin'),
(17, 'Innere Medizin'),
(18, 'Innere Medizin'),
(19, 'Innere Medizin'),
(20, 'Innere Medizin'),
(21, 'Innere Medizin'),
(22, 'Innere Medizin'),
(23, 'Innere Medizin'),
(24, 'Innere Medizin'),
(25, 'Innere Medizin'),
(1, 'Intensivstation'),
(2, 'Intensivstation'),
(3, 'Intensivstation'),
(4, 'Intensivstation'),
(5, 'Intensivstation'),
(6, 'Intensivstation'),
(7, 'Intensivstation'),
(8, 'Intensivstation'),
(9, 'Intensivstation'),
(10, 'Intensivstation'),
(1, 'Onkologie'),
(2, 'Onkologie'),
(3, 'Onkologie'),
(4, 'Onkologie'),
(5, 'Onkologie'),
(6, 'Onkologie'),
(7, 'Onkologie'),
(8, 'Onkologie'),
(9, 'Onkologie'),
(10, 'Onkologie'),
(11, 'Onkologie'),
(12, 'Onkologie'),
(13, 'Onkologie'),
(14, 'Onkologie'),
(15, 'Onkologie'),
(16, 'Onkologie'),
(17, 'Onkologie'),
(18, 'Onkologie'),
(19, 'Onkologie'),
(20, 'Onkologie'),
(21, 'Onkologie'),
(22, 'Onkologie'),
(23, 'Onkologie'),
(24, 'Onkologie'),
(25, 'Onkologie'),
(1, 'Orthopädie'),
(2, 'Orthopädie'),
(3, 'Orthopädie'),
(4, 'Orthopädie'),
(5, 'Orthopädie'),
(6, 'Orthopädie'),
(7, 'Orthopädie'),
(8, 'Orthopädie'),
(9, 'Orthopädie'),
(10, 'Orthopädie'),
(11, 'Orthopädie'),
(12, 'Orthopädie'),
(13, 'Orthopädie'),
(14, 'Orthopädie'),
(15, 'Orthopädie'),
(16, 'Orthopädie'),
(17, 'Orthopädie'),
(18, 'Orthopädie'),
(19, 'Orthopädie'),
(20, 'Orthopädie'),
(21, 'Orthopädie'),
(22, 'Orthopädie'),
(23, 'Orthopädie'),
(24, 'Orthopädie'),
(25, 'Orthopädie'),
(1, 'Pädiatrie'),
(2, 'Pädiatrie'),
(3, 'Pädiatrie'),
(4, 'Pädiatrie'),
(5, 'Pädiatrie'),
(6, 'Pädiatrie'),
(7, 'Pädiatrie'),
(8, 'Pädiatrie'),
(9, 'Pädiatrie'),
(10, 'Pädiatrie'),
(11, 'Pädiatrie'),
(12, 'Pädiatrie'),
(13, 'Pädiatrie'),
(14, 'Pädiatrie'),
(15, 'Pädiatrie'),
(16, 'Pädiatrie'),
(17, 'Pädiatrie'),
(18, 'Pädiatrie'),
(19, 'Pädiatrie'),
(20, 'Pädiatrie'),
(21, 'Pädiatrie'),
(22, 'Pädiatrie'),
(23, 'Pädiatrie'),
(24, 'Pädiatrie'),
(25, 'Pädiatrie');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `Patient`
--
ALTER TABLE `Patient`
  ADD PRIMARY KEY (`VersicherungsNr`),
  ADD UNIQUE KEY `VersicherungsNr` (`VersicherungsNr`),
  ADD KEY `PersonID` (`PersonID`),
  ADD KEY `ZimmerNr` (`ZimmerNr`),
  ADD KEY `StationsBezeichnung` (`StationsBezeichnung`);

--
-- Indexes for table `Person`
--
ALTER TABLE `Person`
  ADD PRIMARY KEY (`Vorname`,`Nachname`),
  ADD UNIQUE KEY `PersonID` (`PersonID`);

--
-- Indexes for table `Station`
--
ALTER TABLE `Station`
  ADD PRIMARY KEY (`Bezeichnung`);

--
-- Indexes for table `TransferListe`
--
ALTER TABLE `TransferListe`
  ADD PRIMARY KEY (`PersonID`,`Von`,`Nach`);

--
-- Indexes for table `Users`
--
ALTER TABLE `Users`
  ADD PRIMARY KEY (`Benutzername`),
  ADD KEY `PersonID` (`PersonID`);

--
-- Indexes for table `Zimmer`
--
ALTER TABLE `Zimmer`
  ADD PRIMARY KEY (`ZimmerNr`,`StationsBezeichnung`),
  ADD KEY `StationsBezeichnung` (`StationsBezeichnung`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `Person`
--
ALTER TABLE `Person`
  MODIFY `PersonID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=361;
--
-- Constraints for dumped tables
--

--
-- Constraints for table `Patient`
--
ALTER TABLE `Patient`
  ADD CONSTRAINT `Patient_ibfk_1` FOREIGN KEY (`PersonID`) REFERENCES `Person` (`PersonID`) ON DELETE CASCADE,
  ADD CONSTRAINT `Patient_ibfk_2` FOREIGN KEY (`ZimmerNr`) REFERENCES `Zimmer` (`ZimmerNr`) ON DELETE SET NULL,
  ADD CONSTRAINT `Patient_ibfk_3` FOREIGN KEY (`StationsBezeichnung`) REFERENCES `Station` (`Bezeichnung`) ON DELETE SET NULL;

--
-- Constraints for table `TransferListe`
--
ALTER TABLE `TransferListe`
  ADD CONSTRAINT `TransferListe_ibfk_1` FOREIGN KEY (`PersonID`) REFERENCES `Patient` (`PersonID`) ON DELETE CASCADE;

--
-- Constraints for table `Users`
--
ALTER TABLE `Users`
  ADD CONSTRAINT `Users_ibfk_1` FOREIGN KEY (`PersonID`) REFERENCES `Person` (`PersonID`) ON DELETE CASCADE;

--
-- Constraints for table `Zimmer`
--
ALTER TABLE `Zimmer`
  ADD CONSTRAINT `Zimmer_ibfk_1` FOREIGN KEY (`StationsBezeichnung`) REFERENCES `Station` (`Bezeichnung`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
