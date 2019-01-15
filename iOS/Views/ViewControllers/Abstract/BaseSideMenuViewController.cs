using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Support.XamarinSidebar.Views;
using MvvmCross.iOS.Views;
using UIKit;

namespace SideMenuSample.iOS.Views.ViewControllers.Abstract
{
    public abstract class BaseMenuViewController<TViewModel> : MvxViewController<TViewModel>, IMvxSidebarMenu where TViewModel : MvxViewModel
    {
        public abstract UIImage MenuButtonImage { get; }

        public virtual bool AnimateMenu => true;

        public virtual float DarkOverlayAlpha => 0.6f;

        public virtual bool HasDarkOverlay => true;

        public virtual bool HasShadowing => false;

        public virtual float ShadowOpacity => 0.5f;

        public virtual float ShadowRadius => 4.0f;

        public virtual UIColor ShadowColor => UIColor.Black;

        public virtual bool DisablePanGesture => false;

        public virtual bool ReopenOnRotate => true;

        private int maxMenuWidth = 250;

        private int minSpacedistanceOfTheMenu = 100;

        public int MenuWidth => UserInterfaceIdiomIsPhone ? int.Parse(UIScreen.MainScreen.Bounds.Width.ToString()) - minSpacedistanceOfTheMenu : maxMenuWidth;

        private bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        public BaseMenuViewController()
        {
        }

        public BaseMenuViewController(string nibName, Foundation.NSBundle bundle) : base(nibName, bundle)
        {
        }

        public BaseMenuViewController(IntPtr ptr) : base(ptr)
        {
        }

        public virtual void MenuWillOpen()
        {
        }

        public virtual void MenuDidOpen()
        {
        }

        public virtual void MenuWillClose()
        {
        }

        public virtual void MenuDidClose()
        {
        }
    }
}