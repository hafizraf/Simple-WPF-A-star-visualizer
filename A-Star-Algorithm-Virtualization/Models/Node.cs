using A_Star_Algorithm_Virtualization.ViewModels;

namespace A_Star_Algorithm_Virtualization.Models
{
    public class Node : ViewModelBase
    {
        #region  Private properties
        private bool isBarrier = false;
        private bool isStartOrEndPoint = false;
        private bool isOpen = false;
        private bool isClosed = false;
        private int fValue = 0;
        private int gValue = 0;
        private int hValue = 0;
        private int number = 0;
        #endregion

        #region Public properties
        public Node Parent { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public bool IsBarrier
        {
            get
            {
                return isBarrier;
            }
            set
            {
                if (isBarrier != value)
                {
                    isBarrier = value;
                    base.OnPropertyChanged("IsBarrier");
                }
            }
        }
        public bool IsOpen
        {
            get
            {
                return isOpen;
            }
            set
            {
                if (isOpen != value)
                {
                    isOpen = value;
                    base.OnPropertyChanged("IsOpen");
                }
            }
        }
        public bool IsClosed
        {
            get
            {
                return isClosed;
            }
            set
            {
                if (isClosed != value)
                {
                    isClosed = value;
                    base.OnPropertyChanged("IsClosed");
                }
            }
        }
        public bool IsStartOrEndPoint
        {
            get
            {
                return isStartOrEndPoint;
            }
            set
            {
                if (isStartOrEndPoint != value)
                {
                    isStartOrEndPoint = value;
                    base.OnPropertyChanged("IsStartOrEndPoint");
                }
            }
        }
        public int FValue
        {
            get
            {
                return fValue;
            }
            set
            {
                if (fValue != value)
                {
                    fValue = value;
                    base.OnPropertyChanged("FValue");
                }
            }
        }
        public int GValue
        {
            get
            {
                return gValue;
            }
            set
            {
                if (gValue != value)
                {
                    gValue = value;
                    base.OnPropertyChanged("GValue");
                }
            }
        }
        public int HValue
        {
            get
            {
                return hValue;
            }
            set
            {
                if (hValue != value)
                {
                    hValue = value;
                    base.OnPropertyChanged("HValue");
                }
            }
        }
        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                if (number != value)
                {
                    number = value;
                    base.OnPropertyChanged("Number");
                }
            }
        }
        #endregion


    }
}
