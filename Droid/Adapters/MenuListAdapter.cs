using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Binding.ExtensionMethods;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V7.RecyclerView;
using SideMenuSample.ViewModels;

namespace SideMenuSample.Droid.Adapters
{
    public class MenuListAdapter : MvxRecyclerAdapter
    {
        public View View;

        public MvxViewModel ViewModel { get; set; }

        public MenuListAdapter(IMvxAndroidBindingContext bindingContext)
             : base(bindingContext)
        {

        }

        public event EventHandler<int> ItemClick;

        public override Android.Support.V7.Widget.RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemBindingContext = new MvxAndroidBindingContext(parent.Context, this.BindingContext.LayoutInflaterHolder);

            View = this.InflateViewForHolder(parent, viewType, itemBindingContext);
          
            return new MyViewHolder(View, itemBindingContext);
        }

        public class MyViewHolder : MvxRecyclerViewHolder
        {
            public TextView name;

            public MyViewHolder(View itemView, IMvxAndroidBindingContext context) : base(itemView, context)

            {
                name = itemView.FindViewById<TextView>(Resource.Id.menutitle);

            }
        }

        protected object GetElementAt(int position)
        {
            return ItemsSource.ElementAt(position);
        }

        private void OnClick(int arg)
        {
            ItemClick(this,arg);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var catalog = ItemsSource.ElementAt(position) as MenuFeedtemViewModel;

            MyViewHolder myHolder = holder as MyViewHolder;
            myHolder.name.Text = catalog.Title;

            myHolder.name.Click += delegate
            {
                if (ViewModel is SideMenuViewModel viewModel)
                {
                    viewModel.NavigateOtherViewModel.Execute(catalog.Id);
                }

                OnClick(position);
            };
        }
    }
}