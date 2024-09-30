using Microsoft.EntityFrameworkCore;

namespace WebAPI_Teledok.Class
{
    public class Teledok_Context : DbContext
    {

        public Teledok_Context()
        {

        }

        public Teledok_Context(DbContextOptions<Teledok_Context> options) : base(options) 
        { 
        
        }

        public virtual DbSet<TypeOfClient> TypeOfClients { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Founder> Founders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Founder>(entity =>
            {
                entity.ToTable("Founder");

                entity.HasKey(e => e.IdFounder);

                entity.Property(e => e.IdFounder)
                .HasColumnName("ID_Founder")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

                entity.Property(e => e.INNFounder)
                .HasColumnName("INN_Founder")
                .HasMaxLength(12)
                .IsRequired(true);

                entity.Property(e => e.SurnameFounder)
                .HasColumnName("Surname_Founder")
                .HasMaxLength(255)
                .IsRequired(true);

                entity.Property(e => e.NameFounder)
                .HasColumnName("Name_Founder")
                .HasMaxLength(255)
                .IsRequired(true);

                entity.Property(e => e.MiddleNameFounder)
                .HasColumnName("MiddleName_Founder")
                .HasMaxLength(255)
                .IsRequired(false);

                entity.Property(e => e.DateOfAdditionFounder)
                .HasColumnName("Date_Of_Addition_Founder")
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETDATE()")
                .IsRequired(true);

                entity.Property(e => e.DateOfUpdateFounder)
                .HasColumnName("Date_Of_Update_Founder")
                .HasColumnType("datetime")
                .IsRequired(false);

                entity.Property(e => e.ClientID)
                .HasColumnName("Client_ID")
                .IsRequired(true);

                entity.HasOne(e => e.Client)
                .WithMany(t => t.Founders)
                .HasForeignKey(e => e.ClientID)
                .HasConstraintName("FK_Client")
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(e => e.INNFounder, "UQ_INN_Founder")
                .IsUnique(true);


            });

            modelBuilder.Entity<Founder>().HasData(new Founder
            {
                IdFounder = 1,
                INNFounder = "8765432109",
                SurnameFounder = "Петров",
                NameFounder = "Алексей",
                MiddleNameFounder = "Сергеевич",
                DateOfAdditionFounder = DateTime.Now,
                ClientID = 1
            },new Founder
            {
                IdFounder = 2,
                INNFounder = "9876543210",
                SurnameFounder = "Иванов",
                NameFounder = "Максим",
                MiddleNameFounder = "Андреевич",
                DateOfAdditionFounder = DateTime.Now,
                ClientID = 3
            }, new Founder
            {
                IdFounder = 3,
                INNFounder = "0987654321",
                SurnameFounder = "Кузнецов",
                NameFounder = "Дмитрий",
                MiddleNameFounder = "Александрович",
                DateOfAdditionFounder = DateTime.Now,
                ClientID = 4
            }, new Founder
            {
                IdFounder = 4,
                INNFounder = "8765432190",
                SurnameFounder = "Васильев",
                NameFounder = "Иван",
                MiddleNameFounder = "Петрович",
                DateOfAdditionFounder = DateTime.Now,
                ClientID = 4
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.HasKey(e => e.IdClient);

                entity.Property(e => e.IdClient)
                .HasColumnName("ID_Client")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

                entity.Property(e => e.INNClient)
                .HasMaxLength(12)
                .HasColumnName("INN_Client")
                .IsRequired(true);

                entity.Property(e => e.NameClient)
                .HasColumnName("Name_Client")
                .HasMaxLength(255)
                .IsRequired(true);

                entity.Property(e => e.DateOfAdditionClient)
                .HasColumnName("Date_Of_Addition_Client")
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETDATE()")
                .IsRequired(true);

                entity.Property(e => e.DateOfUpdateClient)
                .HasColumnName("Date_Of_Update_Client")
                .HasColumnType("datetime")
                .IsRequired(false);

                entity.Property(e => e.TypeOfClientID)
                .HasColumnName("Type_Of_Client_ID")
                .IsRequired(true);

                entity.HasOne(e => e.TypeOfClient)
                .WithMany(t => t.Clients)
                .HasForeignKey(e => e.TypeOfClientID)
                .HasConstraintName("FK_Type_Of_Client")
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(e => e.INNClient, "UQ_INN_Client")
                .IsUnique(true);





            });

            modelBuilder.Entity<Client>().HasData(new Client
            {
                IdClient = 1,
                INNClient = "132808730606",
                NameClient = "ООО Альфа",
                DateOfAdditionClient = DateTime.Now,
                TypeOfClientID = 1,
            },new Client
            {
                IdClient = 2,
                INNClient = "2345678901",
                NameClient = "ИП Иванов",
                DateOfAdditionClient = DateTime.Now,
                TypeOfClientID = 2,

            }, new Client
            {
                IdClient = 3,
                INNClient = "3456789012",
                NameClient = "ООО Бета",
                DateOfAdditionClient = DateTime.Now,
                TypeOfClientID = 1,
            }, new Client
            {
                IdClient = 4,
                INNClient = "4567890123",
                NameClient = "ООО Гамма",
                DateOfAdditionClient = DateTime.Now,
                TypeOfClientID = 1,
            }, new Client
            {
                IdClient = 5,
                INNClient = "5678901234",
                NameClient = "ИП Смирнов",
                DateOfAdditionClient = DateTime.Now,
                TypeOfClientID = 2,

            });



            modelBuilder.Entity<TypeOfClient>(entity =>
            {
                entity.ToTable("Type_Of_Client");

                entity.HasKey(e => e.IdTypeOfClient);

                entity.Property(e => e.IdTypeOfClient)
                 .HasColumnName("ID_Type_Of_Client")
                 .ValueGeneratedOnAdd();

                entity.Property(e => e.NameTypeOfClient)
                 .HasMaxLength(50)
                 .IsUnicode(false)
                 .HasColumnName("Name_Type_Of_Client")
                 .IsRequired(true);

                entity.HasIndex(e => e.NameTypeOfClient, "UQ_Name_Type_Of_Client")
                 .IsUnique(true);

            });

            modelBuilder.Entity<TypeOfClient>().HasData(new TypeOfClient
            {
                IdTypeOfClient = 1,
                NameTypeOfClient = "Юридическое лицо"
            },
            new TypeOfClient
            {
                IdTypeOfClient = 2,
                NameTypeOfClient = "Индивидуальный предприниматель"
            }) ;

                
        }

    }
}
