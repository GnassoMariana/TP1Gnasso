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
    }
}
