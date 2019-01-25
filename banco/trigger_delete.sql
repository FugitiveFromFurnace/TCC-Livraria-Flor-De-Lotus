delimiter //
create trigger trg_deleteLivro
	after delete on livros for each row

begin
    insert into antigaImagem value(old.capaLivro);
end //
        