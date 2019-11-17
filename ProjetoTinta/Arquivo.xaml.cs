using Microsoft.Win32;
using ProjetoTinta.DAO;
using ProjetoTinta.Modelos;
using ProjetoTinta.Servicos;
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
    /// Interaction logic for Arquivo.xaml
    /// </summary>
    public partial class Arquivo : Window
    {
        public Arquivo()
        {
            InitializeComponent();
        }

        private void btnExportar_Click(object sender, RoutedEventArgs e)
        {
            ImportarExportar importar = new ImportarExportar();
            importar.exportarJSON();
        }

        private void btnDialog_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "JSON files (*.json) | *.json";
            if (openDialog.ShowDialog() == true)
            {
                ImportarExportar importar = new ImportarExportar();
                TintaDao tDao = new TintaDao();
                foreach(Tinta tinta in importar.importarJSON(openDialog.FileName)){
                    tDao.inserir(tinta);
                }
            }
        }
    }
}
