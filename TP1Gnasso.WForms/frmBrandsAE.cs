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
using TP1Gnasso.Service.DTOs.SportShoe;
using TP1Gnasso.Service.Interfaces;
using TP1Gnasso.Service.Services;
using TP1Gnasso.WForms.Helpers;

namespace TP1Gnasso.WForms
{
    public partial class frmBrandsAE : Form
    {
        private BrandEditDto _brandEditDto;
        private bool _isUpdate = false;

        private readonly IBrandService _brandService;
        public BrandListDto? CreatedBrand { get; private set; }
        public bool ConcurrencyConflict { get; private set; }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (_brandEditDto != null)
            {
                brandTextBox.Text = _brandEditDto.Name;
                countryComboBox.Text = _brandEditDto.Country;
                checkBox1.Checked = _brandEditDto.Active;
            }
        }

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
                    if(!_isUpdate)
                    {
                        var dto = BuildCreateDto();
                        MessageBox.Show(dto.Active.ToString());

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
                    else
                    {
                        if (_brandEditDto is null)
                        {
                            _brandEditDto = new BrandEditDto();
                        }

                        _brandEditDto.Name = brandTextBox.Text.Trim();
                        _brandEditDto.Country = countryComboBox.Text!;
                        _brandEditDto.Active = checkBox1.Checked;
                        var updateResult = _brandService.Update(_brandEditDto);

                        if (updateResult.IsConcurrencyConflict)
                        {
                            ErrorHelper.ShowErrors(updateResult.Errors);
                            ConcurrencyConflict = true;
                            DialogResult = DialogResult.Cancel;

                            Close();
                            return;


                        }
                        if (updateResult.IsFailure)
                        {
                            ErrorHelper.ShowErrors(updateResult.Errors);
                            return;
                        }
                        DataChanged = true;
                        MessageBox.Show("Record updated");
                        DialogResult = DialogResult.OK;
                        Close();


                    }
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

        public void SetBrnad(BrandEditDto brandEdtiDto)
        {
            _brandEditDto = brandEdtiDto;
            _isUpdate = true;
        }

    }
}
