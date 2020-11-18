using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace EnterpriseCenterWeb.Models
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

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Office> Offices { get; set; }
        public virtual DbSet<OrderDetail> Orderdetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<ProductLine> Productlines { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
                optionsBuilder.UseNpgsql("Name=ConnectionStrings.EnterpriseCenterDatabase");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerNumber)
                    .HasName("customer_pkey");

                entity.ToTable("customer");

                entity.HasIndex(e => e.SalesRepEmployeeNumber)
                    .HasDatabaseName("sales_rep_employee_number");

                entity.Property(e => e.CustomerNumber)
                    .HasColumnName("customer_number")
                    .HasColumnType("numeric(10,0)");

                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasColumnName("address_line_1")
                    .HasMaxLength(50);

                entity.Property(e => e.AddressLine2)
                    .HasColumnName("address_line_2")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(50);

                entity.Property(e => e.ContactFirstName)
                    .IsRequired()
                    .HasColumnName("contact_first_name")
                    .HasMaxLength(50);

                entity.Property(e => e.ContactLastName)
                    .IsRequired()
                    .HasColumnName("contact_last_name")
                    .HasMaxLength(50);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(50);

                entity.Property(e => e.CreditLimit)
                    .HasColumnName("credit_limit")
                    .HasColumnType("numeric(10,2)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasColumnName("customer_name")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(50);

                entity.Property(e => e.PostalCode)
                    .HasColumnName("postal_code")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.SalesRepEmployeeNumber)
                    .HasColumnName("sales_rep_employee_number")
                    .HasColumnType("numeric(10,0)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("NULL::character varying");

                entity.HasOne(d => d.SalesRepEmployeeNumberNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.SalesRepEmployeeNumber)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("customer_ibfk_1");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeNumber)
                    .HasName("employee_pkey");

                entity.ToTable("employee");

                entity.HasIndex(e => e.OfficeCode)
                    .HasDatabaseName("office_code");

                entity.HasIndex(e => e.ReportsTo)
                    .HasDatabaseName("reports_to");

                entity.Property(e => e.EmployeeNumber)
                    .HasColumnName("employee_number")
                    .HasColumnType("numeric(10,0)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100);

                entity.Property(e => e.Extension)
                    .IsRequired()
                    .HasColumnName("extension")
                    .HasMaxLength(10);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(50);

                entity.Property(e => e.JobTitle)
                    .IsRequired()
                    .HasColumnName("job_title")
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(50);

                entity.Property(e => e.OfficeCode)
                    .IsRequired()
                    .HasColumnName("office_code")
                    .HasMaxLength(10);

                entity.Property(e => e.ReportsTo)
                    .HasColumnName("reports_to")
                    .HasColumnType("numeric(10,0)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.HasOne(d => d.OfficeCodeNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.OfficeCode)
                    .HasConstraintName("employee_ibfk_2");

                entity.HasOne(d => d.ReportsToNavigation)
                    .WithMany(p => p.InverseReportsToNavigation)
                    .HasForeignKey(d => d.ReportsTo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("employee_ibfk_1");
            });

            modelBuilder.Entity<Office>(entity =>
            {
                entity.HasKey(e => e.OfficeCode)
                    .HasName("office_pkey");

                entity.ToTable("office");

                entity.Property(e => e.OfficeCode)
                    .HasColumnName("office_code")
                    .HasMaxLength(10);

                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasColumnName("address_line_1")
                    .HasMaxLength(50);

                entity.Property(e => e.AddressLine2)
                    .HasColumnName("address_line_2")
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

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasColumnName("postal_code")
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

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderNumber, e.ProductCode })
                    .HasName("orderdetails_pkey");

                entity.ToTable("orderdetail");

                entity.HasIndex(e => e.ProductCode)
                    .HasDatabaseName("product_code");

                entity.Property(e => e.OrderNumber)
                    .HasColumnName("order_number")
                    .HasColumnType("numeric(10,0)");

                entity.Property(e => e.ProductCode)
                    .HasColumnName("product_code")
                    .HasMaxLength(15);

                entity.Property(e => e.OrderLineNumber)
                    .HasColumnName("order_line_number")
                    .HasColumnType("numeric(5,0)");

                entity.Property(e => e.PriceEach)
                    .HasColumnName("price_each")
                    .HasColumnType("numeric(10,2)");

                entity.Property(e => e.QuantityOrdered)
                    .HasColumnName("quantity_ordered")
                    .HasColumnType("numeric(10,0)");

                entity.HasOne(d => d.OrderNumberNavigation)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderNumber)
                    .HasConstraintName("orderdetail_ibfk_1");

                entity.HasOne(d => d.ProductCodeNavigation)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductCode)
                    .HasConstraintName("orderdetail_ibfk_2");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrderNumber)
                    .HasName("order_pkey");

                entity.ToTable("order");

                entity.HasIndex(e => e.CustomerNumber)
                    .HasDatabaseName("customer_number");

                entity.Property(e => e.OrderNumber)
                    .HasColumnName("order_number")
                    .HasColumnType("numeric(10,0)");

                entity.Property(e => e.Comments).HasColumnName("comments");

                entity.Property(e => e.CustomerNumber)
                    .HasColumnName("customer_number")
                    .HasColumnType("numeric(10,0)");

                entity.Property(e => e.OrderDate)
                    .HasColumnName("order_date")
                    .HasColumnType("date");

                entity.Property(e => e.RequiredDate)
                    .HasColumnName("required_date")
                    .HasColumnType("date");

                entity.Property(e => e.ShippedDate)
                    .HasColumnName("shipped_date")
                    .HasColumnType("date");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(15);

                entity.HasOne(d => d.CustomerNumberNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerNumber)
                    .HasConstraintName("order_ibfk_1");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => new { e.CustomerNumber, e.CheckNumber })
                    .HasName("payment_pkey");

                entity.ToTable("payment");

                entity.Property(e => e.CustomerNumber)
                    .HasColumnName("customer_number")
                    .HasColumnType("numeric(10,0)");

                entity.Property(e => e.CheckNumber)
                    .HasColumnName("check_number")
                    .HasMaxLength(50);

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("numeric(10,2)");

                entity.Property(e => e.PaymentDate)
                    .HasColumnName("payment_date")
                    .HasColumnType("date");

                entity.HasOne(d => d.CustomerNumberNavigation)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.CustomerNumber)
                    .HasConstraintName("payment_ibfk_1");
            });

            modelBuilder.Entity<ProductLine>(entity =>
            {
                entity.HasKey(e => e.ProductLineName)
                    .HasName("productline_pkey");

                entity.ToTable("productline");

                entity.Property(e => e.ProductLineName)
                    .HasColumnName("product_line_name")
                    .HasMaxLength(50);

                entity.Property(e => e.HtmlDescription).HasColumnName("html_description");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.TextDescription)
                    .HasColumnName("text_description")
                    .HasMaxLength(4000)
                    .HasDefaultValueSql("NULL::character varying");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductCode)
                    .HasName("product_pkey");

                entity.ToTable("product");

                entity.HasIndex(e => e.ProductLineName)
                    .HasDatabaseName("product_line");

                entity.Property(e => e.ProductCode)
                    .HasColumnName("product_code")
                    .HasMaxLength(15);

                entity.Property(e => e.BuyPrice)
                    .HasColumnName("buy_price")
                    .HasColumnType("numeric(10,2)");

                entity.Property(e => e.Msrp)
                    .HasColumnName("msrp")
                    .HasColumnType("numeric(10,2)");

                entity.Property(e => e.ProductDescription)
                    .IsRequired()
                    .HasColumnName("product_description");

                entity.Property(e => e.ProductLineName)
                    .IsRequired()
                    .HasColumnName("product_line_name")
                    .HasMaxLength(50);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnName("product_name")
                    .HasMaxLength(70);

                entity.Property(e => e.ProductScale)
                    .IsRequired()
                    .HasColumnName("product_scale")
                    .HasMaxLength(10);

                entity.Property(e => e.ProductVendor)
                    .IsRequired()
                    .HasColumnName("product_vendor")
                    .HasMaxLength(50);

                entity.Property(e => e.QuantityInStock)
                    .HasColumnName("quantity_in_stock")
                    .HasColumnType("numeric(6,0)");

                entity.HasOne(d => d.ProductlineNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductLineName)
                    .HasConstraintName("product_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
