-- phpMyAdmin SQL Dump
-- version 5.2.3
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 30-10-2026 a las 06:01:37
-- Versión del servidor: 10.11.16-MariaDB
-- Versión de PHP: 8.3.36

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `gestor_gastos`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `categoria`
--

CREATE TABLE `categoria` (
  `Id` int(11) NOT NULL,
  `Nombre` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cuenta`
--

CREATE TABLE `cuenta` (
  `Id` int(11) NOT NULL,
  `Nombre` varchar(100) NOT NULL,
  `NumeroCuenta` varchar(100) NOT NULL,
  `Saldo` decimal(18,2) NOT NULL DEFAULT 0.00,
  `UsuarioId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `etiqueta`
--

CREATE TABLE `etiqueta` (
  `Id` int(11) NOT NULL,
  `Nombre` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `gasto`
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

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `gasto_etiqueta`
--

CREATE TABLE `gasto_etiqueta` (
  `Id` int(11) NOT NULL,
  `GastoId` int(11) NOT NULL,
  `EtiquetaId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ingreso`
--

CREATE TABLE `ingreso` (
  `Id` int(11) NOT NULL,
  `Descripcion` varchar(500) NOT NULL,
  `Valor` decimal(18,2) NOT NULL,
  `Fecha` date NOT NULL,
  `CuentaId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `meta_ahorro`
--

CREATE TABLE `meta_ahorro` (
  `Id` int(11) NOT NULL,
  `Nombre` varchar(100) NOT NULL,
  `MontoObjetivo` decimal(18,2) NOT NULL,
  `MontoActual` decimal(18,2) NOT NULL,
  `FechaLimite` date NOT NULL,
  `CuentaId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `metodo_pago`
--

CREATE TABLE `metodo_pago` (
  `Id` int(11) NOT NULL,
  `Nombre` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `presupuesto`
--

CREATE TABLE `presupuesto` (
  `Id` int(11) NOT NULL,
  `ValorLimite` decimal(18,2) NOT NULL,
  `FechaInicio` date NOT NULL,
  `FechaFin` date NOT NULL,
  `CategoriaId` int(11) NOT NULL,
  `UsuarioId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuario`
--

CREATE TABLE `usuario` (
  `Id` int(11) NOT NULL,
  `Nombre` varchar(100) NOT NULL,
  `Apellido` varchar(100) NOT NULL,
  `Documento` varchar(20) NOT NULL,
  `ContrasenaHash` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `categoria`
--
ALTER TABLE `categoria`
  ADD PRIMARY KEY (`Id`);

--
-- Indices de la tabla `cuenta`
--
ALTER TABLE `cuenta`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `NumeroCuenta` (`NumeroCuenta`),
  ADD KEY `UsuarioId` (`UsuarioId`);

--
-- Indices de la tabla `etiqueta`
--
ALTER TABLE `etiqueta`
  ADD PRIMARY KEY (`Id`);

--
-- Indices de la tabla `gasto`
--
ALTER TABLE `gasto`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `MetodopagoId` (`MetodoPagoId`),
  ADD KEY `CategoriaId` (`CategoriaId`),
  ADD KEY `CuentaId` (`CuentaId`);

--
-- Indices de la tabla `gasto_etiqueta`
--
ALTER TABLE `gasto_etiqueta`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `GastoId` (`GastoId`,`EtiquetaId`),
  ADD KEY `EtiquetaId` (`EtiquetaId`);

--
-- Indices de la tabla `ingreso`
--
ALTER TABLE `ingreso`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `CuentaId` (`CuentaId`);

--
-- Indices de la tabla `meta_ahorro`
--
ALTER TABLE `meta_ahorro`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `CuentaId` (`CuentaId`);

--
-- Indices de la tabla `metodo_pago`
--
ALTER TABLE `metodo_pago`
  ADD PRIMARY KEY (`Id`);

--
-- Indices de la tabla `presupuesto`
--
ALTER TABLE `presupuesto`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `CategoriaId` (`CategoriaId`),
  ADD KEY `UsuarioId` (`UsuarioId`);

--
-- Indices de la tabla `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `Documento` (`Documento`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `categoria`
--
ALTER TABLE `categoria`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `cuenta`
--
ALTER TABLE `cuenta`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `etiqueta`
--
ALTER TABLE `etiqueta`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `gasto`
--
ALTER TABLE `gasto`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `gasto_etiqueta`
--
ALTER TABLE `gasto_etiqueta`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `ingreso`
--
ALTER TABLE `ingreso`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `meta_ahorro`
--
ALTER TABLE `meta_ahorro`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `metodo_pago`
--
ALTER TABLE `metodo_pago`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `presupuesto`
--
ALTER TABLE `presupuesto`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `usuario`
--
ALTER TABLE `usuario`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `cuenta`
--
ALTER TABLE `cuenta`
  ADD CONSTRAINT `cuenta_ibfk_1` FOREIGN KEY (`UsuarioId`) REFERENCES `usuario` (`Id`);

--
-- Filtros para la tabla `gasto`
--
ALTER TABLE `gasto`
  ADD CONSTRAINT `gasto_ibfk_1` FOREIGN KEY (`MetodoPagoId`) REFERENCES `metodo_pago` (`Id`),
  ADD CONSTRAINT `gasto_ibfk_2` FOREIGN KEY (`CategoriaId`) REFERENCES `categoria` (`Id`),
  ADD CONSTRAINT `gasto_ibfk_3` FOREIGN KEY (`CuentaId`) REFERENCES `cuenta` (`Id`);

--
-- Filtros para la tabla `gasto_etiqueta`
--
ALTER TABLE `gasto_etiqueta`
  ADD CONSTRAINT `gasto_etiqueta_ibfk_1` FOREIGN KEY (`GastoId`) REFERENCES `gasto` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `gasto_etiqueta_ibfk_2` FOREIGN KEY (`EtiquetaId`) REFERENCES `etiqueta` (`Id`) ON DELETE CASCADE;

--
-- Filtros para la tabla `ingreso`
--
ALTER TABLE `ingreso`
  ADD CONSTRAINT `ingreso_ibfk_1` FOREIGN KEY (`CuentaId`) REFERENCES `cuenta` (`Id`);

--
-- Filtros para la tabla `meta_ahorro`
--
ALTER TABLE `meta_ahorro`
  ADD CONSTRAINT `meta_ahorro_ibfk_1` FOREIGN KEY (`CuentaId`) REFERENCES `cuenta` (`Id`);

--
-- Filtros para la tabla `presupuesto`
--
ALTER TABLE `presupuesto`
  ADD CONSTRAINT `presupuesto_ibfk_1` FOREIGN KEY (`CategoriaId`) REFERENCES `categoria` (`Id`),
  ADD CONSTRAINT `presupuesto_ibfk_2` FOREIGN KEY (`UsuarioId`) REFERENCES `usuario` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
