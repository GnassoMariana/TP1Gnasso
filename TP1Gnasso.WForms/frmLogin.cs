using Microsoft.Extensions.DependencyInjection;
using TP1Gnasso.Entities;
using TP1Gnasso.WForms.Classes;

namespace TP1Gnasso.WForms
{
    public partial class frmLogin : Form
    {
        private readonly IServiceProvider _serviceProvider;
        public frmLogin(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                User? user = SystemUsers.Users.FirstOrDefault(u => u.UserName == userTextBox.Text && u.Password == passwordTextBox.Text);
                if (user is null)
                {
                    MessageBox.Show("User name or password is incorrect.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Sesion.CurrentUser = user;
                this.Hide();
                frmPrincipal frm = _serviceProvider.GetRequiredService<frmPrincipal>();
                frm.ShowDialog();
                InitializeControls();
                this.Show();

            }

        }

        private void InitializeControls()
        {
            userTextBox.Clear();
            passwordTextBox.Clear();
            userTextBox.Select();
        }

        private bool ValidateData()
        {
            bool valid = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(userTextBox.Text))
            {
                valid = false;
                errorProvider1.SetError(userTextBox, "Username is required.");

            }
            if (string.IsNullOrEmpty(passwordTextBox.Text))
            {
                valid = false;
                errorProvider1.SetError(passwordTextBox, "Password is required.");
            }
            return valid;

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
