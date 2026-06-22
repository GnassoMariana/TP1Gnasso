using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP1Gnasso.Entities;
using TP1Gnasso.Service.Common;
using TP1Gnasso.Service.DTOs.SportShoe;
using TP1Gnasso.Service.Interfaces;
using TP1Gnasso.Service.Services;
using TP1Gnasso.WForms.Helpers;

namespace TP1Gnasso.WForms
{
    public partial class frmSportShoesMenu : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private List<SportShoeListDto> sportShoesList;
        private bool activeFilter = false;
        public frmSportShoesMenu(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            using(var scope= _serviceProvider.CreateScope())
            {
                using(SportShoesAE frm = scope.ServiceProvider.GetRequiredService<SportShoesAE>())
                {
                    frm.Text = "New Sport Shoe";
                    frm.ShowDialog();
                    if(frm.DataChanged)
                    {
                        LoadGrid();
                    }
                }
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a sport shoe to update.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            var selectedRow = dataGridView1.SelectedRows[0];
            if (selectedRow.Tag is null) return;
            var sportShoeListDto = (SportShoeListDto)selectedRow.Tag;

            using(var scope = _serviceProvider.CreateScope())
            {
                try
                {
                    var sportShoeService = scope.ServiceProvider.GetRequiredService<ISportShoeService>();
                    var queryResult = sportShoeService.GetForUpdate(sportShoeListDto.SportShoeId);

                    if(queryResult.IsFailure)
                    {
                        ErrorHelper.ShowErrors(queryResult.Errors);
                        return;
                    }

                    var sportShoeUpdateDto = queryResult.Value;
                    using (SportShoesAE frm = scope.ServiceProvider.GetRequiredService<SportShoesAE>())
                    {
                        frm.Text = "Update Sport Shoe:";
                        frm.SetSportShoe(sportShoeUpdateDto);
                        frm.ShowDialog();

                        if (frm.ConcurrencyConflict)
                        {
                            LoadGrid();
                        }
                        if (frm.DataChanged)
                        {
                            LoadGrid();
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

              
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a sport shoe to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var selectedRow = dataGridView1.SelectedRows[0];
            if (selectedRow.Tag is null) return;
            SportShoeListDto sportShoelistDto =(SportShoeListDto)selectedRow.Tag;
            using(var scope= _serviceProvider.CreateScope())
            {
                var sportShoeService = scope.ServiceProvider.GetRequiredService<ISportShoeService>();
                var resultQuery = sportShoeService.GetToDelete(sportShoelistDto.SportShoeId);
                if (resultQuery.IsFailure)
                {
                    string errors = string.Join("\n", resultQuery.Errors);
                    //MessageBox.Show(errors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                var sportShoeDeleteDto = resultQuery.Value;
                var dr = MessageBox.Show($"Are you sure you want to delete {sportShoelistDto.Model} ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No) return;

                try
                {
                    var deleteResult = sportShoeService.Delete(sportShoeDeleteDto!);
                    if (deleteResult.IsConcurrencyConflict)
                    {
                        //string errors = string.Join("\n", resultQuery.Errors);
                        //MessageBox.Show(errors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ErrorHelper.ShowErrors(deleteResult.Errors);
                        LoadGrid();
                        return;

                    }
                    if (deleteResult.IsFailure)
                    {
                        ErrorHelper.ShowErrors(deleteResult.Errors);
                        return;

                    }
                    MessageBox.Show("Record deleted");
                    LoadGrid();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }


        }
        
        

        private void filterButton_Click(object sender, EventArgs e)
        {

        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            LoadGrid();
            ManejarControles(false);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmSportShoesMenu_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void LoadGrid()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var sportShoeService = scope.ServiceProvider.GetRequiredService<ISportShoeService>();
                try
                {
                    var result = sportShoeService.GetAll();
                    if (result.IsFailure)
                    {
                        string errors = string.Join("\n", result.Errors);
                        MessageBox.Show(errors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    sportShoesList = result.Value!;
                    ShowRecordsOnGrid(sportShoesList);
                }

                catch (Exception ex)
                {

                    throw;
                }
            }
        }

        private void ShowRecordsOnGrid(List<SportShoeListDto> sportShoesList)
        {
            GridHelper.LimpiarGrilla(dataGridView1);
            if (sportShoesList is null || sportShoesList.Count == 0) return;

            foreach (var ss in sportShoesList)
            {
                var r = GridHelper.ConstruirFila(dataGridView1);
                GridHelper.SetearFila(r, ss);
                GridHelper.AgregarFila(r, dataGridView1);
            }
            cantidadLabel.Text = sportShoesList.Count.ToString();
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void activeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var sportShoeService = scope.ServiceProvider.GetRequiredService<ISportShoeService>();
                try
                {
                    var result = sportShoeService.FilterByActive(true);
                    if (result.IsFailure)
                    {
                        string errors = string.Join("\n", result.Errors);
                        MessageBox.Show(errors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    sportShoesList = result.Value!;
                    ShowRecordsOnGrid(sportShoesList);
                    ManejarControles(true);
                }

                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void ManejarControles(bool v)
        {
            activeFilter = v;
            tsbActive.BackColor = activeFilter ? Color.Red : SystemColors.Control;

            addButton.Enabled = !v;
            updateButton.Enabled = !v;
            deleteButton.Enabled = !v;


        }

        private void inactiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var sportShoeService = scope.ServiceProvider.GetRequiredService<ISportShoeService>();
                try
                {
                    var result = sportShoeService.FilterByActive(false);
                    if (result.IsFailure)
                    {
                        string errors = string.Join("\n", result.Errors);
                        MessageBox.Show(errors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    sportShoesList = result.Value!;
                    ShowRecordsOnGrid(sportShoesList);
                    ManejarControles(true);
                }

                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }
    }
}
