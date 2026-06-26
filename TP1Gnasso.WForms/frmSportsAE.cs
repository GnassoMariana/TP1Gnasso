using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP1Gnasso.Service.DTOs.Sport;
using TP1Gnasso.Service.Interfaces;
using TP1Gnasso.WForms.Helpers;

namespace TP1Gnasso.WForms
{
    public partial class frmSportsAE : Form
    {

        private readonly ISportService _sportService;

        public SportListDto? CreatedSport { get; private set; }
        public frmSportsAE(ISportService sportService)
        {
            InitializeComponent();
            _sportService = sportService;
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
    }
}
