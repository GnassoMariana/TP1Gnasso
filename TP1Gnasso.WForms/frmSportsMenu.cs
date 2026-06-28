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
using TP1Gnasso.Service.DTOs.Brand;
using TP1Gnasso.Service.DTOs.Sport;
using TP1Gnasso.Service.Interfaces;
using TP1Gnasso.WForms.Helpers;

namespace TP1Gnasso.WForms
{
    public partial class frmSportsMenu : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private List<SportListDto> sportsList;
        private bool activeFilter = false;

        public frmSportsMenu(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void frmSportsMenu_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void LoadGrid()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var sportService = scope.ServiceProvider.GetRequiredService<ISportService>();
                try
                {
                    var result = sportService.GetAll();
                    if (result.IsFailure)
                    {
                        string errors = string.Join("\n", result.Errors);
                        MessageBox.Show(errors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    sportsList = result.Value!;
                    ShowRecordsOnGrid(sportsList);
                }

                catch (Exception ex)
                {

                    throw;
                }
            }
        }

        private void ShowRecordsOnGrid(List<SportListDto> sportsList)
        {
            GridHelper.LimpiarGrilla(sportsDgv);
            if (sportsList is null || sportsList.Count == 0) return;

            foreach (var b in sportsList)
            {
                var r = GridHelper.ConstruirFila(sportsDgv);
                GridHelper.SetearFila(r, b);
                GridHelper.AgregarFila(r, sportsDgv);
            }
            cantidadLabel.Text = sportsList.Count.ToString();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                using (frmSportsAE frm = scope.ServiceProvider.GetRequiredService<frmSportsAE>())
                {
                    frm.Text = "New Sport:";
                    frm.ShowDialog();
                    if (frm.DataChanged)
                    {
                        LoadGrid();
                    }
                }
            }

        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (sportsDgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a sport to update.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            var selectedRow = sportsDgv.SelectedRows[0];
            if (selectedRow.Tag is null) return;
            var sportListDto = (SportListDto)selectedRow.Tag;

            using (var scope = _serviceProvider.CreateScope())
            {
                try
                {
                    var sportService = scope.ServiceProvider.GetRequiredService<ISportService>();
                    var queryResult = sportService.GetForUpdate(sportListDto.SportId);

                    if (queryResult.IsFailure)
                    {
                        ErrorHelper.ShowErrors(queryResult.Errors);
                        return;
                    }

                    var sportUpdateDto = queryResult.Value;
                    using (frmSportsAE frm = scope.ServiceProvider.GetRequiredService<frmSportsAE>())
                    {
                        frm.Text = "Update Sport:";
                        frm.SetSport(sportUpdateDto);
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
            if (sportsDgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a sport to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var selectedRow = sportsDgv.SelectedRows[0];
            if (selectedRow.Tag is null) return;
            SportListDto sportListDto = (SportListDto)selectedRow.Tag;
            using (var scope = _serviceProvider.CreateScope())
            {
                var sportService = scope.ServiceProvider.GetRequiredService<ISportService>();
                var resultQuery = sportService.GetToDelete(sportListDto.SportId);
                if (resultQuery.IsFailure)
                {
                    string errors = string.Join("\n", resultQuery.Errors);
                    MessageBox.Show(errors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                var sportToDelete = resultQuery.Value;
                var dr = MessageBox.Show($"Are you sure you want to delete {sportListDto.Name} ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No) return;

                try
                {
                    var deleteResult = sportService.Delete(sportToDelete!);
                    if (deleteResult.IsConcurrencyConflict)
                    {
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

        private void refreshButton_Click(object sender, EventArgs e)
        {
            LoadGrid();
            ManejarControles(false);
        }

        private void ManejarControles(bool v)
        {
            activeFilter = v;
            tsbActive.BackColor = activeFilter ? Color.Red : SystemColors.Control;

            addButton.Enabled = !v;
            updateButton.Enabled = !v;
            deleteButton.Enabled = !v;
        }

        private void activeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var sportService = scope.ServiceProvider.GetRequiredService<ISportService>();
                try
                {
                    var result = sportService.FilterByActive(true);
                    if (result.IsFailure)
                    {
                        string errors = string.Join("\n", result.Errors);
                        MessageBox.Show(errors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    sportsList = result.Value!;
                    ShowRecordsOnGrid(sportsList);
                    ManejarControles(true);
                }

                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }


        }

        private void inactiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var sportService = scope.ServiceProvider.GetRequiredService<ISportService>();
                try
                {
                    var result = sportService.FilterByActive(false);
                    if (result.IsFailure)
                    {
                        string errors = string.Join("\n", result.Errors);
                        MessageBox.Show(errors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    sportsList = result.Value!;
                    ShowRecordsOnGrid(sportsList);
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
