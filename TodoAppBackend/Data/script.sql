CREATE DATABASE [TodoApp];
USE [TodoApp];

CREATE TABLE [Roles] (
    [Id] integer IDENTITY(1, 1) PRIMARY KEY,
    [Name] varchar(100) not null UNIQUE
);

insert into [Roles] values 
('Admin'),
('User');


CREATE TABLE [Users] (
    Id integer IDENTITY(1, 1) PRIMARY KEY,
    Username varchar(100) UNIQUE not null,
    PasswordHash varchar(250) not null,
    CreatedAt Datetime2 not null DEFAULT getdate(),
    Blocked bit not null default 0,
    [Name] varchar(100) not NULL
);

insert into [Users] VALUES 
('diegodrf','000000000',getdate(),0,'Diego Faria'),
('johnhawk','000000000',getdate(),0,'John Hawk'),
('ppt23','000000000',getdate(),0,'Tedd Juarez');

CREATE TABLE [UsersRoles] (
    UserId int not null FOREIGN KEY REFERENCES [Users](Id),
    RoleId int not null FOREIGN KEY REFERENCES [Roles](Id),
    CONSTRAINT UNIQUE_UsersRoles UNIQUE (UserId, RoleId)
);

insert into [UsersRoles] values 
(1, 1),
(1, 2),
(2, 2),
(3, 2);

CREATE TABLE [Todos] (
    Id integer identity(1, 1) PRIMARY KEY,
    Title varchar(100) not null,
    Content varchar(max),
    UserId int not NULL FOREIGN KEY REFERENCES [Users](Id),
    CreatedAt Datetime2 not null DEFAULT getdate(),
    CompletedAt Datetime2
);

insert into [Todos] values 
('First todo','lorem ipsum',1,getdate(),null),
('Todo tile','lorem ipsum',1,getdate(),getdate()),
('Title', 'lorem ipsum', 1, getdate(), null),
('First todo','lorem ipsum',1,getdate(),null),
('First todo','lorem ipsum',1,getdate(),null),
('First todo','lorem ipsum',2,getdate(),getdate()),
('First todo','lorem ipsum',2,getdate(),null),
('First todo','lorem ipsum',2,getdate(),getdate()),
('First todo','lorem ipsum',3,getdate(),null),
('First todo','lorem ipsum',3,getdate(),null),
('First todo','lorem ipsum',1,getdate(),null);