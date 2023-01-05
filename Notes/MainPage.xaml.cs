namespace Notes;

public partial class MainPage : ContentPage
{
    private readonly string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");

    public MainPage()
    {
        InitializeComponent();
        if (File.Exists(_fileName))
        {
            editor.Text = File.ReadAllText(_fileName);
        }
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        File.WriteAllText(_fileName, editor.Text);
        await DisplayAlert("Save", "Note has successfully save.", "Ok");
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (File.Exists(_fileName))
        {
            File.Delete(_fileName);
        }
        editor.Text = string.Empty;
        await DisplayAlert("Delete", "Note has been deleted", "Ok");
    }
}