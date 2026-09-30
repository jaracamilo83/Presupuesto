CREATE TABLE usuario(
    Id  int PRIMARY KEY AUTO_INCREMENT,
    Email   nvarchar(256)   NOT NULL,
    EmailNormalizado    nvarchar(256) NOT NULL,
    PasswordHash  nvarchar(4000)  NOT NULL
);