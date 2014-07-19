#region Copyright (C) 2005-2011 Team MediaPortal
// Copyright (C) 2005-2011 Team MediaPortal
// http://www.team-mediaportal.com
// 
// MediaPortal is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 2 of the License, or
// (at your option) any later version.
// 
// MediaPortal is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with MediaPortal. If not, see <http://www.gnu.org/licenses/>.

// Note:
// Not sure if I used this source or not, but it seemed to match up close, so added for licensing purposes
#endregion
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tremulous_Server_Search
{
    class ListViewColumnSorter : IComparer
    {
        private int ColumnToSort = 0;
        private ImageTextComparer FirstObjectCompare = new ImageTextComparer();
        private NumberCaseInsensitiveComparer ObjectCompare = new NumberCaseInsensitiveComparer();
        private SortOrder OrderOfSort = SortOrder.Ascending;

        public int Compare(object x, object y)
        {
            int num;
            ListViewItem item = (ListViewItem)x;
            ListViewItem item2 = (ListViewItem)y;
            if (this.ColumnToSort == 0)
                num = this.FirstObjectCompare.Compare(x, y);
            else
                num = this.ObjectCompare.Compare(item.SubItems[this.ColumnToSort].Text, item2.SubItems[this.ColumnToSort].Text);
            if (this.OrderOfSort == SortOrder.Ascending)
                return num;
            if (this.OrderOfSort == SortOrder.Descending)
                return -num;
            return 0;
        }

        public SortOrder Order
        {
            get
            {
                return OrderOfSort;
            }
            set
            {
                OrderOfSort = value;
            }
        }

        public int SortColumn
        {
            get
            {
                return ColumnToSort;
            }
            set
            {
                ColumnToSort = value;
            }
        }
    }
}
