create view view_meses as
	select concat(case monthname(dataVenda)
    when 'Janaury' then 'Jan.'
    when 'February' then 'Fev.'
    when 'March' then 'Mar.'
    when 'April' then 'Abr.'
    when 'May' then 'Maio'
    when 'June' then 'Junho'
    when 'July' then 'Julho'
    when 'August' then 'Agosto'
    when 'September' then 'Set.'
    when 'October' then 'Out.'
    when 'November' then 'Nov.'
    when 'December' then 'Dez.' end, '/', year(dataVenda)) data,
    sum(valorTotal) valor from venda group by data order by month(dataVenda);

create view view_ranking as
	select tituloLivro Titulo, qtdePedido Vendido, date(max(dataVenda)) ultima_venda from pedido inner join livros on idLivroPedido = idLivro inner join venda on idPedido = pedidoVenda where dataVenda >= date_sub(now(), interval 1 month) group by tituloLivro order by qtdePedido desc limit 10;
    
create view view_maisVendidos as SELECT         
        livros.idLivro,
        livros.tituloLivro,
        livros.capaLivro
    FROM
        ((pedido
        JOIN livros ON ((idLivroPedido = idLivro)))
        JOIN venda ON ((idPedido = pedidoVenda)))
    WHERE
        (dataVenda >= (NOW() - INTERVAL 1 MONTH))
    GROUP BY tituloLivro
    ORDER BY qtdePedido DESC
    LIMIT 3;

select format(sum(valorTotal) / 2, '2') Total from venda where month(dataVenda) between (month(now()) - 2) and (month(now()) - 1);
  
select format(sum(valorTotal), '2') Total from venda where month(dataVenda) = month(now());
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