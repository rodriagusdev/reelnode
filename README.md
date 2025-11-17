# Reelnode

# Todo List



 try
        {
            conn.Open();

            string query = "SELECT * FROM tu_tabla";

            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dataGridView1.DataSource = dt; // Mostrar en DataGridView
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message);
        }
