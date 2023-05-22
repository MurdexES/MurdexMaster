use [BarberDB]

create table Barbers
(
  [Name] nvarchar(max) not null check (Name <> ''),
  [Surname] nvarchar(max) not null check (Surname <> ''),
  [Gender] bit not null,
  [PhoneNumber] varchar(max) not null check (LEN(PhoneNumber) >= 7),
  [Email] nvarchar(max) not null check (Email <> ''),
  [BirthDate] date not null check (BirthDate < Barbers.AcceptanceDate),
  [AcceptanceDate] date not null check (AcceptanceDate < GETDATE()),
  [IsChief] bit not null unique ,
  [IsSenior] bit not null ,
  [IsJunior] bit not null ,
);
