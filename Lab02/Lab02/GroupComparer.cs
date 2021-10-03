using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02
{
    public class GroupComparer: IComparer
    {
        int IComparer.Compare(Object x, Object y)
        {
            if (x == null || y == null)
                throw new ArgumentNullException("Arguments are null");

            Group X = (Group)x;
            Group Y = (Group)y;
            return X.Students.Count().CompareTo(Y.Students.Count());
        }
    }
}
