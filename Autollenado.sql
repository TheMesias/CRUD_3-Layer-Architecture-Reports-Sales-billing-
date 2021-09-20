use Practica
insert into Tb_Pagos Values
('TC','TARJETA DE CREDITO'),
('TD','TARJETA DE DEBITO'),
('CO','CONTADO')
insert into Tb_Categoria Values
('V','VIDEO','Elementos dedicados a reproduccion de video'),
('A','AUDIO','Elementos dedicados unicamente a reproduccion de audio'),
('L','LUCES','Elementos dedicados unicamente a ILUMINACION'),
('R','RADIOS','Elementos dedicados a reseptores de señales de audio y multimedia')
insert into Tb_Producto 
values
('V','Pantalla LCD', '15 PULGADAS', 'LG', 110.5, 24),
('A','Parlante', '80 WATTS', 'LG', 87.5, 24),
('A','Parlante', '30 WATTS', 'FUNY', 97.5, 24),
('V','Pantalla LCD', '15 PULGADAS', 'LG', 110.5, 24),
('V','Pantalla LCD', '10 PULGADAS', 'SAMSUNG', 100.5, 24),
('A','Parlante', '30 WATTS', 'PRONEER', 34.5, 24),
('R','Radio', 'RADIO CLACICO', 'SAMSUNG', 80, 24),
('R','Radio', 'RADIO + PANTALLA', 'LG', 280.5, 24),
('A','Amplificador', '300 WATTS', 'PIONER', 300, 24),
('L','Tira led', '5 mts AZUL', 'SAMSUNG', 80, 24),
('L','Tira led', '5 mts ROJO', 'NG', 10, 24),
('L','Tira led', '5 mts MORADO', 'PIONER', 10, 24),
('L','Tira led', '5 mts Multicolor', 'PIONER', 25, 24)
insert into Tb_cliente values
('0000000000', 'Consumidor Final','09xxxxxxxx','Orellana'),
('0605151067', 'Takeo Masaki', '0923456789','Orellana')
insert into Users values ('admin', 'admin', 'Francisco', 'Mesias', 'Administrador', 'email@gmail.com')
go
use Practica
go
declare @user nvarchar(100) = 'xxxxx'
declare @pass nvarchar(100) = 'xxxxx'
go
