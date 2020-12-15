using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Models;
using GrpcClient;

namespace XamarinApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotesPage : ContentPage
    {
        public NotesPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ListView.ItemsSource = await App.Database.GetNotesAsync();

            // 
            this.ClassId = "NotesPage";
            Application.Current.Properties["ParentId"] = this.ClassId;
            var ParentId = Application.Current.Properties["ParentId"];
        }

        async void OnNoteAddedClicked(object sender, EventArgs e)
        {
            Console.WriteLine("****************** OnNoteAddedClicked ******************");
            //var client = new Client();
            //var result = await client.GetJobsStatus();

            await Navigation.PushAsync(new NoteEntryPage
            {
                BindingContext = new Note()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new NoteEntryPage()
                {
                    BindingContext = e.SelectedItem as Note
                });
            }
        }

        private async void SliderTransform_OnClicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new SliderTransform());
            await Navigation.PopAsync();
        }
    }
}