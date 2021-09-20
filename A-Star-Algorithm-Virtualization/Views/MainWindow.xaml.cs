using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using A_Star_Algorithm_Virtualization.Models;
using A_Star_Algorithm_Virtualization.ViewModels;

namespace A_Star_Algorithm_Virtualization.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "RowCount" || e.PropertyName == "ColumnCount")
            {
                RemakeGrid();
            }
        }
        private void ToggleButton_PreviewMouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainWindowViewModel vm = this.DataContext as MainWindowViewModel;
            ToggleButton button = sender as ToggleButton;
            Node node = button.DataContext as Node;
            if (vm.BarrierNodes.Contains(node))
            {
                vm.BarrierNodes.Remove(node);
                vm.Nodes.Add(node);
                AddToStartOrEnd(node);
            }
            else
            {
                if (vm.StartNode == node)
                {
                    vm.StartNode = vm.EndNode;
                    vm.EndNode = null;
                    node.IsStartOrEndPoint = false;
                }
                else if (vm.EndNode == node)
                {
                    vm.EndNode = null;
                    node.IsStartOrEndPoint = false;
                }
                else
                {
                    AddToStartOrEnd(node);
                }
            }
        }
        private void AddToStartOrEnd(Node node)
        {
            MainWindowViewModel vm = this.DataContext as MainWindowViewModel;
            if (vm.StartNode == null)
            {
                vm.StartNode = node;
            }
            else if (vm.EndNode == null)
            {
                vm.EndNode = node;
            }
            else
            {
                vm.StartNode.IsStartOrEndPoint = false;
                vm.StartNode = vm.EndNode;
                vm.EndNode = node;
            }
        }
        private void ToggleButton_PreviewMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainWindowViewModel vm = this.DataContext as MainWindowViewModel;
            ToggleButton button = sender as ToggleButton;
            Node node = button.DataContext as Node;
            if (vm.StartNode == node)
            {
                vm.StartNode = vm.EndNode;
                vm.EndNode = null;
                vm.BarrierNodes.Add(node);
            }
            else if (vm.EndNode == node)
            {
                vm.EndNode = null;
                vm.BarrierNodes.Add(node);
            }
            else if (vm.Nodes.Contains(node))
            {
                vm.Nodes.Remove(node);
                vm.BarrierNodes.Add(node);
            }
            else
            {
                vm.BarrierNodes.Remove(node);
                vm.Nodes.Add(node);
            }

        }
        private void RemakeGrid()
        {
            MainWindowViewModel vm = this.DataContext as MainWindowViewModel;
            vm.BarrierNodes.Clear();
            vm.Nodes.Clear();
            vm.ClosedNodes.Clear();
            vm.ClosedNodes.Clear();
            vm.StartNode = null;
            vm.EndNode = null;

            if (vm.RowCount < 1 || vm.ColumnCount < 1)
            {
                MessageBox.Show("Enter valid values for row and column", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            MainGrid.RowDefinitions.Clear();
            MainGrid.ColumnDefinitions.Clear();
            for (int row = 0; row < vm.RowCount; row++)
            {
                MainGrid.RowDefinitions.Add(new System.Windows.Controls.RowDefinition());
            }
            for (int col = 0; col < vm.ColumnCount; col++)
            {
                MainGrid.ColumnDefinitions.Add(new System.Windows.Controls.ColumnDefinition());
            }
            for (int i = 0; i < vm.ColumnCount * vm.RowCount; i++)
            {
                Node node = new Node { Number = i };
                ToggleButton button = new ToggleButton { DataContext = node };
                node.Row = (int)(i / vm.ColumnCount);
                node.Column = i % vm.ColumnCount;
                Grid.SetRow(button, node.Row);
                Grid.SetColumn(button, node.Column);
                button.PreviewMouseLeftButtonUp += ToggleButton_PreviewMouseLeftButtonUp;
                button.PreviewMouseRightButtonUp += ToggleButton_PreviewMouseRightButtonUp;
                MainGrid.Children.Add(button);
                vm.Nodes.Add(node);
            }
        }

        private void Window_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.DataContext is MainWindowViewModel vm)
            {
                vm.PropertyChanged += ViewModel_PropertyChanged;
                RemakeGrid();
            }
        }

        private void Reset(object sender, RoutedEventArgs e)
        {
            RemakeGrid();
        }
    }
}
