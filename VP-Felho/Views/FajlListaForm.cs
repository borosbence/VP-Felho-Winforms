using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        private fajl _fajl = new fajl();

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
            get => _fajl;
            set
            {
                NevTextBox.Text = value.fajlnev;
                DatumTextBox.Text = value.datum.Year == 1 ?
                    null : value.datum.ToString();
                //Kép megjelenítése
                if (value.kiterjesztes == ".png" || value.kiterjesztes == ".jpg")
                {
                    using (var ms = new MemoryStream(value.adat))
                    {
                        Image img = Image.FromStream(ms);
                        pictureBox1.Image = img;
                    }
                }
                // Ha nem kép a kiterjesztés
                else
                {
                    pictureBox1.Image = null;
                }
                _fajl = value;
            } 
        }

        private void FajlListaForm_Load(object sender, EventArgs e)
        {
            presenter.LoadData();
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

        private void mentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            presenter.SaveFile();
        }

        private void torlesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fajl = (fajl)listBox1.SelectedItem;
            // Ha teljesen üres az adatbázis
            if (fajl != null)
            {
                presenter.RemoveFile();
            }
        }

        private void KijelentkezesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.ShowDialog();
            this.Close();
        }

        private void kilepesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = fajl.fajlnev;
            saveFileDialog1.Filter = "Minden típus | *.*";
            DialogResult dr = saveFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                // Ha a fájlnév mező nem üres
                if (!string.IsNullOrEmpty(saveFileDialog1.FileName))
                {
                    File.WriteAllBytes(saveFileDialog1.FileName, fajl.adat);
                }
            }
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = null;
            //openFileDialog1.Filter = "Word dokumentumok (*.docx)|*.docx|Minden fájl (*.*)|*.*";
            openFileDialog1.Filter = "Minden típus (*.*) | *.*";
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                var teljesFajlnev = openFileDialog1.FileName;
                // Kiválasztottuk a feltöltendő fájlt
                if (!string.IsNullOrEmpty(teljesFajlnev))
                {
                    _fajl.fajlnev = openFileDialog1.SafeFileName;
                    _fajl.kiterjesztes = Path.GetExtension(teljesFajlnev);
                    _fajl.adat = File.ReadAllBytes(openFileDialog1.FileName);
                    _fajl.datum = DateTime.Now;
                    fajl = _fajl;
                }
            }
        }
    }
}
