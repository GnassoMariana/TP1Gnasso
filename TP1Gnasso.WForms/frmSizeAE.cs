using TP1Gnasso.Service.DTOs.Size;
using TP1Gnasso.Service.Interfaces;
using TP1Gnasso.WForms.Helpers;

namespace TP1Gnasso.WForms
{
    public partial class frmSizeAE : Form
    {

        private SizeEditDto _sizeUpdateDto;
        private bool _isUpdate = false;


        private readonly ISizeService _sizeService;

        public SizeListDto? CreatedSize { get; private set; }

        public bool ConcurrencyConflict { get; private set; }
        public bool DataChanged { get; private set; }



        public frmSizeAE(ISizeService sizeService)
        {
            InitializeComponent();
            _sizeService = sizeService;
        }

        private void frmSizeAE_Load(object sender, EventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (_sizeUpdateDto != null)
            {
                sizeTextBox.Text = _sizeUpdateDto.Number.ToString();
                activeCheckBox.Checked = _sizeUpdateDto.Active;
            }

        }

        private bool ValidateData()
        {
            bool valid = true;

            errorProvider1.Clear();

            if (string.IsNullOrWhiteSpace(sizeTextBox.Text))
            {
                valid = false;
                errorProvider1.SetError(sizeTextBox, "Size is required");
            }
            if (!decimal.TryParse(sizeTextBox.Text, out decimal number))
            {
                errorProvider1.SetError(sizeTextBox, "Invalid size");

            }

            if (_sizeUpdateDto == null)
            {
                    _sizeUpdateDto = new SizeEditDto();
            }
            _sizeUpdateDto.Number = number;_sizeUpdateDto.Number = number;


            return valid;
        }


        private SizeCreateDto BuildCreateDto()
        {
            return new SizeCreateDto
            {
                Number = decimal.Parse(sizeTextBox.Text),
                Active = activeCheckBox.Checked
            };
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                try
                {
                    if (!_isUpdate)
                    {
                        var dto = BuildCreateDto();
                        //MessageBox.Show(dto.Active.ToString());

                        var result = _sizeService.Add(dto);

                        if (result.IsFailure)
                        {
                            ErrorHelper.ShowErrors(result.Errors);
                            return;
                        }

                        CreatedSize = _sizeService
                             .GetSizeByNumber(dto.Number!)
                             .Value;

                        DataChanged = true;

                        MessageBox.Show(
                            "Size added successfully",
                            "Message",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        DialogResult = DialogResult.OK;

                    }
                    else
                    {
                        if (_sizeUpdateDto is null)
                        {
                            _sizeUpdateDto = new SizeEditDto();
                        }

                        _sizeUpdateDto.Number =decimal.Parse( sizeTextBox.Text);
                        _sizeUpdateDto.Active = activeCheckBox.Checked;
                        var updateResult = _sizeService.Update(_sizeUpdateDto);

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
        public void SetSize(SizeEditDto sizeUpdateDto)
        {
            _sizeUpdateDto = sizeUpdateDto;
            _isUpdate = true;
        }



    }
}
