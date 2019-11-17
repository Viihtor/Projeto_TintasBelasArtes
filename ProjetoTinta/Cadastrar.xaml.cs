using ProjetoTinta.DAO;
using ProjetoTinta.Modelos;
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
using System.Windows.Shapes;

namespace ProjetoTinta
{
    /// <summary>
    /// Interaction logic for Cadastrar.xaml
    /// </summary>
    public partial class Cadastrar : Window
    {
        public Cadastrar()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            TintaDao tDao = new TintaDao();
            Tinta tinta = new Tinta()
            {
                Cor = txtCor.Text,
                Marca = txtMarca.Text,
                Preco = Convert.ToDecimal(txtPreco.Text)
            };

            tDao.inserir(tinta);
            limparCampos();
        }

        private void limparCampos()
        {
            txtPreco.Clear();
            txtMarca.Clear();
            txtCor.Clear();
        }
    }
}
