use DiscountMe;
go
exec sp_grantlogin 'IIS APPPOOL\DefaultAppPool';
go
exec sp_grantdbaccess 'IIS APPPOOL\DefaultAppPool';
go