-- =================================================================================
-- SCRIPT DE BASE DE DATOS RELACIONAL: ARENA ELEMENTAL (POO - C# WINDOWS FORMS)
-- Diseno Normalizado con Llaves Primarias (PK) y Llaves Foraneas (FK)
-- =================================================================================

CREATE DATABASE ArenaElementalDB;
GO

USE ArenaElementalDB;
GO

-- 1. Tabla de Jugadores (Estadisticas Historicas)
CREATE TABLE Jugadores (
    IdJugador INT IDENTITY(1,1) PRIMARY KEY,
    NombreUsuario VARCHAR(60) NOT NULL UNIQUE,
    PartidasJugadas INT NOT NULL DEFAULT 0,
    Victorias INT NOT NULL DEFAULT 0,
    Derrotas INT NOT NULL DEFAULT 0,
    PorcentajeExito DECIMAL(5,2) NOT NULL DEFAULT 0.00
);

-- 2. Tabla de Cartas de Personaje (12 Personajes: 3 por cada faccion, HP + DEF + ATK = 100)
CREATE TABLE Personajes (
    IdPersonaje INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL UNIQUE,
    Elemento VARCHAR(20) NOT NULL,
    VidaBase INT NOT NULL,
    DefensaBase INT NOT NULL,
    AtaqueBase INT NOT NULL,
    EnergiaInicial INT NOT NULL DEFAULT 2,
    Empatia INT NOT NULL,
    NombreHabilidad VARCHAR(60) NOT NULL,
    Descripcion VARCHAR(200) NOT NULL,
    CONSTRAINT CHK_Balance100 CHECK ((VidaBase + DefensaBase + AtaqueBase) = 100)
);

-- 3. Tabla de Cartas de Escenario (4 Escenarios: 1 asociado a cada faccion)
CREATE TABLE Cartas_Escenario (
    IdEscenario INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(60) NOT NULL UNIQUE,
    ElementoFavorecido VARCHAR(20) NOT NULL,
    ElementoPenalizado VARCHAR(20) NOT NULL,
    BonoAtaque INT NOT NULL,
    BonoDefensa INT NOT NULL,
    UmbralEmpatia INT NOT NULL DEFAULT 75,
    Descripcion VARCHAR(200) NOT NULL
);

-- 4. Tabla de Equipos / Mazos de 5 Cartas por Jugador (Relacion FK con Jugadores y Personajes)
CREATE TABLE Equipos (
    IdEquipo INT IDENTITY(1,1) PRIMARY KEY,
    IdJugador INT NOT NULL,
    NombrePersonaje VARCHAR(50) NOT NULL,
    OrdenRelevo INT NOT NULL CHECK (OrdenRelevo BETWEEN 1 AND 5),
    CONSTRAINT FK_Equipos_Jugadores FOREIGN KEY (IdJugador) REFERENCES Jugadores(IdJugador) ON DELETE CASCADE,
    CONSTRAINT FK_Equipos_Personajes FOREIGN KEY (NombrePersonaje) REFERENCES Personajes(Nombre)
);

-- 5. Tabla de Estadisticas de Partidas (Historial Relacional de Batallas)
CREATE TABLE Estadisticas_Partidas (
    IdPartida INT IDENTITY(1,1) PRIMARY KEY,
    FechaHora DATETIME NOT NULL DEFAULT GETDATE(),
    Jugador1 VARCHAR(60) NOT NULL,
    Jugador2 VARCHAR(60) NOT NULL,
    Ganador VARCHAR(60) NOT NULL,
    Escenario VARCHAR(60) NOT NULL,
    TotalTurnos INT NOT NULL,
    TerremotosOcurridos INT NOT NULL DEFAULT 0
);
GO

-- =================================================================================
-- POBLADO INICIAL DEL CATALOGO DE 16 CARTAS (12 PERSONAJES + 4 ESCENARIOS)
-- =================================================================================

-- Faccion Agua (3 Pokemon - Origen: Estadio Cascada - Suma = 100)
INSERT INTO Personajes (Nombre, Elemento, VidaBase, DefensaBase, AtaqueBase, EnergiaInicial, Empatia, NombreHabilidad, Descripcion) VALUES
('Blastoise', 'Agua', 50, 30, 20, 2, 78, 'Hidrobomba Drenadora', 'Origen: Estadio Cascada (Kanto). Pokemon de agua con canones hidraulicos que restaura vida y drena energia.'),
('Gyarados', 'Agua', 55, 20, 25, 2, 82, 'Acua Cola Curativa', 'Origen: Fosas Abisales del Estadio Cascada. Coloso de los mares de gran vitalidad y empatia elemental.'),
('Vaporeon', 'Agua', 45, 30, 25, 2, 70, 'Marea Acida', 'Origen: Bahias Cristalinas del Estadio Cascada. Evolucion acuatica que se funde con el agua para resistir y contraatacar.');

-- Faccion Fuego (3 Pokemon - Origen: Volcan Cinnabar - Suma = 100)
INSERT INTO Personajes (Nombre, Elemento, VidaBase, DefensaBase, AtaqueBase, EnergiaInicial, Empatia, NombreHabilidad, Descripcion) VALUES
('Charizard', 'Fuego', 40, 20, 40, 2, 62, 'Anillo Igneo', 'Origen: Crater del Volcan Cinnabar. Dragon de fuego cuyas llamas funden cualquier roca o escudo.'),
('Arcanine', 'Fuego', 45, 20, 35, 2, 75, 'Envite Igneo', 'Origen: Llanuras Geotermicas de Cinnabar. Pokemon legendario veloz con ataque ardiente de alto impacto.'),
('Moltres', 'Fuego', 50, 20, 30, 2, 68, 'Llamarada Solar', 'Origen: Caldera Sagrada del Volcan Cinnabar. Ave legendaria del fuego que causa quemaduras directas.');

-- Faccion Tierra (3 Pokemon - Origen: Canon Rocoso - Suma = 100)
INSERT INTO Personajes (Nombre, Elemento, VidaBase, DefensaBase, AtaqueBase, EnergiaInicial, Empatia, NombreHabilidad, Descripcion) VALUES
('Groudon', 'Tierra', 55, 30, 15, 2, 85, 'Filo del Abismo', 'Origen: Abismos Tectonicos del Canon Rocoso. Titan continental que invierte los terremotos en curacion.'),
('Golem', 'Tierra', 50, 35, 15, 2, 80, 'Roca Afilada', 'Origen: Cumbres Graniticas del Canon Rocoso. Coraza de roca pura con la defensa mas alta de la arena.'),
('Tyranitar', 'Tierra', 55, 25, 20, 2, 76, 'Avalancha Sismica', 'Origen: Cordillera Acorazada del Canon Rocoso. Coloso capaz de derribar montanas y escudos rivales.');

-- Faccion Aire (3 Pokemon - Origen: Torre Celeste - Suma = 100)
INSERT INTO Personajes (Nombre, Elemento, VidaBase, DefensaBase, AtaqueBase, EnergiaInicial, Empatia, NombreHabilidad, Descripcion) VALUES
('Rayquaza', 'Aire', 45, 25, 30, 2, 74, 'Ascenso Draco', 'Origen: Cuspide Estratosferica de la Torre Celeste. Guardian de los cielos cuyos ataques perforan el escudo rival.'),
('Pidgeot', 'Aire', 50, 25, 25, 2, 80, 'Vendaval Celeste', 'Origen: Corrientes de Altitud de la Torre Celeste. Maestro del viento que roba energia con rafagas supersonicas.'),
('Lugia', 'Aire', 40, 25, 35, 2, 66, 'Aerochorro', 'Origen: Santuario de las Tormentas en la Torre Celeste. Guardian de las tormentas con ataque aereo devastador.');

-- 4 Cartas de Escenario (Arenas Pokemon)
INSERT INTO Cartas_Escenario (Nombre, ElementoFavorecido, ElementoPenalizado, BonoAtaque, BonoDefensa, UmbralEmpatia, Descripcion) VALUES
('Estadio Cascada', 'Agua', 'Fuego', 5, 4, 75, 'Potencia a los Pokemon de Agua (+5 ATK) y debilita a Fuego.'),
('Volcan Cinnabar', 'Fuego', 'Aire', 5, 3, 75, 'Potencia a los Pokemon de Fuego (+5 ATK) y debilita a Aire.'),
('Canon Rocoso', 'Tierra', 'Agua', 5, 6, 75, 'Potencia a los Pokemon de Tierra (+5 ATK) y debilita a Agua.'),
('Torre Celeste', 'Aire', 'Tierra', 5, 4, 75, 'Potencia a los Pokemon de Aire (+5 ATK) y debilita a Tierra.');

-- Jugadores iniciales
INSERT INTO Jugadores (NombreUsuario, PartidasJugadas, Victorias, Derrotas, PorcentajeExito) VALUES
('Jugador 1', 0, 0, 0, 0.00),
('Jugador 2', 0, 0, 0, 0.00),
('Maestro Elemental (CPU)', 0, 0, 0, 0.00);
GO
