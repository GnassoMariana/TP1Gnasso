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
            using( var frm = _serviceProvider.GetRequiredService<frmSportShoesMenu>())
            {
                frm.Text = "Sport Shoes List";
                frm.ShowDialog();
            }
        }
        
    }
}
