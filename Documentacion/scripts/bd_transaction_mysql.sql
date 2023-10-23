CREATE TABLE [transaction] (
   id_operation int primary key,
   id_invoice int,
   amount decimal(18,2),
   [date] datetime,
);
select * from [transaction]