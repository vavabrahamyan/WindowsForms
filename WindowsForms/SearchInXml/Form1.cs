using System;
using System.Windows.Forms;
using System.Xml;

namespace SearchInXml
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (SearchBox.Text != null && SearchBox.Text.Length > 3)
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load("student.xml");

                foreach (XmlNode node in xDoc.DocumentElement)
                {
                    foreach (XmlNode child in node.ChildNodes)
                    {
                        if (child.Name.ToUpper() == "name".ToUpper() && child.InnerText.ToUpper() == SearchBox.Text.ToUpper())
                        {
                            listView.Items.Add(node.InnerText);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Pa-Bam. It's not correctly input!!");
                SearchBox.Text = string.Empty;
                SearchBox.Focus();
            }
        }
    }
}
