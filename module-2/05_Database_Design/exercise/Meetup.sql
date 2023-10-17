USE [master];
GO

IF DB_ID('MeetUp') IS NOT NULL
BEGIN
	ALTER DATABASE [MeetUp] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE [MeetUp];
END

CREATE DATABASE [MeetUp];
GO

USE [MeetUp];
GO


CREATE TABLE [member] (
  member_id INT IDENTITY (1,1) PRIMARY KEY,
  last_name VARCHAR(255) NOT NULL,
  first_name  VARCHAR (255) NOT NULL,
  phone_number  CHAR (12) NULL,
  DOB DATE  NOT NULL,
  email_address NVARCHAR(255) NOT NULL,
  email_reminder BIT NOT NULL,
 
  )
  CREATE TABLE [event_member](
  member_id INT NOT NULL,
  event_id INT NOT NULL,
  CONSTRAINT [pkevent_memberkey] PRIMARY KEY (member_id,event_id)
  )



  CREATE TABLE [interest_group](
  group_id INT IDENTITY (1,1) PRIMARY KEY,
  group_name VARCHAR(255),
  CONSTRAINT [UQ_group_name] UNIQUE (group_name)
  )

  CREATE TABLE [member_interest_group] (
  member_id INT NOT NULL,
  group_id INT NOT NULL,
 
  )

  CREATE TABLE [member_group] (
  group_id INT NOT NULL,
  member_id INT NOT NULL,
  CONSTRAINT [PKmember_group_id]
  PRIMARY KEY (group_id, member_id)
  
 )
  
  CREATE TABLE [event](
  event_id INT IDENTITY (1,1) PRIMARY KEY,
  event_name VARCHAR(255),
  event_description VARCHAR(255),
  start_time DATETIME,
  event_length INT,
  group_id INT 
  )
  
 INSERT INTO [member] (last_name, first_name,phone_number,DOB,email_address, email_reminder)
 VALUES ('Akomeah', 'Bismark', '614-218-7728', '1995-05-16','bismarkjunior@yahoo.com', 0)
 INSERT INTO [member] (last_name, first_name,phone_number,DOB,email_address, email_reminder)
 VALUES ('Webster', 'Annie', '440-787-6630', '1994-12-31', 'annie.webster@yahoo.com', 1)
 INSERT INTO [member] (last_name, first_name,phone_number,DOB,email_address, email_reminder)
 VALUES ('Akomeah', 'Anne', '440-878-3360', '1994-11-29', 'annie.akomeah@gmail.com', 0)
 INSERT INTO [member] (last_name, first_name,phone_number,DOB,email_address, email_reminder)
 VALUES ('Akomeah' , 'Linda', '614-556-7789', '1976-01-01', 'linda.akomeah@gmail.com', 1)
 INSERT INTO [member] (last_name, first_name,phone_number,DOB,email_address, email_reminder)
 VALUES  ('Thomas' , 'John', '614-576-0094', '1974-04-15', 'john.thomas@gmail.com', 0)
 INSERT INTO [member] (last_name, first_name,phone_number,DOB,email_address, email_reminder)
 VALUES  ('Matthews' , 'Chris', '614-588-4536', '1986-09-11', 'chris.matthews@gmail.com', 1)
 INSERT INTO [member] (last_name, first_name,phone_number,DOB,email_address, email_reminder)
 VALUES  ('Thompson' , 'Louisa', '614-655-8575', '1996-08-12', 'louisa.thompson@gmail.com', 1)
 INSERT INTO [member] (last_name, first_name,phone_number,DOB,email_address,email_reminder)
 VALUES ('Fulton' , 'Marcus', '614-787-3245', '1926-05-18', 'marcus.fulton@gmail.com', 1)



 INSERT INTO [member_group] (member_id, group_id)
 VALUES (1,1)
 INSERT INTO [member_group] (member_id, group_id)
 VALUES (2,2)
 INSERT INTO [member_group] (member_id, group_id)
 VALUES (3,3)
 INSERT INTO [member_group] (member_id, group_id)
 VALUES (4,4)
 INSERT INTO [member_group] (member_id, group_id)
 VALUES (5,3)
 INSERT INTO [member_group] (member_id, group_id)
 VALUES (6,2)
 INSERT INTO [member_group] (member_id, group_id)
 VALUES (7,1)

 INSERT INTO [member_interest_group] (member_id, group_id)
 VALUES (1,1)
 INSERT INTO [member_interest_group] (member_id, group_id)
 VALUES (2,2)
 INSERT INTO [member_interest_group] (member_id, group_id)
 VALUES (3,3)
 INSERT INTO [member_interest_group] (member_id, group_id)
 VALUES (4,4)
 INSERT INTO [member_interest_group] (member_id, group_id)
 VALUES (5,4)
 INSERT INTO [member_interest_group] (member_id, group_id)
 VALUES (6,3)
 INSERT INTO [member_interest_group] (member_id, group_id)
 VALUES (7,2)





 INSERT INTO event (event_name, event_description, start_time, event_length)
 VALUES ('Music in the Park', 'Enjoy a relaxing evening of live music in the local park', '2023-10-20 18:00:00', 250 )
 INSERT INTO event (event_name, event_description, start_time, event_length)
 VALUES ('Tech Conference', 'A cutting-edge tech conference featuring keynote speakers and workshops.', '2023-11-05 09:00:00', 120)
 INSERT INTO event (event_name, event_description, start_time, event_length)
 VALUES ('Art Exhibition Opening', 'Celebrate the opening of a new art exhibition showcasing local artists.', '2023-10-28 19:00:00', 120)
 INSERT INTO event (event_name, event_description, start_time, event_length)
 VALUES ('Charity Run', 'Participate in a charity run to raise funds for a good cause', '2023-11-12 08:30:00', 240)
 INSERT INTO event (event_name, event_description, start_time, event_length)
 VALUES ('Cooking Class', 'Learn to cook delicious dishes from a professional chef.', '2023-10-25 17:30:00', 150)
 INSERT INTO event (event_name, event_description, start_time, event_length)
 VALUES ('Movie Night', 'Watch a classic film under the stars with friends and family.', '2023-11-03 19:00:00', 120)
 INSERT INTO event (event_name, event_description, start_time, event_length)
 VALUES ('Book Club Meeting', 'Discuss the latest book selection and enjoy literary discussions.', '2023-10-22 16:00:00', 90)


