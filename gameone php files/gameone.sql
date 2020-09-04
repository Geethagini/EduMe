-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 04, 2020 at 06:37 PM
-- Server version: 10.1.28-MariaDB
-- PHP Version: 7.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `gameone`
--

-- --------------------------------------------------------

--
-- Table structure for table `hints`
--

CREATE TABLE `hints` (
  `hint_id` int(11) NOT NULL,
  `hint_desc` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `levels`
--

CREATE TABLE `levels` (
  `level_id` int(11) NOT NULL,
  `level_name` varchar(15) NOT NULL,
  `level_desc` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `login`
--

CREATE TABLE `login` (
  `login_id` int(11) NOT NULL,
  `player_id` int(11) NOT NULL,
  `username` varchar(15) NOT NULL,
  `hash` varchar(100) NOT NULL,
  `salt` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `login`
--

INSERT INTO `login` (`login_id`, `player_id`, `username`, `hash`, `salt`) VALUES
(40, 28, 'hasini', '$5$rounds=5000$steamedhamshasin$kqFBd3V//OADw/Gw58zzhh0R4xotjGmzGJCw15RLhc3', '$5$rounds=5000$steamedhamshasini$'),
(47, 31, 'hasara', '$5$rounds=5000$steamedhamshasar$oKJhn1iwzevCIteTQU9NGJGDiIHXr13YMZteC2i6wuB', '$5$rounds=5000$steamedhamshasara$');

-- --------------------------------------------------------

--
-- Table structure for table `players`
--

CREATE TABLE `players` (
  `id` int(10) NOT NULL,
  `username` varchar(15) NOT NULL,
  `age` int(11) DEFAULT NULL,
  `hash` varchar(100) NOT NULL,
  `salt` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `players`
--

INSERT INTO `players` (`id`, `username`, `age`, `hash`, `salt`) VALUES
(28, 'hasini', 13, '$5$rounds=5000$steamedhamshasin$kqFBd3V//OADw/Gw58zzhh0R4xotjGmzGJCw15RLhc3', '$5$rounds=5000$steamedhamshasini$'),
(31, 'hasara', 12, '$5$rounds=5000$steamedhamshasar$oKJhn1iwzevCIteTQU9NGJGDiIHXr13YMZteC2i6wuB', '$5$rounds=5000$steamedhamshasara$');

-- --------------------------------------------------------

--
-- Table structure for table `questions`
--

CREATE TABLE `questions` (
  `question_id` int(11) NOT NULL,
  `question_desc` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `score_board`
--

CREATE TABLE `score_board` (
  `score_id` int(11) NOT NULL,
  `player_id` int(11) NOT NULL,
  `score` int(100) NOT NULL,
  `coins` int(100) NOT NULL,
  `x` int(100) NOT NULL,
  `y` int(100) NOT NULL,
  `z` int(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `score_board`
--

INSERT INTO `score_board` (`score_id`, `player_id`, `score`, `coins`, `x`, `y`, `z`) VALUES
(3, 28, 200, 0, 24, 3, 0),
(10, 31, 50, 0, 0, 0, 0);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `hints`
--
ALTER TABLE `hints`
  ADD PRIMARY KEY (`hint_id`);

--
-- Indexes for table `levels`
--
ALTER TABLE `levels`
  ADD PRIMARY KEY (`level_id`);

--
-- Indexes for table `login`
--
ALTER TABLE `login`
  ADD PRIMARY KEY (`login_id`);

--
-- Indexes for table `players`
--
ALTER TABLE `players`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `questions`
--
ALTER TABLE `questions`
  ADD PRIMARY KEY (`question_id`);

--
-- Indexes for table `score_board`
--
ALTER TABLE `score_board`
  ADD PRIMARY KEY (`score_id`),
  ADD KEY `test` (`player_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `hints`
--
ALTER TABLE `hints`
  MODIFY `hint_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `levels`
--
ALTER TABLE `levels`
  MODIFY `level_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `login`
--
ALTER TABLE `login`
  MODIFY `login_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=48;

--
-- AUTO_INCREMENT for table `players`
--
ALTER TABLE `players`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=32;

--
-- AUTO_INCREMENT for table `questions`
--
ALTER TABLE `questions`
  MODIFY `question_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `score_board`
--
ALTER TABLE `score_board`
  MODIFY `score_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `score_board`
--
ALTER TABLE `score_board`
  ADD CONSTRAINT `test` FOREIGN KEY (`player_id`) REFERENCES `players` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
