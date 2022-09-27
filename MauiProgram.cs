/**
*	Name: XEE LO, PAUL HWANG
*	Date: SEPTEMBER 27, 2022
*	Description: CS 344: SOFTWARE ENGINEERING - LAB 2
*	Bugs: 
*	Reflection: Both Xee and I enjoyed this lab since it helped us get a bit more comfortable with using .NET MAUI.
*				We both agree that working in partners helped quicken the process significantly, especially with the use of GitHub for
*				version control. We hope that future labs also allow us to work together since being able to work alongside others
*				helped me learn the material quicker and also develops our skills in working in teams.
*/

namespace Lab2;

public static class MauiProgram
{
	// the business logic that will send and retrieve data to the database
    public static IBusinessLogic bl = new BusinessLogic();

    public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		return builder.Build();
	}
}
