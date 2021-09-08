/* Customer as Attributes */
Declare @xmldata xml
set @xmldata = '<Customers>' + (SELECT [CustomerID],[Title],[FirstName],[MiddleName],[LastName],[Suffix],[CompanyName],[SalesPerson],[EmailAddress],[Phone] FROM [SalesLT].[Customer] As Customer FOR XML AUTO) + '</Customers>' 
select @xmldata as returnXml

/* Customer as Elements */
Declare @xmldata xml
set @xmldata = '<Customers>' + (SELECT [CustomerID],[Title],[FirstName],[MiddleName],[LastName],[Suffix],[CompanyName],[SalesPerson],[EmailAddress],[Phone] FROM [SalesLT].[Customer] As Customer FOR XML AUTO, ELEMENTS) + '</Customers>' 
select @xmldata as returnXml

/* Customer/Sales Header/Sales Detail */
Declare @xmldata xml
set @xmldata = (SELECT [CustomerID],[Title],[FirstName],[MiddleName],[LastName],[Suffix],[CompanyName],[SalesPerson],[EmailAddress],[Phone], (SELECT [SalesOrderID],[OrderDate],[DueDate],[ShipDate],[Status],[SalesOrderNumber],[PurchaseOrderNumber],[AccountNumber],[CustomerID],[ShipToAddressID],[BillToAddressID],[ShipMethod],[CreditCardApprovalCode],[SubTotal],[TaxAmt],[Freight],[TotalDue],[Comment], (SELECT [SalesOrderID],[SalesOrderDetailID],[OrderQty],[ProductID],[UnitPrice],[UnitPriceDiscount],[LineTotal] FROM SalesLT.SalesOrderDetail OrderDetail WHERE OrderDetail.SalesOrderID = SalesHeader.SalesOrderID FOR XML AUTO, TYPE, ELEMENTS) As OrderDetails FROM SalesLT.SalesOrderHeader SalesHeader WHERE SalesHeader.CustomerID = Customer.CustomerID FOR XML AUTO, TYPE, ELEMENTS) AS SalesHeaders FROM SalesLT.Customer Customer FOR XML AUTO, ELEMENTS)
select @xmldata as returnXml

/* Sales Header as Elements */
Declare @xmldata xml
set @xmldata = (SELECT [SalesOrderID],[OrderDate],[DueDate],[ShipDate],[Status],[SalesOrderNumber],[PurchaseOrderNumber],[AccountNumber],[CustomerID],[ShipToAddressID],[BillToAddressID],[ShipMethod],[CreditCardApprovalCode],[SubTotal],[TaxAmt],[Freight],[TotalDue],[Comment] FROM [SalesLT].[SalesOrderHeader] As SalesOrderHeader FOR XML AUTO, ELEMENTS)
select @xmldata as returnXml

/* Sales Order Detail as Elements */
Declare @xmldata xml
set @xmldata = (SELECT [SalesOrderID],[SalesOrderDetailID],[OrderQty],[ProductID],[UnitPrice],[UnitPriceDiscount],[LineTotal] FROM SalesLT.SalesOrderDetail OrderDetail FOR XML AUTO, ELEMENTS)
select @xmldata as returnXml
