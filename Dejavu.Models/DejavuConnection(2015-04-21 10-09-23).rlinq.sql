-- add column for field _dateCreated
ALTER TABLE [ProgramReviews] ADD [DateCreated] datetime NULL

go

UPDATE [ProgramReviews] SET [DateCreated] = getdate()

go

ALTER TABLE [ProgramReviews] ALTER COLUMN [DateCreated] datetime NOT NULL

go

-- add column for field _chapter
ALTER TABLE [ProgramTestimonies] ADD [Chapter] varchar(255) NULL

go

-- Column was read from database as: [Post] varchar(255) not null
-- modify column for field _post
ALTER TABLE [ProgramTestimonies] ALTER COLUMN [Post] varchar(500) NOT NULL

go

-- add column for field _description
ALTER TABLE [prgram] ADD [Description] varchar(255) NULL

go

