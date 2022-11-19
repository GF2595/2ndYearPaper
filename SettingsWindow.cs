using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class SettingsWindow : Form
    {
        Action<List<List<string>>> save;
        Dictionary<string, List<string>> types;
        string previouslySelectedType = "";

        public SettingsWindow(List<List<string>> typeSpecs, Action<List<List<string>>> sav)
        {
            InitializeComponent();
            types = new Dictionary<string, List<string>>();

            save = sav;

            foreach(List<string> type in typeSpecs)
            {
                typesListBox.Items.Add(type[0]);
                List<string> temp = new List<string>();

                for (int i = 1; i < type.Count; i++)
                {
                    temp.Add(type[i]);
                }

                types.Add(type[0], temp);
            }
        }

        private void savetypeButton_Click(object sender, EventArgs e)
        {
            if (typeTextBox.Text != "")
            {
                if (typesListBox.SelectedIndex > -1)
                {
                    List<string> temp;
                    types.TryGetValue(typesListBox.SelectedItem.ToString(), out temp);
                    types.Remove(typesListBox.SelectedItem.ToString());
                    types.Add(typeTextBox.Text, temp);
                    typesListBox.Items[typesListBox.SelectedIndex] = typeTextBox.Text;
                }
                else
                {
                    typesListBox.Items.Add(typeTextBox.Text);
                    types.Add(typeTextBox.Text, new List<string>());
                }
            }
        }

        private void SettingsWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            List<List<string>> typeSpecs = new List<List<string>>();

            foreach (string type in types.Keys)
            {
                List<string> typeSpecTemp = new List<string>();
                typeSpecTemp.Add(type);

                List<string> temp = new List<string>();
                types.TryGetValue(type, out temp);

                foreach (string spec in temp)
                    typeSpecTemp.Add(spec);

                typeSpecs.Add(typeSpecTemp);
            }

            SettingsLoader.SaveSettings(typeSpecs);
        }

        private void deleteTypeButton_Click(object sender, EventArgs e)
        {
            typeTextBox.Text = "";

            if (typesListBox.SelectedIndex > -1)
            {
                specsListBox.Items.Clear();
                types.Remove(typesListBox.SelectedItem.ToString());
                typesListBox.Items.Remove(typesListBox.SelectedItem);
            }
        }

        private void typeCancelButton_Click(object sender, EventArgs e)
        {
            typeTextBox.Text = "";

            if (typesListBox.SelectedIndex > -1)
            {
                typesListBox.SetSelected(typesListBox.SelectedIndex, false);
                specsListBox.Items.Clear();
                specsPanel.Enabled = false;
            }
        }

        private void saveSpecButton_Click(object sender, EventArgs e)
        {
            if (specTextBox.Text != "")
            {
                if (specsListBox.SelectedIndex > -1)
                {

                    specsListBox.Items.Add(specTextBox.Text);
                    List<string> temp;
                    types.TryGetValue(typesListBox.SelectedItem.ToString(), out temp);
                    temp.Add(specTextBox.Text);
                    types.Remove(typesListBox.SelectedItem.ToString());
                    types.Add(typesListBox.SelectedItem.ToString(), temp);
                }
                else
                {
                    specsListBox.Items.Add(specTextBox.Text);
                    List<string> temp;
                    types.TryGetValue(typesListBox.SelectedItem.ToString(), out temp);
                    temp.Add(specTextBox.Text);
                    types.Remove(typesListBox.SelectedItem.ToString());
                    types.Add(typesListBox.SelectedItem.ToString(), temp);
                }
            }
        }

        private void typesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (typesListBox.SelectedIndex > -1)
            {
                specsListBox.Items.Clear();
                List<string> temp;
                types.TryGetValue(typesListBox.SelectedItem.ToString(), out temp);
                specsPanel.Enabled = true;

                foreach (string str in temp)
                    specsListBox.Items.Add(str);
            }
        }

        private void deleteSpecButton_Click(object sender, EventArgs e)
        {
            specTextBox.Text = "";

            if (specsListBox.SelectedIndex > -1)
            {
                List<string> temp;
                types.TryGetValue(typesListBox.SelectedItem.ToString(), out temp);
                temp.Remove(specsListBox.SelectedItem.ToString());
                types.Remove(typesListBox.SelectedItem.ToString());
                types.Add(typesListBox.SelectedItem.ToString(), temp);

                specsListBox.Items.Remove(specsListBox.SelectedItem);
            }
        }

        private void specCancelButton_Click(object sender, EventArgs e)
        {
            specTextBox.Text = "";
            specsListBox.SetSelected(specsListBox.SelectedIndex, false);
        }
    }
}
