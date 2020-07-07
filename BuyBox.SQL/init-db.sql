USE `buybox`;

SET FOREIGN_KEY_CHECKS = 0;

DROP TABLE IF EXISTS `Session`;
DROP TABLE IF EXISTS `Product`;
DROP TABLE IF EXISTS `Token`;
DROP TABLE IF EXISTS `Price`;
DROP TABLE IF EXISTS `StockEntry`;
DROP TABLE IF EXISTS `LedgerEntry`;

DROP VIEW IF EXISTS _InOutStock;
DROP VIEW IF EXISTS SellableItem;

DROP VIEW IF EXISTS _InOutLedger;
DROP VIEW IF EXISTS ExchangeToken;

DROP PROCEDURE IF EXISTS InsertExchangeTokens;

CREATE TABLE `Session` (
    `Id` VARCHAR(36) NOT NULL PRIMARY KEY,
    `Started` datetime NOT NULL ,
    `Finished` datetime
);

CREATE TABLE `Product` (
    `Id` INT(11) NOT NULL PRIMARY KEY,
    `Name` VARCHAR (50) COLLATE utf8mb4_unicode_ci NOT NULL
);

CREATE TABLE `Token` (
    `Id` VARCHAR(4) NOT NULL COLLATE utf8mb4_unicode_ci NOT NULL PRIMARY KEY,
    `Value` INT NOT NULL
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
    `SessionId` VARCHAR(36) REFERENCES `Session`,
    `RelatedId` INT(11) REFERENCES `LedgerEntry`,
    `Operation` VARCHAR(1),
    `TokenId` VARCHAR(4) NOT NULL REFERENCES `Token` (`Id`)

);

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
      , sum(1) Quantity
     from LedgerEntry
     where Operation = 'I'
     group by TokenId

     union all

     select TokenId
      , (-1) * sum(1) Quantity
     from LedgerEntry
     where Operation = 'O'
     group by TokenId;

CREATE VIEW ExchangeToken as
    select
          p.Id Id
        , p.Value Value
        , sum(sub.Quantity) Quantity
    from _InOutLedger sub
    join Token p on sub.TokenId = p.Id
    group by p.Id, p.Value;

DELIMITER //
CREATE  PROCEDURE  InsertExchangeTokens(p1 INT)
  BEGIN
    SET @x = 0;
    REPEAT SET @x = @x + 1;
    INSERT INTO `LedgerEntry` VALUES(default, null, null, 'I', 'T010');
    INSERT INTO `LedgerEntry` VALUES(default, null, null, 'I', 'T020');
    INSERT INTO `LedgerEntry` VALUES(default, null, null, 'I', 'T050');
    INSERT INTO `LedgerEntry` VALUES(default, null, null, 'I', 'T100');
    UNTIL @x > p1 END REPEAT;
  END;
//
DELIMITER ;

SET FOREIGN_KEY_CHECKS = 1;

INSERT INTO `Product` VALUES (1, 'Tea');
INSERT INTO `Product` VALUES (2, 'Expresso');
INSERT INTO `Product` VALUES (3, 'Juice');
INSERT INTO `Product` VALUES (4, 'Chicken Soup');

INSERT INTO `Token` VALUES ('T100', 100);
INSERT INTO `Token` VALUES ('T050', 50);
INSERT INTO `Token` VALUES ('T020', 20);
INSERT INTO `Token` VALUES ('T010', 10);

INSERT INTO `Price` VALUES (default, 1, 130);
INSERT INTO `Price` VALUES (default, 2, 180);
INSERT INTO `Price` VALUES (default, 3, 180);
INSERT INTO `Price` VALUES (default, 4, 180);

INSERT INTO `StockEntry` VALUES (default, 1, 'I', null, 10);
INSERT INTO `StockEntry` VALUES (default, 2, 'I', null, 20);
INSERT INTO `StockEntry` VALUES (default, 3, 'I', null, 20);
INSERT INTO `StockEntry` VALUES (default, 4, 'I', null, 15);

CALL InsertExchangeTokens(100);