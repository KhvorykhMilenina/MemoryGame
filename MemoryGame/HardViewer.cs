﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    public partial class HardViewer : Form
    {
        public HardViewer()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dt = new DataTable();

            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\MemoryGame-master\MemoryGame\EasyDatabase.mdf;Integrated Security=True";

            using (var cn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("Select Nickname, Score, Time_left From HardPeople Order by Score DESC", cn))
            {
                cn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);

                    dataGridView1.AutoSize = true; dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                    dataGridView1.DataSource = dt;
                }
            }
        }
    }
}
