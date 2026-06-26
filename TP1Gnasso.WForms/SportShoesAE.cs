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
        private readonly ISizeService _sizeService;
        private readonly IGenreService _genreService;
        private readonly IBrandService _brandService;
        private readonly ISportService _sportService;


        public SportShoesAE(ISportShoeService sportShoeService, ISizeService sizeService,
            IGenreService genreService, IBrandService brandService, ISportService sportService)
        {
            InitializeComponent();
            _sportShoeService = sportShoeService;
            _sizeService = sizeService;
            _genreService = genreService;
            _brandService = brandService;
            _sportService = sportService;
        }

        public bool DataChanged { get; private set; }
        public bool ConcurrencyConflict { get; private set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            LoadComboBox();
            if (_sportShoeUpdateDto is null)
            {
                activeCheckbox.Checked = true;
                activeCheckbox.Enabled = false;

            }
            else
            {
                modelTextBox.Text = _sportShoeUpdateDto.Model;
                brandTextBox.Text = _sportShoeUpdateDto.Brand;
                genreComboBox.SelectedValue = _sportShoeUpdateDto.GenreId;
                sportTextBox.Text = _sportShoeUpdateDto.Sport;
                sizeComboBox.SelectedValue = _sportShoeUpdateDto.SizeId;
                priceTextBox.Text = _sportShoeUpdateDto.Price.ToString();
                dateTimePicker1.Value = _sportShoeUpdateDto.ReleaseDate;
                activeCheckbox.Enabled = true;
                _isUpdate = true;

            }
        }

        private void LoadComboBox()
        {

            var sizeResult = _sizeService.GetAll();
            var genreResult = _genreService.GetAll();
            if (sizeResult.IsFailure)
            {
                ErrorHelper.ShowErrors(sizeResult.Errors);
                return;
            }
            if (genreResult.IsFailure)
            {
                ErrorHelper.ShowErrors(genreResult.Errors);
                return;
            }
            GridHelper.LoadComboBoxGenre(genreComboBox,genreResult.Value!);
            GridHelper.LoadComboBoxSizes(sizeComboBox, sizeResult.Value!);
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

                        if (!VerifyBrand()) return;
                        if (!VerifySport()) return;
                       
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
            return new SportShoeCreateDto()
            {

                Model = modelTextBox.Text.Trim(),
                Price = decimal.Parse(priceTextBox.Text),
                ReleaseDate = dateTimePicker1.Value,
                Active = activeCheckbox.Checked,

                Brand = brandTextBox.Text.Trim(),
                Sport = sportTextBox.Text.Trim(),

                GenreId = (int)genreComboBox.SelectedValue!,
                SizeId = (int)sizeComboBox.SelectedValue!
            };

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

        private bool VerifyBrand()
        {
            var result = _brandService.GetBrandByName(
                brandTextBox.Text.Trim());

            if (result.IsSuccess)
            {
                return true;
            }

            var drNewBrand = MessageBox.Show(
                "The brand does not exist. Do you want to create it?",
                "New Brand",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (drNewBrand == DialogResult.No)
            {
                return false;
            }

            var frm = new frmBrandsAE(_brandService);

            frm.SetBrandName( brandTextBox.Text.Trim());


            if (frm.ShowDialog(this) != DialogResult.OK)
            {
                return false;
            }

            var newResult = _brandService.GetBrandByName(
                brandTextBox.Text.Trim());

            if (newResult.IsFailure)
            {
                MessageBox.Show(
                    "The brand was not created.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            MessageBox.Show(
                "Brand created successfully.",
                "Message",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            return true;
        }

        private bool VerifySport()
        {
            var result = _sportService.GetSportByName(
                sportTextBox.Text.Trim());

            if (result.IsSuccess)
            {
                return true;
            }

            var drNewSport = MessageBox.Show(
                "The sport does not exist. Do you want to create it?",
                "New Sport",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (drNewSport == DialogResult.No)
            {
                return false;
            }

            var frm = new frmSportsAE(_sportService);

            frm.SetSportName(sportTextBox.Text.Trim());


            if (frm.ShowDialog(this) != DialogResult.OK)
            {
                return false;
            }

            var newResult = _sportService.GetSportByName(
                sportTextBox.Text.Trim());

            if (newResult.IsFailure)
            {
                MessageBox.Show(
                    "The sport was not created.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            MessageBox.Show(
                "Sport created successfully.",
                "Message",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            return true;
        }
    }

}
