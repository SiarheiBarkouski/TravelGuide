using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace TravelGuide.XamarinUI.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged, IPageContainer<Page>
    {
        public Page CurrentPage { get; }
        
        protected BaseViewModel(Page page)
        {
            CurrentPage = page;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            changed?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
