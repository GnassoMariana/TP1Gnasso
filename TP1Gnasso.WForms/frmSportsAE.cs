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
using TP1Gnasso.Service.Services;
using TP1Gnasso.WForms.Helpers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace TP1Gnasso.WForms
{
    public partial class frmSportsAE : Form
    {
        private SportEditDto _sportUpdateDto;
        private bool _isUpdate = false;


        private readonly ISportService _sportService;

        public SportListDto? CreatedSport { get; private set; }

                public bool ConcurrencyConflict { get; private set; }

        public frmSportsAE(ISportService sportService)
        {
            InitializeComponent();
            _sportService = sportService;
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (_sportUpdateDto != null)
            {
                sportTextBox.Text = _sportUpdateDto.Name;
                activeCheckBox.Checked = _sportUpdateDto.Active;
            }
        }

        public bool DataChanged { get; private set; }

        private bool ValidateData()
        {
            bool valid = true;

            errorProvider1.Clear();

            if (string.IsNullOrWhiteSpace(sportTextBox.Text))
            {
                valid = false;
                errorProvider1.SetError(
                    sportTextBox,
                    "Sport is required");
            }

            return valid;
        }

        private SportCreateDto BuildCreateDto()
        {
            return new SportCreateDto
            {
                Name = sportTextBox.Text.Trim(),
                Active = activeCheckBox.Checked
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

                        var result = _sportService.Add(dto);

                        if (result.IsFailure)
                        {
                            ErrorHelper.ShowErrors(result.Errors);
                            return;
                        }
                        CreatedSport = _sportService.GetSportByName(dto.Name!).Value;
                        DataChanged = true;

                        MessageBox.Show(
                            "Sport added successfully",
                            "Message",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        DialogResult = DialogResult.OK;

                    }
                    else
                    {
                        if (_sportUpdateDto is null)
                        {
                            _sportUpdateDto = new SportEditDto();
                        }

                        _sportUpdateDto.Name = sportTextBox.Text.Trim();
                        _sportUpdateDto.Active = activeCheckBox.Checked;
                        var updateResult = _sportService.Update(_sportUpdateDto);

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

        public void SetSportName(string sportName)
        {
            sportTextBox.Text = sportName;
        }

        private void frmSportsAE_Load(object sender, EventArgs e)
        {

        }

        public void SetSport(SportEditDto sportUpdateDto)
        {
            _sportUpdateDto = sportUpdateDto;
            _isUpdate = true;
        }

    }
}
