<Query Kind="SQL" />

CREATE LOGIN [IIS AppPool\DefaultAppPool] FROM WINDOWS;
CREATE USER IISUser FOR LOGIN [IIS AppPool\DefaultAppPool];
grant execute on schema :: dbo to [IIS AppPool\DefaultAppPool];
grant select on schema :: dbo to [IIS AppPool\DefaultAppPool];
grant insert on schema :: dbo to [IIS AppPool\DefaultAppPool];
grant update on schema :: dbo to [IIS AppPool\DefaultAppPool];
grant delete on schema :: dbo to [IIS AppPool\DefaultAppPool];