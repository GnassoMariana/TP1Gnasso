using TP1Gnasso.Data.Interfaces;
using TP1Gnasso.Service.DTOs.SportShoe;
using TP1Gnasso.Service.Interfaces;
using TP1Gnasso.Service.Services;
using TP1Gnasso.WForms.Helpers;

namespace TP1Gnasso.WForms
{
    public partial class SportShoesAE : Form
    {
        private SportShoeEditDto _sportShoeUpdateDto;
        private readonly ISportShoeService _sportShoeService;
        private bool _isUpdate = false;

        public SportShoesAE(ISportShoeService sportShoeService)
        {
            InitializeComponent();
            _sportShoeService = sportShoeService;
        }

        public bool DataChanged { get; private set; }
        public bool ConcurrencyConflict { get; private set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_sportShoeUpdateDto is null)
            {
                activeCheckbox.Checked = true;
                activeCheckbox.Enabled = false;

            }
            else
            {
                modelTextBox.Text = _sportShoeUpdateDto.Model;
                brandTextBox.Text = _sportShoeUpdateDto.Brand;
                genreComboBox.SelectedItem = _sportShoeUpdateDto.GenreId;
                sportTextBox.Text = _sportShoeUpdateDto.Sport;
                sizeComboBox.SelectedItem = _sportShoeUpdateDto.SizeId;
                priceTextBox.Text = _sportShoeUpdateDto.Price.ToString();
                dateTimePicker1.Value = _sportShoeUpdateDto.ReleaseDate;
                activeCheckbox.Enabled = true;
                _isUpdate = true;

            }
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                try
                {
                    if (!_isUpdate)
                    {
                        SportShoeCreateDto sportShoeCreateDto = BuildCreateDto();
                        var addResult = _sportShoeService.Add(sportShoeCreateDto);

                        if (addResult.IsFailure)
                        {
                            ErrorHelper.ShowErrors(addResult.Errors);
                            return;
                        }
                        DataChanged = true;

                        var addMoreRecords = MessageBox.Show("Record added \nDo you wish to add another?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (addMoreRecords == DialogResult.No)
                        {
                            DialogResult = DialogResult.OK;
                        }
                        InitializeControls();
                    }
                    else
                    {
                        if (_sportShoeUpdateDto is null)
                        {
                            _sportShoeUpdateDto = new SportShoeEditDto();
                        }
                        _sportShoeUpdateDto.Model = modelTextBox.Text.Trim();
                        _sportShoeUpdateDto.Price = decimal.Parse(priceTextBox.Text);
                        _sportShoeUpdateDto.ReleaseDate = dateTimePicker1.Value;
                        _sportShoeUpdateDto.Active = activeCheckbox.Checked;

                        _sportShoeUpdateDto.Brand = brandTextBox.Text.Trim();
                        _sportShoeUpdateDto.Sport = sportTextBox.Text.Trim();

                        _sportShoeUpdateDto.GenreId = (int)genreComboBox.SelectedValue!;
                        _sportShoeUpdateDto.SizeId = (int)sizeComboBox.SelectedValue!;

                        var updateResult = _sportShoeService.Update(_sportShoeUpdateDto);

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
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void InitializeControls()
        {
            modelTextBox.Clear();
            brandTextBox.Clear();
            sportTextBox.Clear();
            priceTextBox.Clear();

            dateTimePicker1.Value = DateTime.Today;
            activeCheckbox.Checked = true;

            genreComboBox.SelectedIndex = -1;
            sizeComboBox.SelectedIndex = -1;

            modelTextBox.Focus();
        }

        private SportShoeCreateDto BuildCreateDto()
        {
            var dto = new SportShoeCreateDto();

            dto.Model = modelTextBox.Text.Trim();
            dto.Price = decimal.Parse(priceTextBox.Text);
            dto.ReleaseDate = dateTimePicker1.Value;
            dto.Active = activeCheckbox.Checked;

            dto.Brand = brandTextBox.Text.Trim();
            dto.Sport = sportTextBox.Text.Trim();

            dto.GenreId = (int)genreComboBox.SelectedValue!;
            dto.SizeId = (int)sizeComboBox.SelectedValue!;

            return dto;
        }

        private bool ValidateData()
        {
            bool valid = true;

            errorProvider1.Clear();

            if (string.IsNullOrWhiteSpace(modelTextBox.Text))
            {
                valid = false;
                errorProvider1.SetError(modelTextBox, "the model is required");
            }

            if (string.IsNullOrWhiteSpace(brandTextBox.Text))
            {
                valid = false;
                errorProvider1.SetError(brandTextBox, "The brand is required");
            }

            if (string.IsNullOrWhiteSpace(sportTextBox.Text))
            {
                valid = false;
                errorProvider1.SetError(sportTextBox, "The sport is required");
            }

            if (!decimal.TryParse(priceTextBox.Text, out decimal price))
            {
                valid = false;
                errorProvider1.SetError(priceTextBox, "Invalid number");
            }
            else if (price <= 0)
            {
                valid = false;
                errorProvider1.SetError(priceTextBox, "Price must be higher ");
            }

            return valid;
        }

        public void SetSportShoe(SportShoeEditDto? sportShoeUpdateDto)
        {
            _sportShoeUpdateDto = sportShoeUpdateDto!;
        }
    }

}
