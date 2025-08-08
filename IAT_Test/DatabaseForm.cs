using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace IAT_Test
{
    public partial class DatabaseForm : Form
    {
        private DataTable table;
        private string selectedTable;

        public DatabaseForm()
        {
            InitializeComponent();
        }

        private void DatabasseForm_Load(object sender, EventArgs e)
        {
            LoadTableList();
        }

        private void LoadTableList()
        {
            try
            {
                using (var conn = new NpgsqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    conn.Open();
                    string sql = @"
                        SELECT table_name 
                        FROM information_schema.tables 
                        WHERE table_schema = 'public'
                        ORDER BY table_name";

                    using (var cmd = new NpgsqlCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        comboBoxTables.Items.Clear();
                        while (reader.Read())
                        {
                            comboBoxTables.Items.Add(reader.GetString(0));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки списка таблиц: {ex.Message}");
            }
        }

        private void comboBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTable = comboBoxTables.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedTable))
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            if (string.IsNullOrEmpty(selectedTable)) return;

            try
            {
                using (var conn = new NpgsqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand($"SELECT * FROM \"{selectedTable}\"", conn))
                    using (var adapter = new NpgsqlDataAdapter(cmd))
                    {
                        table = new DataTable();
                        adapter.Fill(table);
                        dataGridView.DataSource = table;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedTable)) return;

            try
            {
                using (var conn = new NpgsqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    conn.Open();

                    foreach (DataRow row in table.Rows)
                    {
                        if (row.RowState == DataRowState.Modified)
                        {
                            // Формируем SQL для обновления всех столбцов динамически
                            var columns = table.Columns;
                            var setParts = "";
                            foreach (DataColumn col in columns)
                            {
                                if (col.ColumnName == "id") continue;
                                setParts += $"{col.ColumnName}=@{col.ColumnName}, ";
                            }
                            setParts = setParts.TrimEnd(',', ' ');

                            string updateQuery = $"UPDATE \"{selectedTable}\" SET {setParts} WHERE id=@id";

                            using (var cmd = new NpgsqlCommand(updateQuery, conn))
                            {
                                foreach (DataColumn col in columns)
                                {
                                    cmd.Parameters.AddWithValue(col.ColumnName,
                                        row[col] == DBNull.Value ? (object)DBNull.Value : row[col]);
                                }
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    MessageBox.Show("Изменения сохранены.");
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0 || string.IsNullOrEmpty(selectedTable))
            {
                MessageBox.Show("Выберите строку для удаления.");
                return;
            }

            int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["id"].Value);

            if (MessageBox.Show("Удалить выбранную запись?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (var conn = new NpgsqlConnection(DatabaseHelper.GetConnectionString()))
                    {
                        conn.Open();
                        using (var cmd = new NpgsqlCommand($"DELETE FROM \"{selectedTable}\" WHERE id=@id", conn))
                        {
                            cmd.Parameters.AddWithValue("id", id);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Запись удалена.");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении: {ex.Message}");
                }
            }
        }
    }
}
