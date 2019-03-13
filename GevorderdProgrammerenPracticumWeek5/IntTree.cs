using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GevorderdProgrammerenPracticumWeek5
{
    public class IntTree
    {
        #region Code uit les

        private int item;
        private IntTree left = null;
        private IntTree right = null;

        public IntTree(int item)
        {
            this.item = item;
        }

        public void Add(int item)
        {
            if (item != this.item)
            {
                if (item < this.item)
                    if (left == null)
                        left = new IntTree(item);
                    else
                        left.Add(item);
                else if (right == null)
                    right = new IntTree(item);
                else
                    right.Add(item);
            }
        }

        public bool Search(int item)
        {
            if (item == this.item)
                return true;
            if (item < this.item)
                if (left == null)
                    return false;
                else
                    return left.Search(item);
            else if (right == null)
                return false;
            else
                return right.Search(item);
        }

        #endregion

        public int Min()
        {
            return left?.Min() ?? item;
        }

        public int Max()
        {
            return right?.Max() ?? item;
        }

        public int Count()
        {
            var count = 1;

            if (left != null)
                count += left.Count();

            if (right != null)
                count += right.Count();

            return count;
        }

        public string InOrder()
        {
            return (left != null ? left.InOrder() + " " : "") + $"{item}" + (right != null ? " " + right.InOrder() : "");
        }
    }
}
