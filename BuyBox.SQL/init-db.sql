USE `buybox`;

SET FOREIGN_KEY_CHECKS = 0;

DROP TABLE IF EXISTS `Product`;
DROP TABLE IF EXISTS `Token`;
DROP TABLE IF EXISTS `Price`;
DROP TABLE IF EXISTS `StockEntry`;
DROP TABLE IF EXISTS `LedgerEntry`;

DROP VIEW IF EXISTS _InOutStock;
DROP VIEW IF EXISTS SellableItem;

DROP VIEW IF EXISTS _InOutLedger;
DROP VIEW IF EXISTS TradeToken;

CREATE TABLE `Product` (
    `Id` INT(11) NOT NULL PRIMARY KEY,
    `Name` VARCHAR (50) COLLATE utf8mb4_unicode_ci NOT NULL
);

CREATE TABLE `Token` (
    `Id` INT(11) NOT NULL PRIMARY KEY,
    `Code` VARCHAR(4) NOT NULL COLLATE utf8mb4_unicode_ci NOT NULL,
    `Value` DECIMAL(5,2) NOT NULL
);

CREATE TABLE `Price` (
    `Id` INT(11) NOT NULL PRIMARY KEY AUTO_INCREMENT,
    `ProductId` INT(11) NOT NULL REFERENCES `Product` (`Id`),
    `Value` DECIMAL(5, 2) NOT NULL
);

CREATE TABLE `StockEntry` (
    `Id` INT(11) NOT NULL PRIMARY KEY AUTO_INCREMENT,
    `ProductId` INT(11) NOT NULL REFERENCES `Product` (`Id`),
    `Operation` VARCHAR(1) NOT NULL,
    `Session` VARCHAR(36),
    `Quantity` INT(11) NOT NULL
);

CREATE TABLE `LedgerEntry` (
    `Id` INT(11) NOT NULL PRIMARY KEY AUTO_INCREMENT,
    `Session` VARCHAR(36),
    `Operation` VARCHAR(1),
    `TokenId` INT(11) NOT NULL REFERENCES `Token` (`Id`),
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

INSERT INTO `Price` VALUES (default, 1, 1.30);
INSERT INTO `Price` VALUES (default, 2, 1.80);
INSERT INTO `Price` VALUES (default, 3, 1.80);
INSERT INTO `Price` VALUES (default, 4, 1.80);

INSERT INTO `StockEntry` VALUES (default, 1, 'I', '3bc45266-3f49-9971-9c0d-d39b7fa867f3', 10);
INSERT INTO `StockEntry` VALUES (default, 2, 'I', '3bc45266-3f49-9971-9c0d-d39b7fa867f3', 20);
INSERT INTO `StockEntry` VALUES (default, 3, 'I', '3bc45266-3f49-9971-9c0d-d39b7fa867f3', 20);
INSERT INTO `StockEntry` VALUES (default, 4, 'I', '3bc45266-3f49-9971-9c0d-d39b7fa867f3', 15);


INSERT INTO `LedgerEntry` VALUES(default, '3bc45266-3f49-9971-9c0d-d39b7fa867f3', 'I', 1, 100);
INSERT INTO `LedgerEntry` VALUES(default, '3bc45266-3f49-9971-9c0d-d39b7fa867f3', 'I', 2, 100);
INSERT INTO `LedgerEntry` VALUES(default, '3bc45266-3f49-9971-9c0d-d39b7fa867f3', 'I', 3, 100);
INSERT INTO `LedgerEntry` VALUES(default, '3bc45266-3f49-9971-9c0d-d39b7fa867f3', 'I', 4, 100);

CREATE VIEW _InOutStock AS
     select ProductId
      , sum(Quantity) Quantity
     from StockEntry
     where Operation = 'I'
     group by ProductId

     union all

     select ProductId
      , (-1) * sum(Quantity) Quantity
     from StockEntry
     where Operation = 'O'
     group by ProductId;

CREATE VIEW SellableItem AS
    select
         p.Id Id
        ,p.Name Name
        ,pr.Value Price
        ,sum(sub.Quantity) Quantity
    from _InOutStock sub
    join Product p on sub.ProductId = p.Id
    join Price pr on pr.ProductId = p.Id
    group by p.Id, p.Name, pr.Value;

CREATE VIEW _InOutLedger AS
         select TokenId
      , sum(Quantity) Quantity
     from LedgerEntry
     where Operation = 'I'
     group by TokenId

     union all

     select TokenId
      , (-1) * sum(Quantity) Quantity
     from LedgerEntry
     where Operation = 'O'
     group by TokenId;

CREATE VIEW TradeToken as
    select
         p.Id Id
        ,p.Code Code
        ,p.Value Value
        ,sum(sub.Quantity) Quantity
    from _InOutLedger sub
    join Token p on sub.TokenId = p.Id
    group by p.Id, p.Code, p.Value;

SET FOREIGN_KEY_CHECKS = 1;