create table NewMember(
ID int NOT NULL IDENTITY(1,1) primary key,
EnrollID AS 'UID-' + RIGHT('100' + CAST(ID AS VARCHAR(5)), 5) PERSISTED,
mName varchar(250) not null,
mContact bigint not null,
mEmail varchar(250) not null,
mState varchar(250) not null,
mCity varchar(250) not null,
mPinCode bigint not null,
mPassword varchar(255) not null
)



drop table NewMember

ALTER TABLE NewMember alter COLUMN mPassword varchar(250) not null;



--ID , EnrollID , mName, mContact, mEmail, mState, mCity, mPinCode
select * from NewMember	

