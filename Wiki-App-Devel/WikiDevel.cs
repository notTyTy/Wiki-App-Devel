using System;
using System.Globalization;

namespace Wiki_App_Devel
{
    public partial class WikiDevel : Form
    {
        readonly List<Information> wiki = new(); // 6.2 Create a global List<T> of type Information called wiki
        public WikiDevel()
        {
            InitializeComponent();
        }
        private void WikiDevel_Load(object sender, EventArgs e) // Form Load
        {
            ComboboxLoad(); // Adds txt data to the application
        }
        private void ComboboxLoad() // 6.4 Create a custom method to populate the Combobox when the Form Load Method is called
        {
            using StreamReader sr = new("combodata.txt"); // The six categories must be read from a simple text file
            string? category;
            while ((category = sr.ReadLine()) != null)
            {
                CategoryCombobox.Items.Add(category);
            }
        }
        private void AddBtn_Click(object sender, EventArgs e) // 6.3 Create a button to add a new item to the list
        {
            if (ValidName()) // Checks for duplicate names
            {
                MessageBox.Show("This name already exists!", "Duplicate Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (string.IsNullOrEmpty(NameTextbox.Text)
                | CategoryCombobox.SelectedIndex < 1
                | string.IsNullOrEmpty(DefinitionTextbox.Text)
                | (LinearRadio.Checked == false && NonLinearRadio.Checked == false))
            {
                MessageBox.Show("Please ensure all fields are filled!", "Incomplete Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Information information = new();
                information.SetName(NameTextbox.Text.ToLower());
                information.SetStructure(GetRadio());
                information.SetCategory(CategoryCombobox.Text);
                information.SetDefinition(DefinitionTextbox.Text);
                wiki.Add(information);
                ListRefresh();
                NameTextbox.Select(); // Automatically reselects the Name Textbox for new data to be added 
            }
        }
        private void ListRefresh() // A method to clear the listview, and update it with new values where necessary (i.e., add, edit, delete, sort)
        {
            InformationListView.Items.Clear(); // Clears the listview on each new addition
            Sort();
            ClearBoxes(); // Resets currently filled fields
        }
        private void Sort() // 6.9 Create a single custom method that will sort and display Name and Category into listview
        {
            wiki.Sort();

            for (int i = 0; i < wiki.Count; i++) // Loops through the list and adds the relevant items to the name and category fields in the listView
            {
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                ListViewItem item = new(textInfo.ToTitleCase(wiki[i].GetName()));
                item.SubItems.Add(wiki[i].GetCategory());
                InformationListView.Items.Add(item); // Adds name and category to the listview
            }
        }
        private bool ValidName() // 6.5 Create a custom ValidName method that takes parameter string from NameTextbox and returns a bool
        {
            return wiki.Exists(x => x.GetName() == NameTextbox.Text.ToLower());  // Use the built in List<T> method “Exists”
        }
        private void NameTextbox_DoubleClick(object sender, EventArgs e) // 6.13 Create a double click event on the Name TextBox to clear the Textboxes, ComboBox and Radio button.
        {
            ClearBoxes();
        }
        private void ClearBoxes() // 6.12 Create a custom method that will clear and reset the TextBoxes, ComboBox and Radio button
        {
            NameTextbox.Clear();
            CategoryCombobox.SelectedIndex = 0;
            DefinitionTextbox.Clear();
            LinearRadio.Checked = false;
            NonLinearRadio.Checked = false;
            InformationListView.SelectedItems.Clear();
        }
        private void DisplayData() // 6.11 Have data from the listview output to the desired textboxes
        {
            ListViewItem? selectedItem = InformationListView.SelectedItems.Count > 0 ? InformationListView.SelectedItems[0] : null;
            if (selectedItem != null)
            {
                int index = InformationListView.SelectedIndices[0];
                var output = wiki[index];
                DataOutput(output.GetName(), index, output.GetCategory(), output.GetDefinition());
            }
        }
        private void InformationListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayData();
        }
        private void DeleteBtn_Click(object sender, EventArgs e) // 6.7 Create a button that will delete the currently selected record from the listview
        {
            if (InformationListView.SelectedItems.Count > 0)
            {
                DialogResult confirmation = MessageBox.Show("Are you sure you want to delete this", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmation == DialogResult.Yes)
                {
                    wiki.RemoveAt(InformationListView.SelectedIndices[0]);
                    ListRefresh(); // Display an updated version of the sorted list at the end of this process.
                }
                else
                {
                    return; // Ensure the user has the option to backout of this action by using a dialog box
                }
            }
            else
                MessageBox.Show("Please select a value in the listview before attempting to delete", "Delete error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void EditBtn_Click(object sender, EventArgs e) // 6.8 Create a button method that will save the edited record of the currently selected item in the ListView
        {
            if (InformationListView.SelectedItems.Count > 0)
            {
                bool nameExists = (wiki[InformationListView.SelectedIndices[0]].GetName() == NameTextbox.Text.ToLower());
                if (string.IsNullOrWhiteSpace(NameTextbox.Text)
                    | (LinearRadio.Checked == false && NonLinearRadio.Checked == false)
                    | CategoryCombobox.SelectedIndex < 1
                    | string.IsNullOrWhiteSpace(DefinitionTextbox.Text))
                {
                    MessageBox.Show("Please fill in all fields before attempting to edit", "Edit Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (nameExists | !ValidName()) // Checks for instances of the name existing on edit AND add 
                {
                    var index = wiki[InformationListView.SelectedIndices[0]];
                    index.SetName(NameTextbox.Text.ToLower());
                    index.SetStructure(GetRadio());
                    index.SetCategory(CategoryCombobox.Text);
                    index.SetDefinition(DefinitionTextbox.Text);
                    ListRefresh(); // Display an updated version of the sorted list at the end of this process.
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
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            SaveFile("definitions.bin");
        } // 6.14 A button to save data, using a binary reader format
        private void WikiDevel_FormClosing(object sender, FormClosingEventArgs e) // 6.15 The Wiki application will save data when the form closes 
        {
            SaveFile("recovery.bin"); // The application prompts the user the save the file as "recovery.bin"
        }
        private void SaveFile(string defaultName) // The method both 6.14 and 6.15 reference. defaultName is used so the methods 6.14/6.15 have can use seperate file names.  i.e., definitons.bin and recovery.bin
        {
            using SaveFileDialog saveFile = new();
            saveFile.Filter = "bin files (*.bin)|*.bin";
            saveFile.FileName = defaultName;
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using FileStream fs = new(saveFile.FileName, FileMode.Create, FileAccess.Write);
                    using BinaryWriter bw = new(fs);
                    foreach (var item in wiki)
                    {
                        bw.Write(item.GetName());
                        bw.Write(item.GetStructure());
                        bw.Write(item.GetCategory());
                        bw.Write(item.GetDefinition());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error has occured: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
        private void LoadBtn_Click(object sender, EventArgs e) // 6.14 A button to load data, using a binary reader format
        {
            using OpenFileDialog openFile = new();
            openFile.Filter = "bin files (*.bin)|*.bin";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using FileStream fs = new(openFile.FileName, FileMode.Open, FileAccess.Read);
                    using BinaryReader br = new(fs);
                    wiki.Clear();

                    while (fs.Position < fs.Length)
                    {
                        Information loadData = new();

                        loadData.SetName(br.ReadString());
                        loadData.SetStructure(br.ReadString());
                        loadData.SetCategory(br.ReadString());
                        loadData.SetDefinition(br.ReadString());
                        wiki.Add(loadData);
                    }
                    ListRefresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error has occured: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
        private void SearchBtn_Click(object sender, EventArgs e) // 6.10 Use built in binary search to find Information(nameSearch)
        {
            Information searchName = new();
            searchName.SetName(SearchTextbox.Text.ToLower());
            int index = wiki.BinarySearch(searchName);
            if (InformationListView.Items.Count < 1)
            {
                MessageBox.Show("Add data to the array before searching!", "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (index < 0)
            {
                MessageBox.Show("The searched value could not be found", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                InformationListView.Items[0].Selected = false; // On failed search deselects the previously searched value from the listview
                ClearBoxes(); // Resets the outputted data in the text fields on a failed search
            }
            else
            {
                DataOutput(wiki[index].GetName(), index, wiki[index].GetCategory(), wiki[index].GetDefinition()); // Populate the appropriate input controls
                InformationListView.Items[index].Selected = true; // 6.10 Highlight the appropriate data in the listview
            }
            SearchTextbox.Clear(); // SearchTextbox is cleared
            SearchTextbox.Focus(); // Search Textbox remains focus
        }
        private void DataOutput(string nameTextbox, int radioGroupbox, string categoryCombobox, string definitionTextbox) // A method that will take the parameters for output and display the desired data
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo; //  In order to output name as Titlecase -- It is forced lowercase for search as all uppercase search won't query as titlecase
            NameTextbox.Text = textInfo.ToTitleCase(nameTextbox);
            SetRadio(radioGroupbox);
            CategoryCombobox.Text = categoryCombobox;
            DefinitionTextbox.Text = definitionTextbox;
        }
        // 6.6 First method must return a string value from the selected radio button
        private string GetRadio()
        {
            foreach (RadioButton radioButton in StructureGroupbox.Controls)
            {
                if (radioButton.Checked)
                {
                    return radioButton.Text;
                }
            }
            return ""; // Not Possible due to add method error handling
        }
        // 6.6 Second method must send an integer index which will highlight the appropriate radio button
        private void SetRadio(int index)
        {
            foreach (RadioButton radioButton in StructureGroupbox.Controls)
            {
                if (radioButton.Text == wiki[index].GetStructure())
                {
                    radioButton.Checked = true;
                }
            }
        }
    }
}