using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VP_Felho.Presenters;
using VP_Felho.ViewInterfaces;

namespace VP_Felho.Views
{
    public partial class LoginForm : Form, ILoginView
    {
        private LoginPresenter presenter;
        public LoginForm()
        {
            InitializeComponent();
            presenter = new LoginPresenter(this);
        }

        public string felhNev 
        {
            get => FelhNevTextBox.Text;
        }
        public string jelszo 
        {
            get => JelszoTextBox.Text;
        }
        public string errorFelhNev 
        {
            set => errorPFelhNev.SetError(FelhNevTextBox, value); 
        }
        public string errorJelszo 
        {
            set => errorPJelszo.SetError(JelszoTextBox, value); 
        }

        private void BelepesButton_Click(object sender, EventArgs e)
        {
            if (presenter.Belepes())
            {
                FajlListaForm fajlListaForm = new FajlListaForm();
                this.Hide();
                fajlListaForm.ShowDialog();
                this.Close();
            }
        }

        private void JelszoTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BelepesButton.PerformClick();
            }
        }
    }
}
