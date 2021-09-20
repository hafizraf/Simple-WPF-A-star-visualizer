using A_Star_Algorithm_Virtualization.Helper;
using A_Star_Algorithm_Virtualization.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace A_Star_Algorithm_Virtualization.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private int rowCount = 5;
        private int columnCount = 5;
        private Node startNode = null;
        private Node endNode = null;
        private ICommand startCommand;

        public ObservableCollection<Node> Nodes = new ObservableCollection<Node>();
        public ObservableCollection<Node> BarrierNodes = new ObservableCollection<Node>();
        public ObservableCollection<Node> OpenNodes = new ObservableCollection<Node>();
        public ObservableCollection<Node> ClosedNodes = new ObservableCollection<Node>();
        public Node StartNode
        {
            get
            {
                return startNode;
            }
            set
            {
                if (startNode != value)
                {
                    startNode = value;
                    if (startNode != null)
                    {
                        startNode.IsStartOrEndPoint = true;
                    }
                    base.OnPropertyChanged("StartNode");
                }
            }
        }
        public Node EndNode
        {
            get
            {
                return endNode;
            }
            set
            {
                if (endNode != value)
                {
                    endNode = value;
                    if (endNode != null)
                    {
                        endNode.IsStartOrEndPoint = true;
                    }
                    base.OnPropertyChanged("EndNode");
                }
            }
        }
        public MainWindowViewModel()
        {
            Nodes.CollectionChanged += Nodes_CollectionChanged;
            BarrierNodes.CollectionChanged += BarrierNodes_CollectionChanged;
            OpenNodes.CollectionChanged += OpenNodes_CollectionChanged;
            ClosedNodes.CollectionChanged += ClosedNodes_CollectionChanged;
        }
        public int RowCount
        {
            get
            {
                return rowCount;
            }
            set
            {
                if (rowCount != value)
                {
                    rowCount = value;
                    base.OnPropertyChanged("RowCount");
                }
            }
        }
        public int ColumnCount
        {
            get
            {
                return columnCount;
            }
            set
            {
                if (columnCount != value)
                {
                    columnCount = value;
                    base.OnPropertyChanged("ColumnCount");
                }
            }
        }

        private void Nodes_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Node n in e.NewItems)
                {
                    n.IsBarrier = false;
                }
            }
        }
        private void BarrierNodes_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Node n in e.NewItems)
                {
                    n.IsBarrier = true;
                    n.IsStartOrEndPoint = false;
                }

            }
        }
        private void OpenNodes_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Node n in e.NewItems)
                {
                    n.IsOpen = true;
                }

            }
        }
        private void ClosedNodes_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Node n in e.NewItems)
                {
                    n.IsClosed = true;
                }

            }
        }

        public ICommand StartCommand
        {
            get
            {
                if (startCommand == null)
                {
                    startCommand = new RCommand(
                        param => Start(),
                        param => CanStart
                        );
                }
                return startCommand;
            }
        }
        private void Start()
        {
            Task.Run(() =>
            {
                OpenNodes.Add(StartNode);
                while (true)
                {
                    Node node = FindLowestCostOpenNode();
                    if (node == null)
                    {
                        MessageBox.Show("No routes found!!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                    OpenNodes.Remove(node);
                    Nodes.Remove(node);
                    ClosedNodes.Add(node);

                    if (node == EndNode)
                    {
                        Node track = node.Parent;
                        //Success
                        while (track != StartNode)
                        {
                            track.IsStartOrEndPoint = true;
                            track = track.Parent;
                        }
                        return;
                    }
                    EvaluateOpenNodesAround(node);
                }
            });
        }
        private Node FindLowestCostOpenNode()
        {
            if (OpenNodes.Count == 0)
            {
                return null;
            }
            else
            {
                Node res = OpenNodes[0];
                foreach (Node N in OpenNodes)
                {
                    if (N.FValue < res.FValue || (N.FValue == res.FValue && N.HValue < res.HValue))
                    {
                        res = N;
                    }
                }
                return res;
            }
        }
        private List<Node> EvaluateOpenNodesAround(Node node)
        {
            List<Node> nodes = FindOpenNodesAround(node);
            foreach (Node N in nodes)
            {
                if (!N.IsOpen)
                {
                    N.GValue = node.GValue + Utils.FindDistancBetweenPoints(node, N, RowCount, ColumnCount);
                    N.HValue = Utils.FindDistancBetweenPoints(endNode, N, RowCount, ColumnCount);
                    N.FValue = N.GValue + N.HValue;
                    OpenNodes.Add(N);
                    N.Parent = node;
                }
                else
                {
                    int G = node.GValue + Utils.FindDistancBetweenPoints(node, N, RowCount, ColumnCount);
                    int H = Utils.FindDistancBetweenPoints(endNode, N, RowCount, ColumnCount);
                    if (N.FValue > G + H)
                    {
                        N.GValue = G;
                        N.HValue = H;
                        N.FValue = G + H;
                        N.Parent = node;
                    }
                }
            }
            Thread.Sleep(200);
            return nodes;

        }
        private List<Node> FindOpenNodesAround(Node node)
        {
            List<Node> res = new List<Node>();
            foreach (Node N in Nodes)
            {
                if (Math.Abs(N.Row - node.Row) <= 1 && Math.Abs(N.Column - node.Column) <= 1)
                {
                    if (!N.IsClosed )
                    {
                        res.Add(N);
                    }
                }
            }
            return res;
        }
        private bool CanStart
        {
            get
            {
                return StartNode != null && EndNode != null;
            }
        }
    }
}
