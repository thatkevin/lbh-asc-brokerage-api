﻿// <auto-generated />
using System;
using System.Collections.Generic;
using BrokerageApi.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace V1.Infrastructure.Migrations
{
    [DbContext(typeof(BrokerageContext))]
    [Migration("20220326071300_CreateUsers")]
    partial class CreateUsers
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasPostgresEnum(null, "referral_status", new[] { "unassigned", "in_review", "assigned", "on_hold", "archived", "in_progress", "awaiting_approval", "approved" })
                .HasPostgresEnum(null, "user_role", new[] { "brokerage_assistant", "broker", "approver", "care_charges_officer" })
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

            modelBuilder.Entity("BrokerageApi.V1.Infrastructure.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<List<UserRole>>("Roles")
                        .HasColumnType("user_role[]")
                        .HasColumnName("roles");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("ix_users_email");

                    b.ToTable("users");
                });
#pragma warning restore 612, 618
        }
    }
}