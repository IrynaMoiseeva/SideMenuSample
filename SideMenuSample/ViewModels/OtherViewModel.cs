using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using Newtonsoft.Json;
using SideMenuSample.Model;

namespace SideMenuSample.ViewModels
{
    public class OtherViewModel : MvxViewModel<string>
    {
        private static ObservableCollection<MenuFeedtemViewModel> itemsCollection;

        public ObservableCollection<MenuFeedtemViewModel> ItemsCollection
        {
            get { return itemsCollection; }
            set
            {
                itemsCollection = value;
                RaisePropertyChanged(() => ItemsCollection);
            }
        }

        public OtherViewModel()
        {
        }

        public override void Prepare(string param)
        {
            base.Prepare();
        }

        public async Task Init(string param)
        {
            ItemsCollection = new ObservableCollection<MenuFeedtemViewModel>();

            var items = JsonConvert.DeserializeObject<RootObject>(FileJson.jsonData1);
            var data = items.data.data;
            var childmenu = data.Where(b => b.id == param).Select(_ => _.children).First();

            foreach (var item in childmenu)
            {
                var menu = new MenuEntity() { Title = item.label, Id = item.id };
                ItemsCollection.Add(new MenuFeedtemViewModel(menu));

            }
        }

        public override Task Initialize()
        {
            return base.Initialize();
        }
    }
}