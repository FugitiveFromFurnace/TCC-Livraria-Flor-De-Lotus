create database livrariaFinal;

show tables;

select * from livros;
select date(dataVenda) Data, sum(valorTotal) Total from venda group by date(dataVenda);
select * from venda;
select * from pedido;

desc livros;

select * from livros;

update livros set codigoBarras = '9788557170063' where idLivro = 59;

alter table livros add codigoBarras varchar(30) unique after tag;

drop database livrariaFinal;
create database livrariaFinal;

use livrariaFinal;

desc livros;

alter table livros modify column tag varchar(150) default null;

desc pedido;
desc venda;

select PEDIDO.idLivro ID, tituloLivro Titulo, qtdePedido Vendido, qtdeLivro Qtde_Disponivel from pedido inner join livros on pedido.idLivro = livros.idLivro inner join venda on idPedido = pedidoVenda where dataVenda >= date_sub(now(), interval 1 month) group by month(dataVenda), tituloLivro order by qtdePedido;

select date(dataVenda) Data, tituloLivro, qtdePedido from pedido inner join livros on pedido.idLivro = livros.idLivro inner join venda on idPedido = pedidoVenda group by month(Data), tituloLivro order by qtdePedido;

create table notificacao(
	idNotificacao int primary key auto_increment,
    livroNotificacao int,
    qtdeRecomendada int
);

drop table notificacao;

alter table notificacao add constraint foreign key(livroNotificacao) references livros(idLivro);

select PEDIDO.idLivro ID, tituloLivro Titulo, qtdePedido Vendido, qtdeLivro Qtde_Disponivel from pedido inner join livros on pedido.idLivro = livros.idLivro inner join venda on idPedido = pedidoVenda where dataVenda >= date_sub(now(), interval 1 month) group by month(dataVenda), tituloLivro order by qtdePedido;

update livros set qtdeLivro = 3 where idLivro = 58;

delimiter $
create procedure prc_geraNotificacao()
begin

	declare codLivro int;
    declare nomeLivro varchar(150);
    declare qtdeVenda int;
    declare qtdeDisp int;
    declare done int default false;
    
	declare carregarLivroNotificacao cursor
		for select PEDIDO.idLivro ID, tituloLivro Titulo, qtdePedido Vendido, qtdeLivro Qtde_Disponivel from pedido inner join livros on pedido.idLivro = livros.idLivro inner join venda on idPedido = pedidoVenda where dataVenda >= date_sub(now(), interval 1 month) group by month(dataVenda), tituloLivro order by qtdePedido;
    
    declare continue handler for not found set done = true;
    
	open carregarLivroNotificacao;
    delete from notificacao;
    
	lupin : loop
		fetch carregarLivroNotificacao into codLivro, nomeLivro, qtdeVenda, qtdeDisp;
		if done then
			leave lupin;
		end if;
        
        set qtdeVenda = qtdeVenda * 2;
		
		if qtdeVenda > qtdeDisp then		
			insert into notificacao(livroNotificacao, qtdeRecomendada) value(codLivro, qtdeVenda);
		end if;
	
    end loop lupin;
    
    select livroNotificacao Livro, tituloLivro Titulo, qtdeRecomendada Recomendada, qtdeLivro Disponivel from notificacao inner join livros on livroNotificacao = idLivro;
end $

delimiter ;
call prc_geraNotificacao();

select * from notificacao;
select * from livros;

select month(dataVenda) data, sum(valorTotal) valor from venda group by monthname(dataVenda);

select month(dataVenda) data, sum(valorTotal) valor from venda group by month(dataVenda);

create table notificacao(
idNotificacao int primary key auto_increment,
livroNotificacao int,
qtdeRecomendada int);

alter table notificacao add constraint foreign key(livroNotificacao) references livros(idLivro);

drop procedure prc_geraNotificacao;

select * from notificacao;

delete from notificacao;
select count(*) from notificacao;

desc notificacao;

select livroNotificacao Livro, tituloLivro Titulo, qtdeRecomendada Recomendada, qtdeLivro Disponivel from notificacao inner join livros on livroNotificacao = idLivro;