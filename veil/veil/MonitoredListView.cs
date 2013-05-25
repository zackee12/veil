/*
Copyright (c) 2013 "Zachary Graber"

This file is part of veil.

Veil is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace veil
{
    class MonitoredListView : ListView
    {
        public event ItemChangedEventHandler ItemChanged;
        public delegate void ItemChangedEventHandler(object sender, EventArgs e);

        public MonitoredListView() : base()
        {    
        }

        public ListViewItem AddItem(string text)
        {
            ListViewItem lvi = base.Items.Add(text);
            // if there are event listeners raise the event
            if (ItemChanged != null)
            {
                ItemChanged(this, new EventArgs());
            }

            // return the base call
            return lvi;
        }

        public ListViewItem AddItem(ListViewItem value)
        {
            ListViewItem lvi = base.Items.Add(value);
            // if there are event listeners raise the event
            if (ItemChanged != null)
            {
                ItemChanged(this, new EventArgs());
            }

            // return the base call
            return lvi;
        }

        public void RemoveItem(ListViewItem value)
        {
            // call the base method
            base.Items.Remove(value);

            // if there are event listeners raise the event
            if (ItemChanged != null)
            {
                ItemChanged(this, new EventArgs());
            }           
        }

        public void RemoveAtItem(int index)
        {
            // call the base method
            base.Items.RemoveAt(index);

            // if there are event listeners raise the event
            if (ItemChanged != null)
            {
                ItemChanged(this, new EventArgs());
            }
        }

        public void ClearItems()
        {
            // call the base method
            base.Items.Clear();

            // if there are event listeners raise the event
            if (ItemChanged != null)
            {
                ItemChanged(this, new EventArgs());
            }            
        }
    }
}
