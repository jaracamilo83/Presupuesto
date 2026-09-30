ALTER TABLE Transacciones
ADD COLUMN CategoriaId int NOT NULL;
ALTER TABLE Transacciones
ADD CONSTRAINT fk_transacciones_categoria FOREIGN KEY (CategoriaId) REFERENCES Categoria(Id);