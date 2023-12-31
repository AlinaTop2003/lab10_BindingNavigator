﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace пр10
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        ModelEF.ModelEF model = new ModelEF.ModelEF();
        private void StartLoadData()
        {
            model.Users.Load();
            role_NameComboBox.DataSource = model.Roles.ToList();
            usersBindingSource.DataSource = model.Users.Local.ToBindingList();
        }

        private void SaveData()
        {
            try
            {
                Validate();
                usersBindingSource.EndEdit();
                usersBindingSource.ResetBindings(true);
                model.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                StartLoadData();
            }
        }
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            role_NameComboBox.SelectedIndex = 0;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void usersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            StartLoadData();
        }
    }
}
