using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_DataGridView
{
    public partial class Form1 : Form
    {
        Conexion conexion = new Conexion("Data Source = (localdb)\\ProjectsV13; Initial Catalog = demostracion; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public Form1()
        {
            InitializeComponent();
            dgv_demostracion.DataSource = conexion.obtenerTablaParaDGV("personas");
        }
    }
}
