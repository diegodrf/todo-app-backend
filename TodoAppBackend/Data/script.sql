CREATE DATABASE [TodoApp];
USE [TodoApp];

CREATE TABLE [Roles] (
    [Id] INTEGER IDENTITY(1, 1) PRIMARY KEY,
    [Name] VARCHAR(100) NOT NULL UNIQUE
);

INSERT INTO [Roles] VALUES 
('Admin'),
('User');


CREATE TABLE [Users] (
    Id INTEGER IDENTITY(1, 1) PRIMARY KEY,
    Username VARCHAR(100) UNIQUE NOT NULL,
    PasswordHash VARCHAR(250) NOT NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    Blocked BIT NOT NULL default 0,
    [Name] VARCHAR(100) NOT NULL
);

INSERT INTO [Users] VALUES 
('diegodrf','000000000',GETDATE(),0,'Diego Faria'),
('johnhawk','000000000',GETDATE(),0,'John Hawk'),
('ppt23','000000000',GETDATE(),0,'Tedd Juarez');

CREATE TABLE [UsersRoles] (
    UserId INTEGER NOT NULL FOREIGN KEY REFERENCES [Users](Id),
    RoleId INTEGER NOT NULL FOREIGN KEY REFERENCES [Roles](Id),
    CONSTRAINT UNIQUE_UsersRoles UNIQUE (UserId, RoleId)
);

INSERT INTO [UsersRoles] VALUES 
(1, 1),
(1, 2),
(2, 2),
(3, 2);

CREATE TABLE [Todos] (
    Id INTEGER identity(1, 1) PRIMARY KEY,
    Title VARCHAR(100) NOT NULL,
    Content VARCHAR(max),
    UserId INTEGER NOT NULL FOREIGN KEY REFERENCES [Users](Id),
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    CompletedAt DATETIME2
);

INSERT INTO [Todos] VALUES 
('First todo','lorem ipsum',1,GETDATE(),NULL),
('Todo tile','lorem ipsum',1,GETDATE(),GETDATE()),
('Title', 'lorem ipsum', 1, GETDATE(), NULL),
('First todo','lorem ipsum',1,GETDATE(),NULL),
('First todo','lorem ipsum',1,GETDATE(),NULL),
('First todo','lorem ipsum',2,GETDATE(),GETDATE()),
('First todo','lorem ipsum',2,GETDATE(),NULL),
('First todo','lorem ipsum',2,GETDATE(),GETDATE()),
('First todo','lorem ipsum',3,GETDATE(),NULL),
('First todo','lorem ipsum',3,GETDATE(),NULL),
('First todo','lorem ipsum',1,GETDATE(),NULL);