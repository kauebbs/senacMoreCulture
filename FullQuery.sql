use EnxamePhobosDB;

insert into genero (Descricao) values ('Animação'), ('Aventura'), ('Drama'), ('Ficção'), ('Terror');
select * from genero;

insert into filme (Titulo,Produtora,UrlImg,Classificacao_Id,Genero_Id) values ('Ekko','Riot Games','c:\\img\\lagarto.png',2,2);
select * from filme;

UPDATE filme SET  UrlImg = '~/research/img/teemoo.jpg' WHERE Id = 9;

select filme.id, titulo, produtora, urlimg, classificacao.descricao, genero.descricao from filme
inner join classificacao on classificacao_id = classificacao.id inner join genero on Genero_Id = genero.id
order by filme.id asc;

SELECT filme.Id, Titulo, Produtora, UrlImg, Classificacao.Descricao, Genero.Descricao FROM filme INNER JOIN Classificacao ON Classificacao_ID = classificacao.Id INNER JOIN Genero ON Genero_Id = Genero.id ORDER BY filme.id ASC;

DELETE FROM genero WHERE Genero.Id =  '81';

SELECT filme.id,Titulo,produtora, UrlImg, genero.descricao, classificacao.descricao from filme INNER JOIN genero ON Genero_id = Genero.id INNER JOIN classificacao ON classificacao_id = classificacao.id WHERE genero.descricao = @genero;