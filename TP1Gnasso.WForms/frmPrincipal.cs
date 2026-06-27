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
using TP1Gnasso.WForms.Classes;

namespace TP1Gnasso.WForms
{
    public partial class frmPrincipal : Form
    {
        private readonly IServiceProvider _serviceProvider;
        public frmPrincipal(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            conectedUserLabel.Text = $"{Sesion.CurrentUser!.UserName}";
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void sportShoesButton_Click(object sender, EventArgs e)
        {
            using (var frm = _serviceProvider.GetRequiredService<frmSportShoesMenu>())
            {
                frm.Text = "Sport Shoes List";
                frm.ShowDialog();
            }
        }

        private void brandsButton_Click(object sender, EventArgs e)
        {
            using (var frm = _serviceProvider.GetRequiredService<frmBrandsMenu>())
            {
                frm.Text = " Brands List";
                frm.ShowDialog();
            }
        }

        private void sportsButton_Click(object sender, EventArgs e)
        {
            using (var frm = _serviceProvider.GetRequiredService<frmSportsMenu>())
            {
                frm.Text = "Sports List";
                frm.ShowDialog();
            }
        }

        private void sizesButton_Click(object sender, EventArgs e)
        {
            using (var frm = _serviceProvider.GetRequiredService<frmSizeMenu>())
            {
                frm.Text = "Sizes List";
                frm.ShowDialog();
            }
        }

        private void genreButton_Click(object sender, EventArgs e)
        {
            using(var frm = _serviceProvider.GetRequiredService<frmGenreMenu>())
            {
                frm.Text = "Genre List";
                frm.ShowDialog();
            }
        }
    }
}
