using MaterialSkin.Controls;
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

namespace Almacenamiento
{
    public partial class FrmTXT : MaterialForm
    {
       private List<Usuario> User = new List<Usuario> ();
        

        public FrmTXT()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario()
            {
                id = Convert.ToInt32(txtId.Text),
                name= txtName.Text

        };
            User.Add(usuario);


            dgvUsuario.Rows.Clear();
            foreach (Usuario u in User)
            {
                dgvUsuario.Rows.Add(u.id, u.name);
            }

            txtName.Clear();
            txtId.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (StreamWriter save = new StreamWriter("Datos.txt")) { 
            
            foreach(DataGridViewRow fila in dgvUsuario.Rows)
                {
                    string linea = string.Format("{0}, {1}", fila.Cells[0].Value, fila.Cells[1].Value);
                    save.WriteLine(linea);


                }
          
            }
            MessageBox.Show("Datos almacenados correctamente");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            User.Clear();
            dgvUsuario.Rows.Clear();

            using (StreamReader load = new StreamReader("Datos.txt"))
            {

                string linea;
                while((linea = load.ReadLine()) != null)
                {
                    string[] celda = linea.Split(';');
                    Usuario usuario = new Usuario()
                    {
                        id = Convert.ToInt32(celda[0]),
                        name = celda[1]

                    };
                    User.Add(usuario);
                    dgvUsuario.Rows.Add(celda);
                }

            }
            MessageBox.Show("Datos cargados correctamente");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(dgvUsuario.SelectedRows.Count > 0)
            {



                foreach(DataGridViewRow fila in dgvUsuario.SelectedRows)
                {
                    int indice = fila.Index;
                    dgvUsuario.Rows.RemoveAt(indice);
                    User.RemoveAt(indice);


                }

            }
        }
    }
}
