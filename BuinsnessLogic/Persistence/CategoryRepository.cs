using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuinsnessLogic.Models;

namespace BuinsnessLogic.Persistence
{
    public class CategoryRepository : IRepository<Category>
    {
        public List<Category> CategoryList { get; set; } = new List<Category>();
        private string connectionString;

        public CategoryRepository(string connectionString)
        {
            this.connectionString = connectionString;
            loadAllEntitys();
        }

        public int? Add(Category category)
        {
            int? result = -1;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string table = "CATEGORY";
                string coloumns = "CATEGORY.CategoryName";
                string values = "@QuestionDescription, @Difficulty";
                string commandText =
                    $"INSERT INTO {table} ({coloumns})" +
                    $"VALUES ({values})";

                using (SqlCommand cmd = new SqlCommand(commandText, con))
                {
                    cmd.Parameters.Add("@CategoryName", SqlDbType.NVarChar).Value = category.CategoryName;
                    category.CategoryID = Convert.ToInt32(cmd.ExecuteScalar());
                    result = category.CategoryID;
                }

                CategoryList.Add(category);

                return result;
            }
        }

        public void Delete(int? entityID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            return CategoryList;
        }

        public Category GetByID(int? entityID)
        {
            throw new NotImplementedException();
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }
        private void loadAllEntitys()
        {
            using(SqlConnection con = new(connectionString))
            {
                string table = "CATEGORY";
                string values = "CATEGORY.CategoryID, CATEGORY.CategoryName";
                string CommandText = $"SELECT {values} FROM {table}";

                con.Open();
                SqlCommand sQLCommand = new(CommandText, con);
                using (SqlDataReader reader = sQLCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int? categoryID = int.Parse(reader["CategoryID"].ToString());
                        string categoryName = reader["CategoryName"].ToString();

                        CategoryList.Add(new Category(categoryID, categoryName));
                    }
                }

            }
        }
    }
}
