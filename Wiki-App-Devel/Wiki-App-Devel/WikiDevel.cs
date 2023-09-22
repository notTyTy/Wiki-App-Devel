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
            string? category = "";
            while ((category = sr.ReadLine()) != null)
            {
                CategoryCombobox.Items.Add(category);
            }
            sr.Close();
        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (ValidName())
            {
                MessageBox.Show("This name already exists!", "Duplicate Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (string.IsNullOrEmpty(NameTextbox.Text))
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
                wiki.Add(new Information(NameTextbox.Text, "Structure", CategoryCombobox.Text, DefinitionTextbox.Text)); //Name, Category, Structure, Definition
                ListRefresh();
            }
        }
        private void ListRefresh() // A method to clear the listview, and update it with new values where necessary (i.e., add, edit, delete, sort.
        {
            InformationListView.Items.Clear(); // Clears the listview on each new addition
            // Resets currently filled fields
            ClearBoxes();
            Sort();
        }
        private void Sort()
        {
            wiki.Sort();
            for (int i = 0; i < wiki.Count; i++) // Loops through the list and adds the relevant items to the name and category fields in the listView
            {
                ListViewItem item = new(wiki[i].GetName());
                item.SubItems.Add(wiki[i].GetCategory());
                InformationListView.Items.Add(item); // Adds name and category to the listview
            }
        }
        private bool ValidName() // 6.5 Create a custom ValidName method that takes parameter string from NameTextbox and returns a bool
        {
            bool nameExists = wiki.Exists(x => x.GetName() == NameTextbox.Text);
            return nameExists;
        }
        private void NameTextbox_DoubleClick(object sender, EventArgs e)
        {
            ClearBoxes();
        }
        private void ClearBoxes()
        {
            NameTextbox.Clear();
            CategoryCombobox.SelectedIndex = 0;
            // Struct
            DefinitionTextbox.Clear();
        }
        private void DisplayData() // 6.11 Have data from the listview output to the desired textboxes
        {
            ListViewItem? selectedItem = InformationListView.SelectedItems.Count > 0 ? InformationListView.SelectedItems[0] : null;
            if (selectedItem != null)
            {
                NameTextbox.Text = wiki[InformationListView.SelectedIndices[0]].GetName();
                CategoryCombobox.Text = wiki[InformationListView.SelectedIndices[0]].GetCategory();
                DefinitionTextbox.Text = wiki[InformationListView.SelectedIndices[0]].GetDefinition();
            }
        }
        private void InformationListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayData();
        }
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (InformationListView.SelectedItems.Count > 0)
            {
                DialogResult confirmation = MessageBox.Show("Are you sure you want to delete this", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmation == DialogResult.Yes)
                {
                    if (InformationListView.Items.Count > 0)
                    {
                        wiki.RemoveAt(InformationListView.SelectedIndices[0]);
                        ListRefresh();
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please select a value in the listview before attempting to delete", "Delete error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (InformationListView.SelectedItems.Count > 0)
            {
                bool nameExists = (wiki[InformationListView.SelectedIndices[0]].GetName() == NameTextbox.Text);
                if (NameTextbox.Text == "" | CategoryCombobox.SelectedIndex < 1 | DefinitionTextbox.Text == "")
                {
                    MessageBox.Show("Please fill in all fields before attempting to edit", "Edit Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (nameExists | !ValidName())
                {
                    int index = InformationListView.SelectedIndices[0];
                    wiki[index].GetName(NameTextbox.Text);
                    wiki[index].GetStructure("Structure");
                    wiki[index].GetCategory(CategoryCombobox.Text);
                    wiki[index].GetDefinition(DefinitionTextbox.Text);
                    ListRefresh();
                }
                else
                {
                    MessageBox.Show("This value already exists", "Edit Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Please select a value from the listview before trying to edit it", "Edit Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}