using Education.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Education.Win
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var alumnosBL = new AlumnosBL();
            var listadeAlumnos = alumnosBL.ObtenerAlumnos();

            listadeAlumnosBindingSource.DataSource = listadeAlumnos;
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
