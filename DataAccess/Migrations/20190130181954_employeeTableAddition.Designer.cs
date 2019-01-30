﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(AdventureWorksLTContext))]
    [Migration("20190130181954_employeeTableAddition")]
    partial class employeeTableAddition
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataAccess.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("AddressID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("AddressLine2")
                        .HasMaxLength(60);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("CountryRegion")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<Guid>("Rowguid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("rowguid")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("StateProvince")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("AddressId");

                    b.HasIndex("Rowguid")
                        .IsUnique()
                        .HasName("AK_Address_rowguid");

                    b.HasIndex("StateProvince");

                    b.HasIndex("AddressLine1", "AddressLine2", "City", "StateProvince", "PostalCode", "CountryRegion");

                    b.ToTable("Address","SalesLT");
                });

            modelBuilder.Entity("DataAccess.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CustomerID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName")
                        .HasMaxLength(128);

                    b.Property<string>("EmailAddress")
                        .HasMaxLength(50);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("MiddleName")
                        .HasMaxLength(50);

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<bool>("NameStyle");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(128)
                        .IsUnicode(false);

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<string>("Phone")
                        .HasMaxLength(25);

                    b.Property<Guid>("Rowguid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("rowguid")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("SalesPerson")
                        .HasMaxLength(256);

                    b.Property<string>("Suffix")
                        .HasMaxLength(10);

                    b.Property<string>("Title")
                        .HasMaxLength(8);

                    b.HasKey("CustomerId");

                    b.HasIndex("EmailAddress");

                    b.HasIndex("Rowguid")
                        .IsUnique()
                        .HasName("AK_Customer_rowguid");

                    b.ToTable("Customer","SalesLT");
                });

            modelBuilder.Entity("DataAccess.CustomerAddress", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnName("CustomerID");

                    b.Property<int>("AddressId")
                        .HasColumnName("AddressID");

                    b.Property<string>("AddressType")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<Guid>("Rowguid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("rowguid")
                        .HasDefaultValueSql("(newid())");

                    b.HasKey("CustomerId", "AddressId")
                        .HasName("PK_CustomerAddress_CustomerID_AddressID");

                    b.HasIndex("AddressId");

                    b.HasIndex("Rowguid")
                        .IsUnique()
                        .HasName("AK_CustomerAddress_rowguid");

                    b.ToTable("CustomerAddress","SalesLT");
                });

            modelBuilder.Entity("DataAccess.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("Extension");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<DateTime>("HireDate");

                    b.Property<string>("HomePhone");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Notes")
                        .IsRequired();

                    b.Property<byte[]>("Photo");

                    b.Property<string>("PhotoPath");

                    b.Property<string>("PostalCode");

                    b.Property<string>("Region");

                    b.Property<int>("ReportsTo");

                    b.Property<decimal>("Salary");

                    b.Property<string>("Title");

                    b.Property<string>("TitleOfCourtesy");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("DataAccess.ErrorLog", b =>
                {
                    b.Property<int>("ErrorLogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ErrorLogID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ErrorLine");

                    b.Property<string>("ErrorMessage")
                        .IsRequired()
                        .HasMaxLength(4000);

                    b.Property<int>("ErrorNumber");

                    b.Property<string>("ErrorProcedure")
                        .HasMaxLength(126);

                    b.Property<int?>("ErrorSeverity");

                    b.Property<int?>("ErrorState");

                    b.Property<DateTime>("ErrorTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("ErrorLogId");

                    b.ToTable("ErrorLogs");
                });

            modelBuilder.Entity("DataAccess.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ProductID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color")
                        .HasMaxLength(15);

                    b.Property<DateTime?>("DiscontinuedDate")
                        .HasColumnType("datetime");

                    b.Property<decimal>("ListPrice")
                        .HasColumnType("money");

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("ProductCategoryId")
                        .HasColumnName("ProductCategoryID");

                    b.Property<int?>("ProductModelId")
                        .HasColumnName("ProductModelID");

                    b.Property<string>("ProductNumber")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<Guid>("Rowguid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("rowguid")
                        .HasDefaultValueSql("(newid())");

                    b.Property<DateTime?>("SellEndDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("SellStartDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Size")
                        .HasMaxLength(5);

                    b.Property<decimal>("StandardCost")
                        .HasColumnType("money");

                    b.Property<byte[]>("ThumbNailPhoto");

                    b.Property<string>("ThumbnailPhotoFileName")
                        .HasMaxLength(50);

                    b.Property<decimal?>("Weight")
                        .HasColumnType("decimal(8, 2)");

                    b.HasKey("ProductId");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("AK_Product_Name");

                    b.HasIndex("ProductCategoryId");

                    b.HasIndex("ProductModelId");

                    b.HasIndex("ProductNumber")
                        .IsUnique()
                        .HasName("AK_Product_ProductNumber");

                    b.HasIndex("Rowguid")
                        .IsUnique()
                        .HasName("AK_Product_rowguid");

                    b.ToTable("Product","SalesLT");
                });

            modelBuilder.Entity("DataAccess.ProductCategory", b =>
                {
                    b.Property<int>("ProductCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ProductCategoryID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("ParentProductCategoryId")
                        .HasColumnName("ParentProductCategoryID");

                    b.Property<Guid>("Rowguid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("rowguid")
                        .HasDefaultValueSql("(newid())");

                    b.HasKey("ProductCategoryId");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("AK_ProductCategory_Name");

                    b.HasIndex("ParentProductCategoryId");

                    b.HasIndex("Rowguid")
                        .IsUnique()
                        .HasName("AK_ProductCategory_rowguid");

                    b.ToTable("ProductCategory","SalesLT");
                });

            modelBuilder.Entity("DataAccess.ProductDescription", b =>
                {
                    b.Property<int>("ProductDescriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ProductDescriptionID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(400);

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<Guid>("Rowguid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("rowguid")
                        .HasDefaultValueSql("(newid())");

                    b.HasKey("ProductDescriptionId");

                    b.HasIndex("Rowguid")
                        .IsUnique()
                        .HasName("AK_ProductDescription_rowguid");

                    b.ToTable("ProductDescription","SalesLT");
                });

            modelBuilder.Entity("DataAccess.ProductModel", b =>
                {
                    b.Property<int>("ProductModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ProductModelID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CatalogDescription")
                        .HasColumnType("xml");

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<Guid>("Rowguid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("rowguid")
                        .HasDefaultValueSql("(newid())");

                    b.HasKey("ProductModelId");

                    b.HasIndex("CatalogDescription")
                        .HasName("PXML_ProductModel_CatalogDescription");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("AK_ProductModel_Name");

                    b.HasIndex("Rowguid")
                        .IsUnique()
                        .HasName("AK_ProductModel_rowguid");

                    b.ToTable("ProductModel","SalesLT");
                });

            modelBuilder.Entity("DataAccess.ProductModelProductDescription", b =>
                {
                    b.Property<int>("ProductModelId")
                        .HasColumnName("ProductModelID");

                    b.Property<int>("ProductDescriptionId")
                        .HasColumnName("ProductDescriptionID");

                    b.Property<string>("Culture")
                        .HasMaxLength(6);

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<Guid>("Rowguid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("rowguid")
                        .HasDefaultValueSql("(newid())");

                    b.HasKey("ProductModelId", "ProductDescriptionId", "Culture")
                        .HasName("PK_ProductModelProductDescription_ProductModelID_ProductDescriptionID_Culture");

                    b.HasIndex("ProductDescriptionId");

                    b.HasIndex("Rowguid")
                        .IsUnique()
                        .HasName("AK_ProductModelProductDescription_rowguid");

                    b.ToTable("ProductModelProductDescription","SalesLT");
                });

            modelBuilder.Entity("DataAccess.SalesOrderDetail", b =>
                {
                    b.Property<int>("SalesOrderId")
                        .HasColumnName("SalesOrderID");

                    b.Property<int>("SalesOrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SalesOrderDetailID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("LineTotal")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("numeric(38, 6)")
                        .HasComputedColumnSql("(isnull(([UnitPrice]*((1.0)-[UnitPriceDiscount]))*[OrderQty],(0.0)))");

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<short>("OrderQty");

                    b.Property<int>("ProductId")
                        .HasColumnName("ProductID");

                    b.Property<Guid>("Rowguid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("rowguid")
                        .HasDefaultValueSql("(newid())");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("money");

                    b.Property<decimal>("UnitPriceDiscount")
                        .HasColumnType("money");

                    b.HasKey("SalesOrderId", "SalesOrderDetailId")
                        .HasName("PK_SalesOrderDetail_SalesOrderID_SalesOrderDetailID");

                    b.HasIndex("ProductId");

                    b.HasIndex("Rowguid")
                        .IsUnique()
                        .HasName("AK_SalesOrderDetail_rowguid");

                    b.ToTable("SalesOrderDetail","SalesLT");
                });

            modelBuilder.Entity("DataAccess.SalesOrderHeader", b =>
                {
                    b.Property<int>("SalesOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SalesOrderID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountNumber")
                        .HasMaxLength(15);

                    b.Property<int?>("BillToAddressId")
                        .HasColumnName("BillToAddressID");

                    b.Property<string>("Comment");

                    b.Property<string>("CreditCardApprovalCode")
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    b.Property<int>("CustomerId")
                        .HasColumnName("CustomerID");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime");

                    b.Property<decimal>("Freight")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("money")
                        .HasDefaultValueSql("((0.00))");

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<bool?>("OnlineOrderFlag")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((1))");

                    b.Property<DateTime>("OrderDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("PurchaseOrderNumber")
                        .HasMaxLength(25);

                    b.Property<byte>("RevisionNumber");

                    b.Property<Guid>("Rowguid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("rowguid")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("SalesOrderNumber")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasComputedColumnSql("(isnull(N'SO'+CONVERT([nvarchar](23),[SalesOrderID],0),N'*** ERROR ***'))")
                        .HasMaxLength(25);

                    b.Property<DateTime?>("ShipDate")
                        .HasColumnType("datetime");

                    b.Property<string>("ShipMethod")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("ShipToAddressId")
                        .HasColumnName("ShipToAddressID");

                    b.Property<byte>("Status")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((1))");

                    b.Property<decimal>("SubTotal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("money")
                        .HasDefaultValueSql("((0.00))");

                    b.Property<decimal>("TaxAmt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("money")
                        .HasDefaultValueSql("((0.00))");

                    b.Property<decimal>("TotalDue")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("money")
                        .HasComputedColumnSql("(isnull(([SubTotal]+[TaxAmt])+[Freight],(0)))");

                    b.HasKey("SalesOrderId")
                        .HasName("PK_SalesOrderHeader_SalesOrderID");

                    b.HasIndex("BillToAddressId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("Rowguid")
                        .IsUnique()
                        .HasName("AK_SalesOrderHeader_rowguid");

                    b.HasIndex("SalesOrderNumber")
                        .IsUnique()
                        .HasName("AK_SalesOrderHeader_SalesOrderNumber");

                    b.HasIndex("ShipToAddressId");

                    b.ToTable("SalesOrderHeader","SalesLT");
                });

            modelBuilder.Entity("DataAccess.CustomerAddress", b =>
                {
                    b.HasOne("DataAccess.Address", "Address")
                        .WithMany("CustomerAddress")
                        .HasForeignKey("AddressId");

                    b.HasOne("DataAccess.Customer", "Customer")
                        .WithMany("CustomerAddress")
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("DataAccess.Product", b =>
                {
                    b.HasOne("DataAccess.ProductCategory", "ProductCategory")
                        .WithMany("Product")
                        .HasForeignKey("ProductCategoryId");

                    b.HasOne("DataAccess.ProductModel", "ProductModel")
                        .WithMany("Product")
                        .HasForeignKey("ProductModelId");
                });

            modelBuilder.Entity("DataAccess.ProductCategory", b =>
                {
                    b.HasOne("DataAccess.ProductCategory", "ParentProductCategory")
                        .WithMany("InverseParentProductCategory")
                        .HasForeignKey("ParentProductCategoryId")
                        .HasConstraintName("FK_ProductCategory_ProductCategory_ParentProductCategoryID_ProductCategoryID");
                });

            modelBuilder.Entity("DataAccess.ProductModelProductDescription", b =>
                {
                    b.HasOne("DataAccess.ProductDescription", "ProductDescription")
                        .WithMany("ProductModelProductDescription")
                        .HasForeignKey("ProductDescriptionId");

                    b.HasOne("DataAccess.ProductModel", "ProductModel")
                        .WithMany("ProductModelProductDescription")
                        .HasForeignKey("ProductModelId");
                });

            modelBuilder.Entity("DataAccess.SalesOrderDetail", b =>
                {
                    b.HasOne("DataAccess.Product", "Product")
                        .WithMany("SalesOrderDetail")
                        .HasForeignKey("ProductId");

                    b.HasOne("DataAccess.SalesOrderHeader", "SalesOrder")
                        .WithMany("SalesOrderDetail")
                        .HasForeignKey("SalesOrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataAccess.SalesOrderHeader", b =>
                {
                    b.HasOne("DataAccess.Address", "BillToAddress")
                        .WithMany("SalesOrderHeaderBillToAddress")
                        .HasForeignKey("BillToAddressId")
                        .HasConstraintName("FK_SalesOrderHeader_Address_BillTo_AddressID");

                    b.HasOne("DataAccess.Customer", "Customer")
                        .WithMany("SalesOrderHeader")
                        .HasForeignKey("CustomerId");

                    b.HasOne("DataAccess.Address", "ShipToAddress")
                        .WithMany("SalesOrderHeaderShipToAddress")
                        .HasForeignKey("ShipToAddressId")
                        .HasConstraintName("FK_SalesOrderHeader_Address_ShipTo_AddressID");
                });
#pragma warning restore 612, 618
        }
    }
}
