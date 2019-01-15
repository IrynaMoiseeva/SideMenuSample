using Android.Views;
using MvvmCross.Droid.Views.Attributes;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Droid.Views.Fragments;
using MvvmCross.Platform;
using MvvmCross.Core.ViewModels;
using SideMenuSample.ViewModels;
using Android.Support.V7.Widget;
using SideMenuSample.Droid.Adapters;

namespace SideMenuSample.Droid.Views
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.menu_content_fragment_holder, false)]
    public class MenuFragment : MvxFragment<SideMenuViewModel>
    {
        public SideMenuViewModel ViewModel
        {
            get { return base.ViewModel; }
            set { base.ViewModel = value; }
        }

        protected MvxRecyclerView RecyclerView; 

        public MenuListAdapter adapter { get; set; }

        private MainViewActivity MainActivity => (MainViewActivity)Activity;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Android.OS.Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = this.BindingInflate(Resource.Layout.fragment_menu, null);

            RecyclerView = view.FindViewById<MvxRecyclerView>(Resource.Id.recyclerview);

            adapter = new MenuListAdapter((IMvxAndroidBindingContext)this.BindingContext);

            var mvxViewModelLoader = Mvx.Resolve<IMvxViewModelLoader>();
            var vmRequest = MvxViewModelRequest.GetDefaultRequest(typeof(SideMenuViewModel));
            ViewModel = mvxViewModelLoader.LoadViewModel(vmRequest, null) as SideMenuViewModel;
            adapter.ViewModel = ViewModel;

            var linearLayoutManager = new LinearLayoutManager(Context);
            var dividerItemDecoration = new DividerItemDecoration(RecyclerView.Context, linearLayoutManager.Orientation);

            RecyclerView.SetLayoutManager(linearLayoutManager);
            RecyclerView.AddItemDecoration(dividerItemDecoration);

            RecyclerView.Adapter = adapter;
            adapter.ItemClick += OnItemClick;

            return view;
        }

        private void OnItemClick(object sender, int arg)
        {
            MainActivity.CloseDrawers();
        }
    }
}