DROP DATABASE IF EXISTS enterprise_center;
CREATE DATABASE enterprise_center;

CREATE USER enterprise_user WITH PASSWORD 'abcde12345';
GRANT SELECT, INSERT, UPDATE, DELETE ON ALL TABLES IN SCHEMA public TO enterprise_user;