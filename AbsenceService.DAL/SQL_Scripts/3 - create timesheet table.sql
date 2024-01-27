create table timesheet
(
 id int identity(1, 1) primary key,
 employee int references employees(id),
 reason int not null,
 start_date date not null,
 duration int not null,
 discounted bit not null,
 description nvarchar(1024)
);