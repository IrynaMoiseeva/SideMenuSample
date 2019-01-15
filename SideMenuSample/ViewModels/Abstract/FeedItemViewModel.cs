using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace GoodsCatalog.Core.ViewModels.Abstract
{
    public abstract class FeedItemViewModel : MvxViewModel
    {
		protected readonly ICommand goToDetailsCommand;

		protected FeedItemViewModel()
		{
		}

		public virtual ICommand GoToDetailsCommand => goToDetailsCommand;

		private void DoGoToDetails()
		{
			
			if(CanDoGoToDetails() == false)
			{
				return;
			}

			GoToDetails();
			
		}

		protected abstract void GoToDetails();

		protected virtual bool CanDoGoToDetails() => true;
	}
}
