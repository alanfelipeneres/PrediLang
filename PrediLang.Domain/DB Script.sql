--DROP TABLE Resposta;
--DROP TABLE Complemento;
--DROP TABLE Template;

USE PrediLang;

CREATE TABLE Template (
  IdTemplate INTEGER NOT NULL IDENTITY,
  Descricao TEXT NOT NULL,
  Usuario VARCHAR(50) NOT NULL,
  DataRegistro DATETIME NOT NULL,
  CONSTRAINT PK_Template PRIMARY KEY(IdTemplate),
);

CREATE TABLE Resposta (
  IdResposta INTEGER NOT NULL IDENTITY,
  IdTemplate INTEGER NOT NULL,
  Descricao TEXT NOT NULL,
  Usuario VARCHAR(50) NOT NULL,
  DataRegistro DATETIME NOT NULL,
  CONSTRAINT PK_Resposta PRIMARY KEY(IdResposta),
  CONSTRAINT FK_Resposta_Template FOREIGN KEY(IdTemplate)
	REFERENCES Template(IdTemplate),
  INDEX IX_Resposta_Template(IdTemplate)
);

CREATE TABLE Complemento (
  IdComplemento INTEGER NOT NULL IDENTITY,
  IdTemplate INTEGER NOT NULL,
  Pergunta TEXT NOT NULL,
  Resposta TEXT NOT NULL,
  Usuario VARCHAR(50) NOT NULL,
  DataRegistro DATETIME NOT NULL,
  CONSTRAINT PK_Complemento PRIMARY KEY(IdComplemento),
  CONSTRAINT FK_Complemento_Template FOREIGN KEY(IdTemplate)
	REFERENCES Template(IdTemplate),
  INDEX IX_Complemento_Template(IdTemplate)
);
