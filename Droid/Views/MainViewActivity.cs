using Android.App;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Views;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Views.Attributes;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using SideMenuSample.ViewModels;
using Android.OS;
using Android.Support.V4.App;

namespace SideMenuSample.Droid.Views
{
    [Activity(Label="",MainLauncher = true, Theme = "@style/MyTheme.Base")]
    [MvxActivityPresentation]
    public class MainViewActivity : MvxAppCompatActivity<MainViewModel>
    {
        private readonly int drawerGravity = GravityCompat.End;

        private DrawerLayout drawerLayout { get; set; }

        private AppBarLayout AppBar { get; set; }

        private Toolbar toolbar;

        protected virtual bool GetUpNavigationEnabled() => true;
        protected int GetHomeAsUpIndicatorDrawableId() => Resource.Drawable.ic_menu_black;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_main);
            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.main_drawer);

            toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);

            SetSupportActionBar(toolbar);

            var upNavigationEnabled = GetUpNavigationEnabled();

            var actionBar = SupportActionBar;

            if (upNavigationEnabled == true)
            {

            }
            else
            {
                actionBar.SetDisplayHomeAsUpEnabled(false);
                actionBar.SetHomeButtonEnabled(false);
            }

            MenuFragment detailFragment = new MenuFragment();
            Android.App.FragmentTransaction vv = FragmentManager.BeginTransaction();
            vv.Replace(Resource.Id.menu_content_fragment_holder, detailFragment);
            vv.Commit();
        }

        public override void OnBackPressed()
        {
            if (drawerLayout.IsDrawerOpen(drawerGravity))
            {
                drawerLayout.CloseDrawers();
            }
            else
            {
                MoveTaskToBack(true);
            }
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            var itemId = item.ItemId;
           
            if (itemId == Resource.Id.opendrawer)
            {
                OpenDrawer();
                return true;
            }

            return false;
        }

        private void OpenDrawer()
        {
            drawerLayout.OpenDrawer(drawerGravity);
        }

        public void CloseDrawers()
        {
            drawerLayout.CloseDrawers();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.hm_menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }
    }
}