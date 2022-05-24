using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BuinsnessLogic.Models;

namespace BuinsnessLogic.Persistence
{
    public class CategoryRepository : IRepository<Category>
    {

        //=========================================================================
        // Fields & Properties
        //=========================================================================

        public List<Category> CategoryList { get; set; }
        private string connectionString;

        //=========================================================================
        // Constructors
        //=========================================================================

        public CategoryRepository(string connectionString)
        {
            this.connectionString = connectionString;
            CategoryList = new List<Category>();
            loadAllEntitys();
        }

        //=========================================================================
        // Add (CRUD: Create)
        // Adds a category to the database
        //=========================================================================

        public int? Add(Category category)
        {
            int? result = -1;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string table = "CATEGORY";
                string coloumns = "CATEGORY.CategoryName";
                string values = "@CategoryName";
                string commandText =
                    $"INSERT INTO {table} ({coloumns})" +
                    $"VALUES ({values})" +
                    $"SELECT @@IDENTITY";

                using (SqlCommand cmd = new SqlCommand(commandText, con))
                {
                    cmd.Parameters.Add("@CategoryName", SqlDbType.NVarChar).Value = category.CategoryName;
                    category.CategoryID = Convert.ToInt32(cmd.ExecuteScalar());
                    result = category.CategoryID;
                }

                CategoryList.Add(category);
            }
            return result;
        }

        //=========================================================================
        // GetAll (CRUD: Read)
        // Returns all category objects from the list
        //=========================================================================

        public IEnumerable<Category> GetAll()
        {
            return CategoryList;
        }

        //=========================================================================
        // GetByID (CRUD: Read)
        // Returns a specific category object.
        //=========================================================================

        public Category GetByID(int? categoryID)
        {
            Category result = null;

            foreach (Category category in CategoryList)
            {
                if (category.CategoryID.Equals(categoryID))
                {
                    result = category;
                    break;
                }
            }
            return result;
        }

        //=========================================================================
        // Update (CRUD: Update)
        // Updates an already existing category in the database
        //=========================================================================

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }

        //=========================================================================
        // Delete (CRUD: Delete)
        // Removes a catorgy from the database
        //=========================================================================

        public void Delete(int? categoryID)
        {
            throw new NotImplementedException();
        }

        //=========================================================================
        // LoadAllEnitys (CRUD: Update)
        // Loads all entities from the database table CATEGORY
        //=========================================================================

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
