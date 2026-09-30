CREATE TABLE Categoria(
    Id      int PRIMARY KEY  AUTO_INCREMENT,
    Nombre  nvarchar(50)    NOT NULL,
    TipoOperacionId int NOT NULL,
    UsuarioId   int NOT NULL,
    CONSTRAINT fk_categoria_tipo_operacion FOREIGN KEY (TipoOperacionId) REFERENCES TipoOperacion(Id),
    CONSTRAINT fk_categoria_usuario FOREIGN KEY (UsuarioId) REFERENCES Usuario(Id)
);