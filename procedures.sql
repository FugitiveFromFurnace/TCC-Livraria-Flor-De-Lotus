create table notificacao(
	idNotificacao int primary key auto_increment,
    livroNotificacao int,
    qtdeRecomendada int
);

delimiter $
CREATE DEFINER=`root`@`localhost` PROCEDURE `prc_geraNotificacao`()
begin

	declare codLivro int;
    declare nomeLivro varchar(150);
    declare qtdeVenda int;
    declare qtdeDisp int;
    declare done int default false;
    
	declare carregarLivroNotificacao cursor
		for select idLivroPedido ID, tituloLivro Titulo, qtdePedido Vendido, qtdeLivro Qtde_Disponivel from pedido inner join livros on idLivroPedido = idLivro inner join venda on idPedido = pedidoVenda where dataVenda >= date_sub(now(), interval 1 month) group by month(dataVenda), tituloLivro order by qtdePedido;
    
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

CREATE DEFINER=`root`@`localhost` PROCEDURE `prc_retornaPercentual`()
begin
	
	declare x decimal(10, 2);
    declare ganhosMesPassado decimal(10, 2);
	declare ganhosMesAtual decimal(10, 2);
    
    select ifnull(sum(valorTotal), 0) into ganhosMesPassado from venda where month(dataVenda) = month(now()) - 1;
    select ifnull(sum(valorTotal), 0) into ganhosMesAtual from venda where month(dataVenda) = month(now());
    
    set ganhosMesAtual = ganhosMesAtual * 100;
    set x = ganhosMesAtual / ganhosMesPassado;
    
    select concat(format(x - 100, 2), '%');
end $

CREATE DEFINER=`root`@`localhost` PROCEDURE `prc_Vender` (IN `pedidoID` INT, IN `vendedorID` INT, IN `total` DECIMAL(10,2))  begin
		
    declare codigoLivro int;     
	declare quantidade int;
	declare done int default false;
    
    declare selecionarLivros cursor
			for select idLivroPedido, qtdePedido from pedido where idPedido = pedidoID;
	
    declare continue handler for not found set done = true;
    
		open selecionarLivros;
        lupin : loop			
			fetch selecionarLivros into codigoLivro, quantidade;		
			if done then
				leave lupin;
			end if;
                        
            update livros set qtdeLivro = qtdeLivro - quantidade where idLivro = codigoLivro;
            
        end Loop lupin;
        close selecionarLivros;
        
        insert into venda(pedidoVenda, idFunc, dataVenda, valorTotal) value(pedidoID, vendedorID, date(now()), total);
        update pedido set pedidoFinalizado = 1 where idPedido = pedidoID;
    end$

DELIMITER ;

delimiter //
create procedure prc_relacionados(id int) 
 begin
	 select 0 indice , tituloLivro,capaLivro,idLivro, tag from livros where
	 (trim(substring_index(tag,'#',1))=(select substring_index(tag,'#',1) from livros where idLivro = id)) union 
	 select 1 indice,tituloLivro, capaLivro, idLivro, tag from livros where categoriaLivro =
	 (select categoriaLivro from livros where idLivro = id) and 
	 idLivro not in
	 (select idLivro from livros where (trim(substring_index(tag,'#',1))=(select substring_index(tag,'#',1) from livros where idLivro = id))) order by indice limit 7;
end //
 delimiter ;
