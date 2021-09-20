using System;
using System.Windows;
using A_Star_Algorithm_Virtualization.ViewModels;
using A_Star_Algorithm_Virtualization.Views;

namespace A_Star_Algorithm_Virtualization
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static MainWindowViewModel MainWindowViewModelInstance = new MainWindowViewModel();

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow mainWindow = new MainWindow { DataContext = MainWindowViewModelInstance };
            mainWindow.Show();
        }
    }
}
