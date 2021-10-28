--Ejemplo 1
ALTER TABLE Producto
ADD CONSTRAINT DF_Descripcion DEFAULT 'No especifica' 
FOR Descripcion
-----------------------------------------------------

--Ejemplo 2 --
--Ejemplo 3 --
ALTER TABLE Producto
add constraint CHK_Cantidad Check(Cantidad > 10)

INSERT INTO Producto (NOMBRE,DESCRIPCION,CANTIDAD) VALUES('Aspirina','Medicina',12)
INSERT INTO Producto (NOMBRE,DESCRIPCION,CANTIDAD) VALUES('Aspirina','Medicina',45)







