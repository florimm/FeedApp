﻿// <auto-generated />
using FeedApp.Database;
using FeedApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace FeedApp.Migrations
{
    [DbContext(typeof(FeedDbContext))]
    [Migration("20170802230240_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-preview2-25794")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FeedApp.Models.FeedSource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName");

                    b.Property<int>("EncodingType");

                    b.Property<int>("Interval");

                    b.Property<DateTime?>("LastFetched");

                    b.Property<string>("Name");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("FeedSources");
                });

            modelBuilder.Entity("FeedApp.Models.NewsItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Category");

                    b.Property<string>("Description");

                    b.Property<string>("FeedItemId");

                    b.Property<int>("FeedSourceId");

                    b.Property<int>("FeedType");

                    b.Property<DateTime>("FetchTime");

                    b.Property<DateTimeOffset>("Timestamp");

                    b.Property<string>("Title");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("FeedSourceId");

                    b.ToTable("NewsItems");
                });

            modelBuilder.Entity("FeedApp.Models.NewsItem", b =>
                {
                    b.HasOne("FeedApp.Models.FeedSource", "FeedSource")
                        .WithMany()
                        .HasForeignKey("FeedSourceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
