CREATE TABLE Complemento (
  IdComplemento INTEGER NOT NULL IDENTITY,
  IdTemplate INTEGER NOT NULL,
  Pergunta TEXT NOT NULL,
  Resposta TEXT NOT NULL,
  Usuario VARCHAR(50) NOT NULL,
  DataRegistro DATETIME NOT NULL,
  PRIMARY KEY(IdComplemento),
  INDEX Complemento_FKIndex1(IdTemplate)
);

CREATE TABLE RespostaIA (
  IdRespostaIA INTEGER NOT NULL IDENTITY,
  IdTemplate INTEGER NOT NULL,
  Descricao TEXT NOT NULL,
  Usuario VARCHAR(50) NOT NULL,
  DataRegistro DATETIME NOT NULL,
  PRIMARY KEY(IdRespostaIA),
  INDEX RespostaIA_FKIndex1(IdTemplate)
);

CREATE TABLE Template (
  IdTemplate INTEGER NOT NULL IDENTITY,
  Descricao TEXT NOT NULL,
  Usuario VARCHAR(50) NOT NULL,
  DataRegistro DATETIME NOT NULL,
  PRIMARY KEY(IdTemplate)
);

