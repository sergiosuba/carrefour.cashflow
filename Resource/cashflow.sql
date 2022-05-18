-- phpMyAdmin SQL Dump

-- version 5.1.0

-- https://www.phpmyadmin.net/

--

-- Host: db

-- Tempo de geração: 18-Maio-2022 às 15:30

-- Versão do servidor: 8.0.23

-- versão do PHP: 7.4.15

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";

START TRANSACTION;

SET time_zone = "+00:00";

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */

;

/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */

;

/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */

;

/*!40101 SET NAMES utf8mb4 */

;

--

-- Banco de dados: `cashflow`

--

CREATE DATABASE IF NOT EXISTS `cashflow` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;

USE `cashflow`;

-- --------------------------------------------------------

--

-- Estrutura da tabela `AccountingEntry`

--

DROP TABLE IF EXISTS `AccountingEntry`;

CREATE TABLE IF NOT EXISTS `AccountingEntry` (
    `id` varchar(36) NOT NULL,
    `chartAccountId` varchar(36) NOT NULL,
    `value` decimal(10, 0) NOT NULL,
    `flowId` varchar(36) NOT NULL,
    `description` varchar(400) NOT NULL,
    `creationDate` date NOT NULL,
    PRIMARY KEY (`id`),
    KEY `AccountingEntry_Flow` (`flowId`),
    KEY `AccountingEntry_ChartAccount` (`chartAccountId`)
) ENGINE = InnoDB DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci;

--

-- Extraindo dados da tabela `AccountingEntry`

--

INSERT INTO
    `AccountingEntry` (
        `id`,
        `chartAccountId`,
        `value`,
        `flowId`,
        `description`,
        `creationDate`
    )
VALUES
    (
        '23CF88F2-AE59-47CB-9C59-9E6894B26131',
        '411B45BF-EE24-4AED-B221-38993F9CAE9E',
        '10',
        '6b26f932-05b2-453b-95ad-cf019c960470',
        'Vendas a vista',
        '2022-05-18'
    ),
    (
        '48D998FE-D44B-4495-AFC5-EFB81D4A2FF0',
        '411B45BF-EE24-4AED-B221-38993F9CAE9E',
        '30',
        '6b26f932-05b2-453b-95ad-cf019c960470',
        'Vendas a vista',
        '2022-05-18'
    ),
    (
        '605A1A7A-49B5-486B-B591-83691290B5C7',
        'B7B3EF80-DC07-494E-A594-B1F56ADF6273',
        '43',
        'e2f7aae0-1971-4271-9adb-d65148760083',
        'Despesa',
        '2022-05-18'
    ),
    (
        '933BC127-289A-4DC8-897C-0292800966B5',
        '411B45BF-EE24-4AED-B221-38993F9CAE9E',
        '30',
        '6b26f932-05b2-453b-95ad-cf019c960470',
        'Vendas a vista',
        '2022-05-18'
    ),
    (
        '980FA35D-BE5A-4D1B-A949-AEB1C6500131',
        '411B45BF-EE24-4AED-B221-38993F9CAE9E',
        '70',
        '6b26f932-05b2-453b-95ad-cf019c960470',
        'Vendas a vista',
        '2022-05-18'
    ),
    (
        '9E32BBA5-3DF3-4357-AD29-DDAA2B0C7191',
        'B7B3EF80-DC07-494E-A594-B1F56ADF6273',
        '98',
        'e2f7aae0-1971-4271-9adb-d65148760083',
        'Despesa',
        '2022-05-18'
    ),
    (
        'A60F5D37-E1C3-4FA2-B36F-AB251A8A54DB',
        '411B45BF-EE24-4AED-B221-38993F9CAE9E',
        '31',
        '6b26f932-05b2-453b-95ad-cf019c960470',
        'Vendas a vista',
        '2022-05-18'
    ),
    (
        'B62055A0-0586-4076-B9C3-F47E3ACDCD59',
        '411B45BF-EE24-4AED-B221-38993F9CAE9E',
        '21',
        '6b26f932-05b2-453b-95ad-cf019c960470',
        'Vendas a vista',
        '2022-05-18'
    ),
    (
        'EBE001F7-5FB3-4B37-AAAB-50F869E0BDE0',
        'B7B3EF80-DC07-494E-A594-B1F56ADF6273',
        '10',
        'e2f7aae0-1971-4271-9adb-d65148760083',
        'Despesa',
        '2022-05-18'
    );

-- --------------------------------------------------------

--

-- Estrutura da tabela `ChartAccount`

--

DROP TABLE IF EXISTS `ChartAccount`;

CREATE TABLE IF NOT EXISTS `ChartAccount` (
    `id` varchar(36) NOT NULL,
    `name` varchar(100) NOT NULL,
    `description` varchar(400) NOT NULL,
    `creationDate` date NOT NULL,
    PRIMARY KEY (`id`)
) ENGINE = InnoDB DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci;

--

-- Extraindo dados da tabela `ChartAccount`

--

INSERT INTO
    `ChartAccount` (`id`, `name`, `description`, `creationDate`)
VALUES
    (
        '411B45BF-EE24-4AED-B221-38993F9CAE9E',
        'Vendas',
        'Vendas realizadas',
        '0001-01-01'
    ),
    (
        'B7B3EF80-DC07-494E-A594-B1F56ADF6273',
        'Despesas',
        'Despesas realizadas',
        '2022-05-18'
    );

-- --------------------------------------------------------

--

-- Estrutura da tabela `Flow`

--

DROP TABLE IF EXISTS `Flow`;

CREATE TABLE IF NOT EXISTS `Flow` (
    `id` varchar(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `Flow` varchar(10) NOT NULL,
    PRIMARY KEY (`id`)
) ENGINE = InnoDB DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci;

--

-- Extraindo dados da tabela `Flow`

--

INSERT INTO
    `Flow` (`id`, `Flow`)
VALUES
    ('6b26f932-05b2-453b-95ad-cf019c960470', 'Input'),
    ('e2f7aae0-1971-4271-9adb-d65148760083', 'Output');

--

-- Restrições para despejos de tabelas

--

--

-- Limitadores para a tabela `AccountingEntry`

--

ALTER TABLE
    `AccountingEntry`
ADD
    CONSTRAINT `AccountingEntry_ChartAccount` FOREIGN KEY (`chartAccountId`) REFERENCES `ChartAccount` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
ADD
    CONSTRAINT `AccountingEntry_Flow` FOREIGN KEY (`flowId`) REFERENCES `Flow` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT;

COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */

;

/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */

;

/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */

;