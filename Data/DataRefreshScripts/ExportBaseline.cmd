set SqlServerName= %2
set DBName= %3
set datDir= %1
del log.txt
@echo PrepareDBForImport %SqlServerName% >>Log.txt
@echo PrepareDBForImport %DBName% >>Log.txt

@echo PrepareDBForImport %time% >>Log.txt

bcp %DBName%.dbo.Addresses format nul -c  -x  -f %datDir%\Addresses.xml -T -S %SqlServerName%
bcp %DBName%.dbo.HomeKookdMeals format nul -c -x -f %datDir%\HomeKookdMeals.xml -T -S %SqlServerName%
bcp %DBName%.dbo.HomeKookdMealSettings format nul -c -x -f %datDir%\HomeKookdMealSettings.xml -T -S %SqlServerName%
bcp %DBName%.dbo.Kitchens format nul -c -x -f %datDir%\Kitchens.xml -T -S %SqlServerName%
bcp %DBName%.dbo.KookdSchedules format nul -c -x -f %datDir%\KookdSchedules.xml -T -S %SqlServerName%
bcp %DBName%.dbo.MealAttributes format nul -c -x -f %datDir%\MealAttributes.xml -T -S %SqlServerName%
bcp %DBName%.dbo.MealCalendars format nul -c -x -f %datDir%\MealCalendars.xml -T -S %SqlServerName%
bcp %DBName%.dbo.MealDetails format nul -c -x -f %datDir%\MealDetails.xml -T -S %SqlServerName%
bcp %DBName%.dbo.MealReview format nul -c -x -f %datDir%\MealReview.xml -T -S %SqlServerName%
bcp %DBName%.dbo.Meals format nul -c -x -f %datDir%\Meals.xml -T -S %SqlServerName%
bcp %DBName%.dbo.Memberships format nul -c -x -f %datDir%\Memberships.xml -T -S %SqlServerName%
bcp %DBName%.dbo.OrderPriceDetails format nul -c -x -f %datDir%\OrderPriceDetails.xml -T -S %SqlServerName%
bcp %DBName%.dbo.Orders format nul -c -x -f %datDir%\Orders.xml -T -S %SqlServerName%
bcp %DBName%.dbo.PaymentDetails format nul -c -x -f %datDir%\PaymentDetails.xml -T -S %SqlServerName%


REM EXPORTING Data Base Tables ..


BCP %DBName%.dbo.Addresses out %datDir%\Addresses.dat -S %SqlServerName% -T  -f %datDir%\Addresses.xml  >>Log.txt
BCP %DBName%.dbo.HomeKookdMeals out %datDir%\HomeKookdMeals.dat -S %SqlServerName% -T  -f %datDir%\HomeKookdMeals.xml  >>Log.txt
BCP %DBName%.dbo.HomeKookdMealSettings out %datDir%\HomeKookdMealSettings.dat -S %SqlServerName% -T  -f %datDir%\HomeKookdMealSettings.xml  >>Log.txt
BCP %DBName%.dbo.Kitchens out %datDir%\Kitchens.dat -S %SqlServerName% -T  -f %datDir%\Kitchens.xml  >>Log.txt
BCP %DBName%.dbo.KookdSchedules out %datDir%\KookdSchedules.dat -S %SqlServerName% -T  -f %datDir%\KookdSchedules.xml  >>Log.txt
BCP %DBName%.dbo.MealAttributes out %datDir%\MealAttributes.dat -S %SqlServerName% -T  -f %datDir%\MealAttributes.xml  >>Log.txt
BCP %DBName%.dbo.MealCalendars out %datDir%\MealCalendars.dat -S %SqlServerName% -T  -f %datDir%\MealCalendars.xml  >>Log.txt
BCP %DBName%.dbo.MealDetails out %datDir%\MealDetails.dat -S %SqlServerName% -T  -f %datDir%\MealDetails.xml  >>Log.txt
BCP %DBName%.dbo.MealReview out %datDir%\MealReview.dat -S %SqlServerName% -T  -f %datDir%\MealReview.xml  >>Log.txt
BCP %DBName%.dbo.Meals out %datDir%\Meals.dat -S %SqlServerName% -T  -f %datDir%\Meals.xml  >>Log.txt
BCP %DBName%.dbo.Memberships out %datDir%\Memberships.dat -S %SqlServerName% -T  -f %datDir%\Memberships.xml  >>Log.txt
BCP %DBName%.dbo.OrderPriceDetails out %datDir%\OrderPriceDetails.dat -S %SqlServerName% -T  -f %datDir%\OrderPriceDetails.xml  >>Log.txt
BCP %DBName%.dbo.Orders out %datDir%\Orders.dat -S %SqlServerName% -T  -f %datDir%\Orders.xml  >>Log.txt
BCP %DBName%.dbo.PaymentDetails out %datDir%\PaymentDetails.dat -S %SqlServerName% -T  -f %datDir%\PaymentDetails.xml  >>Log.txt


