-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: localhost    Database: e_shift_logistics
-- ------------------------------------------------------
-- Server version	5.5.5-10.4.32-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `assistants`
--

DROP TABLE IF EXISTS `assistants`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `assistants` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `phone` varchar(20) DEFAULT NULL,
  `address` varchar(500) DEFAULT NULL,
  `status` int(11) NOT NULL DEFAULT 1,
  `created_date` datetime DEFAULT current_timestamp(),
  `is_active` tinyint(1) DEFAULT 1,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `assistants`
--

LOCK TABLES `assistants` WRITE;
/*!40000 ALTER TABLE `assistants` DISABLE KEYS */;
INSERT INTO `assistants` VALUES (1,'Nuwan Perera','0771234567','12 Palm Grove, Colombo',3,'2025-07-10 18:44:24',1),(2,'Sanjeewa Silva','0718765432','45 Lake Road, Galle',1,'2025-07-10 18:46:07',1),(3,'Rajitha Gunasekar','0763344556','102 Temple Road, Kandy',1,'2025-07-10 18:46:25',1),(4,'Chamika Karunaratne','0759988776','23 Hilltop, Kurunegala',2,'2025-07-10 18:52:31',1),(5,'Dilshan Dissanayake','0784561239','89 Lotus Avenue, Matara',3,'2025-07-10 18:52:49',1),(6,'Gayan Priyankara','0771122334','5 Flower Road, Negombo',1,'2025-07-10 18:53:16',1),(7,'Saman Wijesinghe','0709988775','50 Beachside, Kalutara',1,'2025-07-10 18:53:33',1),(8,'Niroshan Fernando','0712233445','33 Royal Park, Nuwara Eliya',1,'2025-07-10 18:53:47',1),(9,'Pradeep Jayasuriya','0765566778','67 Sunrise St, Anuradhapura',1,'2025-07-10 18:54:00',1),(10,'Lasantha Bandara','0729988776','18 Station Rd, Badulla',1,'2025-07-10 18:54:14',1);
/*!40000 ALTER TABLE `assistants` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `drivers`
--

DROP TABLE IF EXISTS `drivers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `drivers` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `license_number` varchar(50) NOT NULL,
  `phone` varchar(20) DEFAULT NULL,
  `address` varchar(500) DEFAULT NULL,
  `status` int(11) NOT NULL DEFAULT 1,
  `created_date` datetime DEFAULT current_timestamp(),
  `is_active` tinyint(1) DEFAULT 1,
  PRIMARY KEY (`id`),
  UNIQUE KEY `license_number` (`license_number`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `drivers`
--

LOCK TABLES `drivers` WRITE;
/*!40000 ALTER TABLE `drivers` DISABLE KEYS */;
INSERT INTO `drivers` VALUES (2,'Sunil Perera','DRV-00123','0771234567','14 Palm Street, Colombo',1,'2025-07-10 20:34:25',1),(3,'Kamal Fernando','DRV-00456','0712345678','88 Beach Road, Galle',1,'2025-07-10 20:37:10',1),(4,'Ruwan Silva','DRV-00789','0756789123','20 Lakeview, Kandy',1,'2025-07-10 20:38:38',1),(5,'Anura Jayasena','DRV-01011','0761122334','35 Hill Top, Matale',1,'2025-07-10 20:39:03',1),(6,'Janaka Rajapaksha','DRV-01432','0775566778','67 Rose Ave, Kurunegala',1,'2025-07-10 20:39:21',1),(7,'Mahesh Dissanayake','DRV-01985','0789988776','40 Flower Rd, Nugegoda',1,'2025-07-10 20:41:11',1),(8,'Roshan Abeywickrama','DRV-02020','0721122334','12 Coconut Grove, Jaffna',1,'2025-07-10 20:41:28',1),(9,'Tharindu Samarasekara','DRV-02111','0709988775','56 Station Road, Badulla',1,'2025-07-10 20:41:53',1),(10,'Lalith Herath','DRV-02222','0763344556','22 Temple Street, Anuradhapura',3,'2025-07-10 20:42:17',1),(12,'Dilum Jayawardena','DRV-02333','0798877665','11 Lotus Lane, Hambantota',1,'2025-07-10 20:43:23',1);
/*!40000 ALTER TABLE `drivers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `job_products`
--

DROP TABLE IF EXISTS `job_products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `job_products` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `job_id` int(11) DEFAULT NULL,
  `product_id` int(11) DEFAULT NULL,
  `quantity` int(11) DEFAULT NULL,
  `custom_weight` decimal(8,2) DEFAULT NULL,
  `custom_dimensions` varchar(100) DEFAULT NULL,
  `is_fragile` tinyint(1) DEFAULT 0,
  PRIMARY KEY (`id`),
  KEY `job_id` (`job_id`),
  KEY `product_id` (`product_id`),
  CONSTRAINT `job_products_ibfk_1` FOREIGN KEY (`job_id`) REFERENCES `jobs` (`id`),
  CONSTRAINT `job_products_ibfk_2` FOREIGN KEY (`product_id`) REFERENCES `products` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `job_products`
--

LOCK TABLES `job_products` WRITE;
/*!40000 ALTER TABLE `job_products` DISABLE KEYS */;
INSERT INTO `job_products` VALUES (1,3,4,1,NULL,NULL,0),(2,3,8,1,NULL,NULL,0),(3,4,11,2,NULL,NULL,0),(4,4,6,1,NULL,NULL,0),(5,4,15,1,NULL,NULL,0),(6,5,3,1,NULL,NULL,0),(7,5,6,1,NULL,NULL,0),(8,5,12,16,NULL,NULL,0),(9,5,11,2,NULL,NULL,0),(10,5,10,2,NULL,NULL,0),(11,6,10,1,NULL,NULL,0),(12,6,20,1,NULL,NULL,0),(13,7,4,1,NULL,NULL,0),(14,7,6,1,NULL,NULL,0),(15,8,3,1,NULL,NULL,0),(16,9,7,1,NULL,NULL,0);
/*!40000 ALTER TABLE `job_products` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `job_status_logs`
--

DROP TABLE IF EXISTS `job_status_logs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `job_status_logs` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `job_id` int(11) NOT NULL,
  `status` varchar(50) NOT NULL,
  `updated_by` int(11) DEFAULT NULL,
  `note` text DEFAULT NULL,
  `created_at` datetime DEFAULT current_timestamp(),
  PRIMARY KEY (`id`),
  KEY `job_id` (`job_id`),
  KEY `updated_by` (`updated_by`),
  CONSTRAINT `job_status_logs_ibfk_1` FOREIGN KEY (`job_id`) REFERENCES `jobs` (`id`),
  CONSTRAINT `job_status_logs_ibfk_2` FOREIGN KEY (`updated_by`) REFERENCES `users` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `job_status_logs`
--

LOCK TABLES `job_status_logs` WRITE;
/*!40000 ALTER TABLE `job_status_logs` DISABLE KEYS */;
INSERT INTO `job_status_logs` VALUES (1,3,'Accepted',NULL,'Admin finalized job and assigned unit','2025-07-13 22:54:50'),(2,3,'Ongoing',NULL,'Admin updated status','2025-07-13 22:54:58'),(3,3,'Completed',NULL,'Admin updated status','2025-07-13 22:55:20'),(4,7,'Accepted',NULL,'Admin finalized job and assigned unit','2025-07-15 00:31:34'),(5,7,'Ongoing',NULL,'Admin updated status','2025-07-15 00:36:52'),(6,9,'Accepted',NULL,'Admin finalized job and assigned unit','2025-07-15 21:10:55'),(7,9,'Ongoing',NULL,'Admin updated status','2025-07-15 21:11:30'),(8,9,'Completed',NULL,'Admin updated status','2025-07-15 21:11:58');
/*!40000 ALTER TABLE `job_status_logs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `jobs`
--

DROP TABLE IF EXISTS `jobs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `jobs` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `job_number` varchar(50) NOT NULL,
  `customer_id` int(11) NOT NULL,
  `pickup_location` varchar(500) NOT NULL,
  `delivery_location` varchar(500) NOT NULL,
  `requested_date` datetime NOT NULL,
  `dispatch_date` datetime DEFAULT NULL,
  `completion_date` datetime DEFAULT NULL,
  `description` varchar(1000) DEFAULT NULL,
  `estimated_cost` decimal(10,2) NOT NULL,
  `actual_cost` decimal(10,2) DEFAULT NULL,
  `status` int(11) NOT NULL DEFAULT 1,
  `transport_unit_id` int(11) DEFAULT NULL,
  `created_date` datetime DEFAULT current_timestamp(),
  `notes` varchar(1000) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `job_number` (`job_number`),
  KEY `customer_id` (`customer_id`),
  KEY `transport_unit_id` (`transport_unit_id`),
  CONSTRAINT `jobs_ibfk_1` FOREIGN KEY (`customer_id`) REFERENCES `users` (`id`),
  CONSTRAINT `jobs_ibfk_2` FOREIGN KEY (`transport_unit_id`) REFERENCES `transport_units` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `jobs`
--

LOCK TABLES `jobs` WRITE;
/*!40000 ALTER TABLE `jobs` DISABLE KEYS */;
INSERT INTO `jobs` VALUES (3,'JOB-2025-0001',6,'Colombo 03','Galle Fort','2025-07-13 08:57:56',NULL,'2025-07-13 22:55:20','',125000.00,NULL,5,7,'2025-07-13 08:58:17',NULL),(4,'JOB-2025-0004',6,'Kandy City Center','Nuwara Eliya Main Street','2025-07-29 09:16:40',NULL,'2025-07-13 22:08:12','',0.00,NULL,6,NULL,'2025-07-13 09:18:00',NULL),(5,'JOB-2025-0005',6,'Dehiwala Station Rd','Jaffna City Center','2025-07-25 09:18:05',NULL,'2025-07-13 22:00:55','Large wooden items',525000.00,NULL,5,1,'2025-07-13 09:21:52',NULL),(6,'JOB-2025-0006',6,'Piliyandala Lake Rd','Kiribathgoda Center','2025-07-29 09:21:55',NULL,'2025-07-13 21:59:30','4 crates - non-fragile',85000.00,NULL,5,7,'2025-07-13 09:22:19',NULL),(7,'JOB-2025-0007',7,'Galle ','Baddegama','2025-07-16 00:29:08',NULL,NULL,'',65000.00,NULL,4,7,'2025-07-15 00:29:28',NULL),(8,'JOB-2025-0008',8,'Kandy Main Rd','Colombo 07','2025-07-15 20:54:50',NULL,NULL,'',0.00,NULL,1,NULL,'2025-07-15 20:55:52',NULL),(9,'JOB-2025-0009',8,'Borella','Kalutara North','2025-08-09 21:08:43',NULL,'2025-07-15 21:11:52','',65000.00,NULL,5,1,'2025-07-15 21:08:58',NULL);
/*!40000 ALTER TABLE `jobs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `loads`
--

DROP TABLE IF EXISTS `loads`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `loads` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `load_number` varchar(50) NOT NULL,
  `job_id` int(11) NOT NULL,
  `description` varchar(500) NOT NULL,
  `weight` decimal(10,2) NOT NULL,
  `volume` decimal(10,2) NOT NULL,
  `special_instructions` varchar(500) DEFAULT NULL,
  `created_date` datetime DEFAULT current_timestamp(),
  PRIMARY KEY (`id`),
  UNIQUE KEY `load_number` (`load_number`),
  KEY `job_id` (`job_id`),
  CONSTRAINT `loads_ibfk_1` FOREIGN KEY (`job_id`) REFERENCES `jobs` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `loads`
--

LOCK TABLES `loads` WRITE;
/*!40000 ALTER TABLE `loads` DISABLE KEYS */;
INSERT INTO `loads` VALUES (1,'',6,'Furniture for showroom - fragile items',4.00,4.00,NULL,'2025-07-13 18:53:52'),(3,'JOB-2025-0005-L01',5,'Delivered to Vavuniya',99.00,26.00,NULL,'2025-07-13 21:15:22'),(4,'JOB-2025-0001-L01',3,'Initial request received.',4.00,6.00,NULL,'2025-07-13 22:54:49'),(5,'JOB-2025-0007-L01',7,'10',2.00,3.00,NULL,'2025-07-15 00:31:34'),(6,'JOB-2025-0009-L01',9,'55',3.00,3.00,NULL,'2025-07-15 21:10:55');
/*!40000 ALTER TABLE `loads` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `products`
--

DROP TABLE IF EXISTS `products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `products` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) DEFAULT NULL,
  `default_weight` decimal(8,2) DEFAULT NULL,
  `default_dimensions` varchar(100) DEFAULT NULL,
  `is_fragile` tinyint(1) DEFAULT 0,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products`
--

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
INSERT INTO `products` VALUES (1,'Refrigerator',75.00,'70x70x180 cm',1),(2,'Washing Machine',60.00,'60x60x100 cm',1),(3,'Sofa (3 Seater)',40.00,'200x90x100 cm',0),(4,'Dining Table (6 Seat)',55.00,'180x90x75 cm',0),(5,'Microwave Oven',15.00,'50x40x30 cm',1),(6,'Television (42\")',10.00,'100x15x60 cm',1),(7,'Wardrobe',80.00,'100x60x200 cm',0),(8,'Mattress (Queen Size)',25.00,'200x160x25 cm',0),(9,'Bookshelf',30.00,'80x30x180 cm',0),(10,'Coffee Table',12.00,'100x50x40 cm',0),(11,'Gas Cooker',20.00,'60x60x90 cm',1),(12,'Office Chair',15.00,'70x70x120 cm',0),(13,'Computer Desktop',10.00,'45x20x45 cm',0),(14,'Bicycle',18.00,'170x25x90 cm',0),(15,'Suitcase (Large)',10.00,'80x50x30 cm',0),(16,'Portable Fan',5.00,'30x30x80 cm',1),(17,'Mirror (Full Length)',8.00,'160x40x5 cm',1),(18,'Air Conditioner Unit',35.00,'90x40x30 cm',1),(19,'Baby Crib',20.00,'120x60x100 cm',0),(20,'Treadmill',70.00,'200x80x140 cm',0),(21,'Glass Coffee Table',22.00,'100x60x45 c',0),(22,'Washing Machine',65.00,'60x60x85 cm',0),(23,'LED TV 55 inch',14.50,'124x72x8 cm',1),(24,'Double Door Fridge',80.00,'70x75x180 cm',0);
/*!40000 ALTER TABLE `products` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transport_units`
--

DROP TABLE IF EXISTS `transport_units`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `transport_units` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `unit_number` varchar(50) NOT NULL,
  `truck_id` int(11) NOT NULL,
  `driver_id` int(11) NOT NULL,
  `assistant_id` int(11) DEFAULT NULL,
  `status` int(11) NOT NULL DEFAULT 1,
  `created_date` datetime DEFAULT current_timestamp(),
  `is_active` tinyint(1) DEFAULT 1,
  PRIMARY KEY (`id`),
  UNIQUE KEY `unit_number` (`unit_number`),
  KEY `truck_id` (`truck_id`),
  KEY `driver_id` (`driver_id`),
  KEY `assistant_id` (`assistant_id`),
  CONSTRAINT `transport_units_ibfk_1` FOREIGN KEY (`truck_id`) REFERENCES `trucks` (`id`),
  CONSTRAINT `transport_units_ibfk_2` FOREIGN KEY (`driver_id`) REFERENCES `drivers` (`id`),
  CONSTRAINT `transport_units_ibfk_3` FOREIGN KEY (`assistant_id`) REFERENCES `assistants` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transport_units`
--

LOCK TABLES `transport_units` WRITE;
/*!40000 ALTER TABLE `transport_units` DISABLE KEYS */;
INSERT INTO `transport_units` VALUES (1,'UNIT-2025-001',3,9,3,1,'2025-07-11 00:07:38',1),(3,'UNIT-2025-003',4,4,1,3,'2025-07-11 00:10:11',1),(4,'UNIT-2025-004',7,7,5,2,'2025-07-11 00:27:33',1),(7,'UNIT-2025-005',2,2,7,3,'2025-07-11 00:47:46',1),(8,'UNIT-2025-008',12,8,6,1,'2025-07-11 00:48:05',1),(9,'UNIT-2025-009',9,6,2,1,'2025-07-11 00:48:11',1),(10,'UNIT-2025-010',13,6,8,1,'2025-07-11 00:48:18',1);
/*!40000 ALTER TABLE `transport_units` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `trucks`
--

DROP TABLE IF EXISTS `trucks`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `trucks` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `truck_number` varchar(50) NOT NULL,
  `model` varchar(100) NOT NULL,
  `capacity` int(11) NOT NULL,
  `license_plate` varchar(50) DEFAULT NULL,
  `status` int(11) NOT NULL DEFAULT 1,
  `created_date` datetime DEFAULT current_timestamp(),
  `is_active` tinyint(1) DEFAULT 1,
  PRIMARY KEY (`id`),
  UNIQUE KEY `truck_number` (`truck_number`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `trucks`
--

LOCK TABLES `trucks` WRITE;
/*!40000 ALTER TABLE `trucks` DISABLE KEYS */;
INSERT INTO `trucks` VALUES (2,'TRK-002','Tata Ace',1800,'DEF-5678',2,'2025-07-10 12:15:40',1),(3,'TRK-003','Isuzu NQR',3000,'GHI-9012',1,'2025-07-10 12:16:05',1),(4,'TRK-004','Hino 500 Series',4000,'JKL-3456',1,'2025-07-10 12:16:31',1),(5,'TRK-0500','Tata LPT 1618',7000,'GHI-9090',1,'2025-07-10 12:21:31',1),(7,'TRK-8888','Hino 500 Series',10000,'JKL-1111',4,'2025-07-10 12:26:00',1),(8,'TRK-0501','Tata LPT 1618',7000,'GHI-9094',4,'2025-07-10 12:26:37',0),(9,'TRK-005','Toyota Dyna',1200,'CP-TDY4567',1,'2025-07-10 15:49:55',1),(10,'TRK-0010','Tata LPT 1613',10000,'WP-TATA1122',2,'2025-07-10 15:51:30',0),(12,'TRK-006','Ashok Leyland Ecomet',2200,'WP-ALE4567',1,'2025-07-10 22:56:22',1),(13,'TRK-007','Nissan Atlas',1800,'CP-NAT7890',1,'2025-07-10 22:56:42',1),(15,'TRK-00155','Hyundai Mighty',2000,'WP-HYM2345',1,'2025-07-10 22:59:59',1);
/*!40000 ALTER TABLE `trucks` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `first_name` varchar(100) NOT NULL,
  `last_name` varchar(100) DEFAULT NULL,
  `email` varchar(200) NOT NULL,
  `password_hash` text NOT NULL,
  `user_type` int(11) NOT NULL,
  `phone` varchar(20) DEFAULT NULL,
  `address` varchar(500) DEFAULT NULL,
  `customer_number` varchar(50) DEFAULT NULL,
  `created_date` datetime DEFAULT current_timestamp(),
  `is_active` tinyint(1) DEFAULT 1,
  PRIMARY KEY (`id`),
  UNIQUE KEY `email` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (5,'lahiru ',NULL,'lahiru@rightmo.lk','ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f',1,'774772184',NULL,'CUST1010','2025-07-10 10:00:14',1),(6,'lahiru  Prabodha','','admin@eshift.com','8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92',2,'0774747218','275/2, Waduwelivitiya, Unanavititya','CUST1308','2025-07-13 08:34:33',1),(7,'lahiru prabodha1555 ',NULL,'lahiru74@test.com','8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92',1,'77477218144',NULL,'CUST1500','2025-07-15 00:28:51',1),(8,'lahiru ',NULL,'lprabodha1998@gmail.com','8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92',1,'0745869555',NULL,'CUST1520','2025-07-15 20:54:33',1),(9,'Sunil Perera ',NULL,'test455@test.com','8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92',1,'',NULL,'CUST1919','2025-07-19 19:50:19',1);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'e_shift_logistics'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-07-19 20:30:33
