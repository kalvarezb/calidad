using LibreriaTaller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppTaller
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NegocioTurismo nt = new NegocioTurismo();
        public MainWindow()
        {
            InitializeComponent();

            llenarGrilla();
            txtRut.Focus();
        }

        private void llenarGrilla()
        {
            GrillaDatos.ItemsSource = null;
            GrillaDatos.ItemsSource = nt.traerTodo();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Cliente nuevo = new Cliente(txtRut.Text, txtNombre.Text, txtDireccion.Text, txtEmail.Text);

            if(nt.RegistrarCliente(nuevo)==1)
            {
                MessageBox.Show("Nuevo cliente agregado");
                llenarGrilla();
                limpiarTextos();
            }
        }

        private void limpiarTextos()
        {
            txtDireccion.Clear();
            txtEmail.Clear();
            txtNombre.Clear();
            txtRut.Clear();
            txtRut.Focus();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if(txtRut.Text.Trim().Length>0)
            {
                //Busca el cliente y lo muestra en la pantalla
            }
            else
            {
                MessageBox.Show("Debe ingresar un rut");
                txtRut.Clear();
                txtRut.Focus();
            }
        }
    }
}
