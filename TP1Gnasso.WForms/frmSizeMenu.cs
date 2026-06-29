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
using TP1Gnasso.Service.DTOs.Size;
using TP1Gnasso.Service.DTOs.Sport;
using TP1Gnasso.Service.Interfaces;
using TP1Gnasso.WForms.Helpers;
using static System.Formats.Asn1.AsnWriter;

namespace TP1Gnasso.WForms
{
    public partial class frmSizeMenu : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private List<SizeListDto> sizesList;
        private bool activeFilter = false;

        public frmSizeMenu(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void LoadGrid()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var sizeService = scope.ServiceProvider.GetRequiredService<ISizeService>();
                try
                {
                    var result = sizeService.GetAll();
                    if (result.IsFailure)
                    {
                        string errors = string.Join("\n", result.Errors);
                        MessageBox.Show(errors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    sizesList = result.Value!;
                    ShowRecordsOnGrid(sizesList);
                }

                catch (Exception ex)
                {

                    throw;
                }
            }
        }

        private void ShowRecordsOnGrid(List<SizeListDto> sizesList)
        {
            GridHelper.LimpiarGrilla(sizeDgv);
            if (sizesList is null || sizesList.Count == 0) return;

            foreach (var s in sizesList)
            {
                var r = GridHelper.ConstruirFila(sizeDgv);
                GridHelper.SetearFila(r, s);
                GridHelper.AgregarFila(r, sizeDgv);
            }
            cantidadLabel.Text = sizesList.Count.ToString();
        }

        private void frmSizeMenu_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                using (frmSizeAE frm = scope.ServiceProvider.GetRequiredService<frmSizeAE>())
                {
                    frm.Text = "New Size:";
                    frm.ShowDialog();
                    if (frm.DataChanged)
                    {
                        LoadGrid();
                    }
                }
            }

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (sizeDgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a size to update.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            var selectedRow = sizeDgv.SelectedRows[0];
            if (selectedRow.Tag is null) return;
            var sizeListDto = (SizeListDto)selectedRow.Tag;

            using (var scope = _serviceProvider.CreateScope())
            {
                try
                {
                    var sizeService = scope.ServiceProvider.GetRequiredService<ISizeService>();
                    var queryResult = sizeService.GetForUpdate(sizeListDto.SizeId);

                    if (queryResult.IsFailure)
                    {
                        ErrorHelper.ShowErrors(queryResult.Errors);
                        return;
                    }

                    var sizeUpdateDto = queryResult.Value;
                    using (frmSizeAE frm = scope.ServiceProvider.GetRequiredService<frmSizeAE>())
                    {
                        frm.Text = "Update Size:";
                        frm.SetSize(sizeUpdateDto!);
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
            if (sizeDgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a size to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var selectedRow = sizeDgv.SelectedRows[0];
            if (selectedRow.Tag is null) return;
            SizeListDto sizeListDto = (SizeListDto)selectedRow.Tag;
            using (var scope = _serviceProvider.CreateScope())
            {
                var sizeService = scope.ServiceProvider.GetRequiredService<ISizeService>();
                var resultQuery = sizeService.GetToDelete(sizeListDto.SizeId);
                if (resultQuery.IsFailure)
                {
                    string errors = string.Join("\n", resultQuery.Errors);
                    MessageBox.Show(errors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                var sizeToDelete = resultQuery.Value;
                var dr = MessageBox.Show($"Are you sure you want to delete {sizeListDto.Number} ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No) return;

                try
                {
                    var deleteResult = sizeService.Delete(sizeToDelete!);
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
                var sizeService = scope.ServiceProvider.GetRequiredService<ISizeService>();
                try
                {
                    var result = sizeService.FilterByActive(true);
                    if (result.IsFailure)
                    {
                        string errors = string.Join("\n", result.Errors);
                        MessageBox.Show(errors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    sizesList = result.Value!;
                    ShowRecordsOnGrid(sizesList);
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
                var sizeService = scope.ServiceProvider.GetRequiredService<ISizeService>();
                try
                {
                    var result = sizeService.FilterByActive(false);
                    if (result.IsFailure)
                    {
                        string errors = string.Join("\n", result.Errors);
                        MessageBox.Show(errors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    sizesList = result.Value!;
                    ShowRecordsOnGrid(sizesList);
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



