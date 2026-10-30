create table clientes (
    id_cliente serial not null,
    nome_cliente varchar(100) not null,
    CPF_cliente varchar(11) not null unique,
    email_cliente varchar(255),
    data_nascimento_cliente date,
    primary key (id_cliente)
);


create table dividas (
    id_divida serial not null,
    cliente_id varchar(11),
    valor_divida numeric(10, 2),
    situacao_divida varchar(20),
    data_registro timestamp default now(),
    data_pagamento timestamp,
    constraint fk_CPF_cliente foreign key (cliente_id) references clientes(CPF_cliente),
    primary key (id_divida)
);

select * from clientes;
select * from dividas;

drop table clientes

select id_cliente from clientes where cpf_cliente == "12345678901"
select id_cliente, cpf_cliente from clientes where CPF_cliente = '12345678901'

insert into clientes (nome_cliente, CPF_cliente, email_cliente, data_nascimento_cliente) values (
('Joao Celso', '01645555011', 'teste@teste.com', '2007-05-02');


INSERT INTO clientes (nome_cliente, CPF_cliente, email_cliente, data_nascimento_cliente) VALUES
('Ana Silva', '12345678901', 'ana.silva@email.com', '1990-05-15'),
('Carlos Souza', '98765432109', 'carlos.souza@email.com', '1985-10-20'),
('Mariana Oliveira', '45678912345', 'mariana.oliveira@email.com', '1998-03-12'),
('Roberto Santos', '78912345678', 'roberto.santos@email.com', '1975-12-01'),
('Joao Celso', '01645555011', 'teste@teste.com', '2007-05-02');
INSERT INTO clientes (nome_cliente, CPF_cliente, email_cliente, data_nascimento_cliente) VALUES
('Beatriz Lima', '11122233344', 'beatriz.lima@email.com', '1992-07-22'),
('Lucas Almeida', '55566677788', 'lucas.almeida@email.com', '2001-11-05'),
('Fernanda Costa', '33344455566', 'fernanda.costa@email.com', '1988-09-30'),
('Gabriel Pereira', '99988877766', 'gabriel.pereira@email.com', '1995-02-18');

INSERT INTO clientes (nome_cliente, CPF_cliente, email_cliente, data_nascimento_cliente) VALUES
('Juliana Martins', '77788899900', 'juliana.martins@email.com', '1994-06-10');
insert into clientes values ('')

INSERT INTO dividas (cliente_id, valor_divida, situacao_divida, data_pagamento) VALUES
(1, 1500.50, 'Pendente', NULL),
(1, 350.00, 'Pago', '2026-01-10 14:30:00'),
(2, 2500.00, 'Atrasado', NULL),
(3, 450.75, 'Pago', '2026-05-20 09:15:00'),
(4, 1200.00, 'Pendente', NULL);
