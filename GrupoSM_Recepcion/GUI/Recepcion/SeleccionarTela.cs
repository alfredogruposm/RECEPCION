using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Recepcion
{
    public partial class SeleccionarTela : Form
    {
        GUI.Recepcion.CosteoControl costeocontrol;
        public SeleccionarTela(GUI.Recepcion.CosteoControl fr1)
        {
            costeocontrol = new CosteoControl();
            costeocontrol = fr1;
            InitializeComponent();
        }

        private void SeleccionarTela_Load(object sender, EventArgs e)
        {
            DAO.TelasDAO telasdao = new GrupoSM_Recepcion.DAO.TelasDAO();
            dataGridView1.DataSource = telasdao.tablatelascosteo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text!="")
            {
                if (this.Text == "Seleccionar Combinacion")
                {
                    costeocontrol.label31.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["idtelas"].Value);
                    costeocontrol.label34.Text = comboBox1.Text;
                    costeocontrol.label25.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["precio"].Value);
                    costeocontrol.textBox11.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["nombre"].Value);
                    this.Visible = false;
                    this.Close();
                }
                if (this.Text == "Seleccionar Forro")
                {
                    costeocontrol.label32.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["idtelas"].Value);
                    costeocontrol.label35.Text = comboBox1.Text;
                    costeocontrol.label26.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["precio"].Value);
                    costeocontrol.textBox13.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["nombre"].Value);
                    this.Visible = false;
                    this.Close();
                }
                else
                {
                    costeocontrol.label30.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["idtelas"].Value);
                    costeocontrol.label33.Text = comboBox1.Text;
                    costeocontrol.label24.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["precio"].Value);
                    costeocontrol.textBox12.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["nombre"].Value);
                    this.Visible = false;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Es necesario primero guardar el ancho");
            }
                
            
        }
    }
}
