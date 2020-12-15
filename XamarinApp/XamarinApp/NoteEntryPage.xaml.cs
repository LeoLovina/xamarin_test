using System;
using System.Diagnostics;
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
            this.Price.SetBinding(Editor.TextProperty, "Price");
        }

        protected override void OnAppearing()
        {
            var note = (Note)BindingContext;
            base.OnAppearing();
            var ParentId = Application.Current.Properties["ParentId"]?.ToString();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Debug.WriteLine("OnDisappearing");
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

        private async void MenuItem_OnClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", "Everything is OK", "OK");
        }

        private async void MenuItemAction_OnClicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("ActionSheet: Send to?", "Cancel", null, "Email", "Twitter", "Facebook");
            Debug.WriteLine("Action: " + action);
        }
    }
}