


create table clientes(
	id_cliente serial not null,
	nome_cliente varchar(100),
	CPF_cliente varchar(11),
	email_cliente varchar(1000),
	data_nascimento_cliente timestamp,
	primary key(id_cliente)
);


create table dividas(
	id_divida serial not null,
	cliente_id int not null,
	valor_divida real,
	situacao_divida varchar(20),
	data_registro timestamp default now(),
	data_pagamento timestamp,
	constraint fk_id_cliente foreign key(cliente_id) references clientes(id_cliente),
	primary key(id_divida)
);

 

