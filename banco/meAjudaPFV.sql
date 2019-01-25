-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: 27-Nov-2018 às 20:14
-- Versão do servidor: 10.1.13-MariaDB
-- PHP Version: 5.6.23

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `livrariafinal`
--

DELIMITER $$
--
-- Procedures
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `prc_geraNotificacao` ()  begin

	declare codLivro int;
    declare nomeLivro varchar(150);
    declare qtdeVenda int;
    declare qtdeDisp int;
    declare done int default false;
    
	declare carregarLivroNotificacao cursor
		for select idLivroPedido ID, tituloLivro Titulo, sum(qtdePedido) Vendido, qtdeLivro Qtde_Disponivel from pedido inner join livros on idLivroPedido = idLivro inner join venda on idPedido = pedidoVenda where dataVenda >= date_sub(now(), interval 7 day) group by tituloLivro, livros.idLivro order by qtdePedido;
    
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
end$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `prc_retornaPercentual` ()  begin
	
	declare x decimal(10, 2);
    declare ganhosMesPassado decimal(10, 2);
	declare ganhosMesAtual decimal(10, 2);
    
    select sum(valorTotal) into ganhosMesPassado from venda where month(dataVenda) = month(now()) - 1;
    select sum(valorTotal) into ganhosMesAtual from venda where month(dataVenda) = month(now());
    
    set ganhosMesAtual = ganhosMesAtual * 100;
    set x = ganhosMesAtual / ganhosMesPassado;
    
    select format(x - 100, 2);
end$$

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
    end$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Estrutura da tabela `antigaimagem`
--

