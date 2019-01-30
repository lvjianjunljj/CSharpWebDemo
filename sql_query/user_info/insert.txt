insert into user_info
    values('abcd3','123456');

insert into 
    user_info(username,userpassword)
    values('abcd2','123456');

SET IDENTITY_INSERT user_info ON
insert into 
    user_info(userid,username,userpassword)
    values(2,'abcd','123456');
SET IDENTITY_INSERT user_info OFF
