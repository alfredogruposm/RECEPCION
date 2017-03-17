using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Bodega
{
    public partial class Hoja_Corte : Form
    {
        public Hoja_Corte()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        public int idficha { get; set; }
        public int idproduccion { get; set; }
        private void Hoja_Corte_Load(object sender, EventArgs e)
        {
            DAO.ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.ProduccionDAO();
            producciondao.id_produccion = int.Parse(textBox1.Text);
            dataGridView1.DataSource = producciondao.tallas_preliminaresproduccion();
            DAO.TelasDAO telasdao = new GrupoSM_Recepcion.DAO.TelasDAO();
            telasdao.id_tela_produccion = int.Parse(textBox1.Text);
            dataGridView2.DataSource = telasdao.vertelasproduccion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DAO.Oden_ProduccionDAO ordendao = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
            ordendao.fecha_trazado_inicio = dateTimePicker1.Value;
            ordendao.idorden = int.Parse(textBox1.Text);
            ordendao.Pellon = textBox4.Text;
            ordendao.Marca = textBox6.Text;
            ordendao.Composicion = textBox7.Text;
            ordendao.Modelo = textBox8.Text;
            ordendao.observaciones = richTextBox1.Text;
            ordendao.actualizaobservacion();
            ordendao.insertapellones();
            string resultado = (ordendao.actualizatrazoproduccion());
            if (resultado != "Correcto")
            {
                MessageBox.Show(resultado);
            }
            else
            {
                DialogResult result = MessageBox.Show("¿Desea imprimir la hoja de corte?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    GUI.REPORTES.HojaCorte1 hojacorte1gui = new GrupoSM_Recepcion.GUI.REPORTES.HojaCorte1();
                    hojacorte1gui.idproduccion = this.idproduccion;
                    GUI.REPORTES.HojaCorte2 hojacorte2gui = new GrupoSM_Recepcion.GUI.REPORTES.HojaCorte2();
                    hojacorte2gui.idficha = this.idficha;
                    hojacorte2gui.idproduccion = this.idproduccion;
                    hojacorte1gui.Show();
                    hojacorte2gui.Show();
                    this.Hide();
                    this.Close();
                }
            }
        }
    }
}
