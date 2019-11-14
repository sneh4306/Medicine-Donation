-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 14, 2019 at 06:06 PM
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
  `Uid` int(10) NOT NULL,
  `Approved` varchar(5) NOT NULL,
  `Checked` varchar(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `medicine_donate`
--

INSERT INTO `medicine_donate` (`Mid`, `Mtype`, `Mname`, `Count`, `Expiry_month`, `Expiry_year`, `Uid`, `Approved`, `Checked`) VALUES
(3, 'Analgesics', 'codeine', 5, '06', '2021', 4, 'Yes', 'Yes'),
(13, 'Antipyretic', 'Iodophors', 1, '10', '2020', 95, 'No', 'No'),
(24, 'Analgesics', 'fentanyl ', 2, '08', '2020', 57, 'No', 'No'),
(48, 'Antiseptics', 'Hexachlorophene', 6, '06', '2021', 95, 'Yes', 'Yes'),
(63, 'Antipyretic', 'Paracetamol', 2, '06', '2020', 4, 'Yes', 'Yes'),
(238, 'Analgesics', 'fentanyl ', 1, '06', '2020', 296, 'Yes', 'Yes'),
(632, 'Antibiotics', 'metronidazole', 6, '03', '2020', 4, 'Yes', 'Yes'),
(865, 'Analgesics', 'morphine ', 1, '07', '2020', 57, 'Yes', 'Yes');

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
(57, 'Dhruvin', 9999999999, 'd@g.com', '9mYYCuAobG8Gm9zwk6MRd6rWl+LrS6ZOWu9lZu/fvdg='),
(95, 'Grusha', 1234567890, 'hohoh@g.com', 'rjCx+BN/Kxe9IAd7BryIeduAqQxhbNUFivkaqDvo+IY='),
(296, 'Sneh Chitalia', 1234567890, 'sneh@g.com', 'lM68YvC9WFcY+QyLlQiNbKUIWSmbB+FcUUIsGJLsXnM='),
(708, 'Shiv', 9999999999, 'shiv@g.com', 'MtD4RtIGcGyukWGzKwVWkhpPNU+bJtwXrIwm/xbKUeY=');

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