INSERT INTO [Interest_Group] (group_name)
VALUES ('Family')
INSERT INTO [Interest_Group] (group_name)
VALUES ('Friends')
INSERT INTO [Interest_Group] (group_name)
VALUES ('Professional')
INSERT INTO [Interest_Group] (group_name)
VALUES ('Personal')

--event updates--
UPDATE event SET event.group_id = (SELECT group_id FROM Interest_Group WHERE Interest_Group.group_name = 'family') WHERE event_name = 'Music in the Park'
UPDATE event SET event.group_id = (SELECT group_id FROM Interest_Group WHERE Interest_Group.group_name ='professional') WHERE event_name = 'Tech Conference'
UPDATE event SET event.group_id = (SELECT group_id FROM Interest_Group WHERE Interest_Group.group_name = 'personal') WHERE event_name = 'Art Exhibition Opening'
UPDATE event SET event.group_id = (SELECT group_id FROM Interest_Group WHERE Interest_Group.group_name = 'personal') WHERE event_name = 'Charity Run'
UPDATE event SET event.group_id = (SELECT group_id FROM Interest_Group WHERE Interest_Group.group_name = 'friends') WHERE event_name = 'Cooking Class'
UPDATE event SET event.group_id = (SELECT group_id FROM Interest_Group WHERE Interest_Group.group_name = 'family') WHERE event_name = 'Movie Night'
UPDATE event SET event.group_id = (SELECT group_id FROM Interest_Group WHERE Interest_Group.group_name = 'friends') WHERE event_name = 'Book Club Meeting'

--member group updates--
 
ALTER TABLE [member_interest_group] 
ADD CONSTRAINT [FK_member_id]
FOREIGN KEY(member_id) REFERENCES [member] (member_id)

ALTER TABLE [member_interest_group]
ADD CONSTRAINT [FKmember_interest_group_id]
FOREIGN KEY(group_id) REFERENCES [interest_group] (group_id)


ALTER TABLE [member_group] 
ADD CONSTRAINT [FKmember_group_member_id]
FOREIGN KEY(member_id) REFERENCES [member] (member_id)

ALTER TABLE [member_group] 
ADD CONSTRAINT [FKmember_group_group_id]
FOREIGN KEY(group_id) REFERENCES [interest_group] (group_id)

ALTER TABLE [event_member] 
ADD CONSTRAINT [FKevent_id]
FOREIGN KEY(event_id) REFERENCES [event] (event_id)

ALTER TABLE [event_member] 
ADD CONSTRAINT [FKevent_member_group_id]
FOREIGN KEY(member_id) REFERENCES [member] (member_id)

ALTER TABLE [event] 
ADD CONSTRAINT [check_event_length] CHECK 
(event_length >= 30)

SELECT * FROM member 
SELECT * FROM member_interest_group
SELECT * FROM member_group
SELECT * FROM [event]
SELECT * FROM Interest_Group


