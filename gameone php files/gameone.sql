-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 13, 2020 at 08:44 PM
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
(1, 1, 'hasini', '$5$rounds=5000$steamedhamshasin$kqFBd3V//OADw/Gw58zzhh0R4xotjGmzGJCw15RLhc3', '$5$rounds=5000$steamedhamshasini$'),
(2, 2, 'hasara', '$5$rounds=5000$steamedhamshasar$oKJhn1iwzevCIteTQU9NGJGDiIHXr13YMZteC2i6wuB', '$5$rounds=5000$steamedhamshasara$');

-- --------------------------------------------------------

--
-- Table structure for table `players`
--

CREATE TABLE `players` (
  `id` int(10) NOT NULL,
  `username` varchar(15) NOT NULL,
  `age` int(11) DEFAULT NULL,
  `hash` varchar(100) NOT NULL,
  `salt` varchar(100) NOT NULL,
  `health` int(11) NOT NULL DEFAULT '3'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `players`
--

INSERT INTO `players` (`id`, `username`, `age`, `hash`, `salt`, `health`) VALUES
(1, 'hasini', 12, '$5$rounds=5000$steamedhamshasin$kqFBd3V//OADw/Gw58zzhh0R4xotjGmzGJCw15RLhc3', '$5$rounds=5000$steamedhamshasini$', 1),
(2, 'hasara', 14, '$5$rounds=5000$steamedhamshasar$oKJhn1iwzevCIteTQU9NGJGDiIHXr13YMZteC2i6wuB', '$5$rounds=5000$steamedhamshasara$', 3);

-- --------------------------------------------------------

--
-- Table structure for table `questions`
--

CREATE TABLE `questions` (
  `question_id` varchar(15) NOT NULL,
  `question_desc` varchar(100) NOT NULL,
  `answer` int(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `questions`
--

INSERT INTO `questions` (`question_id`, `question_desc`, `answer`) VALUES
('a01', 'You have 20 coins.Your mother give you 10 coins. How many coins you have now.', 30),
('a02', 'You have 15 coins.Your mother give you 20 coins. How many coins you have now.', 35),
('a03', '10 + 30', 30);

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
  `z` int(100) NOT NULL,
  `level_id` int(11) NOT NULL DEFAULT '1',
  `the_level` int(11) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `score_board`
--

INSERT INTO `score_board` (`score_id`, `player_id`, `score`, `coins`, `x`, `y`, `z`, `level_id`, `the_level`) VALUES
(1, 1, 500, 3, 75, 7, 0, 1, 3),
(2, 2, 550, 1, 68, -4, 0, 1, 1);

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
  MODIFY `login_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `players`
--
ALTER TABLE `players`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `score_board`
--
ALTER TABLE `score_board`
  MODIFY `score_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `login`
--
ALTER TABLE `login`
  ADD CONSTRAINT `test2` FOREIGN KEY (`login_id`) REFERENCES `players` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `score_board`
--
ALTER TABLE `score_board`
  ADD CONSTRAINT `test` FOREIGN KEY (`player_id`) REFERENCES `players` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
