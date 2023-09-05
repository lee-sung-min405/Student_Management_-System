using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace proagain1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        listsort mylistsort = new listsort();
        private void button1_Click(object sender, EventArgs e)
        {
            if(mylistsort.Num_error(maskedTextBox2.Text) == true)
            {
                ListViewItem item_temp = new ListViewItem();
                item_temp.Text = maskedTextBox1.Text;

                item_temp.SubItems.Add(maskedTextBox2.Text);
                item_temp.SubItems.Add(maskedTextBox3.Text);

                listView1.Items.Add(item_temp);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lv in listView1.SelectedItems)
            {
                listView1.Items.Remove(lv);
            }
        }

        private void ListView_ColumnClick(object sender, ColumnClickEventArgs e)

        {
            if (listView1.Sorting == SortOrder.Ascending)
            {
                listView1.Sorting = SortOrder.Descending;
            }
            else
            {
                listView1.Sorting = SortOrder.Ascending;
            }
            listView1.ListViewItemSorter = new listsort.Sorter();
            listsort.Sorter s = (listsort.Sorter)listView1.ListViewItemSorter;
            s.Order = listView1.Sorting;
            s.Column = e.Column;
            listView1.Sort();
        }

        /*class Sorter : System.Collections.IComparer
        {
            public int Column = 0;
            public System.Windows.Forms.SortOrder Order = SortOrder.Ascending;
            public int Compare(object x, object y)
            {
                if (!(x is ListViewItem))
                    return (0);
                if (!(y is ListViewItem))
                    return (0);

                ListViewItem l1 = (ListViewItem)x;
                ListViewItem l2 = (ListViewItem)y;

                if (l1.ListView.Columns[Column].Tag == null)
                {
                    l1.ListView.Columns[Column].Tag = "Text";
                }
                if (l2.ListView.Columns[Column].Tag.ToString() == "Numeric")
                {
                    string str1 = l1.SubItems[Column].Text;
                    string str2 = l2.SubItems[Column].Text;

                    if (str1 == "")
                    {

                        str1 = "99999";
                    }

                    if (str2 == "")
                    {
                        str2 = "99999";
                    }

                    float fl1 = float.Parse(str1);
                    float fl2 = float.Parse(str2);

                    if (Order == SortOrder.Ascending)
                    {
                        return fl1.CompareTo(fl2);
                    }

                    else
                    {
                        return fl2.CompareTo(fl1);
                    }
                }
                else
                {
                    string str1 = l1.SubItems[Column].Text;
                    string str2 = l2.SubItems[Column].Text;

                    if (Order == SortOrder.Ascending)
                    {
                        return str1.CompareTo(str2);
                    }
                    else
                    {
                        return str2.CompareTo(str1);
                    }

                }
            }
        }
    }*/

    }
}

