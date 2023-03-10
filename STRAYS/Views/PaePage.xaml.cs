using STRAYS.Models;
using STRAYS.ViewModels;

namespace STRAYS.Views;

public partial class PaePage : ContentPage
{
	public PaePage(PaeViewModel vm)
	{
		InitializeComponent();
        BindingContext= vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        List<PaeModel> mascota = App.Repositorio.GetAllPaes();
        lista.ItemsSource = mascota;
    }

    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var pae = (Models.PaeModel)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(PaeRegistroPage)}?{nameof(PaeRegistroPage.ItemId)}={pae.IdPae}");

            // Unselect the UI
            lista.SelectedItem = null;
        }
    }

    private void irArriba(object sender, EventArgs e)
    {
        lista.ScrollTo(0);
    }
}