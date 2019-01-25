CREATE DATABASE  IF NOT EXISTS `livrariafinal` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */;
USE `livrariafinal`;
-- MySQL dump 10.13  Distrib 8.0.12, for Win64 (x86_64)
--
-- Host: localhost    Database: livrariafinal
-- ------------------------------------------------------
-- Server version	8.0.12

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `antigaimagem`
--

DROP TABLE IF EXISTS `antigaimagem`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `antigaimagem` (
  `url` varchar(150) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `autor`
--

DROP TABLE IF EXISTS `autor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `autor` (
  `idAutor` int(11) NOT NULL AUTO_INCREMENT,
  `nomeAutor` varchar(150) DEFAULT NULL,
  PRIMARY KEY (`idAutor`)
) ENGINE=InnoDB AUTO_INCREMENT=49 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `avaliacoes`
--

DROP TABLE IF EXISTS `avaliacoes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `avaliacoes` (
  `idLivroAvaliacao` int(11) DEFAULT NULL,
  `idClienteAvaliacao` int(11) DEFAULT NULL,
  `comentarioAvaliacao` text,
  `pontosAvaliacao` float DEFAULT NULL,
  `idAvaliacao` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`idAvaliacao`),
  KEY `idLivroAvaliacao` (`idLivroAvaliacao`),
  KEY `idClienteAvaliacao` (`idClienteAvaliacao`),
  CONSTRAINT `avaliacoes_ibfk_1` FOREIGN KEY (`idLivroAvaliacao`) REFERENCES `livros` (`idlivro`),
  CONSTRAINT `avaliacoes_ibfk_2` FOREIGN KEY (`idClienteAvaliacao`) REFERENCES `cliente` (`idcliente`)
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `categoria`
--

DROP TABLE IF EXISTS `categoria`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `categoria` (
  `idCategoria` int(11) NOT NULL AUTO_INCREMENT,
  `nomeCategoria` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idCategoria`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `cliente`
--

DROP TABLE IF EXISTS `cliente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `cliente` (
  `idCliente` int(11) NOT NULL AUTO_INCREMENT,
  `nomeCliente` varchar(150) DEFAULT NULL,
  `emailCliente` varchar(150) DEFAULT NULL,
  `loginCliente` varchar(50) DEFAULT NULL,
  `senhaCliente` varchar(50) DEFAULT NULL,
  `telefoneCliente` varchar(13) DEFAULT NULL,
  `celularCliente` varchar(13) DEFAULT NULL,
  PRIMARY KEY (`idCliente`),
  UNIQUE KEY `emailCliente` (`emailCliente`),
  UNIQUE KEY `emailCliente_2` (`emailCliente`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `contatos`
--

DROP TABLE IF EXISTS `contatos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `contatos` (
  `idContato` int(11) NOT NULL AUTO_INCREMENT,
  `idClienteContato` int(11) DEFAULT NULL,
  `mensagemContato` text,
  `dataContato` datetime DEFAULT CURRENT_TIMESTAMP,
  `idAssunto` int(11) DEFAULT NULL,
  PRIMARY KEY (`idContato`),
  KEY `idClienteContato` (`idClienteContato`),
  CONSTRAINT `contatos_ibfk_1` FOREIGN KEY (`idClienteContato`) REFERENCES `cliente` (`idcliente`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `descontos`
--

DROP TABLE IF EXISTS `descontos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `descontos` (
  `idDesconto` int(11) NOT NULL AUTO_INCREMENT,
  `nomeDesconto` varchar(30) NOT NULL,
  `valorDesconto` decimal(4,2) DEFAULT NULL,
  `tipoDesconto` enum('Porcentagem','Direto') DEFAULT NULL,
  `utilizado` tinyint(4) DEFAULT '0',
  PRIMARY KEY (`idDesconto`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `editora`
--

DROP TABLE IF EXISTS `editora`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `editora` (
  `idEditora` int(11) NOT NULL AUTO_INCREMENT,
  `nomeEditora` varchar(150) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`idEditora`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `funcionario`
--

DROP TABLE IF EXISTS `funcionario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `funcionario` (
  `IDFUNCIONARIO` int(11) NOT NULL AUTO_INCREMENT,
  `nomeFuncionario` varchar(150) DEFAULT NULL,
  `cpfFuncionario` char(11) DEFAULT NULL,
  `telefoneFuncionario` char(11) DEFAULT NULL,
  `tipoFuncionario` int(11) DEFAULT NULL,
  `emailFuncionario` varchar(150) DEFAULT NULL,
  `loginFuncionario` varchar(50) DEFAULT NULL,
  `senhaFuncionario` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`IDFUNCIONARIO`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `livros`
--

DROP TABLE IF EXISTS `livros`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `livros` (
  `idLivro` int(11) NOT NULL AUTO_INCREMENT,
  `tituloLivro` varchar(150) NOT NULL,
  `tag` varchar(150) NOT NULL DEFAULT '#0#',
  `codigoBarras` varchar(30) NOT NULL,
  `sinopseLivro` text NOT NULL,
  `autorLivro` int(11) NOT NULL,
  `categoriaLivro` int(11) NOT NULL,
  `dataLancamento` datetime NOT NULL,
  `precoLivro` decimal(10,2) NOT NULL,
  `capaLivro` varchar(150) NOT NULL,
  `qtdeLivro` int(11) NOT NULL,
  `editoraLivro` int(11) NOT NULL,
  PRIMARY KEY (`idLivro`),
  KEY `autorLivro` (`autorLivro`),
  KEY `categoriaLivro` (`categoriaLivro`),
  KEY `editoraLivro` (`editoraLivro`),
  CONSTRAINT `livros_ibfk_1` FOREIGN KEY (`autorLivro`) REFERENCES `autor` (`idautor`),
  CONSTRAINT `livros_ibfk_2` FOREIGN KEY (`categoriaLivro`) REFERENCES `categoria` (`idcategoria`),
  CONSTRAINT `livros_ibfk_3` FOREIGN KEY (`editoraLivro`) REFERENCES `editora` (`ideditora`)
) ENGINE=InnoDB AUTO_INCREMENT=155 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `trg_alterarLivro` AFTER UPDATE ON `livros` FOR EACH ROW begin
	if new.capaLivro != old.capaLivro then
		insert into antigaImagem value(old.capaLivro);
	end if;
end */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `trg_deleteLivro` AFTER DELETE ON `livros` FOR EACH ROW begin
    insert into antigaImagem value(old.capaLivro);
end */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `notificacao`
--

DROP TABLE IF EXISTS `notificacao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `notificacao` (
  `IDNOTIFICACAO` int(11) NOT NULL AUTO_INCREMENT,
  `livroNotificacao` int(11) DEFAULT NULL,
  `qtdeRecomendada` int(11) DEFAULT NULL,
  PRIMARY KEY (`IDNOTIFICACAO`),
  KEY `livroNotificacao` (`livroNotificacao`),
  CONSTRAINT `notificacao_ibfk_1` FOREIGN KEY (`livroNotificacao`) REFERENCES `livros` (`idlivro`)
) ENGINE=InnoDB AUTO_INCREMENT=249 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `pedido`
--

DROP TABLE IF EXISTS `pedido`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `pedido` (
  `idPedido` int(11) NOT NULL,
  `idLivroPedido` int(11) NOT NULL,
  `qtdePedido` int(11) DEFAULT NULL,
  `pedidoFinalizado` tinyint(1) DEFAULT '0',
  `idClientePedido` int(11) DEFAULT NULL,
  PRIMARY KEY (`idPedido`,`idLivroPedido`),
  KEY `idClientePedido` (`idClientePedido`),
  CONSTRAINT `pedido_ibfk_1` FOREIGN KEY (`idClientePedido`) REFERENCES `cliente` (`idcliente`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `trg_diminuirQtd` AFTER INSERT ON `pedido` FOR EACH ROW begin
	update livros set qtdeLivro = qtdeLivro - (NEW.qtdePedido)
    where idLivro = new.idLivroPedido;
end */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `trg_verificacarqtd` BEFORE UPDATE ON `pedido` FOR EACH ROW begin
	declare qtde int;
    if new.pedidoFinalizado = old.pedidoFinalizado then
		set qtde = (select qtdeLivro from livros where idLivro = old.idLivroPedido) + old.qtdePedido;
    
		if qtde < new.qtdePedido then
			-- update livros set qtdeLivro = qtdeLivro - new.qtdePedido where idLivro = new.idLivroPedido;        
			signal sqlstate '45000';
		else
			update livros set qtdeLivro = qtdeLivro - (new.qtdePedido - old.qtdePedido) where idLivro = new.idLivroPedido;
		end if;
	end if;
end */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `trg_aumentarQtdeDel` AFTER DELETE ON `pedido` FOR EACH ROW begin
	update livros set qtdeLivro = qtdeLivro + (OLD.qtdePedido)
    where idLivro = old.idLivroPedido;

end */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `venda`
--

DROP TABLE IF EXISTS `venda`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `venda` (
  `IDVENDA` int(11) NOT NULL AUTO_INCREMENT,
  `idFunc` int(11) NOT NULL,
  `pedidoVenda` int(11) NOT NULL,
  `dataVenda` datetime NOT NULL,
  `valorTotal` decimal(10,2) NOT NULL,
  PRIMARY KEY (`IDVENDA`),
  KEY `idFunc` (`idFunc`),
  KEY `pedidoVenda` (`pedidoVenda`),
  CONSTRAINT `venda_ibfk_1` FOREIGN KEY (`idFunc`) REFERENCES `funcionario` (`idfuncionario`),
  CONSTRAINT `venda_ibfk_2` FOREIGN KEY (`pedidoVenda`) REFERENCES `pedido` (`idpedido`)
) ENGINE=InnoDB AUTO_INCREMENT=107 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Temporary view structure for view `view_livrocompleto`
--

DROP TABLE IF EXISTS `view_livrocompleto`;
/*!50001 DROP VIEW IF EXISTS `view_livrocompleto`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8mb4;
/*!50001 CREATE VIEW `view_livrocompleto` AS SELECT 
 1 AS `COD`,
 1 AS `Titulo`,
 1 AS `Saga`,
 1 AS `Preco`,
 1 AS `Quantidade`,
 1 AS `Autor`,
 1 AS `Categoria`,
 1 AS `capa`,
 1 AS `Editora`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `view_maisvendidos`
--

DROP TABLE IF EXISTS `view_maisvendidos`;
/*!50001 DROP VIEW IF EXISTS `view_maisvendidos`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8mb4;
/*!50001 CREATE VIEW `view_maisvendidos` AS SELECT 
 1 AS `idLivro`,
 1 AS `tituloLivro`,
 1 AS `capaLivro`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `view_mensagens`
--

DROP TABLE IF EXISTS `view_mensagens`;
/*!50001 DROP VIEW IF EXISTS `view_mensagens`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8mb4;
/*!50001 CREATE VIEW `view_mensagens` AS SELECT 
 1 AS `idContato`,
 1 AS `Cliente`,
 1 AS `Mensagem`,
 1 AS `Email`,
 1 AS `Assunto`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `view_meses`
--

DROP TABLE IF EXISTS `view_meses`;
/*!50001 DROP VIEW IF EXISTS `view_meses`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8mb4;
/*!50001 CREATE VIEW `view_meses` AS SELECT 
 1 AS `data`,
 1 AS `valor`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `view_ranking`
--

DROP TABLE IF EXISTS `view_ranking`;
/*!50001 DROP VIEW IF EXISTS `view_ranking`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8mb4;
/*!50001 CREATE VIEW `view_ranking` AS SELECT 
 1 AS `Titulo`,
 1 AS `Vendido`,
 1 AS `ultima_venda`*/;
SET character_set_client = @saved_cs_client;

--
-- Dumping events for database 'livrariafinal'
--

--
-- Dumping routines for database 'livrariafinal'
--
/*!50003 DROP PROCEDURE IF EXISTS `prc_geraNotificacao` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `prc_geraNotificacao`()
begin

	declare codLivro int;
    declare nomeLivro varchar(150);
    declare qtdeVenda int;
    declare qtdeDisp int;
    declare done int default false;
    
	declare carregarLivroNotificacao cursor
		for select idLivroPedido ID, tituloLivro Titulo, qtdePedido Vendido, qtdeLivro Qtde_Disponivel from pedido inner join livros on idLivroPedido = idLivro inner join venda on idPedido = pedidoVenda where dataVenda >= date_sub(now(), interval 1 month) group by month(dataVenda) order by qtdePedido;
    
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
    
    select livroNotificacao Livro, tituloLivro Titulo, qtdeRecomendada Recomendada, qtdeLivro Disponivel, capaLivro capa from notificacao inner join livros on livroNotificacao = idLivro;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `prc_relacionados` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `prc_relacionados`(id int)
begin
	 select 0 indice , tituloLivro,capaLivro,idLivro, tag from livros where
	 (trim(substring_index(tag,'#',1)) like concat('%',(select substring_index(tag,'#',1) from livros where idLivro = id)),'%') and idLivro != id and qtdeLivro > 0 union 
	 select 1 indice,tituloLivro, capaLivro, idLivro, tag from livros where categoriaLivro =
	 (select categoriaLivro from livros where idLivro = id) and 
	 idLivro not in
	 (select idLivro from livros where (trim(substring_index(tag,'#',1)) like concat('%',(select substring_index(tag,'#',1) from livros where idLivro = id)),'%')) and qtdeLivro > 0 and idLivro != id order by indice;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `prc_retornaPercentual` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
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
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `prc_Vender` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `prc_Vender`(IN `pedidoID` INT, IN `vendedorID` INT, IN `total` DECIMAL(10,2))
begin
		
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
            
        end Loop lupin;
        close selecionarLivros;
        
        insert into venda(pedidoVenda, idFunc, dataVenda, valorTotal) value(pedidoID, vendedorID, date(now()), total);
        update pedido set pedidoFinalizado = 1 where idPedido = pedidoID;
    end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Final view structure for view `view_livrocompleto`
--

/*!50001 DROP VIEW IF EXISTS `view_livrocompleto`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `view_livrocompleto` AS select `livros`.`idLivro` AS `COD`,`livros`.`tituloLivro` AS `Titulo`,if((`livros`.`tag` = '0'),'Livro único',`livros`.`tag`) AS `Saga`,`livros`.`precoLivro` AS `Preco`,`livros`.`qtdeLivro` AS `Quantidade`,`autor`.`nomeAutor` AS `Autor`,`categoria`.`nomeCategoria` AS `Categoria`,`livros`.`capaLivro` AS `capa`,`editora`.`nomeEditora` AS `Editora` from (((`livros` join `categoria` on((`livros`.`categoriaLivro` = `categoria`.`idCategoria`))) join `autor` on((`autor`.`idAutor` = `livros`.`autorLivro`))) join `editora` on((`editora`.`idEditora` = `livros`.`editoraLivro`))) order by `livros`.`tituloLivro` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `view_maisvendidos`
--

/*!50001 DROP VIEW IF EXISTS `view_maisvendidos`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `view_maisvendidos` AS select `livros`.`idLivro` AS `idLivro`,`livros`.`tituloLivro` AS `tituloLivro`,`livros`.`capaLivro` AS `capaLivro` from ((`pedido` join `livros` on((`pedido`.`idLivroPedido` = `livros`.`idLivro`))) join `venda` on((`pedido`.`idPedido` = `venda`.`pedidoVenda`))) where (`venda`.`dataVenda` >= (now() - interval 1 month)) group by `livros`.`idLivro` order by `pedido`.`qtdePedido` desc limit 3 */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `view_mensagens`
--

/*!50001 DROP VIEW IF EXISTS `view_mensagens`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `view_mensagens` AS select `contatos`.`idContato` AS `idContato`,`contatos`.`idClienteContato` AS `Cliente`,`contatos`.`mensagemContato` AS `Mensagem`,concat('<',`cliente`.`emailCliente`,'> ',`cliente`.`nomeCliente`) AS `Email`,`contatos`.`idAssunto` AS `Assunto` from (`contatos` join `cliente` on((`cliente`.`idCliente` = `contatos`.`idClienteContato`))) order by `contatos`.`idAssunto` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `view_meses`
--

/*!50001 DROP VIEW IF EXISTS `view_meses`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `view_meses` AS select concat((case monthname(`venda`.`dataVenda`) when 'Janaury' then 'Jan.' when 'February' then 'Fev.' when 'March' then 'Mar.' when 'April' then 'Abr.' when 'May' then 'Maio' when 'June' then 'Junho' when 'July' then 'Julho' when 'August' then 'Agosto' when 'September' then 'Set.' when 'October' then 'Out.' when 'November' then 'Nov.' when 'December' then 'Dez.' end),'/',year(`venda`.`dataVenda`)) AS `data`,sum(`venda`.`valorTotal`) AS `valor` from `venda` group by concat((case monthname(`venda`.`dataVenda`) when 'Janaury' then 'Jan.' when 'February' then 'Fev.' when 'March' then 'Mar.' when 'April' then 'Abr.' when 'May' then 'Maio' when 'June' then 'Junho' when 'July' then 'Julho' when 'August' then 'Agosto' when 'September' then 'Set.' when 'October' then 'Out.' when 'November' then 'Nov.' when 'December' then 'Dez.' end),'/',year(`venda`.`dataVenda`)) order by month(`venda`.`dataVenda`) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `view_ranking`
--

/*!50001 DROP VIEW IF EXISTS `view_ranking`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `view_ranking` AS select `livros`.`tituloLivro` AS `Titulo`,`pedido`.`qtdePedido` AS `Vendido`,cast(max(`venda`.`dataVenda`) as date) AS `ultima_venda` from ((`pedido` join `livros` on((`pedido`.`idLivroPedido` = `livros`.`idLivro`))) join `venda` on((`pedido`.`idPedido` = `venda`.`pedidoVenda`))) where (`venda`.`dataVenda` >= (now() - interval 1 month)) group by `livros`.`tituloLivro` order by `pedido`.`qtdePedido` desc limit 10 */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-12-07 14:07:08
