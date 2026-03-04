create database eventdb;
1
create table Userinfo (
Emailid varchar(100) primary key,
Username Varchar(50) NOT NULL check(len(Username)between 1 And 50),
role varchar(20) not null check(role in ('Admin', 'Participant')),
Password varchar(20) Not NUll check(len(Password)between 6 and 20) );


2
create table EventDetails(
Eventid int primary key,
EventName varchar(50) not null check(len(EventName) between 1 and 50),
Eventcategory varchar(50) not null check(len(Eventcategory) between 1 and 50),
Eventdate datetime Not Null ,
Description varchar(25) Null,
Status varchar(20) check(Status in ('Active', 'In-Active'))
);

3  
create table SpeakersDetails(
Speakerid int primary key,
SpeakerName Varchar(50) not null check(len(SpeakerName) between 1 and 50)
 );
 
 4
create table SessionInfo (
    SessionId  int  primary key,
    EventId int not null,
    SessionTitle varchar(50) not null
        check (len(SessionTitle) between 1 AND 50),
    SpeakerId INT NOT NULL,
    _Description varchar(255) null,
    SessionStart DATETIME not null,
    SessionEnd DATETIME not null,
    SessionUrl varchar(255) null,
        foreign key (EventId)
        references EventDetails(EventId),
        foreign key (SpeakerId)
        references SpeakersDetails(SpeakerId));

5 
create table ParticipantEventDetails (
    Id int IDENTITY(1,1) primary key,
    ParticipantEmailId varchar(100) not null,
    EventId int not null,
    SessionId int not null,
    IsAttended bit not null
        check (IsAttended in (0,1)),
        foreign key (ParticipantEmailId)
        references UserInfo(EmailId),
        foreign key (EventId)
references EventDetails(EventId),
        foreign key (SessionId)
        references SessionInfo(SessionId)
);


SELECT name 
FROM sys.tables;