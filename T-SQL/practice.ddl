if object_id('dbo.employees','u') is not null drop table dbo.emplotees;

create table dbo.employees
(
  empid int not null,
  firstname varchar(30) not null,
  lastname varchar(30) not null,
  hiredate date not null,
  mgrid int null,
  ssn varchar(20) not null,
  salary money not null
);

alter table dbo.employees add constraint pk_employees primary key(empid); 

alter table dbo.employees add constraint empolyee_unique_ssn unique(ssn);

if object_id('dbo.orders', 'u') is not null drop table dbo.orders;

create table dbo.orders
(
  orderid int not null,
  empid int not null,
  custid varchar(10) not null,
  orderts datetime not null,
  qty int not null,
  constraint pk_orders primary key(orderid)
);

alter table dbo.orders add constraint orders_unique_custid unique(custid);

alter table dbo.orders add constraint fk_orders_employee foreign key(empid) references dbo.employees(empid);

alter table dbo.employees with check add constraint fk_employee_employees foreign key(mgrid) references dbo.employees(empid);

alter table dbo.employees with nocheck add constraint check_salary check(salary > 0);

alter table dbo.orders add constraint default_orderts_value default(current_timestamp) for orderts;


