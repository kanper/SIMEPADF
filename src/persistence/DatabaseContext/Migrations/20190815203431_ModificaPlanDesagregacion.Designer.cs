﻿// <auto-generated />
using System;
using DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DatabaseContext.Migrations
{
    [DbContext(typeof(simepadfContext))]
    [Migration("20190815203431_ModificaPlanDesagregacion")]
    partial class ModificaPlanDesagregacion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Model.Domain.Actividad", b =>
                {
                    b.Property<int>("CodigoActividad")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DeletedBy");

                    b.Property<string>("NombreActividad")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<int>("ResultadoId");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("CodigoActividad");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DeletedBy");

                    b.HasIndex("NombreActividad")
                        .IsUnique();

                    b.HasIndex("ResultadoId");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Actividad");
                });

            modelBuilder.Entity("Model.Domain.Desagregacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DeletedBy");

                    b.Property<string>("TipoDesagregacion")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DeletedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Desagregacion");
                });

            modelBuilder.Entity("Model.Domain.EstadoProyecto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TipoEstado")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("EstadoProyecto");
                });

            modelBuilder.Entity("Model.Domain.FrecuenciaMedicion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DeletedBy");

                    b.Property<string>("NombreFrecuencia")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DeletedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("FrecuenciaMedicion");
                });

            modelBuilder.Entity("Model.Domain.FuenteDato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DeletedBy");

                    b.Property<string>("NombreFuente")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DeletedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("FuenteDato");
                });

            modelBuilder.Entity("Model.Domain.Indicador", b =>
                {
                    b.Property<int>("CodigoIndicador");

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DeletedBy");

                    b.Property<string>("NombreIndicador")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("CodigoIndicador");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DeletedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Indicador");
                });

            modelBuilder.Entity("Model.Domain.Meta", b =>
                {
                    b.Property<int>("CodigoMeta");

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DeletedBy");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.Property<int>("ValorMeta");

                    b.HasKey("CodigoMeta");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DeletedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Meta");
                });

            modelBuilder.Entity("Model.Domain.NivelImpacto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DeletedBy");

                    b.Property<string>("NombreNivelImpacto")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DeletedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("NivelImpacto");
                });

            modelBuilder.Entity("Model.Domain.Objetivo", b =>
                {
                    b.Property<int>("CodigoObjetivo")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DeletedBy");

                    b.Property<string>("NombreObjetivo")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("CodigoObjetivo");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DeletedBy");

                    b.HasIndex("NombreObjetivo")
                        .IsUnique();

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Objetivo");
                });

            modelBuilder.Entity("Model.Domain.OrganizacionResponsable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DeletedBy");

                    b.Property<string>("NombreOrganizacion")
                        .IsRequired()
                        .HasMaxLength(70);

                    b.Property<string>("SiglasOrganizacion")
                        .IsRequired()
                        .HasMaxLength(8);

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DeletedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("OrganizacionResponsable");
                });

            modelBuilder.Entity("Model.Domain.Pais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DeletedBy");

                    b.Property<string>("NombrePais")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("SiglaPais")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DeletedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Pais");
                });

            modelBuilder.Entity("Model.Domain.PlanDesagregacion", b =>
                {
                    b.Property<int>("DesagregacionId");

                    b.Property<int>("PlanMonitoreoEvaluacionIndicadorId");

                    b.Property<string>("PlanMonitoreoEvaluacionProyectoCodigoProyecto");

                    b.HasKey("DesagregacionId", "PlanMonitoreoEvaluacionIndicadorId", "PlanMonitoreoEvaluacionProyectoCodigoProyecto");

                    b.HasIndex("PlanMonitoreoEvaluacionProyectoCodigoProyecto", "PlanMonitoreoEvaluacionIndicadorId");

                    b.ToTable("PlanDesagregacion");
                });

            modelBuilder.Entity("Model.Domain.PlanMonitoreoEvaluacion", b =>
                {
                    b.Property<string>("ProyectoCodigoProyecto");

                    b.Property<int>("IndicadorId");

                    b.Property<int?>("FrecuenciaMedicionId");

                    b.Property<int?>("FuenteDatoId");

                    b.Property<string>("MetodologiaRecoleccion")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("NivelImpactoId");

                    b.Property<string>("ValorLineaBase")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ProyectoCodigoProyecto", "IndicadorId");

                    b.HasIndex("FrecuenciaMedicionId");

                    b.HasIndex("FuenteDatoId");

                    b.HasIndex("IndicadorId");

                    b.HasIndex("NivelImpactoId");

                    b.ToTable("PlanMonitoreoEvaluacion");
                });

            modelBuilder.Entity("Model.Domain.Proyecto", b =>
                {
                    b.Property<string>("CodigoProyecto")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Beneficiarios");

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DeletedBy");

                    b.Property<int>("EstadoProyectoId");

                    b.Property<DateTime>("FechaAprobacion");

                    b.Property<DateTime>("FechaFin");

                    b.Property<DateTime>("FechaInicio");

                    b.Property<double>("MontoProyecto");

                    b.Property<string>("NombreProyecto")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("CodigoProyecto");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DeletedBy");

                    b.HasIndex("EstadoProyectoId");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Proyecto");
                });

            modelBuilder.Entity("Model.Domain.ProyectoOrganizacion", b =>
                {
                    b.Property<int>("OrganizacionResponsableId");

                    b.Property<string>("ProyectoId");

                    b.HasKey("OrganizacionResponsableId", "ProyectoId");

                    b.HasIndex("ProyectoId");

                    b.ToTable("ProyectoOrganizacion");
                });

            modelBuilder.Entity("Model.Domain.ProyectoPais", b =>
                {
                    b.Property<int>("PaisId");

                    b.Property<string>("ProyectoId");

                    b.HasKey("PaisId", "ProyectoId");

                    b.HasIndex("ProyectoId");

                    b.ToTable("ProyectoPais");
                });

            modelBuilder.Entity("Model.Domain.ProyectoSocio", b =>
                {
                    b.Property<int>("SocioInternacionalId");

                    b.Property<string>("ProyectoId");

                    b.HasKey("SocioInternacionalId", "ProyectoId");

                    b.HasIndex("ProyectoId");

                    b.ToTable("ProyectoSocio");
                });

            modelBuilder.Entity("Model.Domain.ProyectoUsuario", b =>
                {
                    b.Property<string>("UsuarioId");

                    b.Property<string>("ProyectoId");

                    b.HasKey("UsuarioId", "ProyectoId");

                    b.HasIndex("ProyectoId");

                    b.ToTable("ProyectoUsuario");
                });

            modelBuilder.Entity("Model.Domain.Resultado", b =>
                {
                    b.Property<int>("CodigoResultado")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DeletedBy");

                    b.Property<string>("NombreResultado")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<int>("ObjetivoId");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("CodigoResultado");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DeletedBy");

                    b.HasIndex("NombreResultado")
                        .IsUnique();

                    b.HasIndex("ObjetivoId");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Resultado");
                });

            modelBuilder.Entity("Model.Domain.Rol", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<bool>("Enabled");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("NormalizedName");

                    b.HasKey("Id");

                    b.ToTable("Rol");
                });

            modelBuilder.Entity("Model.Domain.SocioInternacional", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DeletedBy");

                    b.Property<string>("NombreSocio")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("SiglasSocio")
                        .IsRequired()
                        .HasMaxLength(8);

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DeletedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("SocioInternacional");
                });

            modelBuilder.Entity("Model.Domain.Usuario", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ApellidoPersonal")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("Estado");

                    b.Property<DateTime>("FechaAfilacion");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NombrePersonal")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash")
                        .IsRequired();

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Model.Domain.Actividad", b =>
                {
                    b.HasOne("Model.Domain.Usuario", "CreatedUsuario")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("Model.Domain.Usuario", "DeletedUsuario")
                        .WithMany()
                        .HasForeignKey("DeletedBy");

                    b.HasOne("Model.Domain.Resultado", "Resultado")
                        .WithMany("Actividades")
                        .HasForeignKey("ResultadoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Model.Domain.Usuario", "UpdatedUsuario")
                        .WithMany()
                        .HasForeignKey("UpdatedBy");
                });

            modelBuilder.Entity("Model.Domain.Desagregacion", b =>
                {
                    b.HasOne("Model.Domain.Usuario", "CreatedUsuario")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("Model.Domain.Usuario", "DeletedUsuario")
                        .WithMany()
                        .HasForeignKey("DeletedBy");

                    b.HasOne("Model.Domain.Usuario", "UpdatedUsuario")
                        .WithMany()
                        .HasForeignKey("UpdatedBy");
                });

            modelBuilder.Entity("Model.Domain.FrecuenciaMedicion", b =>
                {
                    b.HasOne("Model.Domain.Usuario", "CreatedUsuario")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("Model.Domain.Usuario", "DeletedUsuario")
                        .WithMany()
                        .HasForeignKey("DeletedBy");

                    b.HasOne("Model.Domain.Usuario", "UpdatedUsuario")
                        .WithMany()
                        .HasForeignKey("UpdatedBy");
                });

            modelBuilder.Entity("Model.Domain.FuenteDato", b =>
                {
                    b.HasOne("Model.Domain.Usuario", "CreatedUsuario")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("Model.Domain.Usuario", "DeletedUsuario")
                        .WithMany()
                        .HasForeignKey("DeletedBy");

                    b.HasOne("Model.Domain.Usuario", "UpdatedUsuario")
                        .WithMany()
                        .HasForeignKey("UpdatedBy");
                });

            modelBuilder.Entity("Model.Domain.Indicador", b =>
                {
                    b.HasOne("Model.Domain.Actividad", "Actividad")
                        .WithOne("Indicador")
                        .HasForeignKey("Model.Domain.Indicador", "CodigoIndicador")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Model.Domain.Usuario", "CreatedUsuario")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("Model.Domain.Usuario", "DeletedUsuario")
                        .WithMany()
                        .HasForeignKey("DeletedBy");

                    b.HasOne("Model.Domain.Usuario", "UpdatedUsuario")
                        .WithMany()
                        .HasForeignKey("UpdatedBy");
                });

            modelBuilder.Entity("Model.Domain.Meta", b =>
                {
                    b.HasOne("Model.Domain.Indicador", "Indicador")
                        .WithOne("Meta")
                        .HasForeignKey("Model.Domain.Meta", "CodigoMeta")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Model.Domain.Usuario", "CreatedUsuario")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("Model.Domain.Usuario", "DeletedUsuario")
                        .WithMany()
                        .HasForeignKey("DeletedBy");

                    b.HasOne("Model.Domain.Usuario", "UpdatedUsuario")
                        .WithMany()
                        .HasForeignKey("UpdatedBy");
                });

            modelBuilder.Entity("Model.Domain.NivelImpacto", b =>
                {
                    b.HasOne("Model.Domain.Usuario", "CreatedUsuario")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("Model.Domain.Usuario", "DeletedUsuario")
                        .WithMany()
                        .HasForeignKey("DeletedBy");

                    b.HasOne("Model.Domain.Usuario", "UpdatedUsuario")
                        .WithMany()
                        .HasForeignKey("UpdatedBy");
                });

            modelBuilder.Entity("Model.Domain.Objetivo", b =>
                {
                    b.HasOne("Model.Domain.Usuario", "CreatedUsuario")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("Model.Domain.Usuario", "DeletedUsuario")
                        .WithMany()
                        .HasForeignKey("DeletedBy");

                    b.HasOne("Model.Domain.Usuario", "UpdatedUsuario")
                        .WithMany()
                        .HasForeignKey("UpdatedBy");
                });

            modelBuilder.Entity("Model.Domain.OrganizacionResponsable", b =>
                {
                    b.HasOne("Model.Domain.Usuario", "CreatedUsuario")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("Model.Domain.Usuario", "DeletedUsuario")
                        .WithMany()
                        .HasForeignKey("DeletedBy");

                    b.HasOne("Model.Domain.Usuario", "UpdatedUsuario")
                        .WithMany()
                        .HasForeignKey("UpdatedBy");
                });

            modelBuilder.Entity("Model.Domain.Pais", b =>
                {
                    b.HasOne("Model.Domain.Usuario", "CreatedUsuario")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("Model.Domain.Usuario", "DeletedUsuario")
                        .WithMany()
                        .HasForeignKey("DeletedBy");

                    b.HasOne("Model.Domain.Usuario", "UpdatedUsuario")
                        .WithMany()
                        .HasForeignKey("UpdatedBy");
                });

            modelBuilder.Entity("Model.Domain.PlanDesagregacion", b =>
                {
                    b.HasOne("Model.Domain.Desagregacion", "Desagregacion")
                        .WithMany("PlanDesagregaciones")
                        .HasForeignKey("DesagregacionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Model.Domain.PlanMonitoreoEvaluacion", "PlanMonitoreoEvaluacion")
                        .WithMany("PlanDesagregaciones")
                        .HasForeignKey("PlanMonitoreoEvaluacionProyectoCodigoProyecto", "PlanMonitoreoEvaluacionIndicadorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Model.Domain.PlanMonitoreoEvaluacion", b =>
                {
                    b.HasOne("Model.Domain.FrecuenciaMedicion", "FrecuenciaMedicion")
                        .WithMany("Planes")
                        .HasForeignKey("FrecuenciaMedicionId");

                    b.HasOne("Model.Domain.FuenteDato", "FuenteDato")
                        .WithMany("Planes")
                        .HasForeignKey("FuenteDatoId");

                    b.HasOne("Model.Domain.Indicador", "Indicador")
                        .WithMany("PlanMonitoreoEvaluaciones")
                        .HasForeignKey("IndicadorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Model.Domain.NivelImpacto", "NivelImpacto")
                        .WithMany("Planes")
                        .HasForeignKey("NivelImpactoId");

                    b.HasOne("Model.Domain.Proyecto", "Proyecto")
                        .WithMany("PlanMonitoreoEvaluaciones")
                        .HasForeignKey("ProyectoCodigoProyecto")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Model.Domain.Proyecto", b =>
                {
                    b.HasOne("Model.Domain.Usuario", "CreatedUsuario")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("Model.Domain.Usuario", "DeletedUsuario")
                        .WithMany()
                        .HasForeignKey("DeletedBy");

                    b.HasOne("Model.Domain.EstadoProyecto", "EstadoProyecto")
                        .WithMany("Proyecto")
                        .HasForeignKey("EstadoProyectoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Model.Domain.Usuario", "UpdatedUsuario")
                        .WithMany()
                        .HasForeignKey("UpdatedBy");
                });

            modelBuilder.Entity("Model.Domain.ProyectoOrganizacion", b =>
                {
                    b.HasOne("Model.Domain.OrganizacionResponsable", "OrganizacionResponsable")
                        .WithMany("ProyectoOrganizaciones")
                        .HasForeignKey("OrganizacionResponsableId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Model.Domain.Proyecto", "Proyecto")
                        .WithMany("ProyectoOrganizaciones")
                        .HasForeignKey("ProyectoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Model.Domain.ProyectoPais", b =>
                {
                    b.HasOne("Model.Domain.Pais", "Pais")
                        .WithMany("ProyectoPaises")
                        .HasForeignKey("PaisId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Model.Domain.Proyecto", "Proyecto")
                        .WithMany("ProyectoPaises")
                        .HasForeignKey("ProyectoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Model.Domain.ProyectoSocio", b =>
                {
                    b.HasOne("Model.Domain.Proyecto", "Proyecto")
                        .WithMany("ProyectoSocios")
                        .HasForeignKey("ProyectoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Model.Domain.SocioInternacional", "SocioInternacional")
                        .WithMany("ProyectoSocios")
                        .HasForeignKey("SocioInternacionalId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Model.Domain.ProyectoUsuario", b =>
                {
                    b.HasOne("Model.Domain.Proyecto", "Proyecto")
                        .WithMany("ProyectoUsuarios")
                        .HasForeignKey("ProyectoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Model.Domain.Usuario", "Usuario")
                        .WithMany("ProyectoUsuarios")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Model.Domain.Resultado", b =>
                {
                    b.HasOne("Model.Domain.Usuario", "CreatedUsuario")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("Model.Domain.Usuario", "DeletedUsuario")
                        .WithMany()
                        .HasForeignKey("DeletedBy");

                    b.HasOne("Model.Domain.Objetivo", "Objetivo")
                        .WithMany("Resultados")
                        .HasForeignKey("ObjetivoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Model.Domain.Usuario", "UpdatedUsuario")
                        .WithMany()
                        .HasForeignKey("UpdatedBy");
                });

            modelBuilder.Entity("Model.Domain.SocioInternacional", b =>
                {
                    b.HasOne("Model.Domain.Usuario", "CreatedUsuario")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("Model.Domain.Usuario", "DeletedUsuario")
                        .WithMany()
                        .HasForeignKey("DeletedBy");

                    b.HasOne("Model.Domain.Usuario", "UpdatedUsuario")
                        .WithMany()
                        .HasForeignKey("UpdatedBy");
                });
#pragma warning restore 612, 618
        }
    }
}
