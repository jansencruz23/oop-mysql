-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 06, 2023 at 05:51 PM
-- Server version: 10.4.22-MariaDB
-- PHP Version: 8.1.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dbsis`
--

-- --------------------------------------------------------

--
-- Table structure for table `students`
--

CREATE TABLE `students` (
  `StudentId` int(20) NOT NULL,
  `FirstName` varchar(50) NOT NULL,
  `MiddleInitial` varchar(10) NOT NULL,
  `LastName` varchar(50) NOT NULL,
  `Course` varchar(100) NOT NULL,
  `YearLevel` int(10) NOT NULL,
  `Picture` mediumtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `students`
--

INSERT INTO `students` (`StudentId`, `FirstName`, `MiddleInitial`, `LastName`, `Course`, `YearLevel`, `Picture`) VALUES
(1, 'Jansen', 'C', 'Cruz', 'BSCS', 2, ''),
(101, 'zzz', 'zzz', 'zzz', 'bscs', 1, ''),
(102, 'Name', 'MI', 'LN', 'Course', 2, ''),
(103, 'Lebron', 'J', 'James', 'Lakers', 21, ''),
(104, '1', '1', '1', '1', 1, 'D:\\Users\\user\\Downloads\\315197296_664265021964709_6448645728878737009_n.jpg'),
(105, 'x', 'x', 'x', 'x', 0, 'D:\\Users\\user\\Downloads\\Green Yellow Minimalist Event Magazine (12).png');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `students`
--
ALTER TABLE `students`
  ADD PRIMARY KEY (`StudentId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `students`
--
ALTER TABLE `students`
  MODIFY `StudentId` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=106;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
