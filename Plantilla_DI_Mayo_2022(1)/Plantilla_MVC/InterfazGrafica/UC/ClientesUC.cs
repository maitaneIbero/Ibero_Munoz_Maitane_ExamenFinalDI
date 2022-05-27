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
    public partial class ClientesUC : UserControl
    {
        #region Atributos

        /// <summary>
        /// Indice del cliente que se ha seleccionado
        /// </summary>
        private int indiceCliente = -1;

        private ClienteDTO clinteSeleccionado;

        private List<ClienteDTO> listaClientes;

        private String idClienteSeleccionado;

        private String nombreClienteSeleccionado;

        /// <summary>
        /// Delegado para llamar al metodo del DashBoard
        /// </summary>
        public delegate void ClickButton();
        public event ClickButton ClienteSeleccionado;

        #endregion

        #region Constructor

        public ClientesUC()
        {
            InitializeComponent();

            listaClientes =  ControladorBLL.PedirListaClientes();

            // TODO: cargar la lista de clientes en el combobox (la lista la teneis como atributo en este UC) 
            foreach(ClienteDTO x in listaClientes)
            {
                comboBox_Clientes.Items.Add(x.NombreCliente);
            }

        }
        #endregion

        #region Propiedades
        public int IndiceCliente { get => indiceCliente; set => indiceCliente = value; }
        public ClienteDTO ClinteSeleccionado { get => clinteSeleccionado; set => clinteSeleccionado = value; }
        public List<ClienteDTO> ListaClientes { get => listaClientes; set => listaClientes = value; }
        public string IDClienteSeleccionado { get => idClienteSeleccionado; set => idClienteSeleccionado = value; }
        public string NombreClienteSeleccionado { get => nombreClienteSeleccionado; set => nombreClienteSeleccionado = value; }


        #endregion

        #region Metodos

        #endregion

        #region Eventos


        private void but_SeleccionarCliente_Click(object sender, EventArgs e)
        {
            int indiceClienteSeleccionado = this.comboBox_Clientes.SelectedIndex;


            if (indiceClienteSeleccionado < 0)
            {
                MessageBox.Show("Por favor, para continuar seleciona un cliente", "Cliente no seleccionado");
            }
            else
            {
                this.ClinteSeleccionado = this.listaClientes[indiceClienteSeleccionado];
                this.idClienteSeleccionado = ClinteSeleccionado.IDCliente;
                this.nombreClienteSeleccionado = ClinteSeleccionado.NombreCliente;

                // metodo delegado asociado al Dashboard
                ClienteSeleccionado();


            }
        }

        #endregion

        private void comboBox_Clientes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
