﻿using System;
using DropZone.Annotations;
using DropZone.ViewModels;
using Xamarin.Forms;

namespace DropZone.Views
{
    /// <summary>
    /// The main page which list all jumps.
    /// </summary>
    public class MainListPage : XForms.Toolkit.Mvvm.BaseView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainListPage"/> class.
        /// </summary>
        public MainListPage([NotNull] MainPageViewModel viewModel)
        {
            if (viewModel == null) throw new ArgumentNullException("viewModel");

            Icon = "list.png";
            ConfigureViewModel(viewModel);
            ConfigureContent(viewModel);
            ConfigureToolbar();
        }

        private void ConfigureViewModel(MainPageViewModel viewModel)
        {
            BindingContext = viewModel;

            Appearing += async (sender, args) =>
            {
                IsBusy = true;
                await viewModel.OnLoad(Navigation);
                IsBusy = false;
            };
        }

        private void ConfigureContent(MainPageViewModel viewModel)
        {
            SearchBar search = new SearchBar
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            search.TextChanged += (sender, args) => viewModel.Filter(args.NewTextValue);

            ListView listView = new ListView
            {
                ItemTemplate = new DataTemplate(typeof (JumpCell))
            };
            listView.SetBinding(ListView.ItemsSourceProperty, "Jumps");
            listView.ItemSelected += (sender, args) => viewModel.ItemSelected((JumpViewModel) args.SelectedItem);
            
            Content = new StackLayout
            {
                Children = 
                {
                    search,
                    listView
                }
            };
        }

        private void ConfigureToolbar()
        {
            Title = "Jump List";
        }
    }
}
