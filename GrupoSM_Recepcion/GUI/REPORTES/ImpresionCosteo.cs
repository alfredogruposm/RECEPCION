using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.REPORTES
{
    public partial class ImpresionCosteo : Form
    {
        public ImpresionCosteo()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }
        public int costeo { get; set; }
        public int idficha { get; set; }
        private void ImpresionCosteo_Load(object sender, EventArgs e)
        {

            DAO.SolicitudesDAO solicitudesdao = new DAO.SolicitudesDAO();
            solicitudesdao.idsolicitud = this.costeo;

            DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
            aviosdao.id_ficha_avio = this.idficha;

            DAO.TelasDAO telasdao = new DAO.TelasDAO();
            telasdao.costeo = this.costeo;
            
            GUI.PLANTILLAS.ImpresionCosteo1 report = new PLANTILLAS.ImpresionCosteo1();

            report.SetDataSource(solicitudesdao.devuelveimpresioncosteo());
            report.Subreports["TelasCosteoSubRPT"].SetDataSource(telasdao.devuelvetelascosteoimpresion());
            report.Subreports["AviosCosteoSubRPT"].SetDataSource(aviosdao.sacar_avios());
            report.Subreports["DatosCosteo"].SetDataSource(solicitudesdao.devuelveimpresioncosteo());

            crystalReportViewer1.ReportSource = report;
            crystalReportViewer1.Refresh();
        }
    }
}
