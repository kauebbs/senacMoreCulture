use EnxamePhobosDB;
select * from usuario;
select * from tipousuario;

insert into tipoUsuario (Descricao) values ('Administrador'),('Outros');


insert into usuario (Nome,Email,Senha,DataNascUsuario,TipoUsuario_Id) values ('Uil','uil@email.com','123456','19800229',1),('Robsu','robsu@email.com','123457','19600622',2);

/*Autenticar*/
select Nome,Senha,TipoUsuario_Id from Usuario where Nome = 'Robsu' and Senha = '123457';

/*Listar*/
select Usuario.Id, Nome, Email, Senha, DataNascUsuario, Descricao from Usuario inner join TipoUsuario on Usuario.TipoUsuario_Id = TipoUsuario.Id order by Usuario.Id asc;

select * from usuario where usuario.nome = 'uil';
select * from usuario where usuario.id = '1';

insert into usuario (Nome,Email,Senha,DataNascUsuario,TipoUsuario_Id) values ('Cylvia','cylvia@email.com','111111','20010329',2),('Infernia','infernia@email.com','222222','19921016',1),('Samael','samael@email.com','333333','19880607',2);

update Usuario set Nome = 'Miguel', Email = 'miguel@email.com', Senha = '181818', DataNascUsuario = '20060118' where Usuario.Id = 8;

DELETE FROM usuario WHERE Usuario.Id = 8;

