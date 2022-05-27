using BusinessLogicLayer;
using ObjetosTransferencia.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfazGrafica.UC
{
    public partial class ResumenUC : UserControl
    {

        private List<PedidoDTO> listaPedidos;
        

        public ResumenUC(List<PedidoDTO> listaPedidos)
        {
            InitializeComponent();

            // TODO: Añade los campos que se piden al eje X e Y
          

            List<DateTime> x = new List<DateTime>();
            List<Double> y = new List<Double>();
            Double precioTotal = 0;

            foreach (PedidoDTO pedido in listaPedidos)
            {
                x.Add(pedido.FechaPedido);
                y.Add(pedido.PrecioEnvio);
                precioTotal += pedido.PrecioEnvio;
            }
            chart_Pedidos.Series["Gastos Envio"].Points.DataBindXY(x.ToArray(),y.ToArray());
            lab_SumaEnvio.Text = lab_SumaEnvio.Text + " " + precioTotal;
            

            // TODO: suma los gastos
        }


    }
}
