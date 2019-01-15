using Android.Views;
using MvvmCross.Droid.Views.Attributes;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Droid.Views.Fragments;
using SideMenuSample.ViewModels;
using MvvmCross.Binding.BindingContext;
using SideMenuSample.Droid.Adapters;

namespace SideMenuSample.Droid.Views
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.main_content_fragment_holder, false)]
    public class MenuChildFragment : MvxFragment<OtherViewModel>
    {
        public MenuListAdapter adapter { get; set; }

        public OtherViewModel ViewModel
        {
            get { return base.ViewModel; }
            set { base.ViewModel = value; }
        }

        protected MvxRecyclerView RecyclerView;

        private MainViewActivity MainActivity => (MainViewActivity)Activity;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Android.OS.Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = this.BindingInflate(Resource.Layout.fragment_menu, null);

            RecyclerView = view.FindViewById<MvxRecyclerView>(Resource.Id.recyclerview);

            adapter = new MenuListAdapter((IMvxAndroidBindingContext)this.BindingContext);

            adapter.ViewModel = ViewModel;

            RecyclerView.Adapter = adapter;
            var bindingSet = this.CreateBindingSet<MenuChildFragment, OtherViewModel>();
            bindingSet.Bind(RecyclerView).For(v => v.ItemsSource).To(v => v.ItemsCollection);
            bindingSet.Apply();

            return view;
        }

        public MenuFeedtemViewModel SelectedMenu
        {
            set => MainActivity.CloseDrawers();
        }
    }
}