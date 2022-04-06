-- -----------------------------------------------------
-- Schema AccountOwner
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `AccountOwner` ;
USE `AccountOwner` ;

-- -----------------------------------------------------
-- Table `AccountOwner`.`Owner`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `AccountOwner`.`Owner` ;

CREATE TABLE IF NOT EXISTS `AccountOwner`.`Owner` (
  `OwnerId` CHAR(36) NOT NULL,
  `Name` NVARCHAR(60) NOT NULL,
  `DateOfBirth` DATE NOT NULL,
  `Address` NVARCHAR(100) NOT NULL,
  PRIMARY KEY (`OwnerId`))
ENGINE = InnoDB;