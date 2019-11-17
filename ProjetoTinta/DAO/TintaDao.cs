using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using ProjetoTinta.Modelos;
using System.Windows;

namespace ProjetoTinta.DAO
{
    public class TintaDao
    {
        private MySqlConnection conn;
        private String connectionString = ConfigurationManager.ConnectionStrings["banco"].ConnectionString;

        public List<Tinta> listar()
        {
            List<Tinta> listaTintas = new List<Tinta>();
            try
            {
                conn = new MySqlConnection(connectionString);
                conn.Open();
                String query = "SELECT * FROM tintas";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Prepare();
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Tinta tinta = new Tinta()
                    {
                        Marca = Convert.ToString(dr["Marca"]),
                        Cor = Convert.ToString(dr["Cor"]),
                        Preco = Convert.ToDecimal(dr["Preco"]),
                    };
                    listaTintas.Add(tinta);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return listaTintas;
        }
        public void inserir(Tinta tinta)
        {
            conn = new MySqlConnection(connectionString);
            conn.Open();
            String query = "INSERT INTO tintas (cor, marca, preco) VALUES  (@cor,@marca,@preco)";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@cor", tinta.Cor);
            cmd.Parameters.AddWithValue("@marca", tinta.Marca);
            cmd.Parameters.AddWithValue("@preco", tinta.Preco);

            cmd.ExecuteNonQuery();
            conn.Close();

        }
    }
}
