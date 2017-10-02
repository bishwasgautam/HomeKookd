﻿// <auto-generated />
using HomeKookd.DataAccess.HomeKookdMainContext;
using HomeKookd.DataAccess.HomeKookdMainContext.Entities;
using HomeKookd.DataAccess.HomeKookdMainContext.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;

namespace HomeKookd.DataAccess.Migrations
{
    [DbContext(typeof(HomeKookdMainDataContext))]
    [Migration("20171002015524_Initial-Create")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HomeKookd.DataAccess.HomeKookdMainContext.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AddressType");

                    b.Property<string>("Apartment");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<bool>("IsActive");

                    b.Property<int>("KitchenId");

                    b.Property<DateTime>("LastUpdatedDateTime");

                    b.Property<int>("ResidenceType");

                    b.Property<string>("Street");

                    b.Property<int>("UserId");

                    b.Property<string>("Zip");

                    b.HasKey("Id");

                    b.HasIndex("KitchenId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("HomeKookd.DataAccess.HomeKookdMainContext.Entities.HomeKookdMeal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("KookId");

                    b.Property<int>("KookdCalendarId");

                    b.Property<int?>("KookdOrderId");

                    b.Property<DateTime>("KookdTime");

                    b.HasKey("Id");

                    b.HasIndex("KookId");

                    b.HasIndex("KookdCalendarId");

                    b.HasIndex("KookdOrderId");

                    b.ToTable("HomeKookdMeals");
                });

