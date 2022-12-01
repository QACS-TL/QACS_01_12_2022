The Database First app needs to access a SQL Server database the set up script for which is located in MoviesDatabaseSQLServerScriptReduced.sql

The CodeFirstEF and DatabaseFirstEF projects use the Entity Framework to hook up to an underlying database. The Codefirst app will automatically generate the (SQL Server) database from scratch.

The DataBAseFirstEFMySQL project is designed to work with a MySQL database.

You will almost ceratinly need to configure the connection strings with appropriate credentials and server names.

The NoSQLDB app uses a MongoDB database. No SQL databases are "in vogue" because they are designed to work with "messy, ragged data" of the sort being collected by organisations these days.