﻿namespace Wiki_App_Devel
{
    partial class WikiDevel
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            AddBtn = new Button();
            EditBtn = new Button();
            DeleteBtn = new Button();
            SearchTextbox = new TextBox();
            SearchBtn = new Button();
            NameTextbox = new TextBox();
            DefinitionTextbox = new TextBox();
            StructureGroupbox = new GroupBox();
            radioButton1 = new RadioButton();
            CategoryCombobox = new ComboBox();
            SaveBtn = new Button();
            InformationListView = new ListView();
            NameColumn = new ColumnHeader();
            CategoryColumn = new ColumnHeader();
            StatusStrip = new StatusStrip();
            LoadBtn = new Button();
            NameLabel = new Label();
            CategoryLabel = new Label();
            DefinitonLabel = new Label();
            radioButton2 = new RadioButton();
            StructureGroupbox.SuspendLayout();
            SuspendLayout();
            // 
            // AddBtn
            // 
            AddBtn.Location = new Point(30, 23);
            AddBtn.Name = "AddBtn";
            AddBtn.Size = new Size(84, 23);
            AddBtn.TabIndex = 0;
            AddBtn.Text = "Add";
            AddBtn.UseVisualStyleBackColor = true;
            AddBtn.Click += AddBtn_Click;
            // 
            // EditBtn
            // 
            EditBtn.Location = new Point(128, 23);
            EditBtn.Name = "EditBtn";
            EditBtn.Size = new Size(84, 23);
            EditBtn.TabIndex = 1;
            EditBtn.Text = "Edit";
            EditBtn.UseVisualStyleBackColor = true;
            // 
            // DeleteBtn
            // 
            DeleteBtn.Location = new Point(224, 23);
            DeleteBtn.Name = "DeleteBtn";
            DeleteBtn.Size = new Size(84, 23);
            DeleteBtn.TabIndex = 2;
            DeleteBtn.Text = "Delete";
            DeleteBtn.UseVisualStyleBackColor = true;
            // 
            // SearchTextbox
            // 
            SearchTextbox.Location = new Point(327, 22);
            SearchTextbox.Name = "SearchTextbox";
            SearchTextbox.Size = new Size(208, 23);
            SearchTextbox.TabIndex = 3;
            // 
            // SearchBtn
            // 
            SearchBtn.Location = new Point(541, 22);
            SearchBtn.Name = "SearchBtn";
            SearchBtn.Size = new Size(84, 23);
            SearchBtn.TabIndex = 4;
            SearchBtn.Text = "Search";
            SearchBtn.UseVisualStyleBackColor = true;
            // 
            // NameTextbox
            // 
            NameTextbox.Location = new Point(83, 52);
            NameTextbox.Name = "NameTextbox";
            NameTextbox.Size = new Size(225, 23);
            NameTextbox.TabIndex = 5;
            // 
            // DefinitionTextbox
            // 
            DefinitionTextbox.Location = new Point(22, 185);
            DefinitionTextbox.Multiline = true;
            DefinitionTextbox.Name = "DefinitionTextbox";
            DefinitionTextbox.Size = new Size(286, 156);
            DefinitionTextbox.TabIndex = 6;
            // 
            // StructureGroupbox
            // 
            StructureGroupbox.Controls.Add(radioButton1);
            StructureGroupbox.Location = new Point(22, 81);
            StructureGroupbox.Name = "StructureGroupbox";
            StructureGroupbox.Size = new Size(105, 78);
            StructureGroupbox.TabIndex = 7;
            StructureGroupbox.TabStop = false;
            StructureGroupbox.Text = "Structure";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(8, 22);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(57, 19);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "Linear";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // CategoryCombobox
            // 
            CategoryCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            CategoryCombobox.FormattingEnabled = true;
            CategoryCombobox.Location = new Point(133, 101);
            CategoryCombobox.Name = "CategoryCombobox";
            CategoryCombobox.Size = new Size(175, 23);
            CategoryCombobox.TabIndex = 8;
            // 
            // SaveBtn
            // 
            SaveBtn.Location = new Point(134, 349);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(84, 23);
            SaveBtn.TabIndex = 9;
            SaveBtn.Text = "Save";
            SaveBtn.UseVisualStyleBackColor = true;
            // 
            // InformationListView
            // 
            InformationListView.Columns.AddRange(new ColumnHeader[] { NameColumn, CategoryColumn });
            InformationListView.Location = new Point(327, 55);
            InformationListView.Name = "InformationListView";
            InformationListView.Size = new Size(298, 317);
            InformationListView.TabIndex = 10;
            InformationListView.UseCompatibleStateImageBehavior = false;
            InformationListView.View = View.Details;
            // 
            // NameColumn
            // 
            NameColumn.Text = "Name";
            NameColumn.Width = 161;
            // 
            // CategoryColumn
            // 
            CategoryColumn.Text = "Category";
            CategoryColumn.Width = 136;
            // 
            // StatusStrip
            // 
            StatusStrip.Location = new Point(0, 397);
            StatusStrip.Name = "StatusStrip";
            StatusStrip.Size = new Size(636, 22);
            StatusStrip.TabIndex = 11;
            StatusStrip.Text = "StatusStrip";
            // 
            // LoadBtn
            // 
            LoadBtn.Location = new Point(224, 349);
            LoadBtn.Name = "LoadBtn";
            LoadBtn.Size = new Size(84, 23);
            LoadBtn.TabIndex = 12;
            LoadBtn.Text = "Load";
            LoadBtn.UseVisualStyleBackColor = true;
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Location = new Point(30, 55);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(42, 15);
            NameLabel.TabIndex = 13;
            NameLabel.Text = "Name ";
            // 
            // CategoryLabel
            // 
            CategoryLabel.AutoSize = true;
            CategoryLabel.Location = new Point(133, 81);
            CategoryLabel.Name = "CategoryLabel";
            CategoryLabel.Size = new Size(55, 15);
            CategoryLabel.TabIndex = 14;
            CategoryLabel.Text = "Category";
            // 
            // DefinitonLabel
            // 
            DefinitonLabel.AutoSize = true;
            DefinitonLabel.Location = new Point(22, 167);
            DefinitonLabel.Name = "DefinitonLabel";
            DefinitonLabel.Size = new Size(59, 15);
            DefinitonLabel.TabIndex = 15;
            DefinitonLabel.Text = "Definition";
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(30, 128);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(85, 19);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "Non-Linear";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // WikiDevel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(636, 419);
            Controls.Add(radioButton2);
            Controls.Add(DefinitonLabel);
            Controls.Add(CategoryLabel);
            Controls.Add(NameLabel);
            Controls.Add(LoadBtn);
            Controls.Add(StatusStrip);
            Controls.Add(InformationListView);
            Controls.Add(SaveBtn);
            Controls.Add(CategoryCombobox);
            Controls.Add(StructureGroupbox);
            Controls.Add(DefinitionTextbox);
            Controls.Add(NameTextbox);
            Controls.Add(SearchBtn);
            Controls.Add(SearchTextbox);
            Controls.Add(DeleteBtn);
            Controls.Add(EditBtn);
            Controls.Add(AddBtn);
            Name = "WikiDevel";
            Text = "Wiki App";
            StructureGroupbox.ResumeLayout(false);
            StructureGroupbox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AddBtn;
        private Button EditBtn;
        private Button DeleteBtn;
        private TextBox SearchTextbox;
        private Button SearchBtn;
        private TextBox NameTextbox;
        private TextBox DefinitionTextbox;
        private GroupBox StructureGroupbox;
        private ComboBox CategoryCombobox;
        private Button SaveBtn;
        private ListView InformationListView;
        private StatusStrip StatusStrip;
        private Button LoadBtn;
        private Label NameLabel;
        private Label CategoryLabel;
        private Label DefinitonLabel;
        private ColumnHeader NameColumn;
        private ColumnHeader CategoryColumn;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
    }
}