using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banco_Dados
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;user=root;database=viagens;password=;");
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM t_veiculos", conn);
            //datatable  = armazena os resultados da consulta
            DataTable dt = new DataTable();
            conn.Open();

            //MySqlDataAdapter= preencher o datatable com os resultados da consulta
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();

            //vincule  data ao datagrid para exibir os dados na grade
            dataGridView1.DataSource= dt;
        }

        private void txtPesquisaBD_TextChanged(object sender, EventArgs e)
        {
            string pesquisa = txtPesquisaBD.Text;
            MySqlConnection conn = new MySqlConnection("server=localhost;user=root;database=viagens;password=;");
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM t_veiculos where modelo like '%"+pesquisa+"%'",conn);
            //datatable  = armazena os resultados da consulta
            DataTable dt = new DataTable();
            conn.Open();

            //MySqlDataAdapter= preencher o datatable com os resultados da consulta
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();

            //vincule  data ao datagrid para exibir os dados na grade
            dataGridView1.DataSource = dt;
        }
    }
}
