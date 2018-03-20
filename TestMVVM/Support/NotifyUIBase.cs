using System.ComponentModel;

namespace TestMVVM
{
    public class NotifyUIBase : INotifyPropertyChanged
    {
        public NotifyUIBase()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
