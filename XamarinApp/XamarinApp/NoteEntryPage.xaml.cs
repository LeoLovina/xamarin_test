using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Models;

namespace XamarinApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteEntryPage : ContentPage
    {
        public NoteEntryPage()
        {
            InitializeComponent();
        }


        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            note.Date = DateTime.UtcNow;
            await App.Database.SaveNoteAsync(note);
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (Note) BindingContext;
            await App.Database.DeleteNoteAsync(note);
            await Navigation.PopAsync();
        }

        private void BtnStart_OnClicked(object sender, EventArgs e)
        {
            Indicator.IsRunning = true;
        }

        private void BtnStop_OnClicked(object sender, EventArgs e)
        {
            Indicator.IsRunning = false;
        }
    }
}