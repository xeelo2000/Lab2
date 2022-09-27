# Lab 2 - .NET MAUI GUI for Lab 1
## Purpose 
This lab helps get us familiar with .NET MAUI by creating a UI for the backend that was established in Lab 1.

## `MainPage.xaml`
* Responsible for defining the user interface
* This contains a ListView which is acquiring data from the Database (which is just a flat file titled clues.db)

## `MainPage.xaml.cs`
* Responsible for establishing the connection between the ListView and the database with:
```
EntriesLV.ItemsSource = MauiProgram.bl.GetEntries();
```
* Also calls the proper `BusinessLogic` methods
* Displays the alerts for any error messages that may appear

## `BusinessLogic.cs`
* Used as a means of communication between the UI (`MainPage.xaml` / `MainPage.xaml.cs`) and the Database (`Database.cs`) by calling proper methods
* Checks user input via `CheckEntryFields()`

## `Database.cs`
* Connected to the file that serves as the "database"
* This directly writes to and reads from the "database" and is responsible for serialization and deserialization

## How to Run
1. Open the `Lab2.sln`file in the Visual Studio
2. Ensure that an Android device is able to be simulated ([Android Studio](https://developer.android.com/studio) was used for this specific lab)
3. Run the application via Visual Studio and ensure that the target is the an device that is able to be emulated
![SCR-20220927-ijs](https://user-images.githubusercontent.com/105162443/192606677-a5195bdc-67a4-4083-b994-27e164b82eac.png)
4. The app should be exist within the tablet and function there!

## Alternative Way to Run (Windows / Mac)
If there are issues that arise with running it via an emulated device, you're able to just target it to be ran just as .NET MAUI Application directly on your computer.
![SCR-20220927-iob](https://user-images.githubusercontent.com/105162443/192607007-0e6e73ca-fd7d-4eb8-bbc7-9e447b41457c.png)

## Lab Output (for Professor)
**Before Insertion:**  
<img width="1072" alt="SS1" src="https://user-images.githubusercontent.com/105162443/192607131-f6969d3d-357c-405f-8a3a-190a708afe4e.png">

**After Insertion:**  
<img width="1072" alt="SS2" src="https://user-images.githubusercontent.com/105162443/192607139-10587566-fd02-4c0a-816f-1959dbc1f8cf.png">
