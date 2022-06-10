# Auth Service

### Ports

Reserved service ports:

- port 5115 - Auth Service (Https)
- port 5105 - Auth Service (Http)
- port 5005 - Auth Service (Grpc)

### Migration - creating migration commands:

IdentityServer4
```
Add-Migration InitialPersistedGrantDbMigration -c PersistedGrantDbContext -o Infrastructure/Migrations/IdentityServer/PersistedGrantDb
Add-Migration InitialConfigurationDbMigration -c IdentityServerDbContext -o Infrastructure/Migrations/IdentityServer/ConfigurationDb
```

AuthService
```
Add-Migration InitialApplicationDbMigration -c ApplicationDbContext -o Infrastructure/Migrations/Application/ApplicationDb
```

### Migration - update database commands
```
update-database -context ApplicationDbContext
update-database -context IdentityServerDbContext
update-database -context PersistedGrantDbContext
```
