using ProjetoTinta.DAO;
using ProjetoTinta.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjetoTinta.Servicos
{
    public class ImportarExportar
    {
        public void exportarJSON()
        {
            TintaDao tDao = new TintaDao();

            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<Tinta>));
            diretorioExiste();
            FileStream fs = new FileStream(@"C:\BelasArtes\tintas.json", FileMode.OpenOrCreate);
            ser.WriteObject(fs, tDao.listar());
            fs.Close();
            MessageBox.Show("JSON gerado com sucesso!");
        }

        public List<Tinta> importarJSON(string FileName)
        {
            List<Tinta> tintas = new List<Tinta>();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<Tinta>));
            FileStream fs = new FileStream(@FileName, FileMode.OpenOrCreate);
            tintas = (List<Tinta>)ser.ReadObject(fs);
            fs.Close();
            return tintas;
        }

        private void diretorioExiste()
        {
            string diretorio = @"C:\BelasArtes";

            if (!Directory.Exists(diretorio))
            {
                Directory.CreateDirectory(diretorio);

            }

        }
    }
}
