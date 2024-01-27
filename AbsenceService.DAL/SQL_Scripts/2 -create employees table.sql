create table employees
(
 id int identity(1, 1) primary key,
 last_name nvarchar(128) not null,
 first_name nvarchar(128) not null
);