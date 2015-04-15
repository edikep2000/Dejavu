#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the FluentMappingGenerator.ttinclude code generation file.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Data.Common;
using Telerik.OpenAccess.Metadata.Fluent;
using Telerik.OpenAccess.Metadata.Fluent.Advanced;
using Dejavu.Models;
using Telerik.OpenAccess.Metadata.Relational;

namespace Dejavu.Models
{

	public partial class EntitiesModelFluentMetadataSource : FluentMetadataSource
	{
		
		protected override IList<MappingConfiguration> PrepareMapping()
		{
			List<MappingConfiguration> mappingConfigurations = new List<MappingConfiguration>();
			
			MappingConfiguration<Program> programConfiguration = this.GetProgramMappingConfiguration();
			mappingConfigurations.Add(programConfiguration);
			
			MappingConfiguration<ProgramReviews> programreviewsConfiguration = this.GetProgramReviewsMappingConfiguration();
			mappingConfigurations.Add(programreviewsConfiguration);
			
			MappingConfiguration<ProgramRatings> programratingsConfiguration = this.GetProgramRatingsMappingConfiguration();
			mappingConfigurations.Add(programratingsConfiguration);
			
			MappingConfiguration<ProgramTestimonies> programtestimoniesConfiguration = this.GetProgramTestimoniesMappingConfiguration();
			mappingConfigurations.Add(programtestimoniesConfiguration);
			
			return mappingConfigurations;
		}
		
		protected override void SetContainerSettings(MetadataContainer container)
		{
			container.Name = "EntitiesModel";
			container.DefaultNamespace = "Dejavu.Models";
			container.NameGenerator.RemoveLeadingUnderscores = false;
			container.NameGenerator.SourceStrategy = Telerik.OpenAccess.Metadata.NamingSourceStrategy.Property;
			container.NameGenerator.RemoveCamelCase = false;
		}
		public MappingConfiguration<Program> GetProgramMappingConfiguration()
		{
			MappingConfiguration<Program> configuration = this.GetProgramClassConfiguration();
			this.PrepareProgramPropertyConfigurations(configuration);
			this.PrepareProgramAssociationConfigurations(configuration);

			return configuration;
		}

		public MappingConfiguration<Program> GetProgramClassConfiguration()
		{
			MappingConfiguration<Program> configuration = new MappingConfiguration<Program>();
			configuration.MapType(x => new { });
	
			return configuration;
		}
	
		public void PrepareProgramPropertyConfigurations(MappingConfiguration<Program> configuration)
		{
			configuration.HasProperty(x => x.Id).IsIdentity(KeyGenerator.Autoinc).HasFieldName("_id");
			configuration.HasProperty(x => x.Name).HasFieldName("_name");
			configuration.HasProperty(x => x.DateHeld).HasFieldName("_dateHeld");
			configuration.HasProperty(x => x.BannerUrl).HasFieldName("_bannerUrl");
			configuration.HasProperty(x => x.VideoUrl).HasFieldName("_videoUrl");
			configuration.HasProperty(x => x.DateCreated).HasFieldName("_dateCreated");
		}
	
		public void PrepareProgramAssociationConfigurations(MappingConfiguration<Program> configuration)
		{
			configuration.HasAssociation(x => x.ProgramRatings).HasFieldName("_programRatings").WithOpposite(x => x.Program).WithDataAccessKind(DataAccessKind.ReadWrite);
			configuration.HasAssociation(x => x.ProgramReviews).HasFieldName("_programReviews").WithOpposite(x => x.Program).ToColumn("ProgramId").WithDataAccessKind(DataAccessKind.ReadWrite);
			configuration.HasAssociation(x => x.ProgramTestimonies).HasFieldName("_programTestimonies").WithOpposite(x => x.Program).ToColumn("ProgramId").WithDataAccessKind(DataAccessKind.ReadWrite);
		}
		
		public MappingConfiguration<ProgramReviews> GetProgramReviewsMappingConfiguration()
		{
			MappingConfiguration<ProgramReviews> configuration = this.GetProgramReviewsClassConfiguration();
			this.PrepareProgramReviewsPropertyConfigurations(configuration);
			this.PrepareProgramReviewsAssociationConfigurations(configuration);

			return configuration;
		}

		public MappingConfiguration<ProgramReviews> GetProgramReviewsClassConfiguration()
		{
			MappingConfiguration<ProgramReviews> configuration = new MappingConfiguration<ProgramReviews>();
			configuration.MapType(x => new { }).ToTable("ProgramReviews");
	
			return configuration;
		}
	
		public void PrepareProgramReviewsPropertyConfigurations(MappingConfiguration<ProgramReviews> configuration)
		{
			configuration.HasProperty(x => x.Id).IsIdentity().HasFieldName("_id").ToColumn("Id").IsNotNullable().HasColumnType("bigint").HasPrecision(0).HasScale(0).WithConverter("OpenAccessRuntime.Data.BigIntConverter");
			configuration.HasProperty(x => x.PostedBy).HasFieldName("_postedBy").ToColumn("PostedBy").IsNotNullable().HasColumnType("varchar").HasLength(255).WithConverter("OpenAccessRuntime.Data.VariableLengthAnsiStringConverter");
			configuration.HasProperty(x => x.Chapter).HasFieldName("_chapter").ToColumn("Chapter").IsNotNullable().HasColumnType("varchar").HasLength(255).WithConverter("OpenAccessRuntime.Data.VariableLengthAnsiStringConverter");
			configuration.HasProperty(x => x.Review).HasFieldName("_review").ToColumn("Review").IsNotNullable().HasColumnType("varchar").HasLength(255).WithConverter("OpenAccessRuntime.Data.VariableLengthAnsiStringConverter");
			configuration.HasProperty(x => x.ProgramId).HasFieldName("_programId").ToColumn("ProgramId").IsNotNullable().HasColumnType("int").HasPrecision(0).HasScale(0).WithConverter("OpenAccessRuntime.Data.IntConverter");
		}
	
