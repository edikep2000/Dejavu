-- Dejavu.Models.ProgramRatings
CREATE TABLE [ProgramRatings] (
    [Rating] int NOT NULL,                  -- _rating
    [ProgramId] int NOT NULL,               -- _program
    [Id] bigint IDENTITY NOT NULL,          -- _id
    CONSTRAINT [pk_ProgramRatings] PRIMARY KEY ([Id])
)
go

-- Dejavu.Models.ProgramReviews
CREATE TABLE [ProgramReviews] (
    [Review] varchar(255) NOT NULL,         -- _review
    [ProgramId] int NOT NULL,               -- _program
    [PostedBy] varchar(255) NOT NULL,       -- _postedBy
    [Id] bigint NOT NULL,                   -- _id
    [Chapter] varchar(255) NOT NULL,        -- _chapter
    CONSTRAINT [pk_ProgramReviews] PRIMARY KEY ([Id])
)
go

-- Dejavu.Models.ProgramTestimonies
CREATE TABLE [ProgramTestimonies] (
    [ProgramId] int NOT NULL,               -- _program
    [PostedBy] varchar(255) NOT NULL,       -- _postedBy
    [Post] varchar(255) NOT NULL,           -- _post
    [Likes] bigint NOT NULL,                -- _likes
    [Id] bigint NOT NULL,                   -- _id
    [DatePosted] datetime NOT NULL,         -- _datePosted
    CONSTRAINT [pk_ProgramTestimonies] PRIMARY KEY ([Id])
)
go

-- Dejavu.Models.Program
CREATE TABLE [prgram] (
    [VideoUrl] varchar(255) NULL,           -- _videoUrl
    [nme] varchar(255) NULL,                -- _name
    [Id] int IDENTITY NOT NULL,             -- _id
    [DateHeld] datetime NOT NULL,           -- _dateHeld
    [DateCreated] datetime NOT NULL,        -- _dateCreated
    [BannerUrl] varchar(255) NULL,          -- _bannerUrl
    CONSTRAINT [pk_prgram] PRIMARY KEY ([Id])
)
go

CREATE INDEX [idx_ProgramRatings_ProgramId] ON [ProgramRatings]([ProgramId])
go

CREATE INDEX [idx_ProgramReviews_ProgramId] ON [ProgramReviews]([ProgramId])
go

CREATE INDEX [idx_PrgrmTestimonies_ProgramId] ON [ProgramTestimonies]([ProgramId])
go

ALTER TABLE [ProgramRatings] ADD CONSTRAINT [ref_ProgramRatings_prgram] FOREIGN KEY ([ProgramId]) REFERENCES [prgram]([Id])
go

ALTER TABLE [ProgramReviews] ADD CONSTRAINT [ref_ProgramReviews_prgram] FOREIGN KEY ([ProgramId]) REFERENCES [prgram]([Id])
go

ALTER TABLE [ProgramTestimonies] ADD CONSTRAINT [ref_ProgramTestimonies_prgram] FOREIGN KEY ([ProgramId]) REFERENCES [prgram]([Id])
go

