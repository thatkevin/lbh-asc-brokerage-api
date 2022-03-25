﻿// <auto-generated />
using System;
using BrokerageApi.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace V1.Infrastructure.Migrations
{
    [DbContext(typeof(BrokerageContext))]
    partial class BrokerageContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasPostgresEnum(null, "referral_status", new[] { "unassigned", "in_review", "assigned", "on_hold", "archived", "in_progress", "awaiting_approval", "approved" })
                .HasPostgresEnum(null, "workflow_type", new[] { "assessment", "review", "reassessment", "historic" })
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("BrokerageApi.V1.Infrastructure.Referral", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AssignedTo")
                        .HasColumnType("text")
                        .HasColumnName("assigned_to");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("SocialCareId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("social_care_id");

                    b.Property<ReferralStatus>("Status")
                        .HasColumnType("referral_status")
                        .HasColumnName("status");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at");

                    b.Property<DateTime?>("UrgentSince")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("urgent_since");

                    b.Property<string>("WorkflowId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("workflow_id");

                    b.Property<WorkflowType>("WorkflowType")
                        .HasColumnType("workflow_type")
                        .HasColumnName("workflow_type");

                    b.HasKey("Id")
                        .HasName("pk_referrals");

                    b.HasIndex("WorkflowId")
                        .IsUnique()
                        .HasDatabaseName("ix_referrals_workflow_id");

                    b.ToTable("referrals");
                });
#pragma warning restore 612, 618
        }
    }
}
