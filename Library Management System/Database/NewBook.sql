create table NewBook(
bId int NOT NULL IDENTITY(1,1) primary key,
bName varchar(250) not null,
bAuthor varchar(250) not null,
bPubl varchar(250) not null,
bPubDate varchar(250) not null,
bPrice bigint not null,
bQuan bigint not null
)

drop table NewBook

--insert into NewBook (bName, bAuthor, bPubl, bPubDate, bPrice, bQuan) values ('OOPs', 'Jk Singh Kumar', '', '');
select * from NewBook
