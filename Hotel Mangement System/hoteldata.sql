-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Aug 22, 2022 at 05:56 PM
-- Server version: 10.4.24-MariaDB
-- PHP Version: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `hoteldata`
--

-- --------------------------------------------------------

--
-- Table structure for table `books`
--

CREATE TABLE `books` (
  `id` int(100) NOT NULL,
  `Booked_Room_ID` varchar(255) NOT NULL,
  `Booked_Client_ID` varchar(255) NOT NULL,
  `Booked_Price` int(100) NOT NULL,
  `Booked_Date` varchar(100) NOT NULL,
  `Booked_Departure_Date` varchar(100) NOT NULL,
  `No_Of_Rooms` int(11) NOT NULL,
  `No_Of_Children` int(11) NOT NULL,
  `No_Of_Adults` int(11) NOT NULL,
  `Breakfast` varchar(10) DEFAULT NULL,
  `Lunch` varchar(10) DEFAULT NULL,
  `Dinner` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `books`
--

INSERT INTO `books` (`id`, `Booked_Room_ID`, `Booked_Client_ID`, `Booked_Price`, `Booked_Date`, `Booked_Departure_Date`, `No_Of_Rooms`, `No_Of_Children`, `No_Of_Adults`, `Breakfast`, `Lunch`, `Dinner`) VALUES
(10, 'SA001', '123456789', 6000, '2022-00-22', '2022-00-25', 1, 0, 1, 'Breakfast', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `customer`
--

CREATE TABLE `customer` (
  `id` int(100) NOT NULL,
  `Customer_Name` varchar(255) NOT NULL,
  `Customer_Address` varchar(255) NOT NULL,
  `Customer_Tel` varchar(20) NOT NULL,
  `Customer_NIC` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `customer`
--

INSERT INTO `customer` (`id`, `Customer_Name`, `Customer_Address`, `Customer_Tel`, `Customer_NIC`) VALUES
(1, 'DilumSadeepa', 'test address, test', '6783497821', '123456789'),
(2, 'waruna disanayaka', 'nikaweratiya', '0769610260', '991620842V');

-- --------------------------------------------------------

--
-- Table structure for table `property`
--

CREATE TABLE `property` (
  `id` int(11) NOT NULL,
  `itemName` varchar(255) NOT NULL,
  `itemCategory` varchar(255) NOT NULL,
  `itemNo` int(11) NOT NULL,
  `itemPrice` float(10,2) NOT NULL,
  `addDate` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `room`
--

CREATE TABLE `room` (
  `id` int(100) NOT NULL,
  `Room_Name` varchar(255) NOT NULL,
  `Room_ID` varchar(50) NOT NULL,
  `Room_Type` varchar(50) NOT NULL,
  `Room_Price` int(20) NOT NULL,
  `Room_Description` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `room`
--

INSERT INTO `room` (`id`, `Room_Name`, `Room_ID`, `Room_Type`, `Room_Price`, `Room_Description`) VALUES
(2, 'Single room', 'SA001', 'Single Room A/C', 2000, 'This is single ac room'),
(3, 'Double room', 'DA001', 'Double Room None A/C', 2000, 'Double room non A/C');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `books`
--
ALTER TABLE `books`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `customer`
--
ALTER TABLE `customer`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `property`
--
ALTER TABLE `property`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `room`
--
ALTER TABLE `room`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `books`
--
ALTER TABLE `books`
  MODIFY `id` int(100) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `customer`
--
ALTER TABLE `customer`
  MODIFY `id` int(100) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `property`
--
ALTER TABLE `property`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `room`
--
ALTER TABLE `room`
  MODIFY `id` int(100) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