		public void PrepareProgramReviewsAssociationConfigurations(MappingConfiguration<ProgramReviews> configuration)
		{
			configuration.HasAssociation(x => x.Program).HasFieldName("_program").WithOpposite(x => x.ProgramReviews).ToColumn("ProgramId").IsRequired().WithDataAccessKind(DataAccessKind.ReadWrite);
		}
		
		public MappingConfiguration<ProgramRatings> GetProgramRatingsMappingConfiguration()
		{
			MappingConfiguration<ProgramRatings> configuration = this.GetProgramRatingsClassConfiguration();
			this.PrepareProgramRatingsPropertyConfigurations(configuration);
			this.PrepareProgramRatingsAssociationConfigurations(configuration);

			return configuration;
		}

		public MappingConfiguration<ProgramRatings> GetProgramRatingsClassConfiguration()
		{
			MappingConfiguration<ProgramRatings> configuration = new MappingConfiguration<ProgramRatings>();
			configuration.MapType(x => new { });
	
			return configuration;
		}
	
		public void PrepareProgramRatingsPropertyConfigurations(MappingConfiguration<ProgramRatings> configuration)
		{
			configuration.HasProperty(x => x.Id).IsIdentity(KeyGenerator.Autoinc).HasFieldName("_id");
			configuration.HasProperty(x => x.ProgramId).HasFieldName("_programId");
			configuration.HasProperty(x => x.Rating).HasFieldName("_rating");
		}
	
		public void PrepareProgramRatingsAssociationConfigurations(MappingConfiguration<ProgramRatings> configuration)
		{
			configuration.HasAssociation(x => x.Program).HasFieldName("_program").WithOpposite(x => x.ProgramRatings).WithDataAccessKind(DataAccessKind.ReadWrite);
		}
		
		public MappingConfiguration<ProgramTestimonies> GetProgramTestimoniesMappingConfiguration()
		{
			MappingConfiguration<ProgramTestimonies> configuration = this.GetProgramTestimoniesClassConfiguration();
			this.PrepareProgramTestimoniesPropertyConfigurations(configuration);
			this.PrepareProgramTestimoniesAssociationConfigurations(configuration);

			return configuration;
		}

		public MappingConfiguration<ProgramTestimonies> GetProgramTestimoniesClassConfiguration()
		{
			MappingConfiguration<ProgramTestimonies> configuration = new MappingConfiguration<ProgramTestimonies>();
			configuration.MapType(x => new { }).ToTable("ProgramTestimonies");
	
			return configuration;
		}
	
		public void PrepareProgramTestimoniesPropertyConfigurations(MappingConfiguration<ProgramTestimonies> configuration)
		{
			configuration.HasProperty(x => x.Id).IsIdentity().HasFieldName("_id").ToColumn("Id").IsNotNullable().HasColumnType("bigint").HasPrecision(0).HasScale(0).WithConverter("OpenAccessRuntime.Data.BigIntConverter");
			configuration.HasProperty(x => x.PostedBy).HasFieldName("_postedBy").ToColumn("PostedBy").IsNotNullable().HasColumnType("varchar").HasLength(255).WithConverter("OpenAccessRuntime.Data.VariableLengthAnsiStringConverter");
			configuration.HasProperty(x => x.DatePosted).HasFieldName("_datePosted").ToColumn("DatePosted").IsNotNullable().HasColumnType("datetime").WithConverter("OpenAccessRuntime.Data.MssqlMinDateConverter");
			configuration.HasProperty(x => x.Post).HasFieldName("_post").ToColumn("Post").IsNotNullable().HasColumnType("varchar").HasLength(255).WithConverter("OpenAccessRuntime.Data.VariableLengthAnsiStringConverter");
			configuration.HasProperty(x => x.Likes).HasFieldName("_likes").ToColumn("Likes").IsNotNullable().HasColumnType("bigint").HasPrecision(0).HasScale(0).WithConverter("OpenAccessRuntime.Data.BigIntConverter");
			configuration.HasProperty(x => x.ProgramId).HasFieldName("_programId").ToColumn("ProgramId").IsNotNullable().HasColumnType("int").HasPrecision(0).HasScale(0).WithConverter("OpenAccessRuntime.Data.IntConverter");
		}
	
		public void PrepareProgramTestimoniesAssociationConfigurations(MappingConfiguration<ProgramTestimonies> configuration)
		{
			configuration.HasAssociation(x => x.Program).HasFieldName("_program").WithOpposite(x => x.ProgramTestimonies).ToColumn("ProgramId").IsRequired().WithDataAccessKind(DataAccessKind.ReadWrite);
		}
		
	}
}
#pragma warning restore 1591