namespace Lab2;

public partial class MainPage : ContentPage
{
	//int count = 0;

	public MainPage()
	{
		InitializeComponent();
		//EntriesLV.ItemsSource = MauiProgram.entryDB.AllEntries;
	}

	void AddEntry(System.Object sender, System.EventArgs e)
	{
		MauiProgram.bl.AddEntry(Clue.Text, Answer.Text, Int32.Parse(Difficulty.Text), Date.Text);
		DisplayAlert("Congratulations", "Entry has been added!", "Ok");
	}

	//HOW TO GET ID FROM EVENT?????
	//DELETE ENTRY AND EDIT ENTRY ARE TAKING IN INTS !!!!
	void DeleteEntry(System.Object sender, System.EventArgs e)
	{
		//EntriesLV.SelectedItem = null;
		//Entry entry = EntriesLV.SelectedItem;
		
	}

	void EditEntry(System.Object sender, System.EventArgs e)
	{

	}

	// TODO: write all the functions needed
}

