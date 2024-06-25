using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Windows;

namespace dz13._05
{
    public partial class Window1 : Window
    {
        private string _connectionString;

        public Window1(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;
            LoadData(_connectionString);
        }

        private void LoadData(string connectionString)
        {
            List<Product> products = new List<Product>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT ID, Name, [Type], Color, Calories FROM Products", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Product product = new Product
                        {
                            ID = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Type = reader.GetString(2),
                            Color = reader.GetString(3),
                            Calories = reader.GetInt32(4)
                        };
                        products.Add(product);
                    }
                    reader.Close();
                }
                ProductsGrid.ItemsSource = products;
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message, "SQL Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public class Product
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Type { get; set; }
            public string Color { get; set; }
            public int Calories { get; set; }
        }
    }
}
