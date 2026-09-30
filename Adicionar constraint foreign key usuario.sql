ALTER TABLE TiposCuentas
ADD CONSTRAINT fk_tipos_cuentas_usuario FOREIGN KEY (UsuarioId) REFERENCES Usuario(id);