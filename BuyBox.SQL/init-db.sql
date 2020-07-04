USE `buybox`;

SET FOREIGN_KEY_CHECKS = 0;

DROP TABLE IF EXISTS `Product`;
DROP TABLE IF EXISTS `Token`;
DROP TABLE IF EXISTS `StockHistory`;
DROP TABLE IF EXISTS `Ledger`;

CREATE TABLE `Product` (
    `Id` INT(11) NOT NULL PRIMARY KEY,
    `Name` VARCHAR (50) COLLATE utf8mb4_unicode_ci NOT NULL
);

CREATE TABLE `Token` (
    `Id` INT(11) NOT NULL PRIMARY KEY,
    `Code` VARCHAR(4) NOT NULL COLLATE utf8mb4_unicode_ci NOT NULL,
    `Value` DECIMAL(5,2) NOT NULL
);

CREATE TABLE `StockHistory` (
    `Id` INT(11) NOT NULL PRIMARY KEY AUTO_INCREMENT,
    `Product_Id` INT(11) NOT NULL REFERENCES `Product` (`Id`),
    `Operation` VARCHAR(1) NOT NULL,
    `When` DATETIME NOT NULL,
    `Quantity` INT(11) NOT NULL
);

CREATE TABLE `Ledger` (
    `Id` INT(11) NOT NULL PRIMARY KEY AUTO_INCREMENT,
    `Transaction` DATETIME NOT NULL,
    `Operation` VARCHAR(1),
    `When` DATETIME NOT NULL,
    `Token_Id` INT(11) REFERENCES `Token` (`Id`),
    `Quantity` INT(11) NOT NULL

);

INSERT INTO `Product` VALUES (1, 'Tea');
INSERT INTO `Product` VALUES (2, 'Expresso');
INSERT INTO `Product` VALUES (3, 'Juice');
INSERT INTO `Product` VALUES (4, 'Chicken Soup');

INSERT INTO `Token` VALUES (1, 'D100', 1.00);
INSERT INTO `Token` VALUES (2, 'D050', 0.50);
INSERT INTO `Token` VALUES (3, 'D020', 0.20);
INSERT INTO `Token` VALUES (4, 'D010', 0.10);

INSERT INTO `StockHistory` VALUES (default, 1, 'I', NOW(), 10);
INSERT INTO `StockHistory` VALUES (default, 2, 'I', NOW(), 20);
INSERT INTO `StockHistory` VALUES (default, 3, 'I', NOW(), 20);
INSERT INTO `StockHistory` VALUES (default, 4, 'I', NOW(), 15);

INSERT INTO `Ledger` VALUES(default, NOW(), 'I', NOW(), 1, 100);
INSERT INTO `Ledger` VALUES(default, NOW(), 'I', NOW(), 2, 100);
INSERT INTO `Ledger` VALUES(default, NOW(), 'I', NOW(), 3, 100);
INSERT INTO `Ledger` VALUES(default, NOW(), 'I', NOW(), 4, 100);

SET FOREIGN_KEY_CHECKS = 1;