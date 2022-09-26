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
        var message = MauiProgram.bl.AddEntry(Clue.Text, Answer.Text, Int32.Parse(Difficulty.Text), Date.Text);
        DisplayAlert("Add Entry Message:", message.ToString(), "Ok");
    }

	//HOW TO GET ID FROM EVENT?????
	//DELETE ENTRY AND EDIT ENTRY ARE TAKING IN INTS !!!!
	void DeleteEntry(System.Object sender, System.EventArgs e)
	{
		//EntriesLV.SelectedItem = null;
		Entry entry = (Entry)EntriesLV.SelectedItem;
        var message = MauiProgram.bl.DeleteEntry(entry);
        DisplayAlert("Delete Entry Message:", message.ToString(), "Ok");
    }

	void EditEntry(System.Object sender, System.EventArgs e)
	{

	}

	// TODO: write all the functions needed
}

