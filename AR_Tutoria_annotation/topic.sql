-- phpMyAdmin SQL Dump
-- version 5.0.3
-- https://www.phpmyadmin.net/
--
-- 主機： 127.0.0.1
-- 產生時間： 2020-12-09 11:59:47
-- 伺服器版本： 10.4.14-MariaDB
-- PHP 版本： 7.2.34

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- 資料庫： `topic`
--

-- --------------------------------------------------------

--
-- 資料表結構 `game1`
--

CREATE TABLE `game1` (
  `id` text NOT NULL,
  `time_1` text NOT NULL,
  `id_name` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- 傾印資料表的資料 `game1`
--

INSERT INTO `game1` (`id`, `time_1`, `id_name`) VALUES
('玩家按下遊戲說明三', '2020-12-09 18:51:36', ''),
('玩家按下遊戲說明二', '2020-12-09 18:51:38', ''),
('玩家按下遊戲說明一', '2020-12-09 18:52:14', ''),
('怪物生成', '2020-12-09 18:53:16', ''),
('怪物生成', '2020-12-09 18:54:11', 'X556UR (ASUSTeK COMPUTER INC.)'),
('玩家按下遊戲說明三', '2020-12-09 18:54:13', 'X556UR (ASUSTeK COMPUTER INC.)'),
('玩家按下遊戲說明一', '2020-12-09 18:54:14', 'X556UR (ASUSTeK COMPUTER INC.)');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
