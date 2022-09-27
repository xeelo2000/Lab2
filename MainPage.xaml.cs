namespace Lab2;

public partial class MainPage : ContentPage
{
	//int count = 0;

	public MainPage()
	{
		InitializeComponent();
		EntriesLV.ItemsSource = MauiProgram.bl.GetEntries();
	}

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

	
	void DeleteEntry(System.Object sender, System.EventArgs e)
	{
		//EntriesLV.SelectedItem = null;
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

	void GetEntries()
	{

	}
	// TODO: write all the functions needed
}

