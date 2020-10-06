CREATE DATABASE sic;
USE sic;
CREATE TABLE bodega
(
	codigo_bodega NUMERIC(5) PRIMARY KEY,
    nombre_bodega VARCHAR(60),
    estatus_bodega NUMERIC(1)
);
CREATE TABLE linea
(
	codigo_linea NUMERIC(5) PRIMARY KEY,
    nombre_linea VARCHAR(60),
    estatus_linea NUMERIC(1)
);
CREATE TABLE marca
(
	codigo_marca NUMERIC(5) PRIMARY KEY,
    nombre_marca VARCHAR(60),
    estatus_marca NUMERIC(1)
);
CREATE TABLE producto
(
	codigo_producto NUMERIC(18) PRIMARY KEY,
    nombre_producto VARCHAR(60),
    precio_producto FLOAT(10,2),
    codigo_linea NUMERIC(5),
    codigo_marca NUMERIC(5),
    estatus_producto NUMERIC(1),
    FOREIGN KEY (codigo_linea) REFERENCES linea(codigo_linea),
    FOREIGN KEY (codigo_marca) REFERENCES marca(codigo_marca)
);
CREATE TABLE existencia
(
	codigo_bodega NUMERIC(5),
    codigo_producto NUMERIC(18),
    cantidad_existencia NUMERIC(10),
    PRIMARY KEY (codigo_bodega, codigo_producto),
	FOREIGN KEY (codigo_bodega) REFERENCES bodega(codigo_bodega),
    FOREIGN KEY (codigo_producto) REFERENCES producto(codigo_producto)
);
CREATE TABLE vendedor
(
	codigo_vendedor NUMERIC(5) PRIMARY KEY,
    nombre_vendedor VARCHAR(60),
    direccion_vendedor VARCHAR(60),
    telefono_vendedor VARCHAR(20),
    estatus_vendedor NUMERIC(1)
);
CREATE TABLE cliente
(
	codigo_cliente NUMERIC(5) PRIMARY KEY,
    nombre_cliente VARCHAR(60),
    direccion_cliente VARCHAR(60),
    nit_cliente VARCHAR(20),
    telefono_cliente VARCHAR(20),
    estatus_cliente NUMERIC(1)
);
CREATE TABLE proveedor
(
	codigo_proveedor NUMERIC(5) PRIMARY KEY,
    nombre_proveedor VARCHAR(60),
    direccion_proveedor VARCHAR(60),
    telefono_proveedor VARCHAR(20),
    nit_proveedor VARCHAR(50),
    estatus_proveedor NUMERIC(1)
);
CREATE TABLE compra_encabezado
(
	documento_compraenca NUMERIC(10) PRIMARY KEY,
    codigo_proveedor NUMERIC(5),
    fecha_compraenca DATE,
	total_compraenca FLOAT(10,2),
    estatus_compraenca NUMERIC(1),
    FOREIGN KEY (codigo_proveedor) REFERENCES proveedor(codigo_proveedor)
);
CREATE TABLE compra_detalle
(
	documento_compraenca NUMERIC(10),
    codigo_producto NUMERIC(18),
    cantidad_compradet NUMERIC(10),
    costo_compradet FLOAT(10,2),
	codigo_bodega NUMERIC(5),
    PRIMARY KEY (documento_compraenca, codigo_producto),
    FOREIGN KEY (documento_compraenca) REFERENCES compra_encabezado(documento_compraenca),
    FOREIGN KEY (codigo_producto) REFERENCES producto(codigo_producto),
    FOREIGN KEY (codigo_bodega) REFERENCES bodega(codigo_bodega)
);
CREATE TABLE venta_encabezado
(
	documento_ventaenca NUMERIC(10) PRIMARY KEY,
    codigo_vendedor NUMERIC(5),
    codigo_cliente NUMERIC(5),
    fecha_ventaenca DATE,
    total_ventaenca FLOAT(10,2),
    estatus_ventaenca NUMERIC(1),
    FOREIGN KEY (codigo_vendedor) REFERENCES vendedor(codigo_vendedor),
    FOREIGN KEY (codigo_cliente) REFERENCES cliente(codigo_cliente)
);
CREATE TABLE venta_detalle
(
	documento_ventaenca NUMERIC(10),
    codigo_producto NUMERIC(18),
    cantidad_ventadet NUMERIC(10),
    costo_ventadet FLOAT(10,2),
    codigo_bodega NUMERIC(5),
    PRIMARY KEY (documento_ventaenca, codigo_producto),
    FOREIGN KEY (documento_ventaenca) REFERENCES venta_encabezado(documento_ventaenca),
    FOREIGN KEY (codigo_producto) REFERENCES producto(codigo_producto),
    FOREIGN KEY (codigo_bodega) REFERENCES bodega(codigo_bodega)
);
INSERT INTO linea VALUES (1,"Línea Blanca",1);
INSERT INTO linea VALUES (2,"Línea Electronica",1);

INSERT INTO marca VALUES (1,"MABE",1);
INSERT INTO marca VALUES (2,"WHIRLPOOL",1);
INSERT INTO marca VALUES (3,"SAMSUNG",1);
INSERT INTO marca VALUES (4,"LG",1);
INSERT INTO marca VALUES (5,"SONY",1);
INSERT INTO marca VALUES (6,"APPLE",1);

INSERT INTO bodega VALUES (1,"BODEGA NO. 1",1);
INSERT INTO bodega VALUES (2,"BODEGA NO. 2",1);
INSERT INTO bodega VALUES (3,"BODEGA NO. 3",1);
INSERT INTO bodega VALUES (4,"BODEGA NO. 4",1);

INSERT INTO PRODUCTO VALUES (1,"IPHONE 8",8500,2,6,1);
INSERT INTO PRODUCTO VALUES (2,"IPHONE X",9500.50,2,6,1);
INSERT INTO PRODUCTO VALUES (3,"TV OLED 4K",12152.99,2,4,1);
INSERT INTO PRODUCTO VALUES (4,"REFRIGERADORA DOBLE PUERTA",9800,1,2,1);
INSERT INTO PRODUCTO VALUES (5,"ESTUFA 6 HORNILLAS",7200,1,1,1);
