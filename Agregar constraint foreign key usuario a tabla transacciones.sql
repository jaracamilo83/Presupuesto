ALTER TABLE Transacciones
MODIFY COLUMN UsuarioId int;
ALTER TABLE Transacciones
ADD CONSTRAINT fk_transacciones_usuario FOREIGN KEY (UsuarioId) REFERENCES Usuario(Id);