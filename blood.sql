/*
Navicat MySQL Data Transfer

Source Server         : localhost
Source Server Version : 50505
Source Host           : localhost:3306
Source Database       : blood

Target Server Type    : MYSQL
Target Server Version : 50505
File Encoding         : 65001

Date: 2018-01-04 09:53:30
*/

SET FOREIGN_KEY_CHECKS=0;
-- ----------------------------
-- Table structure for `tbldonor`
-- ----------------------------
DROP TABLE IF EXISTS `tbldonor`;
CREATE TABLE `tbldonor` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `cardNum` varchar(20) DEFAULT NULL,
  `bloodtype` varchar(10) DEFAULT NULL,
  `donorID` int(11) DEFAULT NULL,
  `DocDate` date DEFAULT NULL,
  `status` varchar(1) DEFAULT NULL,
  `Encodeby` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tbldonor
-- ----------------------------

-- ----------------------------
-- Table structure for `tblmaintenance`
-- ----------------------------
DROP TABLE IF EXISTS `tblmaintenance`;
CREATE TABLE `tblmaintenance` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `m_key` varchar(50) DEFAULT NULL,
  `m_value` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tblmaintenance
-- ----------------------------
INSERT INTO `tblmaintenance` VALUES ('1', 'ParLevel', '30');

-- ----------------------------
-- Table structure for `tblpersoninfo`
-- ----------------------------
DROP TABLE IF EXISTS `tblpersoninfo`;
CREATE TABLE `tblpersoninfo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `firstname` varchar(50) DEFAULT NULL,
  `middlename` varchar(50) DEFAULT NULL,
  `lastname` varchar(50) DEFAULT NULL,
  `gender` varchar(1) DEFAULT NULL,
  `dob` date DEFAULT NULL,
  `ContactNum` varchar(15) DEFAULT NULL,
  `maritalStatus` varchar(20) DEFAULT NULL,
  `preStreet` varchar(150) DEFAULT NULL,
  `preBarangay` varchar(150) DEFAULT NULL,
  `preCity` varchar(150) DEFAULT NULL,
  `preProvince` varchar(150) DEFAULT NULL,
  `preZipcode` varchar(10) DEFAULT NULL,
  `perStreet` varchar(150) DEFAULT NULL,
  `perBarangay` varchar(150) DEFAULT NULL,
  `perCity` varchar(150) DEFAULT NULL,
  `perProvince` varchar(150) DEFAULT NULL,
  `perZipcode` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tblpersoninfo
-- ----------------------------

-- ----------------------------
-- Table structure for `tblrecipient`
-- ----------------------------
DROP TABLE IF EXISTS `tblrecipient`;
CREATE TABLE `tblrecipient` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `DocDate` date DEFAULT NULL,
  `BloodType` varchar(10) DEFAULT NULL,
  `RecipientID` int(11) DEFAULT NULL,
  `Status` varchar(1) DEFAULT NULL,
  `Encodeby` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tblrecipient
-- ----------------------------

-- ----------------------------
-- Table structure for `tblstock`
-- ----------------------------
DROP TABLE IF EXISTS `tblstock`;
CREATE TABLE `tblstock` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `bloodtype` varchar(5) DEFAULT NULL,
  `inv` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tblstock
-- ----------------------------
INSERT INTO `tblstock` VALUES ('1', 'A', '-90');
INSERT INTO `tblstock` VALUES ('2', 'B', '-138');
INSERT INTO `tblstock` VALUES ('3', 'AB', '-45');
INSERT INTO `tblstock` VALUES ('4', 'O', '-128');
INSERT INTO `tblstock` VALUES ('5', 'A-', '-155');
INSERT INTO `tblstock` VALUES ('6', 'B-', '-173');
INSERT INTO `tblstock` VALUES ('7', 'AB-', '-170');
INSERT INTO `tblstock` VALUES ('8', 'O-', '-1002');

-- ----------------------------
-- Table structure for `tbluser`
-- ----------------------------
DROP TABLE IF EXISTS `tbluser`;
CREATE TABLE `tbluser` (
  `ID` int(11) NOT NULL,
  `UserName` varchar(50) DEFAULT NULL,
  `UserPassword` varchar(50) DEFAULT NULL,
  `Firstname` varchar(50) DEFAULT NULL,
  `Middlename` varchar(50) NOT NULL,
  `Lastname` varchar(50) DEFAULT NULL,
  `Role` varchar(50) DEFAULT NULL,
  `Status` varchar(1) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tbluser
-- ----------------------------
INSERT INTO `tbluser` VALUES ('0', 'd', 'xrz5OsUeCbg=', 'Dar', 'Baisac', 'Gomez', 'Admin', '1');
