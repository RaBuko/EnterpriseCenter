using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EnterpriseCenterApp.Model
{
    public partial class EnterpriseCenterContext : DbContext
    {
        public EnterpriseCenterContext()
        {
        }

        public EnterpriseCenterContext(DbContextOptions<EnterpriseCenterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Offices> Offices { get; set; }
        public virtual DbSet<Orderdetails> Orderdetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Payments> Payments { get; set; }
        public virtual DbSet<Productlines> Productlines { get; set; }
        public virtual DbSet<Products> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Name=ConnectionStrings.EnterpriseCenterDatabase");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.Customernumber)
                    .HasName("customers_pkey");

                entity.ToTable("customers");

                entity.HasIndex(e => e.Salesrepemployeenumber)
                    .HasName("salesrepemployeenumber");

                entity.Property(e => e.Customernumber)
                    .HasColumnName("customernumber")
                    .HasColumnType("numeric(10,0)");

                entity.Property(e => e.Addressline1)
                    .IsRequired()
                    .HasColumnName("addressline1")
                    .HasMaxLength(50);

                entity.Property(e => e.Addressline2)
                    .HasColumnName("addressline2")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(50);

                entity.Property(e => e.Contactfirstname)
                    .IsRequired()
                    .HasColumnName("contactfirstname")
                    .HasMaxLength(50);

                entity.Property(e => e.Contactlastname)
                    .IsRequired()
                    .HasColumnName("contactlastname")
                    .HasMaxLength(50);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(50);

                entity.Property(e => e.Creditlimit)
                    .HasColumnName("creditlimit")
                    .HasColumnType("numeric(10,2)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.Customername)
                    .IsRequired()
                    .HasColumnName("customername")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(50);

                entity.Property(e => e.Postalcode)
                    .HasColumnName("postalcode")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.Salesrepemployeenumber)
                    .HasColumnName("salesrepemployeenumber")
                    .HasColumnType("numeric(10,0)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("NULL::character varying");

                entity.HasOne(d => d.SalesrepemployeenumberNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.Salesrepemployeenumber)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("customers_ibfk_1");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.Employeenumber)
                    .HasName("employees_pkey");

                entity.ToTable("employees");

                entity.HasIndex(e => e.Officecode)
                    .HasName("officecode");

                entity.HasIndex(e => e.Reportsto)
                    .HasName("reportsto");

                entity.Property(e => e.Employeenumber)
                    .HasColumnName("employeenumber")
                    .HasColumnType("numeric(10,0)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100);

                entity.Property(e => e.Extension)
                    .IsRequired()
                    .HasColumnName("extension")
                    .HasMaxLength(10);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasMaxLength(50);

                entity.Property(e => e.Jobtitle)
                    .IsRequired()
                    .HasColumnName("jobtitle")
                    .HasMaxLength(50);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname")
                    .HasMaxLength(50);

                entity.Property(e => e.Officecode)
                    .IsRequired()
                    .HasColumnName("officecode")
                    .HasMaxLength(10);

                entity.Property(e => e.Reportsto)
                    .HasColumnName("reportsto")
                    .HasColumnType("numeric(10,0)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.HasOne(d => d.OfficecodeNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.Officecode)
                    .HasConstraintName("employees_ibfk_2");

                entity.HasOne(d => d.ReportstoNavigation)
                    .WithMany(p => p.InverseReportstoNavigation)
                    .HasForeignKey(d => d.Reportsto)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("employees_ibfk_1");
            });

            modelBuilder.Entity<Offices>(entity =>
            {
                entity.HasKey(e => e.Officecode)
                    .HasName("offices_pkey");

                entity.ToTable("offices");

                entity.Property(e => e.Officecode)
                    .HasColumnName("officecode")
                    .HasMaxLength(10);

                entity.Property(e => e.Addressline1)
                    .IsRequired()
                    .HasColumnName("addressline1")
                    .HasMaxLength(50);

                entity.Property(e => e.Addressline2)
                    .HasColumnName("addressline2")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(50);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(50);

                entity.Property(e => e.Postalcode)
                    .IsRequired()
                    .HasColumnName("postalcode")
                    .HasMaxLength(15);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.Territory)
                    .IsRequired()
                    .HasColumnName("territory")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Orderdetails>(entity =>
            {
                entity.HasKey(e => new { e.Ordernumber, e.Productcode })
                    .HasName("orderdetails_pkey");

                entity.ToTable("orderdetails");

                entity.HasIndex(e => e.Productcode)
                    .HasName("productcode");

                entity.Property(e => e.Ordernumber)
                    .HasColumnName("ordernumber")
                    .HasColumnType("numeric(10,0)");

                entity.Property(e => e.Productcode)
                    .HasColumnName("productcode")
                    .HasMaxLength(15);

                entity.Property(e => e.Orderlinenumber)
                    .HasColumnName("orderlinenumber")
                    .HasColumnType("numeric(5,0)");

                entity.Property(e => e.Priceeach)
                    .HasColumnName("priceeach")
                    .HasColumnType("numeric(10,2)");

                entity.Property(e => e.Quantityordered)
                    .HasColumnName("quantityordered")
                    .HasColumnType("numeric(10,0)");

                entity.HasOne(d => d.OrdernumberNavigation)
                    .WithMany(p => p.Orderdetails)
                    .HasForeignKey(d => d.Ordernumber)
                    .HasConstraintName("orderdetails_ibfk_1");

                entity.HasOne(d => d.ProductcodeNavigation)
                    .WithMany(p => p.Orderdetails)
                    .HasForeignKey(d => d.Productcode)
                    .HasConstraintName("orderdetails_ibfk_2");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.Ordernumber)
                    .HasName("orders_pkey");

                entity.ToTable("orders");

                entity.HasIndex(e => e.Customernumber)
                    .HasName("customernumber");

                entity.Property(e => e.Ordernumber)
                    .HasColumnName("ordernumber")
                    .HasColumnType("numeric(10,0)");

                entity.Property(e => e.Comments).HasColumnName("comments");

                entity.Property(e => e.Customernumber)
                    .HasColumnName("customernumber")
                    .HasColumnType("numeric(10,0)");

                entity.Property(e => e.Orderdate)
                    .HasColumnName("orderdate")
                    .HasColumnType("date");

                entity.Property(e => e.Requireddate)
                    .HasColumnName("requireddate")
                    .HasColumnType("date");

                entity.Property(e => e.Shippeddate)
                    .HasColumnName("shippeddate")
                    .HasColumnType("date");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(15);

                entity.HasOne(d => d.CustomernumberNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Customernumber)
                    .HasConstraintName("orders_ibfk_1");
            });

            modelBuilder.Entity<Payments>(entity =>
            {
                entity.HasKey(e => new { e.Customernumber, e.Checknumber })
                    .HasName("payments_pkey");

                entity.ToTable("payments");

                entity.Property(e => e.Customernumber)
                    .HasColumnName("customernumber")
                    .HasColumnType("numeric(10,0)");

                entity.Property(e => e.Checknumber)
                    .HasColumnName("checknumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("numeric(10,2)");

                entity.Property(e => e.Paymentdate)
                    .HasColumnName("paymentdate")
                    .HasColumnType("date");

                entity.HasOne(d => d.CustomernumberNavigation)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.Customernumber)
                    .HasConstraintName("payments_ibfk_1");
            });

            modelBuilder.Entity<Productlines>(entity =>
            {
                entity.HasKey(e => e.Productline)
                    .HasName("productlines_pkey");

                entity.ToTable("productlines");

                entity.Property(e => e.Productline)
                    .HasColumnName("productline")
                    .HasMaxLength(50);

                entity.Property(e => e.Htmldescription).HasColumnName("htmldescription");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.Textdescription)
                    .HasColumnName("textdescription")
                    .HasMaxLength(4000)
                    .HasDefaultValueSql("NULL::character varying");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.Productcode)
                    .HasName("products_pkey");

                entity.ToTable("products");

                entity.HasIndex(e => e.Productline)
                    .HasName("productline");

                entity.Property(e => e.Productcode)
                    .HasColumnName("productcode")
                    .HasMaxLength(15);

                entity.Property(e => e.Buyprice)
                    .HasColumnName("buyprice")
                    .HasColumnType("numeric(10,2)");

                entity.Property(e => e.Msrp)
                    .HasColumnName("msrp")
                    .HasColumnType("numeric(10,2)");

                entity.Property(e => e.Productdescription)
                    .IsRequired()
                    .HasColumnName("productdescription");

                entity.Property(e => e.Productline)
                    .IsRequired()
                    .HasColumnName("productline")
                    .HasMaxLength(50);

                entity.Property(e => e.Productname)
                    .IsRequired()
                    .HasColumnName("productname")
                    .HasMaxLength(70);

                entity.Property(e => e.Productscale)
                    .IsRequired()
                    .HasColumnName("productscale")
                    .HasMaxLength(10);

                entity.Property(e => e.Productvendor)
                    .IsRequired()
                    .HasColumnName("productvendor")
                    .HasMaxLength(50);

                entity.Property(e => e.Quantityinstock)
                    .HasColumnName("quantityinstock")
                    .HasColumnType("numeric(6,0)");

                entity.HasOne(d => d.ProductlineNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Productline)
                    .HasConstraintName("products_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
