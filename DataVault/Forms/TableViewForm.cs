using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DataVault.DataModels;
using EFWinforms;

namespace DataVault
{
    public partial class TableViewForm : Form
    {
        private readonly string tableName;
        private readonly MainForm parent;

        private bool Changed
        {
            set
            {
                var status = !value ? "Saved" : "Modified";
                Text = $"Table: {tableName} - [{status}]";
            }
        }

        public TableViewForm(string tableName, MainForm parent)
        {
            this.tableName = tableName;
            this.parent = parent;
            InitializeComponent();
            
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataMember = tableName;
            dataGridView1.Columns[0].ReadOnly = true; // id column

            Changed = false;
        }

        private void ReloadRecords()
        {
            entityDataSource1.Refresh();
            Changed = false;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            ReloadRecords();
            dataGridView1.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                entityDataSource1.SaveChanges();
                Changed = false;
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = GetErrorMessages(ex);
                MessageBox.Show(this, "Возникли следующие ошибки:\n" + string.Join("\n", errorMessages),
                    "Не удалось сохранить данные", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Извлекает список сообщений об ошибках валидации из исключения
        /// </summary>
        private static IEnumerable<string> GetErrorMessages(DbEntityValidationException ex)
        {
            return ex.EntityValidationErrors.SelectMany(
                    valResult => valResult.ValidationErrors,
                    (v, e) => e.PropertyName + ": " + e.ErrorMessage)
                .ToList();
        }
        
        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(this, e.Exception.Message, "Указано некорректное значение", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            entityDataSource1.CancelChanges();
            this.Close();
        }

        private void TableViewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Show();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Changed = true;
        }
    }
}