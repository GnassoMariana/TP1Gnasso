using Microsoft.Extensions.DependencyInjection;
using TP1Gnasso.Service.DTOs.Brand;
using TP1Gnasso.Service.Interfaces;
using TP1Gnasso.WForms.Helpers;

namespace TP1Gnasso.WForms
{
    public partial class frmBrandsMenu : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private List<BrandListDto> brandsList;
        private bool activeFilter = false;
        public frmBrandsMenu(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void frmBrandsMenu_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void LoadGrid()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var brandService = scope.ServiceProvider.GetRequiredService<IBrandService>();
                try
                {
                    var result = brandService.GetAll();
                    if (result.IsFailure)
                    {
                        string errors = string.Join("\n", result.Errors);
                        MessageBox.Show(errors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    brandsList = result.Value!;
                    ShowRecordsOnGrid(brandsList);
                }

                catch (Exception ex)
                {

                    throw;
                }
            }
        }

        private void ShowRecordsOnGrid(List<BrandListDto> brandsList)
        {
            GridHelper.LimpiarGrilla(brandDgv);
            if (brandsList is null || brandsList.Count == 0) return;

            foreach (var b in brandsList)
            {
                var r = GridHelper.ConstruirFila(brandDgv);
                GridHelper.SetearFila(r, b);
                GridHelper.AgregarFila(r, brandDgv);
            }
            cantidadLabel.Text = brandsList.Count.ToString();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                using (frmBrandsAE frm = scope.ServiceProvider.GetRequiredService<frmBrandsAE>())
                {
                    frm.Text = "New Brand:";
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
            if (brandDgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a brand to update.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            var selectedRow = brandDgv.SelectedRows[0];
            if (selectedRow.Tag is null) return;
            var brandListDto = (BrandListDto)selectedRow.Tag;

            using (var scope = _serviceProvider.CreateScope())
            {
                try
                {
                    var brandService = scope.ServiceProvider.GetRequiredService<IBrandService>();
                    var queryResult = brandService.GetForUpdate(brandListDto.BrandId);

                    if (queryResult.IsFailure)
                    {
                        ErrorHelper.ShowErrors(queryResult.Errors);
                        return;
                    }

                    var brandUpdateDto = queryResult.Value;
                    using (frmBrandsAE frm = scope.ServiceProvider.GetRequiredService<frmBrandsAE>())
                    {
                        frm.Text = "Update Brand:";
                        frm.SetBrnad(brandUpdateDto);
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
            if (brandDgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a brand to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var selectedRow = brandDgv.SelectedRows[0];
            if (selectedRow.Tag is null) return;
            BrandListDto brandListDto = (BrandListDto)selectedRow.Tag;
            using (var scope = _serviceProvider.CreateScope())
            {
                var brandService = scope.ServiceProvider.GetRequiredService<IBrandService>();
                var resultQuery = brandService.GetToDelete(brandListDto.BrandId);
                if (resultQuery.IsFailure)
                {
                    string errors = string.Join("\n", resultQuery.Errors);
                    //MessageBox.Show(errors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                var brandDeleteDto = resultQuery.Value;
                var dr = MessageBox.Show($"Are you sure you want to delete {brandListDto.Name} ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No) return;

                try
                {
                    var deleteResult = brandService.Delete(brandDeleteDto!);
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

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            LoadGrid();
            ManejarControles(false);
        }

        private void activeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var brandsService = scope.ServiceProvider.GetRequiredService<IBrandService>();
                try
                {
                    var result = brandsService.FilterByActive(true);
                    if (result.IsFailure)
                    {
                        string errors = string.Join("\n", result.Errors);
                        MessageBox.Show(errors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    brandsList = result.Value!;
                    ShowRecordsOnGrid(brandsList);
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
                var brandService = scope.ServiceProvider.GetRequiredService<IBrandService>();
                try
                {
                    var result = brandService.FilterByActive(false);
                    if (result.IsFailure)
                    {
                        string errors = string.Join("\n", result.Errors);
                        MessageBox.Show(errors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    brandsList = result.Value!;
                    ShowRecordsOnGrid(brandsList);
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


