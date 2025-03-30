using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AccesoDatos
{
    public partial class SQLServer : Form
    {
        private void EjecutaComando(string ConsultaSQL)
        {
            try
            {
                string strConn = $"Server={Servidor};" +
                    $"Database={Basedatos};" +
                    $"User Id={UsuarioId};" +
                    $"Password={Password}";

                SqlConnection conn = new SqlConnection(strConn);
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = ConsultaSQL;
                cmd.ExecuteNonQuery();


                llenarGrid();

            }
            catch (SqlException Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error en el sistema");
            }
        }
        private void llenarGrid()
        {
            try
            {
                string strConn = $"Server={Servidor};" +
                    $"Database={Basedatos};" +
                    $"User Id={UsuarioId};" +
                    $"Password={Password}";

                SqlConnection conn = new SqlConnection(strConn);
                conn.Open();

                string sqlQuery = "select * from Alumnos";
                SqlDataAdapter adp = new SqlDataAdapter(sqlQuery, conn);

                DataSet ds = new DataSet();
                adp.Fill(ds, "Alumnos");
                dgvAlumnos.DataSource = ds.Tables[0];
            }



            catch (SqlException Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error en el sistema");
            }
        }

        private string Servidor = "ERIC\\SQLEXPRESS2024";
        private string Basedatos = "ESCOLAR";
        private string UsuarioId = "sa";
        private string Password = "madridfc12";
        public SQLServer()
        {
            InitializeComponent();
        }

        private void SQLServer_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                string strConn = $"Server={Servidor};" +
                    $"Database=master;" +
                    $"User Id={UsuarioId};" +
                    $"Password={Password}";


                SqlConnection conn = new SqlConnection(strConn);
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "CREATE DATABASE ESCOLAR";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Base de datos creada");
            }
            catch (SqlException Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error en el sistema");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                EjecutaComando("CREATE TABLE " +
                        "Alumnos (NoControl varchar(10), Nombre varchar(50), Carrera int)");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNoControl.Text.Trim().Length > 0 &&
                    txtNombre.Text.Trim().Length > 0 &&
                    txtCarrera.Text.Trim().Length > 0)
                {
                    string strConn = $"Server={Servidor};" +
                        $"Database={Basedatos};" +
                        $"User Id={UsuarioId};" +
                        $"Password={Password}";


                    SqlConnection conn = new SqlConnection(strConn);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO " +
                        "Alumnos (NoControl, nombre, carrera) " +
                        "VALUES ('" + txtNoControl.Text +
                        "', '" + txtNombre.Text +
                        "', " + txtCarrera.Text + ")";
                    cmd.ExecuteNonQuery();

                    llenarGrid();
                }
                else { }
            }
            catch (Exception Ex) { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            llenarGrid();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAlumnos.SelectedRows.Count > 0) // Verificar que hay una fila seleccionada
                {
                    // Obtener los datos de la fila seleccionada
                    DataGridViewRow selectedRow = dgvAlumnos.SelectedRows[0];
                    string noControl = selectedRow.Cells["NoControl"].Value.ToString();

                    // Verificar que los campos de texto tengan datos
                    if (txtNoControl.Text.Trim().Length > 0 &&
                        txtNombre.Text.Trim().Length > 0 &&
                        txtCarrera.Text.Trim().Length > 0)
                    {
                        string strConn = $"Server={Servidor};" +
                            $"Database={Basedatos};" +
                            $"User Id={UsuarioId};" +
                            $"Password={Password}";

                        using (SqlConnection conn = new SqlConnection(strConn))
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = conn;
                            cmd.CommandText = "UPDATE Alumnos " +
                                               "SET Nombre = @Nombre, Carrera = @Carrera " +
                                               "WHERE NoControl = @NoControl";

                            // Usar parámetros para evitar SQL injection
                            cmd.Parameters.AddWithValue("@NoControl", txtNoControl.Text);
                            cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                            cmd.Parameters.AddWithValue("@Carrera", txtCarrera.Text);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Registro actualizado correctamente");
                                llenarGrid();
                            }
                            else
                            {
                                MessageBox.Show("No se encontró el registro a actualizar");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor complete todos los campos");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor seleccione un registro para actualizar");
                }
            }
            catch (SqlException Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error en el sistema: " + Ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Verifica que haya una fila seleccionada en el DataGridView
            if (dgvAlumnos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un alumno para borrar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtiene el NoControl del registro seleccionado
            string noControl = dgvAlumnos.SelectedRows[0].Cells["NoControl"].Value.ToString();

            // Pide confirmación antes de borrar
            DialogResult respuesta = MessageBox.Show(
                $"¿Estás seguro de borrar al alumno con No. Control {noControl}?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta != DialogResult.Yes) return;

            try
            {
                string strConn = $"Server={Servidor};Database={Basedatos};User Id={UsuarioId};Password={Password};";

                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    conn.Open();

                    // Consulta SQL con parámetros (evita SQL Injection)
                    string query = "DELETE FROM Alumnos WHERE NoControl = @NoControl";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NoControl", noControl);
                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Alumno borrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            llenarGrid(); // Actualiza el DataGridView
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el alumno.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error de SQL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }}

        private void button7_Click(object sender, EventArgs e)
        {
            string criterioBusqueda = txtNoControl.Text.Trim();

            if (string.IsNullOrEmpty(criterioBusqueda))
            {
                MessageBox.Show("Ingresa un criterio de búsqueda.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string strConn = $"Server={Servidor};Database={Basedatos};User Id={UsuarioId};Password={Password};";

                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    conn.Open();

                    // Consulta SQL con parámetros (búsqueda flexible)
                    string query = @"
                SELECT * FROM Alumnos 
                WHERE NoControl LIKE @Criterio OR 
                      Nombre LIKE @Criterio
            ";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@Criterio", $"%{criterioBusqueda}%");

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Mostrar resultados en el DataGridView
                    dgvAlumnos.DataSource = dt;

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No se encontraron coincidencias.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error de SQL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    } }

