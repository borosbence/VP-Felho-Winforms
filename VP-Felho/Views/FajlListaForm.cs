using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VP_Felho.Models;
using VP_Felho.Presenters;
using VP_Felho.Services;
using VP_Felho.ViewInterfaces;

namespace VP_Felho.Views
{
    public partial class FajlListaForm : Form, IFajlListaView
    {
        private FajlListaPresenter presenter;
        public FajlListaForm()
        {
            InitializeComponent();
            toolStripStatusLabel1.Text = CurrentUser.UserName;
            presenter = new FajlListaPresenter(this);
        }

        public List<fajl> fajlLista 
        {
            get => (List<fajl>)listBox1.DataSource;
            set => listBox1.DataSource = value; 
        }
        public fajl fajl 
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException(); 
        }

        private void FajlListaForm_Load(object sender, EventArgs e)
        {
            presenter.LoadData();
        }

        private void kilepesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
