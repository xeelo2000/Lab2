namespace Lab2;
/**
Name: XEE LO, PAUL HWANG
Date: SEPTEMBER 27, 2022
Description: CS 344: SOFTWARE ENGINEERING - LAB 2
Bugs: 
Reflection: 
*/
public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		EntriesLV.ItemsSource = MauiProgram.bl.GetEntries();
	}


    /// <summary>
    /// This is the AddEntry button event that will take the user input 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
	void AddEntry(System.Object sender, System.EventArgs e)
	{
        if (int.TryParse(Difficulty.Text, out int difficulty))      
        {
            var message = MauiProgram.bl.AddEntry(Clue.Text, Answer.Text, difficulty, Date.Text);
            if (message != InvalidFieldError.NoError)
            {
                DisplayAlert("Add Entry Message:", message.ToString(), "Ok");
            }
        }
        else
        {
            DisplayAlert("Add Entry Message:", "InvalidDifficulty", "Ok");
        }
    }


	/// <summary>
    /// This is the DeleteEntry button that will find the SelectedItem in the listview and return the entry that is selected to be deleted
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
	void DeleteEntry(System.Object sender, System.EventArgs e)
	{
		Entry entry = (Entry)EntriesLV.SelectedItem;

        if(entry != null)
        {
            var message = MauiProgram.bl.DeleteEntry(entry);
            if (message != EntryDeletionError.NoError)
            {
                DisplayAlert("Delete Entry Message:", message.ToString(), "Ok");
            }
        }
        else
        {
            DisplayAlert("Delete Entry Message:", "EntryNotFound", "Ok");
        }
    }


    /// <summary>
    /// This is the EditEntry button that will find the entry that was selected in the listview and change its input
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
	void EditEntry(System.Object sender, System.EventArgs e)
	{
        Entry entry = (Entry)EntriesLV.SelectedItem;

        if(entry != null)
        {
            var message = MauiProgram.bl.EditEntry(entry, Clue.Text, Answer.Text, Int32.Parse(Difficulty.Text), Date.Text, entry.Id);
            if (message != EntryEditError.NoError)
            {
                DisplayAlert("Edit Entry Message:", message.ToString(), "Ok");
            }
        }
        else
        {
            DisplayAlert("Edit Entry Message:", "EntryNotFound", "Ok");
        }
    }
}

