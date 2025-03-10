USE [StoreSample]
GO
/****** Object:  StoredProcedure [dbo].[CustomerOrderPrediction]    Script Date: 9/03/2025 5:14:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CustomerOrderPrediction]
AS
  
 BEGIN  

   

WITH OrderIntervals AS (
    SELECT 
        O.custid,
        O.orderdate,
        LAG(O.orderdate) OVER (PARTITION BY O.custid ORDER BY O.orderdate) AS PreviousOrderDate
    FROM [StoreSample].[Sales].[Orders] AS O
),
AvgOrderIntervals AS (
    SELECT 
        custid,
        AVG(DATEDIFF(DAY, PreviousOrderDate, orderdate)) AS AvgDaysBetweenOrders
    FROM OrderIntervals
    WHERE PreviousOrderDate IS NOT NULL
    GROUP BY custid
),
LastOrder AS (
    SELECT 
        O.custid,
        MAX(O.orderdate) AS LastOrderDate
    FROM [StoreSample].[Sales].[Orders] AS O
    GROUP BY O.custid
)
SELECT c.custid AS CustId,
    C.companyname AS CustomerName,
    L.LastOrderDate,
    DATEADD(DAY, COALESCE(A.AvgDaysBetweenOrders, 0), L.LastOrderDate) AS NextPredictedOrder
FROM [Sales].Customers AS C
INNER JOIN LastOrder AS L ON C.custid = L.custid
LEFT JOIN AvgOrderIntervals AS A ON C.custid = A.custid
ORDER BY C.companyname



  END
GO
/****** Object:  StoredProcedure [dbo].[Employee_GetAll]    Script Date: 9/03/2025 5:14:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Script for SelectTopNRows command from SSMS  ******/
CREATE PROCEDURE [dbo].[Employee_GetAll]
	
AS
BEGIN
SELECT [empid] AS EmpId
      ,[firstname] +' '+ [lastname]  AS FullName
      ,[title] AS Title 
      ,[titleofcourtesy] AS TitleOfCourtesy
      ,[birthdate] AS BirthDate
      ,[hiredate] AS HireDate
      ,[address] AS Address
      ,[city] AS City
      ,[region] AS Region
      ,[postalcode] AS PostalCode
      ,[country] AS Country
      ,[phone] AS Phone,
	   mgrid AS Mgrid
  FROM [StoreSample].[HR].[Employees]

  END
GO
/****** Object:  StoredProcedure [dbo].[Order_GetCust]    Script Date: 9/03/2025 5:14:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Order_GetCust]  @CustId int AS
   BEGIN  
SELECT distinct   O.[orderid] AS OrderId
      ,[custid]  AS CustId
      ,[empid]
      ,[orderdate] AS OrderDate
      ,[requireddate] AS RequiredDate
      ,[shippeddate] AS ShippedDate
      ,[shipperid]
      ,[freight] AS Freight
      ,[shipname] AS ShipName
      ,[shipaddress] AS ShipAddress
      ,[shipcity] AS ShipCity
      ,[shipregion] AS ShipRegion
      ,[shippostalcode] AS ShippostalCode
      ,[shipcountry] AS ShipCountry
	  --,D.productid AS ProductId
	  --,D.unitprice AS  UnitPrice
	  --,D.qty  AS  Qty
	  --,d.discount as Discount
	  ,0 AS ProductId
	  ,0.0 AS  UnitPrice
	  ,0 AS  Qty
	  ,0.0 discount
  FROM [StoreSample].[Sales].[Orders] AS O
  INNER JOIN  [StoreSample].[Sales].OrderDetails AS D
  ON (O.[orderid]=D.[orderid])
  WHERE custid =@CustId

  END
GO
/****** Object:  StoredProcedure [dbo].[Order_Insert]    Script Date: 9/03/2025 5:14:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Order_Insert]  
@custId int, 
@empid int, 
@orderdate datetime, 
@requireddate datetime, 
@shippeddate datetime, 
@shipperid int, 
@freight money, 
@shipname nvarchar(40),
@shipaddress nvarchar(60), 
@shipcity nvarchar(15), 
@shipcountry nvarchar(15), 

@productid int, 
@unitprice money, 
@qty smallint, 
@discount numeric(4,3)


AS
   BEGIN  


INSERT INTO [Sales].[Orders]
           ([custid]
           ,[empid]
           ,[orderdate]
           ,[requireddate]
           ,[shippeddate]
           ,[shipperid]
           ,[freight]
           ,[shipname]
           ,[shipaddress]
           ,[shipcity]
           ,[shipcountry])
     VALUES
           (@custId
           ,@empid
           ,@orderdate
           ,@requireddate
           ,@shippeddate
           ,@shipperid
           ,@freight
           ,@shipname
           ,@shipaddress
           ,@shipcity
           ,@shipcountry
           )

 DECLARE @id int
 SELECT @id =   (SELECT SCOPE_IDENTITY())

INSERT INTO [Sales].[OrderDetails]
           ([orderid]
           ,[productid]
           ,[unitprice]
           ,[qty]
           ,[discount])
     VALUES
           (@id
           ,@productid
           ,@unitprice
           ,@qty
           ,@discount)



  END
GO
/****** Object:  StoredProcedure [dbo].[Product_GetAll]    Script Date: 9/03/2025 5:14:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Product_GetAll]
	
AS
BEGIN
	SELECT [productid] AS ProductId
		  ,[productname] AS ProductName
		  ,[supplierid] AS SupplierId
		  ,[categoryid] AS CategoryId
		  ,[unitprice] AS UnitPrice
		  ,[discontinued] AS Discontinued
	  FROM [StoreSample].[Production].[Products]
END
GO
/****** Object:  StoredProcedure [dbo].[Shipper_GetAll]    Script Date: 9/03/2025 5:14:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


  -- =============================================
CREATE PROCEDURE [dbo].[Shipper_GetAll]
	
AS
BEGIN
	SELECT [shipperid] AS ShipperId
      ,[companyname] AS CompanyName
      ,[phone] AS Phone
  FROM [StoreSample].[Sales].[Shippers]
END
GO
