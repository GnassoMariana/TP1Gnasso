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
using TP1Gnasso.Service.Interfaces;
using TP1Gnasso.WForms.Helpers;

namespace TP1Gnasso.WForms
{
    public partial class frmBrandsAE : Form
    {

        private readonly IBrandService _brandService;
        public BrandListDto? CreatedBrand { get; private set; }

        public frmBrandsAE(IBrandService brandService)
        {
            InitializeComponent();

            _brandService = brandService;
            LoadCountries();
        }

        public bool DataChanged { get; private set; }

        private void LoadCountries()
        {
            string filePath = Path.Combine(
                Application.StartupPath,
                "Countries.txt");

            if (!File.Exists(filePath))
            {
                MessageBox.Show("Countries file not found");
                return;
            }

            var countries = File.ReadAllLines(filePath)
                .Where(c => !string.IsNullOrWhiteSpace(c))
                .ToList();

            countryComboBox.DataSource = countries;

        }

        private bool ValidateData()
        {
            bool valid = true;

            errorProvider1.Clear();

            if (string.IsNullOrWhiteSpace(brandTextBox.Text))
            {
                valid = false;
                errorProvider1.SetError(brandTextBox, "Brand is required");
            }

            if (countryComboBox.SelectedIndex < 0)
            {
                valid = false;
                errorProvider1.SetError(countryComboBox, "Country is required");
            }

            return valid;
        }

        private BrandCreateDto BuildCreateDto()
        {
            return new BrandCreateDto
            {
                Name = brandTextBox.Text.Trim(),
                Country = countryComboBox.Text,
                Active = checkBox1.Checked
            };
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                try
                {
                    var dto = BuildCreateDto();

                    var result = _brandService.Add(dto);

                    if (result.IsFailure)
                    {
                        ErrorHelper.ShowErrors(result.Errors);
                        return;
                    }

                    CreatedBrand = _brandService
                         .GetBrandByName(dto.Name!)
                         .Value;

                    DataChanged = true;

                    MessageBox.Show(
                        "Brand added successfully",
                        "Message",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void SetBrandName(string brandName)
        {
            brandTextBox.Text = brandName;
        }
    }
}
