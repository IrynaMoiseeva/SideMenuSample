using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using Newtonsoft.Json;
using SideMenuSample.Model;

namespace SideMenuSample.ViewModels
{
    public class SideMenuViewModel : MvxViewModel
    {
        private MenuFeedtemViewModel selectedViewModel;

        private static ObservableCollection<MenuFeedtemViewModel> itemsCollection;

        private readonly IMvxNavigationService navigationService;
        private MvxCommand<string> navigateOtherViewModel;

        public SideMenuViewModel(IMvxNavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public ObservableCollection<MenuFeedtemViewModel> ItemsCollection
        {
            get { return itemsCollection; }
            set
            {
                itemsCollection = value;
            }
        }

        public IMvxAsyncCommand<string> NavigateCommand { get; private set; }

        public MenuFeedtemViewModel SelectedViewModel
        {
            get
            {
                return selectedViewModel;
            }

            private set
            {
                selectedViewModel = value;
                RaisePropertyChanged();
            }
        }

        public void Init()
        {
            ItemsCollection = new ObservableCollection<MenuFeedtemViewModel>();
            var items = JsonConvert.DeserializeObject<RootObject>(FileJson.jsonData1);
            List<Datum> menulist = items.data.data;

            foreach (var item in menulist)
            {
                var menuitem = new MenuEntity() { Title = item.label, Id = item.id };
                ItemsCollection.Add(new MenuFeedtemViewModel(menuitem));
            }
        }

        public MvxCommand<string> NavigateOtherViewModel
        {
            get
            {
                navigateOtherViewModel = navigateOtherViewModel ??
                 new MvxCommand<string>((param) => ShowViewModel<OtherViewModel>(new { param }));

                return navigateOtherViewModel;
            }
        }
    }
}