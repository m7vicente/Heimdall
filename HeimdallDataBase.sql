BEGIN TRANSACTION

	CREATE TABLE Usuario (
		CodUsuario INT PRIMARY KEY NOT NULL IDENTITY,
		NomeCompleto VARCHAR(100) NOT NULL,
		Email VARCHAR(100) NOT NULL UNIQUE,
		Cargo VARCHAR(50),
		Senha VARCHAR(100) NOT NULL,
		Ativo BIT DEFAULT 1,
		DataCadastro DATETIME DEFAULT (GETDATE() - '02:00:00.000')
	);
GO
	CREATE TABLE Computador(
		CodComputador INT PRIMARY KEY NOT NULL IDENTITY(1000,1),
		NomePersonalizado VARCHAR(50) NOT NULL,
		NomeComputador VARCHAR(50) NOT NULL,
		NomeFrabricante VARCHAR(50) NOT NULL,
		IPV4 CHAR (15),
		VersaoFirmeware VARCHAR(30) NOT NULL,
		FKCodUsuario INT NOT NULL  FOREIGN KEY REFERENCES Usuario(CodUsuario)
	);
GO
	CREATE TABLE SistemaOperacional(
		CodSo INT PRIMARY KEY NOT NULL IDENTITY(10,1),
		NomeFrabricante VARCHAR(30),
		NomeVersao VARCHAR(30),
		Familia VARCHAR(20),
		FKCodComputador INT NOT NULL FOREIGN KEY REFERENCES Computador(CodComputador) UNIQUE,
		FKCodUsuario INT NOT NULL  FOREIGN KEY REFERENCES Usuario(CodUsuario)
	);


	CREATE TABLE Processador(
		CodProcessador INT PRIMARY KEY NOT NULL IDENTITY,
		NomeFabricante VARCHAR(50) NOT NULL,
		Modelo VARCHAR(50) NOT NULL,
		FrequenciaBase FLOAT NOT NULL,
		Nucleos INT NOT NULL,
		Serial VARCHAR(15),
		FKCodComputador INT NOT NULL FOREIGN KEY REFERENCES Computador(CodComputador) UNIQUE,
		FKCodUsuario INT NOT NULL  FOREIGN KEY REFERENCES Usuario(CodUsuario)
	);


	CREATE TABLE HistoricoEstadoProcessador(
		CodHistoricoEstado INT PRIMARY KEY NOT NULL IDENTITY,
		ProcessadorExecucao INT NOT NULL,
		FrequenciaAtual FLOAT,
		PorcentagemUltlizacao INT,
		ThreadExecucao INT,
		TempoExecucao VARCHAR(20),
		Temperatura FLOAT,
		DataEstado DATETIME DEFAULT (GETDATE() - '02:00:00.000'),
		FKCodProcessador INT NOT NULL  FOREIGN KEY REFERENCES Processador(CodProcessador) ,
		FKCodComputador INT NOT NULL FOREIGN KEY REFERENCES Computador(CodComputador),
		FKCodUsuario INT NOT NULL  FOREIGN KEY REFERENCES Usuario(CodUsuario)
	);


	CREATE TABLE HistoricoEstadoRam(
		CodEstadoRam INT PRIMARY KEY NOT NULL IDENTITY,
		Ultilizada FLOAT,
		Disponivel FLOAT,
		SwapTotal FLOAT,
		SwapDisponivel FLOAT,
		QuantidadeTotal FLOAT,
		PorcentagemUltilizada INT,
		DataEstado DATETIME DEFAULT (GETDATE() - '02:00:00.000'),
		FKCodComputador INT NOT NULL FOREIGN KEY REFERENCES Computador(CodComputador),
		FKCodUsuario INT NOT NULL  FOREIGN KEY REFERENCES Usuario(CodUsuario)
	);



	CREATE TABLE Armazenamento(
			CodUUId CHAR(36) PRIMARY KEY NOT NULL,
			TipoArmazenamento VARCHAR(50),
			CapacidadeTotal FLOAT NOT NULL,
			FKCodComputador INT NOT NULL FOREIGN KEY REFERENCES Computador(CodComputador),
			FKCodUsuario INT NOT NULL  FOREIGN KEY REFERENCES Usuario(CodUsuario)
	);

	CREATE TABLE HistoricoEstadoArmazenamento(
			CodHistoricoArmazenamento INT PRIMARY KEY NOT NULL IDENTITY,
			CapacidadeUltilizada FLOAT NOT NULL,
			LetraLocal CHAR(4),
			DataEstado DATETIME DEFAULT (GETDATE() - '02:00:00.000'),
			FKCodUUId CHAR(36) NOT NULL FOREIGN KEY REFERENCES Armazenamento(CodUUId),
			FKCodComputador INT NOT NULL FOREIGN KEY REFERENCES Computador(CodComputador),
			FKCodUsuario INT NOT NULL  FOREIGN KEY REFERENCES Usuario(CodUsuario)
	);

	COMMIT TRANSACTION

-- LIMPAR O BANCO

DROP TABLE HistoricoEstadoArmazenamento;

DROP TABLE HistoricoEstadoProcessador;

DROP TABLE HistoricoEstadoRam;

GO

DROP TABLE Armazenamento;

DROP TABLE Processador;

DROP TABLE SistemaOperacional;

DROP TABLE computador;

GO

DROP TABLE Usuario;

-- ANTIGA TABELA DE DE DISCO MASSIVO, SUBSTITUIDA PELA TABELA ARMAZENAMENTO E HITORICO ARMAZENAMENTO

--	CREATE TABLE DiscoMassivo(
--		CodDiscoMassivo INT PRIMARY KEY NOT NULL IDENTITY,
--		Modelo VARCHAR(10),
--		CapacidadeTotal FLOAT,
--		CapacidadeUltilizada FLOAT,
--		Identificador CHAR(5),
--		FKCodComputador INT NOT NULL FOREIGN KEY REFERENCES Computador(CodComputador),
--		FKCodUsuario INT NOT NULL  FOREIGN KEY REFERENCES Usuario(CodUsuario)
--	);
--GO
	
--	CREATE TABLE HistoricoDiscoMassivo(
--		CodHistoricoDiscoMassivo INT PRIMARY KEY NOT NULL IDENTITY,
--		TempoResposta INT,
--		VelocidadeLeitura INT,
--		TempoAtividade INT,
--		VelocidadeEscrita INT,
--		DataEstado DATETIME DEFAULT GETDATE(),
--		FKCodDiscoMassivo INT FOREIGN KEY REFERENCES DiscoMassivo(CodDiscoMassivo),
--		FKCodComputador INT NOT NULL FOREIGN KEY REFERENCES Computador(CodComputador),
--		FKCodUsuario INT NOT NULL  FOREIGN KEY REFERENCES Usuario(CodUsuario)
--	);

--	DROP TABLE HistoricoDiscoMassivo
--	GO
--	DROP TABLE DiscoMassivo
--	GO

