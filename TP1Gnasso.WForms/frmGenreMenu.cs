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
using TP1Gnasso.Service.DTOs.Genre;
using TP1Gnasso.Service.Interfaces;
using TP1Gnasso.WForms.Helpers;

namespace TP1Gnasso.WForms
{
    public partial class frmGenreMenu : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private List<GenreListDto> genreList;
        public frmGenreMenu(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void frmGenreMenu_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void LoadGrid()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var genreService = scope.ServiceProvider.GetRequiredService<IGenreService>();
                try
                {
                    var result = genreService.GetAll();
                    if (result.IsFailure)
                    {
                        string errors = string.Join("\n", result.Errors);
                        MessageBox.Show(errors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    genreList = result.Value!;
                    ShowRecordsOnGrid(genreList);
                }

                catch (Exception ex)
                {

                    throw;
                }
            }
        }

        private void ShowRecordsOnGrid(List<GenreListDto> genreList)
        {
            GridHelper.LimpiarGrilla(genreDgv);
            if (genreList is null || genreList.Count == 0) return;

            foreach (var g in genreList)
            {
                var r = GridHelper.ConstruirFila(genreDgv);
                GridHelper.SetearFila(r, g);
                GridHelper.AgregarFila(r, genreDgv);
            }
            //cantidadLabel.Text = brandsList.Count.ToString();
        }
    }

}

