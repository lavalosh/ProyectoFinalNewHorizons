CREATE TABLE Invoice (
   id_invoice int primary key,
   amount decimal,
   state int,
);
select * from Invoice;

insert into Invoice values(1,1009,1);
insert into Invoice values(2,503,1);
insert into Invoice values(3,2079,1);
insert into Invoice values(4,20000,1);
insert into Invoice values(5,109,1);
insert into Invoice values(6,9999,1);
insert into Invoice values(7,1789,1);