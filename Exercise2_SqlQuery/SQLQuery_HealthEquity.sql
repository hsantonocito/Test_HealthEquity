

SELECT (C.FirstName + ' ' + C.LastName) "Full Name", 
Age, OrderID, DateCreated, MethodOfPurchase "Purchase Method",
ProductName, ProductOrigin
FROM Customer C
INNER JOIN Orders O ON C.PersonID = O.PersonID
INNER JOIN OrdersDetails D ON O.OrderID = D.OrderID
WHERE D.ProductID = 1112222333 



