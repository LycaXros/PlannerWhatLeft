using DevExpress.Mvvm;
using DevExpress.Xpf.WindowsUI.Navigation;
using DXApplication1.DataModel;

namespace DXApplication1.ViewModel
{
    //A View Model for an ItemDetailPage
    public class ItemDetailViewModel : ViewModelBase, INavigationAware
    {
        SampleDataItem selectedItem;
        public ItemDetailViewModel() { }
        public SampleDataItem SelectedItem
        {
            get { return selectedItem; }
            set { SetProperty<SampleDataItem>(ref selectedItem, value, "SelectedItem"); }
        }
        private void LoadState(object navigationParameter)
        {
            SampleDataItem item = SampleDataSource.GetItem((string)navigationParameter);
            SelectedItem = item;
        }
        #region INavigationAware Members
        public void NavigatedFrom(NavigationEventArgs e)
        {
        }
        public void NavigatedTo(NavigationEventArgs e)
        {
            LoadState(e.Parameter);
        }
        public void NavigatingFrom(NavigatingEventArgs e)
        {
        }
        #endregion
    }
}
