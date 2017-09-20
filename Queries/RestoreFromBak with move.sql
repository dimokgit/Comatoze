--1. logical names of the database and log files inside the .bak file
RESTORE FILELISTONLY  
FROM DISK = 'F:\northwind.bak'  
GO  

--2 take logical names: Northwind,Northwind_log

--3
RESTORE DATABASE Northwind  
FROM DISK = 'F:\northwind.bak'  
WITH MOVE 'Northwind' TO 'F:\SQLDATA\northwind.mdf',  
MOVE 'Northwind_log' TO 'E:\SQLLOG\northwind.ldf'  
