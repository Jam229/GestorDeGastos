-- phpMyAdmin SQL Dump
-- version 5.2.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 09, 2026 at 07:35 PM
-- Server version: 10.11.16-MariaDB
-- PHP Version: 8.3.36

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `gestor_gastos`
--

-- --------------------------------------------------------

--
-- Table structure for table `categoria`
--

CREATE TABLE `categoria` (
  `Id` int(11) NOT NULL,
  `Nombre` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `categoria`
--

INSERT INTO `categoria` (`Id`, `Nombre`) VALUES
(2, 'Alimentación'),
(3, 'Transporte'),
(4, 'Vivienda'),
(5, 'Entretenimiento'),
(6, 'Servicios');

-- --------------------------------------------------------

--
-- Table structure for table `cuenta`
--

CREATE TABLE `cuenta` (
  `Id` int(11) NOT NULL,
  `Nombre` varchar(100) NOT NULL,
  `NumeroCuenta` varchar(100) NOT NULL,
  `Saldo` decimal(18,2) NOT NULL DEFAULT 0.00,
  `UsuarioId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `cuenta`
--

INSERT INTO `cuenta` (`Id`, `Nombre`, `NumeroCuenta`, `Saldo`, `UsuarioId`) VALUES
(5, 'Bancolombia ahorros', '123456789', 500000.00, 5),
(6, 'Nequi', '3001234567', 200000.00, 5),
(7, 'Davivienda nómina', '987654321', 1000000.00, 6);

-- --------------------------------------------------------

--
-- Table structure for table `etiqueta`
--

CREATE TABLE `etiqueta` (
  `Id` int(11) NOT NULL,
  `Nombre` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `etiqueta`
--

INSERT INTO `etiqueta` (`Id`, `Nombre`) VALUES
(2, 'Recurrente'),
(4, 'Imprevisto'),
(5, 'Compartido'),
(6, 'Antojo'),
(7, 'Trabajo'),
(8, 'Vacaciones'),
(9, 'Suscripcion'),
(10, 'Regalo');

-- --------------------------------------------------------

--
-- Table structure for table `gasto`
--

CREATE TABLE `gasto` (
  `Id` int(11) NOT NULL,
  `Descripcion` varchar(500) NOT NULL,
  `Valor` decimal(18,2) NOT NULL,
  `Fecha` date NOT NULL,
  `MetodoPagoId` int(11) NOT NULL,
  `CategoriaId` int(11) NOT NULL,
  `CuentaId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `gasto`
--

INSERT INTO `gasto` (`Id`, `Descripcion`, `Valor`, `Fecha`, `MetodoPagoId`, `CategoriaId`, `CuentaId`) VALUES
(3, 'Almuerzo', 25000.00, '2026-10-31', 2, 2, 5),
(6, 'Arriendo', 1500000.00, '2026-10-31', 2, 4, 5),
(7, 'Mercado semanal', 180000.00, '2026-10-12', 3, 2, 5),
(8, 'Bus y metro', 60000.00, '2026-10-08', 2, 3, 5),
(9, 'Gasolina', 90000.00, '2026-10-20', 4, 3, 5),
(10, 'Cine con amigos', 45000.00, '2026-10-25', 3, 5, 5),
(11, 'Internet', 80000.00, '2026-10-05', 3, 6, 5),
(12, 'Domicilio', 35000.00, '2026-10-18', 3, 2, 6),
(13, 'Mercado septiembre', 150000.00, '2026-09-30', 3, 2, 5),
(14, 'Almuerzo noviembre', 30000.00, '2026-11-01', 2, 2, 5),
(15, 'Mercado Luis', 500000.00, '2026-10-15', 3, 2, 7);

-- --------------------------------------------------------

--
-- Table structure for table `gasto_etiqueta`
--

CREATE TABLE `gasto_etiqueta` (
  `Id` int(11) NOT NULL,
  `GastoId` int(11) NOT NULL,
  `EtiquetaId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `gasto_etiqueta`
--

INSERT INTO `gasto_etiqueta` (`Id`, `GastoId`, `EtiquetaId`) VALUES
(5, 3, 2),
(1, 3, 4),
(8, 6, 2),
(7, 10, 5),
(6, 10, 6),
(10, 11, 2),
(9, 11, 9);

-- --------------------------------------------------------

--
-- Table structure for table `ingreso`
--

CREATE TABLE `ingreso` (
  `Id` int(11) NOT NULL,
  `Descripcion` varchar(500) NOT NULL,
  `Valor` decimal(18,2) NOT NULL,
  `Fecha` date NOT NULL,
  `CuentaId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `ingreso`
--

INSERT INTO `ingreso` (`Id`, `Descripcion`, `Valor`, `Fecha`, `CuentaId`) VALUES
(2, 'Salario octubre', 2500000.00, '2026-10-30', 5),
(4, 'Salario Septiembre', 2500000.00, '2026-09-30', 5),
(5, 'Pago horas extra', 150000.00, '2026-10-15', 5),
(6, 'Venta de libros', 120000.00, '2026-10-22', 6),
(7, 'Salario Luis', 3000000.00, '2026-10-15', 7),
(8, 'Bono noviembre', 800000.00, '2026-11-01', 5);

-- --------------------------------------------------------

--
-- Table structure for table `meta_ahorro`
--

CREATE TABLE `meta_ahorro` (
  `Id` int(11) NOT NULL,
  `Nombre` varchar(100) NOT NULL,
  `MontoObjetivo` decimal(18,2) NOT NULL,
  `MontoActual` decimal(18,2) NOT NULL,
  `FechaLimite` date NOT NULL,
  `CuentaId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `meta_ahorro`
--

INSERT INTO `meta_ahorro` (`Id`, `Nombre`, `MontoObjetivo`, `MontoActual`, `FechaLimite`, `CuentaId`) VALUES
(1, 'Viaje a Cartagena', 3000000.00, 750000.00, '2026-12-15', 5),
(2, 'Computador nuevo', 4000000.00, 4000000.00, '2026-12-31', 5),
(3, 'Fondo de emergencia', 1000000.00, 400000.00, '2027-03-31', 6);

-- --------------------------------------------------------

--
-- Table structure for table `metodo_pago`
--

CREATE TABLE `metodo_pago` (
  `Id` int(11) NOT NULL,
  `Nombre` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `metodo_pago`
--

INSERT INTO `metodo_pago` (`Id`, `Nombre`) VALUES
(2, 'Efectivo'),
(3, 'Tarjeta débito'),
(4, 'Tarjeta crédito');

-- --------------------------------------------------------

--
-- Table structure for table `presupuesto`
--

CREATE TABLE `presupuesto` (
  `Id` int(11) NOT NULL,
  `ValorLimite` decimal(18,2) NOT NULL,
  `FechaInicio` date NOT NULL,
  `FechaFin` date NOT NULL,
  `CategoriaId` int(11) NOT NULL,
  `UsuarioId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `presupuesto`
--

INSERT INTO `presupuesto` (`Id`, `ValorLimite`, `FechaInicio`, `FechaFin`, `CategoriaId`, `UsuarioId`) VALUES
(1, 300000.00, '2026-11-01', '2026-11-30', 2, 5),
(2, 300000.00, '2026-10-01', '2026-10-31', 2, 5),
(3, 120000.00, '2026-10-01', '2026-10-31', 3, 5),
(4, 200000.00, '2026-10-01', '2026-10-31', 5, 5);

-- --------------------------------------------------------

--
-- Table structure for table `usuario`
--

CREATE TABLE `usuario` (
  `Id` int(11) NOT NULL,
  `Nombre` varchar(100) NOT NULL,
  `Apellido` varchar(100) NOT NULL,
  `Documento` varchar(20) NOT NULL,
  `Correo` varchar(100) NOT NULL,
  `ContrasenaHash` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `usuario`
--

INSERT INTO `usuario` (`Id`, `Nombre`, `Apellido`, `Documento`, `Correo`, `ContrasenaHash`) VALUES
(5, 'Ana', 'Torres', '1000000001', 'ana.torres@example.com', '600000.z5+AWtOQW8hMBRfujVrMHA==.3Z9W9zAbQf+JxrPC1U//jRLmQaeuJpvnBwmmmriAhdE='),
(6, 'Luis', 'Gómez', '1000000002', 'luis.gomez@example.com', '600000.bTczAgEUIBZrrJrndhYm9g==.x+tvq5Oz/5QdfFLmFczXo2s+O68mPhdf1kHlCJvTtiE='),
(7, 'Carla', 'Ruiz', '1000000003', 'carla.ruiz@example.com', '600000.wZI8H3dRLirBFbrZGwEK6g==.1lEf0JCikvmv1s1uZuAHpRpaw37+U8PIWMqyXMuuPfE=');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `categoria`
--
ALTER TABLE `categoria`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `cuenta`
--
ALTER TABLE `cuenta`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `NumeroCuenta` (`NumeroCuenta`),
  ADD KEY `UsuarioId` (`UsuarioId`);

--
-- Indexes for table `etiqueta`
--
ALTER TABLE `etiqueta`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `gasto`
--
ALTER TABLE `gasto`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `MetodopagoId` (`MetodoPagoId`),
  ADD KEY `CategoriaId` (`CategoriaId`),
  ADD KEY `CuentaId` (`CuentaId`);

--
-- Indexes for table `gasto_etiqueta`
--
ALTER TABLE `gasto_etiqueta`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `GastoId` (`GastoId`,`EtiquetaId`),
  ADD KEY `EtiquetaId` (`EtiquetaId`);

--
-- Indexes for table `ingreso`
--
ALTER TABLE `ingreso`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `CuentaId` (`CuentaId`);

--
-- Indexes for table `meta_ahorro`
--
ALTER TABLE `meta_ahorro`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `CuentaId` (`CuentaId`);

--
-- Indexes for table `metodo_pago`
--
ALTER TABLE `metodo_pago`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `presupuesto`
--
ALTER TABLE `presupuesto`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `CategoriaId` (`CategoriaId`),
  ADD KEY `UsuarioId` (`UsuarioId`);

--
-- Indexes for table `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `Documento` (`Documento`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `categoria`
--
ALTER TABLE `categoria`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `cuenta`
--
ALTER TABLE `cuenta`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `etiqueta`
--
ALTER TABLE `etiqueta`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `gasto`
--
ALTER TABLE `gasto`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT for table `gasto_etiqueta`
--
ALTER TABLE `gasto_etiqueta`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `ingreso`
--
ALTER TABLE `ingreso`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `meta_ahorro`
--
ALTER TABLE `meta_ahorro`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `metodo_pago`
--
ALTER TABLE `metodo_pago`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `presupuesto`
--
ALTER TABLE `presupuesto`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `usuario`
--
ALTER TABLE `usuario`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `cuenta`
--
ALTER TABLE `cuenta`
  ADD CONSTRAINT `cuenta_ibfk_1` FOREIGN KEY (`UsuarioId`) REFERENCES `usuario` (`Id`);

--
-- Constraints for table `gasto`
--
ALTER TABLE `gasto`
  ADD CONSTRAINT `gasto_ibfk_1` FOREIGN KEY (`MetodoPagoId`) REFERENCES `metodo_pago` (`Id`),
  ADD CONSTRAINT `gasto_ibfk_2` FOREIGN KEY (`CategoriaId`) REFERENCES `categoria` (`Id`),
  ADD CONSTRAINT `gasto_ibfk_3` FOREIGN KEY (`CuentaId`) REFERENCES `cuenta` (`Id`);

--
-- Constraints for table `gasto_etiqueta`
--
ALTER TABLE `gasto_etiqueta`
  ADD CONSTRAINT `gasto_etiqueta_ibfk_1` FOREIGN KEY (`GastoId`) REFERENCES `gasto` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `gasto_etiqueta_ibfk_2` FOREIGN KEY (`EtiquetaId`) REFERENCES `etiqueta` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `ingreso`
--
ALTER TABLE `ingreso`
  ADD CONSTRAINT `ingreso_ibfk_1` FOREIGN KEY (`CuentaId`) REFERENCES `cuenta` (`Id`);

--
-- Constraints for table `meta_ahorro`
--
ALTER TABLE `meta_ahorro`
  ADD CONSTRAINT `meta_ahorro_ibfk_1` FOREIGN KEY (`CuentaId`) REFERENCES `cuenta` (`Id`);

--
-- Constraints for table `presupuesto`
--
ALTER TABLE `presupuesto`
  ADD CONSTRAINT `presupuesto_ibfk_1` FOREIGN KEY (`CategoriaId`) REFERENCES `categoria` (`Id`),
  ADD CONSTRAINT `presupuesto_ibfk_2` FOREIGN KEY (`UsuarioId`) REFERENCES `usuario` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
