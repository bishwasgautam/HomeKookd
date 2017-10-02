set datDir=%1
set SqlServerName=%2
set DBName=%3

cd /d %~dp0

if exist Log.txt del Log.txt

@echo PrepareDBForImport %SqlServerName% >> Log.txt
@echo PrepareDBForImport %DBName% >> Log.txt
@echo PrepareDBForImport %time% >> Log.txt

@REM Getting DB ready for import ..
SQLCMD -S %SqlServerName% -d %DBName% -i PrepareDBForImport.sql >> Log.txt

@echo Start BCP %time% >> Log.txt

@REM Importing ..
BCP %DBName%.dbo.Addresses in %datDir%\Addresses.dat -S %SqlServerName% -T -c -E -q >> Log.txt
BCP %DBName%.dbo.HomeKookdMeals in %datDir%\HomeKookdMeals.dat -S %SqlServerName% -T -E -q -f %datDir%\HomeKookdMeals.xml >> Log.txt
BCP %DBName%.dbo.HomeKookdMealSettings in %datDir%\HomeKookdMealSettings.dat -S %SqlServerName% -T -E -q -f %datDir%\HomeKookdMealSettings.xml >> Log.txt
BCP %DBName%.dbo.Kitchens in %datDir%\Kitchens.dat -S %SqlServerName% -T -E -q -f %datDir%\Kitchens.xml >> Log.txt
BCP %DBName%.dbo.KookdSchedules in %datDir%\KookdSchedules.dat -S %SqlServerName% -T -E -q -f %datDir%\KookdSchedules.xml >> Log.txt
BCP %DBName%.dbo.MealAttributes in %datDir%\MealAttributes.dat -S %SqlServerName% -T -E -q -f %datDir%\MealAttributes.xml >> Log.txt
BCP %DBName%.dbo.MealCalendars in %datDir%\MealCalendars.dat -S %SqlServerName% -T -E -q -f %datDir%\MealCalendars.xml >> Log.txt
BCP %DBName%.dbo.MealDetails in %datDir%\MealDetails.dat -S %SqlServerName% -T -E -q -f %datDir%\MealDetails.xml >> Log.txt
BCP %DBName%.dbo.MealReview in %datDir%\MealReview.dat -S %SqlServerName% -T -E -q -f %datDir%\MealReview.xml >> Log.txt
BCP %DBName%.dbo.Meals in %datDir%\Meals.dat -S %SqlServerName% -T -E -q -f %datDir%\Meals.xml >> Log.txt
BCP %DBName%.dbo.Memberships in %datDir%\Memberships.dat -S %SqlServerName% -T -E -q -f %datDir%\Memberships.xml >> Log.txt
BCP %DBName%.dbo.OrderPriceDetails in %datDir%\OrderPriceDetails.dat -S %SqlServerName% -T -E -q -f %datDir%\OrderPriceDetails.xml >> Log.txt
BCP %DBName%.dbo.Orders in %datDir%\Orders.dat -S %SqlServerName% -T -E -q -f %datDir%\Orders.xml >> Log.txt
BCP %DBName%.dbo.PaymentDetails in %datDir%\PaymentDetails.dat -S %SqlServerName% -T -E -q -f %datDir%\PaymentDetails.xml >> Log.txt


@REM Finishing up ..


