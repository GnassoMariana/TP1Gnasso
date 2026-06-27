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
using TP1Gnasso.Service.Interfaces;
using TP1Gnasso.WForms.Helpers;

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
    }

}

