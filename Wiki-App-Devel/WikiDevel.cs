using System;
using System.IO;
using System.Text;

namespace Wiki_App_Devel
{
    public partial class WikiDevel : Form
    {
        // 6.2 Create a global List<T> of type Information called wiki
        List<Information> wiki = new List<Information>();
        public WikiDevel()
        {
            InitializeComponent();
            ComboboxLoad();
        }
        // 6.4 Create a custom method to populate the Combobox when the Form Load Method is called
        private void ComboboxLoad()
        {
            // The six categories must be read from a simple text file
            StreamReader sr = new StreamReader("combodata.txt");
            string category = "";
            while ((category = sr.ReadLine()) != null)
            {
                CategoryCombobox.Items.Add(category);
            }
            sr.Close();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            int index = 0; //This index is an empty string, done to keep the program looking clean.
            if (string.IsNullOrEmpty(NameTextbox.Text))
            {
                MessageBox.Show("Please input a name", "Empty Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (CategoryCombobox.SelectedIndex < 1)
            {
                MessageBox.Show("Please select a category", "Empty Category", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (string.IsNullOrEmpty(DefinitionTextbox.Text))
            {
                MessageBox.Show("Please input a definition", "Empty Definition", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            // else if for radio buttons.

            else
            {
                index = CategoryCombobox.SelectedIndex; // Gets the item index in the Combobox
                string? comboboxValue = CategoryCombobox.Items[index].ToString(); // Outputs the string value at the chosen index

                wiki.Add(new Information(NameTextbox.Text, "Structure", comboboxValue, DefinitionTextbox.Text)); //Name, Category, Structure, Definition
                ListRefresh();
                Sort();
            }
        }
        private void ListRefresh() // A method to clear the listview, and update it with new values where necessary (i.e., add, edit, delete, sort.
        {
            InformationListView.Items.Clear(); // Clears the listview on each new addition
            // Resets currently filled fields
            NameTextbox.Clear();
            CategoryCombobox.SelectedIndex = 0;
            DefinitionTextbox.Clear();
        }
        private void Sort()
        {
            wiki.Sort(delegate (Information x, Information y) // Sorts through the data and swaps
                {
                    return x.GetName().CompareTo(y.GetName());
                });
            for (int i = 0; i < wiki.Count; i++) // Loops through the list and adds the relevant items to the name and category fields in the listView
            {
                ListViewItem item = new(wiki[i].GetName());
                item.SubItems.Add(wiki[i].GetCategory());
                InformationListView.Items.Add(item); // Adds name and category to the listview
            }
        }
        private void DisplayData() // A method to output the data to the required boxes
        {
             
        }
    }
}