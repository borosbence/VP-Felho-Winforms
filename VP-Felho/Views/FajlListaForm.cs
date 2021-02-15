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
            set
            {
                // valami + "." + jpg
                NevTextBox.Text = string.IsNullOrEmpty(value.fajlnev) ?
                    null : value.fajlnev + "." + value.kiterjesztes;
                DatumTextBox.Text = value.datum.Year == 1 ?
                    null : value.datum.ToString();
            } 
        }

        private void FajlListaForm_Load(object sender, EventArgs e)
        {
            presenter.LoadData();
        }

        private void kilepesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            var fajl = (fajl)listBox1.SelectedItem;
            if (fajl != null)
            {
                presenter.SelectFile(fajl.id);
            }
        }

        private void ujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.ClearSelected();
            presenter.CreateFile();
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = saveFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                
            }
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            //openFileDialog1.Filter = "Word dokumentumok (*.docx)|*.docx|Minden fájl (*.*)|*.*";
            openFileDialog1.Filter = "Minden fájl (*.*) | *.*";
            openFileDialog1.FileName = null;
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                MessageBox.Show(openFileDialog1.FileName);
            }
        }
    }
}
