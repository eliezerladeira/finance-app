-- --------------------------------------------------------
-- Servidor:                     127.0.0.1
-- Versão do servidor:           10.4.32-MariaDB - mariadb.org binary distribution
-- OS do Servidor:               Win64
-- HeidiSQL Versão:              12.7.0.6850
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

-- Copiando dados para a tabela financeapp.accounts: ~0 rows (aproximadamente)
INSERT INTO `accounts` (`Id`, `Name`, `Type`, `InitialBalance`, `UserId`, `CreatedAt`, `IsActive`) VALUES
	('833640b9-0d26-4769-9742-a5e89c9be03f', 'Nubank', 1, 1000.00, 'df94f743-009a-4dde-9c4f-9b1147d041f5', '2026-03-05 21:55:15', 1);

-- Copiando dados para a tabela financeapp.credit_cards: ~1 rows (aproximadamente)
INSERT INTO `credit_cards` (`id`, `name`, `credit_limit`, `closing_day`, `due_day`, `user_id`, `created_at`) VALUES
	('1edca767-29d3-4f40-a1ad-9ec73ddb4feb', 'Nubank', 5000.00, 10, 17, 'df94f743-009a-4dde-9c4f-9b1147d041f5', '2026-03-06 00:32:35');

-- Copiando dados para a tabela financeapp.invoices: ~0 rows (aproximadamente)

-- Copiando dados para a tabela financeapp.transactions: ~0 rows (aproximadamente)

-- Copiando dados para a tabela financeapp.users: ~1 rows (aproximadamente)
INSERT INTO `users` (`Id`, `Name`, `Email`, `PasswordHash`, `CreatedAt`, `IsActive`) VALUES
	('df94f743-009a-4dde-9c4f-9b1147d041f5', 'Eliezer', 'eliezer@email.com', '$2a$11$6NLo8XNubBETWn9BvuEWM.lxLlD3RflAeGFWTgNKtquzRhAURg.x6', '2026-03-05 21:49:37', 1);

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
