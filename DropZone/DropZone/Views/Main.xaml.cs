using System;
using Xamarin.Forms;

namespace DropZone.Views
{
    /// <summary>
    /// The main page of the Drop Zone application.
    /// </summary>
    public partial class Main : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Main"/> class.
        /// </summary>
        public Main()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Called when add entry button is clicked.
        /// </summary>
        public async void OnButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(App.GetLogEntryPage());
        }
    }
}
