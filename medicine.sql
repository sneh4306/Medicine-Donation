-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 13, 2019 at 11:04 PM
-- Server version: 10.4.8-MariaDB
-- PHP Version: 7.2.24

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `medicine`
--

-- --------------------------------------------------------

--
-- Table structure for table `medicine_donate`
--

CREATE TABLE `medicine_donate` (
  `Mid` int(10) NOT NULL,
  `Mtype` varchar(50) NOT NULL,
  `Mname` varchar(50) NOT NULL,
  `Count` int(7) NOT NULL,
  `Expiry_month` varchar(10) NOT NULL,
  `Expiry_year` varchar(4) NOT NULL,
  `Uid` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `medicine_donate`
--

INSERT INTO `medicine_donate` (`Mid`, `Mtype`, `Mname`, `Count`, `Expiry_month`, `Expiry_year`, `Uid`) VALUES
(3, 'Analgesics', 'codeine', 5, '06', '2021', 4),
(63, 'Antipyretic', 'Paracetamol', 2, '06', '2020', 4);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `Id` int(10) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `Contact` bigint(10) NOT NULL,
  `Email` varchar(50) NOT NULL,
  `Pass` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`Id`, `Name`, `Contact`, `Email`, `Pass`) VALUES
(4, 'Sneh', 9999999999, 'haha@g.com', 'lM68YvC9WFcY+QyLlQiNbKUIWSmbB+FcUUIsGJLsXnM='),
(11, 'Neelay', 1234567890, 'n@g.com', '4VE0+57srmeF8vrEGFMGXpjtUtqBOo0rw2O+HAD994c='),
(28, 'Sneh', 9999999999, 'hihi@g.com', 'lM68YvC9WFcY+QyLlQiNbKUIWSmbB+FcUUIsGJLsXnM='),
(46, 'Admin', 9999999999, 'admin@gmail.com', 'IrfexzBdY+LHabDJFBEU5poZTMhTtETHO3vjoHcbYoo='),
(95, 'Grusha', 1234567890, 'hohoh@g.com', 'rjCx+BN/Kxe9IAd7BryIeduAqQxhbNUFivkaqDvo+IY=');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `medicine_donate`
--
ALTER TABLE `medicine_donate`
  ADD PRIMARY KEY (`Mid`),
  ADD KEY `Uid` (`Uid`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`Id`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `medicine_donate`
--
ALTER TABLE `medicine_donate`
  ADD CONSTRAINT `medicine_donate_ibfk_1` FOREIGN KEY (`Uid`) REFERENCES `users` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
