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
    class ImageTextComparer : IComparer
    {
        private NumberCaseInsensitiveComparer ObjectCompare = new NumberCaseInsensitiveComparer();

        public int Compare(object x, object y)
        {
            ListViewItem item = (ListViewItem)x;
            int imageIndex = item.ImageIndex;
            ListViewItem item2 = (ListViewItem)y;
            int num2 = item2.ImageIndex;
            return (imageIndex == num2) ? this.ObjectCompare.Compare(item.Text, item2.Text) : Convert.ToInt32(imageIndex > num2) * 2 - 1;
        }
    }
}