CREATE TABLE `antigaimagem` (
  `url` varchar(150) COLLATE utf8_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Estrutura da tabela `autor`
--

CREATE TABLE `autor` (
  `idAutor` int(11) NOT NULL,
  `nomeAutor` varchar(150) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `autor`
--

INSERT INTO `autor` (`idAutor`, `nomeAutor`) VALUES
(4, 'Rick Riordan'),
(7, 'Alexander Gordon Smith'),
(8, 'Lemony Snicket'),
(10, 'J. K. Rowling'),
(17, 'Ernest Cline');

-- --------------------------------------------------------

--
-- Estrutura da tabela `avaliacoes`
--

CREATE TABLE `avaliacoes` (
  `idLivroAvaliacao` int(11) DEFAULT NULL,
  `idClienteAvaliacao` int(11) DEFAULT NULL,
  `comentarioAvaliacao` text,
  `pontosAvaliacao` float DEFAULT NULL,
  `idAvaliacao` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `avaliacoes`
--

INSERT INTO `avaliacoes` (`idLivroAvaliacao`, `idClienteAvaliacao`, `comentarioAvaliacao`, `pontosAvaliacao`, `idAvaliacao`) VALUES
(58, 5, 'hahaha', 3, 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `categoria`
--

CREATE TABLE `categoria` (
  `idCategoria` int(11) NOT NULL,
  `nomeCategoria` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `categoria`
--

INSERT INTO `categoria` (`idCategoria`, `nomeCategoria`) VALUES
(1, 'Terror'),
(2, 'Fantasia'),
(3, 'Ação'),
(5, 'Suspense');

-- --------------------------------------------------------

--
-- Estrutura da tabela `cliente`
--

CREATE TABLE `cliente` (
  `idCliente` int(11) NOT NULL,
  `nomeCliente` varchar(150) DEFAULT NULL,
  `cpfCliente` char(11) NOT NULL,
  `emailCliente` varchar(150) DEFAULT NULL,
  `loginCliente` varchar(50) DEFAULT NULL,
  `senhaCliente` varchar(50) DEFAULT NULL,
  `telefoneCliente` varchar(13) DEFAULT NULL,
  `celularCliente` varchar(13) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `cliente`
--

INSERT INTO `cliente` (`idCliente`, `nomeCliente`, `cpfCliente`, `emailCliente`, `loginCliente`, `senhaCliente`, `telefoneCliente`, `celularCliente`) VALUES
(3, 'compra', '11111111111', NULL, NULL, NULL, NULL, NULL),
(4, 'teste', '47965914867', 'jdnsajkdgajk@outlook.com', 'teste', '124578', NULL, NULL),
(5, 'math hsjfs', '47892533780', 'danielcity1@gmail.com', NULL, '25d55ad283aa400af464c76d713c07ad', '', '11961537300');

-- --------------------------------------------------------

--
-- Estrutura da tabela `descontos`
--

CREATE TABLE `descontos` (
  `idDesconto` int(11) NOT NULL,
  `nomeDesconto` varchar(30) NOT NULL,
  `valorDesconto` decimal(4,2) DEFAULT NULL,
  `tipoDesconto` enum('Porcentagem','Direto') DEFAULT NULL,
  `utilizado` tinyint(4) DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `descontos`
--

INSERT INTO `descontos` (`idDesconto`, `nomeDesconto`, `valorDesconto`, `tipoDesconto`, `utilizado`) VALUES
(1, 'teste', '15.00', 'Direto', 0);

-- --------------------------------------------------------

--
-- Estrutura da tabela `editora`
--

CREATE TABLE `editora` (
  `idEditora` int(11) NOT NULL,
  `nomeEditora` varchar(150) COLLATE utf8_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Extraindo dados da tabela `editora`
--

INSERT INTO `editora` (`idEditora`, `nomeEditora`) VALUES
(1, 'Intrínseca'),
(2, 'teste'),
(3, 'Benvirá'),
(4, 'Companhia das Letras'),
(5, 'Rocco'),
(10, 'Leya');

-- --------------------------------------------------------

--
-- Estrutura da tabela `funcionario`
--

CREATE TABLE `funcionario` (
  `idFuncionario` int(11) NOT NULL,
  `nomeFuncionario` varchar(150) DEFAULT NULL,
  `cpfFuncionario` char(11) DEFAULT NULL,
  `telefoneFuncionario` char(11) DEFAULT NULL,
  `tipoFuncionario` int(11) DEFAULT NULL,
  `emailFuncionario` varchar(150) DEFAULT NULL,
  `loginFuncionario` varchar(50) DEFAULT NULL,
  `senhaFuncionario` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `funcionario`
--

INSERT INTO `funcionario` (`idFuncionario`, `nomeFuncionario`, `cpfFuncionario`, `telefoneFuncionario`, `tipoFuncionario`, `emailFuncionario`, `loginFuncionario`, `senhaFuncionario`) VALUES
(1, 'Matheus', '47965914867', '986450803', 2, 'matheus.carvalho@outlook.com', 'math', '12345678'),
(3, 'teste', '11111111111', '958691147', 1, 'sdfasdf@outlook.com', 'teste', '0123456'),
(4, 'sfsdafsaf', '83320297082', '958641020', 0, 'sfbsdjkf@gmail.com', 'AlanZLoka', 'AlanZloka'),
(5, 'ALAN', '40937871079', '958641020', 0, 'nswcklsnclks@gmail.com', 'testeAlan', '12345');

-- --------------------------------------------------------

--
-- Estrutura da tabela `livros`
--

CREATE TABLE `livros` (
  `idLivro` int(11) NOT NULL,
  `tituloLivro` varchar(150) NOT NULL,
  `tag` varchar(150) NOT NULL,
  `codigoBarras` varchar(30) NOT NULL,
  `sinopseLivro` text NOT NULL,
  `autorLivro` int(11) NOT NULL,
  `categoriaLivro` int(11) NOT NULL,
  `dataLancamento` datetime NOT NULL,
  `precoLivro` decimal(10,2) NOT NULL,
  `capaLivro` varchar(150) NOT NULL,
  `qtdeLivro` int(11) NOT NULL,
  `editoraLivro` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `livros`
--

INSERT INTO `livros` (`idLivro`, `tituloLivro`, `tag`, `codigoBarras`, `sinopseLivro`, `autorLivro`, `categoriaLivro`, `dataLancamento`, `precoLivro`, `capaLivro`, `qtdeLivro`, `editoraLivro`) VALUES
(56, 'Encarcerados', 'Fuga de Furnace', '9788564065239', 'Sob o céu está o inferno. Sob o inferno, a Penitenciaria de Furnace.\nDe um dia para outro, Alex Sawyer passou de valentão a delinquente juvenil. Os trocados arrancados dos garotos na escola já não eram suficientes, e, com a ajuda de seu melhor amigo, Toby, começou a cometer pequenos furtos na vizinhança. Até que uma noite, homens fortes, de terno preto, e um esquisitão usando uma máscara de gás cruzaram o caminho dos dois. Toby foi cruelmente assassinado e Alex, preso e acusado pela morte do amigo. Seu novo lar? A Penitenciária de Furnace, um buraco - literalmente - para onde todos os garotos condenados são enviados, e de onde só é possível sair morto. Com guardas sádicos e criaturas terríveis responsáveis pela segurança, Furnace é o inferno. O lugar é infestado de criminosos - como as perigosas gangues Caveiras e os Cinquenta e Nove - mas também há muitos garotos que, como Alex, foram presos por crimes que não cometeram. Como escapar e provar sua inocência? Em quem confiar? O que na verdade era Furnace: um reformatório? Um depósito? Ou, pior, um laboratório maligno?', 7, 5, '2018-06-06 00:00:00', '15.80', 'ENCARCERADOS.jpg', 233, 3),
(57, 'Solitária', 'Fuga de Furnace', '9788564065642', 'Quando mandaram a Sala Dois pelos ares, Alex, Zê, Gary e Toby acreditaram ter alcançado a tão sonhada liberdade. Porém, o que parecia um sonho acabou se transformando em um de seus piores pesadelos. A explosão os jogou nas profundezas de Furnace. Nada de ar puro, apenas escuridão e labirintos de pedra. Com os guardas e o diretor da prisão em seu encalço, os garotos sabem que é uma questão de tempo até voltarem para a cela. O verdadeiro horror de Furnace só está começando. Recapturados, eles agora precisam encarar a solitária - nada mais que um buraco no solo com apenas uma porta, trancada pelo lado de fora e vigiada pelos ternos-pretos e pelos temidos Ofegantes. Seu destino? Serem devorados pelos ratos que povoam as entranhas de Furnace, enlouquecer dentro da cela úmida ou... tentar escapar novamente. ', 7, 5, '2018-06-13 00:00:00', '13.00', 'SOLITARIA.jpg', 12, 3),
(58, 'Sentença de Morte', 'Fuga de Furnace', '9788582400104', '"Eu estava na penitenciária de Furnace. E ali nem mesmo a morte ousava mostrar a sua face". Mais uma vez a tentativa de fuga de Alex fracassa. E, agora, a punição que o aguarda é muito mas MUITO mais cruel. Depois de uma temporada enfurnado na solitária, ele se vê na enfermaria, cercado de Ofegantes. O pior está para acontecer. Alex está para se tornar um deles. Enquanto o sádico diretor bombeia lentamente o néctar para suas veias, Alex vai, aos poucos, se transformando na figura que mais teme: um terno-preto. Para lutar contra as forças malignas que se apossam de seu corpo, ele precisa se lembrar de quem realmente é e seguir o conselho de seu amigo Garry: nunca esquecer o seu nome. Essa pode ser a única saída para não perder sua identidade. Mas como escapar dele mesmo, se agora possuía em seu sangue a crueldade de um super-humano de Furnace?', 7, 5, '2018-10-17 00:00:00', '16.00', 'SENTENCA_DE_MORTE.jpg', 41, 3),
(59, 'Fugitivos', 'Fuga de Furnace', '9788557170063', 'Os prisioneiros conseguiram escapar e o caos se instalou na cidade. As autoridades pedem que a população não saia às ruas, e os números de emergência não estão funcionando. É cada um por si...\nEnquanto tentam avisar o exército de que o diretor Cross e seu exército de ternos-pretos são os responsáveis pela destruição que está ocorrendo na cidade, Alex, Simon e Zê novamente no subterrâneo da cidade ficam cara a cara com feras muito mais poderosas do que os cães e os ratos: um tipo de mutação que está se espalhando como peste, e uma simples mordida de um infectado pode transformar os demais em segundos.\nEnquanto isso, uma voz na cabeça de Alex o coloca em dúvida sobre o que ele é e a quem seu corpo pertence. Para descobrir, precisará desafiar seu maior inimigo, o homem por trás de todo esse inferno: Alfredo Furnace.', 7, 5, '2018-10-17 00:00:00', '20.00', 'FUGITIVOS.jpg', 283, 3),
(60, 'Execução', 'Fuga de Furnace', '150052050520', 'Depois de finalmente escapar de Furnace e matar o diretor Cross, Alex parte para sua maior missão: encontrar e destruir Alfredo Furnace. E o garoto não descansará enquanto não cumpri-la. Porém, após quase ser aniquilado na Torre de Furnace, Alex é levado a um hospital militar, e, no lugar onde deveria ser curado, um novo pesadelo tem início. Sob as ordens da coronel Panettierre, um grupo de cientistas usa Alex para tentar descobrir a verdade por trás do néctar. E não é apenas a vida de Alex que corre perigo nas mãos dessa mulher obcecada pelo poder: Zê também está prestes a virar um experimento. Panettierre quer descobrir por que o garoto é imune aos poderosos efeitos do néctar, usando a desculpa de que ele pode ser a cura para todos os outros garotos transformados. Para fugir das garras de Panettierre e encontrar Alfredo Furnace, que continua a se comunicar com ele através de seus pensamentos, Alex contará com a ajuda de seus inseparáveis amigos e de seres que foram seus maiores inimigos dentro da Penitenciária de Furnace: ternos-pretos e vikings. Mas qual o segredo por trás dessa nova aliança? Por que o estão ajudando em vez de matá-lo? Por que Alfredo Furnace quer que Alex continue vivo e o encontre cara a cara?', 7, 5, '2018-10-17 00:00:00', '25.00', 'EXECUCAO.jpg', 153, 3),
(61, 'Mau Começo', 'Desventuras em série', '45978622135', 'Mau Começo é o primeiro volume de uma série em que Lemony Snicket conta as desventuras dos irmãos Baudelaire. Klaus, Sunny e Violet, são encantadores e inteligentes, mas ocupam o primeiro lugar na classificação das pessoas mais infelizes do mundo. De fato, a infelicidade segue os seus passos desde a primeira página, quando eles estão na praia e recebem uma trágica notícia. Esses ímãs que atraem desgraças terão de enfrentar, por exemplo, um gosmento vilão dominado pela cobiça, um incêndio calamitoso, roupas que pinicam o corpo e mingau frio no café da manhã. É por isso que, logo na quarta capa, Snicket avisa ao leitor: "Não há nada que o impeça de fechar o livro imediatamente e sair para uma outra leitura sobre coisas felizes, se é isso que você prefere".\n\nEm 2005, Jim Carrey estrelou uma versão cinematográfica dos três primeiros livros da série, no papel de conde Olaf.', 8, 2, '2018-10-29 00:00:00', '18.00', 'DESVENTURAS_EM_SERIE_MAU_COMECO.jpg', 134, 4),
(62, 'A Sala dos Répteis', 'Desventuras em série', '45978622137', 'Lemony Snicket é um autor que não pode ser acusado de falta de franqueza. Sabe que nem todo mundo suporta as tristezas que ele conta e por isso - para que depois ninguém reclame - faz questão de avisar: ''Se você esperava encontrar uma história tranqüila e alegre, lamento dizer que escolheu o livro errado. A história pode parecer animadora no início, quando os meninos Baudelaire passam o tempo em companhia de alguns répteis interessantes e de um tio alto-astral, mas não se deixem enganar...''\n\nOs Baudelaire têm mesmo uma incrível má sorte, mas pode-se afirmar que a vida deles seria bem mais fácil se não tivessem de enfrentar o tempo todo as armadilhas de seu arquiinimigo: o conde Olaf, um homem revoltante, gosmento e pérfido. Em ''Mau Começo'' ele deu uma pequena amostra do que é capaz de fazer para infernizar a vida de Violet, Klaus e Sunny Baudelaire - e aqui as coisas só pioram.', 8, 1, '2018-10-29 00:00:00', '20.00', 'A_SALA_DOS_REPTEIS.jpg', 156, 1),
(63, 'O Hospital Hostil', 'Desventuras em série', '45978622100', 'Um período especialmente infeliz se anuncia nas vidas aflitivas de Violet, Klaus e Sunny Baudelaire. Durante uma tenebrosa e exaustiva caminhada noturna, eles param diante do Armazém Geral Última Chance e decidem entrar para pedir ajuda.Eles não podem recorrer aos pais (pois os perderam num incêndio), nem à polícia (que estava entre seus perseguidores noturnos), tampouco a conhecidos (pois os irmãos têm conhecidos demais, o que é quase o mesmo que não ter nenhum).Depois da morte dos pais no incêndio, Violet, Klaus e Sunny se vêem sob os cuidados de inúmeros tutores, alguns deles cruéis, como o ganancioso e traiçoeiro Conde Olaf, o vilão que é o verdadeiro responsável por eles estarem ali, totalmente sozinhos no meio da noite, em frente ao Armazém.Violet, Klaus e Sunny resolvem passar um telegrama para o sr. Poe, um banqueiro que fora encarregado de cuidar dos órfãos. O sr. Poe nunca se mostrou especialmente eficaz, mas pelo menos ele não era cruel, não tinha sido assassinado nem era o Conde Olaf, e essas parecem ser razões suficientes para contatá-lo.Além de se safar de terríveis enrascadas, os Baudelaire ainda terão de suportar a estada no sinistro Hospital Heimlich e provar que não são cruéis assassinos. Esse é apenas o começo de páginas e páginas de situações desesperadoras, que contêm detalhes opressivos como um desconfiado dono de armazém, uma cirurgia desnecessária, um sistema de intercomunicadores, uma anestesia e balões em forma de coração.', 8, 2, '2018-10-29 00:00:00', '15.99', 'DESVENTURAS_EM_SERIE_O_HOSPITAL_HOSTIL.jpg', 8, 4),
(64, 'O Espetáculo Carnívoro', 'Desventuras em série', '45978625478', 'No princípio de mais um episódio funesto de suas penosas existências, Violet, Klaus e Sunny Baudelaire se encontram no porta-malas de um carro preto. Qualquer pessoa que não seja um pacote ou uma mala preferiria viajar confortavelmente instalado no banco do passageiro, mas os órfãos Baudelaire não têm escolha. Quando refugiaram-se no bagageiro desse carro sinistro, eles escapavam de uma situação ainda pior.As três crianças encontram-se na "barriga da fera", o que vale dizer que estão numa enrascada. Ao volante do automóvel está o ganancioso Conde Olaf, um vilão traiçoeiro que, desde que os Baudelaire perderam os pais num incêndio, vem perseguindo os três com o objetivo de se apossar da fortuna herdada por eles. Até aqui, felizmente, ele foi mal-sucedido.Além de se safar dessa armadilha, em O espetáculo carnívoro Violet, Klaus e Sunny Baudelaire terão de escapar do Parque Caligari e enfrentar uma multidão indócil. Tudo isso para tentar localizar o dossiê Snicket e decifrar a sigla C.S.C., que pode confirmar se um dos pais das crianças realmente sobreviveu ao terrível incêndio.Pseudônimo do escritor Daniel Handler, Lemony Snicket se tornou um fenômeno editorial em todo o mundo. Snicket homenageia Edgar Allan Poe e Charles Baudelaire, pais da literatura de mistério e da poesia simbolista, subvertendo os padrões bem comportados da literatura infanto-juvenil para compor uma saga engraçada e arrepiante.', 8, 2, '2018-10-29 00:00:00', '23.10', 'DESVENTURAS_EM_SERIE_O_ESPETACULO_CARNI.jpg', 50, 4),
(65, 'O Escorregador de Gelo', 'Desventuras em série', '9785596485', 'Por mais azarados que sejam, até agora os órfãos Baudelaire pelo menos sempre estiveram juntos. Pois neste livro décimo a tragédia é ainda maior: separados do bebê Sunny, Klaus e Violet são obrigados a descer uma montanha escorregadia, enquanto tentam salvar a irmã mais nova das garras do temível conde Olaf.Será que os Baudelaire finalmente descobrirão o significado da sigla C.S.C.? Será que, desta vez, o final será feliz? É provável que não. Como sempre, a história está repleta de mistérios e mensagens secretas, situações absurdas, desgraça e mal-estar para todos - menos para o leitor, é claro. Mas quem gosta de alegria não deve nem abrir este livro, avisa o autor, pois a vida dos Baudelaire é sempre uma desventura pior do que a outra.Desventuras em Série é um fenômeno editorial em todo o mundo. Desde seu lançamento, em 1999, a série já vendeu mais de 6 milhões de exemplares, em 37 países. Em 2005, Jim Carrey estrelou uma versão cinematográfica dos três primeiros livros da série, no papel de conde Olaf.Pseudônimo do escritor Daniel Handler, Lemony Snicket leva o exagero às raias do absurdo e faz o realismo perder feio para o mais deslavado faz-de-conta. O resultado não poderia ser outro: um jogo literário incessantemente bem-humorado. Snicket homenageia Edgar Allan Poe e Charles Baudelaire, pais da literatura de mistério e da poesia simbolista, subvertendo os padrões bem comportados da literatura infanto-juvenil para compor uma saga engraçada e arrepiante.', 8, 5, '2018-10-29 00:00:00', '23.00', 'DESVENTURAS_EM_SERIE_O_ESCORREGADOR_DE.jpg', 25, 4),
(79, 'Jogador Nº1', '', '9788544106976', 'Um dos livros mais cultuados da década chega aos cinemas pelas mãos de Steven Spielberg Jogador Nº 1, de Ernest Cline, o livro de ficção científica mais amado e cultuado dos últimos tempos, chega agora aos cinemas numa superprodução dirigida por Steven Spielberg e estrelada por Tye Sheridan e Simon Pegg! Não perca a chance de conhecer todos os detalhes dessa história fantástica. O ano é 2044 e a Terra não é mais a mesma. Fome, guerras e desemprego empurraram a humanidade para um estado de apatia nunca antes visto. Wade Watts é mais um dos que escapa da desanimadora realidade passando horas e horas conectado ao OASIS – uma utopia virtual global que permite aos usuários ser o que quiserem; um lugar onde se pode viver e se apaixonar em qualquer um dos mundos inspirados nos filmes, videogames e cultura pop dos anos 1980. Mas a possibilidade de existir em outra realidade não é o único atrativo do OASIS: o falecido James Halliday, bilionário e criador do jogo, escondeu em algum lugar desse imenso playground uma série de Easter Eggs, e premiará com sua enorme fortuna – e poder – aquele que conseguir desvendá-los. E Wade acabou de encontrar o primeiro.', 17, 2, '2018-11-22 00:00:00', '18.00', 'JOGADOR_N_1.jpg', 150, 10),
(83, 'vdsgdgds', '', '4555454', 'reg rgre grefg rewgr ', 4, 1, '2018-11-27 00:00:00', '4499.00', 'Penguins.jpg', 455, 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `notificacao`
--

CREATE TABLE `notificacao` (
  `idNotificacao` int(11) NOT NULL,
  `livroNotificacao` int(11) DEFAULT NULL,
  `qtdeRecomendada` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estrutura da tabela `pedido`
--

CREATE TABLE `pedido` (
  `idPedido` int(11) NOT NULL,
  `idLivroPedido` int(11) NOT NULL,
  `qtdePedido` int(11) DEFAULT NULL,
  `pedidoFinalizado` tinyint(1) DEFAULT '0',
  `idClientePedido` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Extraindo dados da tabela `pedido`
--

INSERT INTO `pedido` (`idPedido`, `idLivroPedido`, `qtdePedido`, `pedidoFinalizado`, `idClientePedido`) VALUES
(12, 56, 3, 1, 4),
(12, 58, 2, 1, 4),
(13, 57, 3, 1, 4),
(13, 59, 2, 1, 4),
(14, 55, 2, 1, 4),
(14, 59, 1, 1, 4),
(14, 60, 5, 1, 4),
(16, 55, 2, 1, 4),
(16, 57, 3, 1, 4),
(18, 57, 5, 1, 4),
(20, 56, 4, 2, 4),
(20, 57, 4, 2, 4),
(21, 56, 4, 1, 4),
(21, 57, 4, 1, 4),
(31, 59, 4, 1, 4),
(32, 57, 1, 1, 4),
(33, 59, 1, 1, 4),
(34, 58, 1, 1, 4),
(35, 59, 1, 1, 4),
(37, 59, 35, 1, 4),
(38, 59, 10, 1, 4),
(39, 56, 2, 1, 4),
(41, 60, 10, 1, 4),
(42, 58, 10, 1, 4),
(43, 63, 3, 1, 4),
(45, 60, 4, 1, 4),
(46, 62, 8, 1, 4),
(47, 61, 5, 1, 4),
(47, 62, 4, 1, 4),
(48, 57, 2, 1, 4),
(48, 61, 6, 1, 4),
(49, 61, 4, 1, 4),
(50, 63, 10, 1, 4),
(51, 63, 10, 1, 4),
(52, 60, 5, 1, 4),
(53, 61, 2, 1, 4),
(53, 63, 2, 1, 4),
(54, 56, 4, 1, 4),
(55, 62, 7, 1, 4),
(56, 62, 4, 1, 4),
(57, 61, 3, 1, 4),
(58, 60, 3, 0, 4),
(59, 56, 2, 1, 4),
(60, 56, 3, 0, 4),
(61, 56, 2, 1, 4),
(62, 60, 2, 1, 4),
(63, 62, 5, 1, 4),
(64, 60, 4, 1, 4),
(65, 60, 5, 1, 4),
(66, 58, 7, 1, 4),
(67, 59, 15, 1, 4),
(68, 59, 50, 1, 4),
(69, 62, 6, 1, 4),
(70, 59, 5, 1, 4),
(71, 65, 25, 1, 4),
(72, 65, 25, 1, 4),
(73, 63, 8, 1, 4),
(74, 57, 15, 1, 4),
(75, 62, 5, 1, 3),
(76, 62, 5, 1, 3),
(77, 59, 7, 1, 3),
(78, 60, 6, 1, 3),
(79, 58, 1, 2, 5),
(79, 60, 4, 2, 5),
(79, 62, 1, 2, 5),
(80, 62, 5, 1, 3),
(81, 62, 25, 1, 3),
(82, 56, 100, 1, 3),
(83, 61, 40, 1, 3);

-- --------------------------------------------------------

--
-- Estrutura da tabela `venda`
--

CREATE TABLE `venda` (
  `idVenda` int(11) NOT NULL,
  `idFunc` int(11) NOT NULL,
  `pedidoVenda` int(11) NOT NULL,
  `dataVenda` datetime NOT NULL,
  `valorTotal` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `venda`
--

INSERT INTO `venda` (`idVenda`, `idFunc`, `pedidoVenda`, `dataVenda`, `valorTotal`) VALUES
(23, 1, 12, '2018-10-18 00:00:00', '79.40'),
(27, 1, 16, '2018-10-18 00:00:00', '69.00'),
(29, 1, 18, '2018-10-20 00:00:00', '65.00'),
(30, 1, 21, '2018-10-23 00:00:00', '115.20'),
(36, 1, 31, '2018-10-23 00:00:00', '80.00'),
(37, 1, 32, '2018-10-23 00:00:00', '13.00'),
(38, 1, 33, '2018-10-23 00:00:00', '20.00'),
(39, 1, 34, '2018-10-23 00:00:00', '16.00'),
(40, 1, 35, '2018-10-23 00:00:00', '20.00'),
(42, 1, 37, '2018-10-26 00:00:00', '700.00'),
(43, 1, 38, '2018-10-26 00:00:00', '200.00'),
(44, 1, 39, '2018-10-26 00:00:00', '31.60'),
(46, 1, 41, '2018-10-26 00:00:00', '250.00'),
(47, 1, 42, '2018-10-29 00:00:00', '160.00'),
(48, 1, 43, '2018-10-30 00:00:00', '47.97'),
(49, 1, 43, '2018-09-20 00:00:00', '50.00'),
(50, 1, 45, '2018-10-31 00:00:00', '100.00'),
(51, 1, 46, '2018-10-31 00:00:00', '160.00'),
(52, 1, 52, '2018-11-06 00:00:00', '125.00'),
(53, 1, 53, '2018-11-06 00:00:00', '67.98'),
(54, 1, 54, '2018-11-06 00:00:00', '63.20'),
(55, 1, 55, '2018-11-06 00:00:00', '140.00'),
(56, 1, 56, '2018-11-06 00:00:00', '80.00'),
(57, 1, 57, '2018-11-08 00:00:00', '54.00'),
(58, 1, 59, '2018-11-08 00:00:00', '31.60'),
(59, 1, 61, '2018-11-08 00:00:00', '31.60'),
(60, 1, 62, '2018-11-08 00:00:00', '50.00'),
(61, 1, 63, '2018-11-12 00:00:00', '100.00'),
(62, 1, 64, '2018-11-12 00:00:00', '100.00'),
(63, 1, 65, '2018-11-12 00:00:00', '125.00'),
(64, 1, 66, '2018-11-12 00:00:00', '112.00'),
(65, 1, 67, '2018-11-13 00:00:00', '300.00'),
(66, 1, 68, '2018-11-13 00:00:00', '1000.00'),
(67, 1, 69, '2018-11-13 00:00:00', '120.00'),
(95, 1, 70, '2018-11-14 00:00:00', '100.00'),
(96, 1, 71, '2018-11-20 00:00:00', '575.00'),
(97, 1, 72, '2018-11-20 00:00:00', '575.00'),
(98, 1, 73, '2018-11-20 00:00:00', '127.92'),
(99, 1, 74, '2018-11-20 00:00:00', '195.00'),
(100, 1, 75, '2018-11-22 00:00:00', '100.00'),
(101, 1, 76, '2018-11-22 00:00:00', '85.00'),
(102, 1, 77, '2018-11-22 00:00:00', '140.00'),
(103, 1, 78, '2018-11-26 00:00:00', '135.00'),
(104, 1, 80, '2018-11-26 00:00:00', '100.00'),
(105, 1, 81, '2018-11-27 00:00:00', '500.00'),
(106, 1, 82, '2018-11-27 00:00:00', '1580.00'),
(107, 1, 83, '2018-11-27 00:00:00', '720.00');

-- --------------------------------------------------------

--
-- Stand-in structure for view `view_maisvendidos`
--
CREATE TABLE `view_maisvendidos` (
`idLivro` int(11)
,`tituloLivro` varchar(150)
,`capaLivro` varchar(150)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `view_meses`
--
CREATE TABLE `view_meses` (
`data` varchar(11)
,`valor` decimal(32,2)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `view_ranking`
--
CREATE TABLE `view_ranking` (
`Titulo` varchar(150)
,`Vendido` int(11)
,`ultima_venda` date
);

-- --------------------------------------------------------

--
-- Structure for view `view_maisvendidos`
--
DROP TABLE IF EXISTS `view_maisvendidos`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `view_maisvendidos`  AS  select `livros`.`idLivro` AS `idLivro`,`livros`.`tituloLivro` AS `tituloLivro`,`livros`.`capaLivro` AS `capaLivro` from ((`pedido` join `livros` on((`pedido`.`idLivroPedido` = `livros`.`idLivro`))) join `venda` on((`pedido`.`idPedido` = `venda`.`pedidoVenda`))) where (`venda`.`dataVenda` >= (now() - interval 1 month)) group by `livros`.`tituloLivro` order by `pedido`.`qtdePedido` desc limit 3 ;

-- --------------------------------------------------------

--
-- Structure for view `view_meses`
--
DROP TABLE IF EXISTS `view_meses`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `view_meses`  AS  select concat((case monthname(`venda`.`dataVenda`) when 'Janaury' then 'Jan.' when 'February' then 'Fev.' when 'March' then 'Mar.' when 'April' then 'Abr.' when 'May' then 'Maio' when 'June' then 'Junho' when 'July' then 'Julho' when 'August' then 'Agosto' when 'September' then 'Set.' when 'October' then 'Out.' when 'November' then 'Nov.' when 'December' then 'Dez.' end),'/',year(`venda`.`dataVenda`)) AS `data`,sum(`venda`.`valorTotal`) AS `valor` from `venda` group by concat((case monthname(`venda`.`dataVenda`) when 'Janaury' then 'Jan.' when 'February' then 'Fev.' when 'March' then 'Mar.' when 'April' then 'Abr.' when 'May' then 'Maio' when 'June' then 'Junho' when 'July' then 'Julho' when 'August' then 'Agosto' when 'September' then 'Set.' when 'October' then 'Out.' when 'November' then 'Nov.' when 'December' then 'Dez.' end),'/',year(`venda`.`dataVenda`)) order by month(`data`) ;

-- --------------------------------------------------------

--
-- Structure for view `view_ranking`
--
DROP TABLE IF EXISTS `view_ranking`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `view_ranking`  AS  select `livros`.`tituloLivro` AS `Titulo`,`pedido`.`qtdePedido` AS `Vendido`,cast(max(`venda`.`dataVenda`) as date) AS `ultima_venda` from ((`pedido` join `livros` on((`pedido`.`idLivroPedido` = `livros`.`idLivro`))) join `venda` on((`pedido`.`idPedido` = `venda`.`pedidoVenda`))) where (`venda`.`dataVenda` >= (now() - interval 1 month)) group by `livros`.`tituloLivro` order by `pedido`.`qtdePedido` desc limit 10 ;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `autor`
--
ALTER TABLE `autor`
  ADD PRIMARY KEY (`idAutor`);

--
-- Indexes for table `avaliacoes`
--
ALTER TABLE `avaliacoes`
  ADD PRIMARY KEY (`idAvaliacao`);

--
-- Indexes for table `categoria`
--
ALTER TABLE `categoria`
  ADD PRIMARY KEY (`idCategoria`);

--
-- Indexes for table `cliente`
--
ALTER TABLE `cliente`
  ADD PRIMARY KEY (`idCliente`);

--
-- Indexes for table `descontos`
--
ALTER TABLE `descontos`
  ADD PRIMARY KEY (`idDesconto`);

--
-- Indexes for table `editora`
--
ALTER TABLE `editora`
  ADD PRIMARY KEY (`idEditora`);

--
-- Indexes for table `funcionario`
--
ALTER TABLE `funcionario`
  ADD PRIMARY KEY (`idFuncionario`);

--
-- Indexes for table `livros`
--
ALTER TABLE `livros`
  ADD PRIMARY KEY (`idLivro`);

--
-- Indexes for table `notificacao`
--
ALTER TABLE `notificacao`
  ADD PRIMARY KEY (`idNotificacao`);

--
-- Indexes for table `pedido`
--
ALTER TABLE `pedido`
  ADD PRIMARY KEY (`idPedido`,`idLivroPedido`);

--
-- Indexes for table `venda`
--
ALTER TABLE `venda`
  ADD PRIMARY KEY (`idVenda`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `autor`
--
ALTER TABLE `autor`
  MODIFY `idAutor` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;
--
-- AUTO_INCREMENT for table `avaliacoes`
--
ALTER TABLE `avaliacoes`
  MODIFY `idAvaliacao` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `cliente`
--
ALTER TABLE `cliente`
  MODIFY `idCliente` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT for table `descontos`
--
ALTER TABLE `descontos`
  MODIFY `idDesconto` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `editora`
--
ALTER TABLE `editora`
  MODIFY `idEditora` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;
--
-- AUTO_INCREMENT for table `funcionario`
--
ALTER TABLE `funcionario`
  MODIFY `idFuncionario` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT for table `livros`
--
ALTER TABLE `livros`
  MODIFY `idLivro` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=84;
--
-- AUTO_INCREMENT for table `notificacao`
--
ALTER TABLE `notificacao`
  MODIFY `idNotificacao` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `venda`
--
ALTER TABLE `venda`
  MODIFY `idVenda` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=152;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
