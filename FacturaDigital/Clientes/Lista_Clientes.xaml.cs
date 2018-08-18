﻿using DataModel.EF;
using FacturaDigital.Recursos;
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

namespace FacturaDigital.Clientes
{
    /// <summary>
    /// Interaction logic for Lista_Clientes.xaml
    /// </summary>
    public partial class Lista_Clientes : Page
    {
        public Lista_Clientes()
        {
            InitializeComponent();
            GetListaClientes();
        }

        private void GetListaClientes()
        {
            try
            {
                List<Cliente> Cliente = null;
                using (db_FacturaDigital db = new db_FacturaDigital())
                {
                    Cliente = db.Cliente.ToList();
                }

                if (Cliente != null)
                    dgv_Clientes.ItemsSource = Cliente;
            }
            catch (Exception ex)
            {
                RecursosSistema.LogError(ex);
                MessageBox.Show("Ocurrio un error al obtener la lista de clientes", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        private void EliminarCliente(object sender, RoutedEventArgs e)
        {

        }

        private void AgregarNuevoCliente(object sender, RoutedEventArgs e)
        {
            RecursosSistema.MainConteiner.Content = new Clientes();
        }
    }
}
