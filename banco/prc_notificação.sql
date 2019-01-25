create table notificacao(
	idNotificacao int primary key auto_increment,
    livroNotificacao int,
    qtdeRecomendada int
);

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