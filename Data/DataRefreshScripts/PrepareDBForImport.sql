-- Drop Check Contraints

EXEC sp_msforeachtable "ALTER TABLE ? NOCHECK CONSTRAINT all"
SET QUOTED_IDENTIFIER ON
-- Clear Current Data
GO
DELETE Addresses
GO

DELETE HomeKookdMeals
GO
DELETE HomeKookdMealSettings
GO
DELETE Kitchens
GO

DELETE KookdSchedules
GO

DELETE MealAttributes
GO
DELETE MealCalendars
GO
DELETE MealDetails
GO
DELETE MealReview
GO
DELETE Meals
GO
DELETE Memberships
GO
DELETE OrderPriceDetails
GO
DELETE Orders
GO
DELETE PaymentDetails
GO
