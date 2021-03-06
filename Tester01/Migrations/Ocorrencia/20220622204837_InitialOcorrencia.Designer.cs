// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using seCuidaBenca.Data;

#nullable disable

namespace seCuidaBenca.Migrations.Ocorrencia
{
    [DbContext(typeof(OcorrenciaContext))]
    [Migration("20220622204837_InitialOcorrencia")]
    partial class InitialOcorrencia
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Ocorrencia", b =>
                {
                    b.Property<int>("Id_Ocorrencia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_ocorrencia");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id_Ocorrencia"));

                    b.Property<string>("DescricaoDaOcorrencia")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Id_DoUsuario")
                        .HasColumnType("integer");

                    b.HasKey("Id_Ocorrencia");

                    b.ToTable("ocorrencia");
                });
#pragma warning restore 612, 618
        }
    }
}