            modelBuilder.Entity("HomeKookd.DataAccess.HomeKookdMainContext.Entities.HomeKookdMealSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<int>("DeliveryOption");

                    b.Property<int>("HeadCount");

                    b.Property<int>("HomeKookdMealId");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("LastUpdatedDateTime");

                    b.HasKey("Id");

                    b.HasIndex("HomeKookdMealId")
                        .IsUnique();

                    b.ToTable("HomeKookdMealSettings");
                });

            modelBuilder.Entity("HomeKookd.DataAccess.HomeKookdMainContext.Entities.Kitchen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AddressId");

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.Property<int>("KookId");

                    b.Property<DateTime>("LastUpdatedDateTime");

                    b.Property<int>("Serves");

                    b.HasKey("Id");

                    b.HasIndex("KookId");

                    b.ToTable("Kitchens");
                });

            modelBuilder.Entity("HomeKookd.DataAccess.HomeKookdMainContext.Entities.Kook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("LastUpdatedDateTime");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Kooks");
                });

            modelBuilder.Entity("HomeKookd.DataAccess.HomeKookdMainContext.Entities.KookdMealCalendar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("MealCalendars");
                });

            modelBuilder.Entity("HomeKookd.DataAccess.HomeKookdMainContext.Entities.KookdOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<bool>("IsActive");

                    b.Property<int>("KookId");

                    b.Property<DateTime>("LastUpdatedDateTime");

                    b.Property<int>("OrderStatus");

                    b.Property<int>("OrderedByUserId");

                    b.Property<int>("UpdatedByUserId");

                    b.HasKey("Id");

                    b.HasIndex("KookId");

                    b.HasIndex("OrderedByUserId");

                    b.HasIndex("UpdatedByUserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("HomeKookd.DataAccess.HomeKookdMainContext.Entities.KookdSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("HomeKookdMealSettingId");

                    b.Property<bool?>("IsRecurring");

                    b.Property<DateTime>("ReadyAt");

                    b.Property<DateTime>("RecurEndDateTime");

                    b.Property<DateTime>("RecurStartDateTime");

                    b.Property<int?>("RecurringFrequencyInDays");

                    b.HasKey("Id");

                    b.HasIndex("HomeKookdMealSettingId")
                        .IsUnique();

                    b.ToTable("KookdSchedules");
                });

            modelBuilder.Entity("HomeKookd.DataAccess.HomeKookdMainContext.Entities.Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<string>("Description");

                    b.Property<int>("HomeKookdMealId");

                    b.Property<bool>("IsActive");

                    b.Property<int>("KitchenId");

                    b.Property<int>("KookId");

                    b.Property<DateTime>("LastUpdatedDateTime");

                    b.Property<string>("Name");

                    b.Property<double>("Price");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("HomeKookdMealId")
                        .IsUnique();

                    b.HasIndex("KitchenId");

                    b.HasIndex("KookId");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("HomeKookd.DataAccess.HomeKookdMainContext.Entities.MealAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Attribute");

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<bool>("Flagged");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("LastUpdatedDateTime");

                    b.Property<int>("MealDetailId");

                    b.HasKey("Id");

                    b.HasIndex("MealDetailId");

                    b.ToTable("MealAttributes");
                });

            modelBuilder.Entity("HomeKookd.DataAccess.HomeKookdMainContext.Entities.MealDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<string>("Ingredients");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("LastUpdatedDateTime");

                    b.Property<int>("MealId");

                    b.Property<int>("TotalCalories");

                    b.HasKey("Id");

                    b.HasIndex("MealId")
                        .IsUnique();

                    b.ToTable("MealDetails");
                });

            modelBuilder.Entity("HomeKookd.DataAccess.HomeKookdMainContext.Entities.MealReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<int>("MealId");

                    b.Property<int>("PriceWorthyIndex");

                    b.Property<int>("TasteIndex");

                    b.Property<int?>("TestimonyId");

                    b.Property<int>("TextureIndex");

                    b.HasKey("Id");

                    b.HasIndex("MealId");

                    b.HasIndex("TestimonyId");

                    b.ToTable("MealReview");
                });

            modelBuilder.Entity("HomeKookd.DataAccess.HomeKookdMainContext.Entities.Membership", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BeginDate");

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<DateTime?>("EndDate");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("LastUpdatedDateTime");

                    b.Property<string>("Remarks");

                    b.Property<int>("Status");

                    b.Property<int>("UpdatedBy");

                    b.Property<int?>("UpdatedByUserId");

                    b.Property<DateTime>("UserLastSeen");

                    b.HasKey("Id");

                    b.HasIndex("UpdatedByUserId")
                        .IsUnique()
                        .HasFilter("[UpdatedByUserId] IS NOT NULL");

                    b.ToTable("Memberships");
                });

            modelBuilder.Entity("HomeKookd.DataAccess.HomeKookdMainContext.Entities.OrderPriceDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("CalculatedTax");

                    b.Property<decimal>("HomeKookdFees");

                    b.Property<int>("KookdOrderId");

                    b.Property<decimal>("TotalAfterTax");

                    b.Property<decimal>("TotalBeforeTax");

                    b.HasKey("Id");

                    b.HasIndex("KookdOrderId")
                        .IsUnique();

                    b.ToTable("OrderPriceDetails");
                });

            modelBuilder.Entity("HomeKookd.DataAccess.HomeKookdMainContext.Entities.PaymentDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("Method");

                    b.Property<int>("PaymentInfoId");

                    b.HasKey("Id");

                    b.HasIndex("PaymentInfoId")
                        .IsUnique();

                    b.ToTable("PaymentDetails");

                    b.HasDiscriminator<string>("Discriminator").HasValue("PaymentDetails");
                });

            modelBuilder.Entity("HomeKookd.DataAccess.HomeKookdMainContext.Entities.PaymentInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("KookdOrderId");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("KookdOrderId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("PaymentInfo");
                });

            modelBuilder.Entity("HomeKookd.DataAccess.HomeKookdMainContext.Entities.Phone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AreaCode");

                    b.Property<string>("CountryCode");

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<string>("Extension");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("LastUpdatedDateTime");

                    b.Property<string>("PhoneNumber");

                    b.Property<int>("Type");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Phones");
                });

            modelBuilder.Entity("HomeKookd.DataAccess.HomeKookdMainContext.Entities.Testimony", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<int?>("KookId");

                    b.Property<int>("Rating");

                    b.Property<string>("Review");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("KookId");

                    b.HasIndex("UserId");

                    b.ToTable("Testimonies");
                });

            modelBuilder.Entity("HomeKookd.DataAccess.HomeKookdMainContext.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("Image");

                    b.Property<bool>("IsActive");

                    b.Property<string>("LastName");

                    b.Property<DateTime>("LastUpdatedDateTime");

                    b.Property<string>("MiddleName");

                    b.Property<string>("Sex");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("KookdUsers");
                });

            modelBuilder.Entity("HomeKookd.DataAccess.HomeKookdMainContext.Entities.CreditCardPaymentDetails", b =>
                {
                    b.HasBaseType("HomeKookd.DataAccess.HomeKookdMainContext.Entities.PaymentDetails");

                    b.Property<int?>("BillingAddressId");

                    b.Property<string>("CardNumber");

                    b.Property<DateTime>("Expiration");

                    b.Property<int>("SecurityCode");

                    b.HasIndex("BillingAddressId");

                    b.ToTable("CreditCardPaymentDetails");

                    b.HasDiscriminator().HasValue("CC");
                });

            modelBuilder.Entity("HomeKookd.DataAccess.HomeKookdMainContext.Entities.CryptoCurrencyPaymentDetails", b =>
                {
                    b.HasBaseType("HomeKookd.DataAccess.HomeKookdMainContext.Entities.PaymentDetails");

                    b.Property<string>("WalletAddress");

                    b.ToTable("CryptoCurrencyPaymentDetails");

                    b.HasDiscriminator().HasValue("Crypto");
                });

            modelBuilder.Entity("HomeKookd.DataAccess.HomeKookdMainContext.Entities.Address", b =>
                {
                    b.HasOne("HomeKookd.DataAccess.HomeKookdMainContext.Entities.Kitchen", "Kitchen")
                        .WithOne("Address")
                        .HasForeignKey("HomeKookd.DataAccess.HomeKookdMainContext.Entities.Address", "KitchenId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HomeKookd.DataAccess.HomeKookdMainContext.Entities.User", "User")
                        .WithMany("Addresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HomeKookd.DataAccess.HomeKookdMainContext.Entities.HomeKookdMeal", b =>
                {
                    b.HasOne("HomeKookd.DataAccess.HomeKookdMainContext.Entities.Kook", "Kook")
                        .WithMany("HomeKookdMeals")
                        .HasForeignKey("KookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HomeKookd.DataAccess.HomeKookdMainContext.Entities.KookdMealCalendar", "KookdMealCalendar")
                        .WithMany("HomeKookdMeals")
                        .HasForeignKey("KookdCalendarId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HomeKookd.DataAccess.HomeKookdMainContext.Entities.KookdOrder")
                        .WithMany("HomeKookdMeals")
                        .HasForeignKey("KookdOrderId");
                });

            modelBuilder.Entity("HomeKookd.DataAccess.HomeKookdMainContext.Entities.HomeKookdMealSetting", b =>
                {
                    b.HasOne("HomeKookd.DataAccess.HomeKookdMainContext.Entities.HomeKookdMeal", "HomeKookdMeal")
                        .WithOne("HomeKookdMealSetting")
                        .HasForeignKey("HomeKookd.DataAccess.HomeKookdMainContext.Entities.HomeKookdMealSetting", "HomeKookdMealId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HomeKookd.DataAccess.HomeKookdMainContext.Entities.Kitchen", b =>
                {
                    b.HasOne("HomeKookd.DataAccess.HomeKookdMainContext.Entities.Kook", "Kook")
                        .WithMany("Kitchen")
                        .HasForeignKey("KookId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HomeKookd.DataAccess.HomeKookdMainContext.Entities.Kook", b =>
                {
                    b.HasOne("HomeKookd.DataAccess.HomeKookdMainContext.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("HomeKookd.DataAccess.HomeKookdMainContext.Entities.KookdOrder", b =>
                {
                    b.HasOne("HomeKookd.DataAccess.HomeKookdMainContext.Entities.Kook", "Kook")
                        .WithMany()
                        .HasForeignKey("KookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HomeKookd.DataAccess.HomeKookdMainContext.Entities.User", "OrderedByUser")
                        .WithMany("Orders")
                        .HasForeignKey("OrderedByUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HomeKookd.DataAccess.HomeKookdMainContext.Entities.User", "UpdatedByUser")
                        .WithMany("UpdatedOrders")
                        .HasForeignKey("UpdatedByUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HomeKookd.DataAccess.HomeKookdMainContext.Entities.KookdSchedule", b =>
                {
                    b.HasOne("HomeKookd.DataAccess.HomeKookdMainContext.Entities.HomeKookdMealSetting", "HomeKookdMealSetting")
                        .WithOne("KookdSchedule")
                        .HasForeignKey("HomeKookd.DataAccess.HomeKookdMainContext.Entities.KookdSchedule", "HomeKookdMealSettingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HomeKookd.DataAccess.HomeKookdMainContext.Entities.Meal", b =>
                {
                    b.HasOne("HomeKookd.DataAccess.HomeKookdMainContext.Entities.HomeKookdMeal", "HomeKookdMeal")
                        .WithOne("Meal")
                        .HasForeignKey("HomeKookd.DataAccess.HomeKookdMainContext.Entities.Meal", "HomeKookdMealId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HomeKookd.DataAccess.HomeKookdMainContext.Entities.Kitchen", "Kitchen")
                        .WithMany("Meals")
                        .HasForeignKey("KitchenId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HomeKookd.DataAccess.HomeKookdMainContext.Entities.Kook", "Kook")
                        .WithMany("OfferedMeals")
                        .HasForeignKey("KookId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HomeKookd.DataAccess.HomeKookdMainContext.Entities.MealAttribute", b =>
                {
                    b.HasOne("HomeKookd.DataAccess.HomeKookdMainContext.Entities.MealDetail", "MealDetail")
                        .WithMany("Attributes")
                        .HasForeignKey("MealDetailId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HomeKookd.DataAccess.HomeKookdMainContext.Entities.MealDetail", b =>
                {
                    b.HasOne("HomeKookd.DataAccess.HomeKookdMainContext.Entities.Meal", "Meal")
                        .WithOne("MealDetail")
                        .HasForeignKey("HomeKookd.DataAccess.HomeKookdMainContext.Entities.MealDetail", "MealId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HomeKookd.DataAccess.HomeKookdMainContext.Entities.MealReview", b =>
                {
                    b.HasOne("HomeKookd.DataAccess.HomeKookdMainContext.Entities.Meal", "Meal")
                        .WithMany("MealReviews")
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HomeKookd.DataAccess.HomeKookdMainContext.Entities.Testimony", "Testimony")
                        .WithMany()
                        .HasForeignKey("TestimonyId");
                });

            modelBuilder.Entity("HomeKookd.DataAccess.HomeKookdMainContext.Entities.Membership", b =>
                {
                    b.HasOne("HomeKookd.DataAccess.HomeKookdMainContext.Entities.User", "User")
                        .WithOne("Membership")
                        .HasForeignKey("HomeKookd.DataAccess.HomeKookdMainContext.Entities.Membership", "UpdatedByUserId");
                });

            modelBuilder.Entity("HomeKookd.DataAccess.HomeKookdMainContext.Entities.OrderPriceDetails", b =>
                {
                    b.HasOne("HomeKookd.DataAccess.HomeKookdMainContext.Entities.KookdOrder", "KookdOrder")
                        .WithOne("OrderPriceDetails")
                        .HasForeignKey("HomeKookd.DataAccess.HomeKookdMainContext.Entities.OrderPriceDetails", "KookdOrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HomeKookd.DataAccess.HomeKookdMainContext.Entities.PaymentDetails", b =>
                {
                    b.HasOne("HomeKookd.DataAccess.HomeKookdMainContext.Entities.PaymentInfo", "PaymentInfo")
                        .WithOne("PaymentDetails")
                        .HasForeignKey("HomeKookd.DataAccess.HomeKookdMainContext.Entities.PaymentDetails", "PaymentInfoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HomeKookd.DataAccess.HomeKookdMainContext.Entities.PaymentInfo", b =>
                {
                    b.HasOne("HomeKookd.DataAccess.HomeKookdMainContext.Entities.KookdOrder", "KookdOrder")
                        .WithOne("PaymentInfo")
                        .HasForeignKey("HomeKookd.DataAccess.HomeKookdMainContext.Entities.PaymentInfo", "KookdOrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HomeKookd.DataAccess.HomeKookdMainContext.Entities.User")
                        .WithMany("PaymentInfo")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("HomeKookd.DataAccess.HomeKookdMainContext.Entities.Phone", b =>
                {
                    b.HasOne("HomeKookd.DataAccess.HomeKookdMainContext.Entities.User", "User")
                        .WithMany("Phones")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HomeKookd.DataAccess.HomeKookdMainContext.Entities.Testimony", b =>
                {
                    b.HasOne("HomeKookd.DataAccess.HomeKookdMainContext.Entities.Kook", "Kook")
                        .WithMany("Testimonies")
                        .HasForeignKey("KookId");

                    b.HasOne("HomeKookd.DataAccess.HomeKookdMainContext.Entities.User", "User")
                        .WithMany("Testimonies")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("HomeKookd.DataAccess.HomeKookdMainContext.Entities.CreditCardPaymentDetails", b =>
                {
                    b.HasOne("HomeKookd.DataAccess.HomeKookdMainContext.Entities.Address", "BillingAddress")
                        .WithMany()
                        .HasForeignKey("BillingAddressId");
                });
#pragma warning restore 612, 618
        }
    }
}