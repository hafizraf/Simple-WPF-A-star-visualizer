using System.ComponentModel;

namespace A_Star_Algorithm_Virtualization.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// The constructor of this class
        /// </summary>
        protected ViewModelBase()
        {
        }

        /// <summary>
        /// The event to handle the property change for the model class properties.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// This method will notify property changed event whenever it is being set.
        /// </summary>
        /// <param name="propertyName">The property name</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler eventHandler = PropertyChanged;

            if (eventHandler != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
