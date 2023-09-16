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


        private void ComboboxLoad()
        {
            StreamReader sr = new StreamReader("combodata.txt");
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                CategoryCombobox.Items.Add(line);
            }
            sr.Close();  
        }



        // 6.3 Create a button method to Add a new item to the list

        private void AddBtn_Click(object sender, EventArgs e)
        {
            // Name Textbox
            NameTextbox.Text = "";
            // Combobox Category
            // Radio group Structure

            // Multiline Definition
            DefinitionTextbox.Text = "";
        }

        private void StructureGroupbox_Enter(object sender, EventArgs e)
        {

        }
    }

}