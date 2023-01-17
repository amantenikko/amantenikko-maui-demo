namespace TipCalculator3;

public partial class StandardTipPage : ContentPage
{
    private Color colorNavy = Colors.Navy;
    private Color colorSilver = Colors.Silver;

    public StandardTipPage()
    {
        InitializeComponent();
        billInput.TextChanged += (s, e) => CalculateTip();
    }

    void CalculateTip()
    {

        if (Double.TryParse(billInput.Text, out double bill) && bill > 0)
        {
            double tip = Math.Round(bill * 0.15, 2);
            double final = bill + tip;

            tipOutput.Text = tip.ToString("C");
            totalOutput.Text = final.ToString("C");
        }

    }

    void OnLight(object sender, EventArgs e)
    {
        Resources["bgColor"] = colorSilver;
        Resources["fgColor"] = colorNavy;
    }

    void OnDark(object sender, EventArgs e)
    {
        Resources["bgColor"] = colorNavy;
        Resources["fgColor"] = colorSilver;
    }

    async void GotoCustom(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(CustomTipPage));
    }

}