using A_Star_Algorithm_Virtualization.Models;
using System;
using System.Windows;
using System.Windows.Media;

namespace A_Star_Algorithm_Virtualization.Helper
{
    public static class Utils
    {
        public static T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            //get parent item
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);

            //we've reached the end of the tree
            if (parentObject == null) return null;

            //check if the parent matches the type we're looking for
            if (parentObject is T parent)
            {
                return parent;
            }
            else
            {
                return FindParent<T>(parentObject);
            }
        }
        public static int FindDistancBetweenPoints(Node point1,Node point2, int rowCount, int colCount)
        {
            int res = 0;

            int diff1 = Math.Abs(point2.Row - point1.Row);
            int diff2 = Math.Abs(point2.Column - point1.Column);

            if(diff1 > diff2)
            {
                res = (diff1 - diff2) * 10 + diff2 * 14;
            }
            else
            {
                res = (diff2 - diff1) * 10 + diff1 * 14;
            }
            return res;
        }
    }
}
