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
    
 
CREATE VIEW `view_livrocompleto` AS
    SELECT 
        `livros`.`idLivro` AS `COD`,
        `livros`.`tituloLivro` AS `Titulo`,
        `livros`.`tag` AS `Saga`,
        `livros`.`precoLivro` AS `Preco`,
        `livros`.`qtdeLivro` AS `Quantidade`,
        `autor`.`nomeAutor` AS `Autor`,
        `categoria`.`nomeCategoria` AS `Categoria`,
        `livros`.`capaLivro` AS `capa`,
        `editora`.`nomeEditora` AS `Editora`
    FROM
        (((`livros`
        JOIN `categoria` ON ((`livros`.`categoriaLivro` = `categoria`.`idCategoria`)))
        JOIN `autor` ON ((`autor`.`idAutor` = `livros`.`autorLivro`)))
        JOIN `editora` ON ((`editora`.`idEditora` = `livros`.`editoraLivro`)))
    ORDER BY `livros`.`tituloLivro`
