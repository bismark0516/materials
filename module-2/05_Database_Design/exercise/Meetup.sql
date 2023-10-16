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
   CREATE TABLE [Interest_Group](
  group_id INT IDENTITY (1,1) PRIMARY KEY,
  group_name VARCHAR(255),
  CONSTRAINT [UQ_group_name] UNIQUE (group_name)
  )

  CREATE TABLE [member_interest_group] (
  member_id INT NOT NULL,
  group_id INT NOT NULL,
  )

  CREATE TABLE [member_group] (
  group_id INT ,
  member_id INT 
 )
  

  CREATE TABLE [event](
  event_id INT IDENTITY (1,1),
  event_name VARCHAR(255),
  event_description VARCHAR(255),
  start_time DATETIME,
  event_length INT,
  group_id INT REFERENCES Interest_Group(group_id)
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

--UPDATE event SET event .group_id = (SELECT group_id FROM Interest_Group WHERE Interest_Group.group_name = 'family') WHERE event_name = 'Music in the Park'
--UPDATE event SET group_id = '3' WHERE event_name = 'Tech Conference'
--UPDATE event SET group_id = '4' WHERE event_name = 'Art Exhibition Opening'
--UPDATE event SET group_id = '4' WHERE event_name = 'Charity Run'
--UPDATE event SET group_id = '1' WHERE event_name = 'Cooking Class'
--UPDATE event SET group_id = '1' WHERE event_name = 'Movie Night'
--UPDATE event SET group_id = '2' WHERE event_name = 'Book Club Meeting'

--ALTER TABLE [] WITH CHECK ADD CONSTRAINT [FK_state_city]
--FOREIGN KEY(capital) REFERENCES [city] (city_id)
--SELECT * FROM event
