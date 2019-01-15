using System;
using GoodsCatalog.Core.ViewModels.Abstract;
using MvvmCross.Core.ViewModels;
using SideMenuSample.Model;

namespace SideMenuSample.ViewModels
{
    public class MenuFeedtemViewModel : FeedItemViewModel
    {
        private bool selected;

        public MenuFeedtemViewModel(MenuEntity menuEntity)
        {
            Title = menuEntity.Title;
            Id = menuEntity.Id;
        }

        public MvxCommand MyCommand { get; set; }

        public string Title { get; }
        public string Id { get; }

        public Type NavigationViewModel { get; }

        public bool IsSelected
        {
            get { return selected; }
            set
            {
                selected = value;
            }
        }

        protected override void GoToDetails()
        {
            throw new NotImplementedException();
        }
    }
}