create table user_info(
    userid int primary key not null IDENTITY(1,1),
    username varchar(100) not null,
    userpassword varchar(100) not null
    );