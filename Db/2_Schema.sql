

DROP TABLE IF EXISTS productlines cascade; 
CREATE TABLE productlines (
  productLine varchar(50) not null,
  textDescription varchar(4000) default null,
  htmlDescription text,
  image bytea,
  primary key (productLine)
);

DROP TABLE IF EXISTS products cascade;
CREATE TABLE products (
  productCode varchar(15) not null,
  productName varchar(70) not null,
  productLine varchar(50) not null,
  productScale varchar(10) not null,
  productVendor varchar(50) not null,
  productDescription text not null,
  quantityInStock numeric(6) not null,
  buyPrice numeric(10,2) not null,
  MSRP numeric(10,2) not null,
  primary key (productCode),
  constraint products_ibfk_1 foreign key (productLine) references productlines (productLine)
  on delete cascade
);

CREATE INDEX productLine on products (productLine);


DROP TABLE IF EXISTS offices cascade; 
CREATE TABLE offices (
  officeCode varchar(10) not null,
  city varchar(50) not null,
  phone varchar(50) not null,
  addressLine1 varchar(50) not null,
  addressLine2 varchar(50) default null,
  state varchar(50) default null,
  country varchar(50) not null,
  postalCode varchar(15) not null,
  territory varchar(10) not null,
  primary key (officeCode)
) ;



DROP TABLE IF EXISTS employees cascade ;
CREATE TABLE employees (
  employeeNumber numeric(10) not null,
  lastName varchar(50) not null,
  firstName varchar(50) not null,
  extension varchar(10) not null,
  email varchar(100) not null,
  officeCode varchar(10) not null,
  reportsTo numeric(10) default null,
  jobTitle varchar(50) not null,
  primary key (employeeNumber)
 ,
  constraint employees_ibfk_1 foreign key (reportsTo) references employees (employeeNumber) on delete cascade,
  constraint employees_ibfk_2 foreign key (officeCode) references offices (officeCode) on delete cascade
) ;

CREATE INDEX reportsTo on employees (reportsTo);
CREATE INDEX officeCode on employees (officeCode);


DROP TABLE IF EXISTS customers cascade;
CREATE TABLE customers (
  customerNumber numeric(10) not null,
  customerName varchar(50) not null,
  contactLastName varchar(50) not null,
  contactFirstName varchar(50) not null,
  phone varchar(50) not null,
  addressLine1 varchar(50) not null,
  addressLine2 varchar(50) default null,
  city varchar(50) not null,
  state varchar(50) default null,
  postalCode varchar(15) default null,
  country varchar(50) not null,
  salesRepEmployeeNumber numeric(10) default null,
  creditLimit numeric(10,2) default null,
  primary key (customerNumber),
  constraint customers_ibfk_1 foreign key (salesRepEmployeeNumber) references employees (employeeNumber) on delete cascade
);

CREATE INDEX salesRepEmployeeNumber on customers (salesRepEmployeeNumber);


DROP TABLE IF EXISTS payments cascade;
CREATE TABLE payments (
  customerNumber numeric(10) not null,
  checkNumber varchar(50) not null,
  paymentDate date not null,
  amount numeric(10,2) not null,
  primary key (customerNumber,checkNumber),
  constraint payments_ibfk_1 foreign key (customerNumber) references customers (customerNumber) on delete cascade
) ;


DROP TABLE IF EXISTS orders cascade;
CREATE TABLE orders (
  orderNumber numeric(10) not null,
  orderDate date not null,
  requiredDate date not null,
  shippedDate date default null,
  status varchar(15) not null,
  comments text,
  customerNumber numeric(10) not null,
  primary key (orderNumber),
  constraint orders_ibfk_1 foreign key (customerNumber) references customers (customerNumber) on delete cascade
);

CREATE INDEX customerNumber on orders (customerNumber);


DROP TABLE IF EXISTS orderdetails cascade;
CREATE TABLE orderdetails (
  orderNumber numeric(10) not null,
  productCode varchar(15) not null,
  quantityOrdered numeric(10) not null,
  priceEach numeric(10,2) not null,
  orderLineNumber numeric(5) not null,
  primary key (orderNumber,productCode),
  constraint orderdetails_ibfk_1 foreign key (orderNumber) references orders (orderNumber) on delete cascade,
  constraint orderdetails_ibfk_2 foreign key (productCode) references products (productCode) on delete cascade
);

CREATE INDEX productCode on orderdetails (productCode);