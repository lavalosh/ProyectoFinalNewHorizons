CREATE DATABASE BD_OPERATION
GO
USE BD_OPERATION
GO
CREATE TABLE PAYMENT
(
ID_OPERATION INT PRIMARY KEY IDENTITY(1,1),
ID_INVOICE INT,
AMOUNT DECIMAL(18,2),
[DATE] DATETIME
)
GO
SELECT * FROM PAYMENT