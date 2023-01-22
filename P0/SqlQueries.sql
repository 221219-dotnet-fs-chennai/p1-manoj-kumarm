use project0
GO

create table [trainer_details](
	[trainerid] int not null,
	[Email] varchar(50),
	[Password] varchar(max),
	[fullname] varchar(50),
	[phone] varchar(10),
	[website] varchar(50),
	[aboutme] varchar(max),
	[gender] varchar(10),
	constraint [PK_trainer_id] primary key ([trainerid])
)
	
create table [trainer_skill](
	[skill] varchar(50),
	[trainerskillid] int not null
	constraint [FK_trainer_skill_id] foreign key ([trainerskillid]) references [trainer_details] ([trainerid]) on delete cascade
)

create table [trainer_education](
	[institute] varchar(max),
	[degreename] varchar(100),
	[gpa] varchar(5),
	[startdate] varchar(10),
	[enddate] varchar(10),
	[trainereducationid] int not null,
	constraint [FK_trainer_education_id] foreign key (trainereducationid) references [trainer_details]([trainerid]) on delete cascade
)


create table [trainer_company](
	[companyname] varchar(50),
	[title] varchar(25),
	[startyear] varchar(20),
	[endyear] varchar(20),
	[trainercompanyid] int not null,
	constraint [FK_trainer_company_id] foreign key ([trainercompanyid]) references [trainer_details]([trainerid]) on delete cascade
)


create table [trainer_location](
	[zipcode] varchar(6) not null,
	[city] varchar(50),
	[trainerlocationid] int not null
	unique constraint [FK_trainer_location_id] foreign key ([trainerlocationid]) references [trainer_details]([trainerid]) on delete cascade
)


select * from trainer_details
select * from trainer_company   
select * from trainer_education
select * from trainer_location
select * from trainer_skill

