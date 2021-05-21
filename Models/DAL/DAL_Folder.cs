using DSSGEDAdmin.Models.Entities;
using DSSGEDAdmin.Utilities.DataAccess;
using DSSGEDAdmin.Utilities.DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace DSSGEDAdmin.Models.DAL
{
    public class DAL_Folder
    {
        // Add folder
        public static void Add(Folder folder)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string StrSQL = "INSERT INTO Folder (Name,PathName,Description,IdPerson) VALUES(@Name,@PathName,@Description, @IdPerson)";
                SqlCommand cmd = new SqlCommand(StrSQL, con);
                cmd.Parameters.AddWithValue("@Name", folder.Name ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@PathName", folder.PathName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Description", folder.Description ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@IdPerson", folder.IdPerson);
                DataBaseAccessUtilities.NonQueryRequest(cmd);
            }
        }
        // Update folder
        public static void Update(int id,Folder folder)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string StrSQL = "UPDATE Folder SET Name=@Name,PathName=@PathName,Description=@Description WHERE Id = @CurId";
                SqlCommand cmd = new SqlCommand(StrSQL, con);
                cmd.Parameters.AddWithValue("@CurId", id);
                cmd.Parameters.AddWithValue("@Name", folder.Name ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@PathName", folder.PathName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Description", folder.Description ?? (object)DBNull.Value);
                DataBaseAccessUtilities.NonQueryRequest(cmd);
            }
        }
        // Delete folder
        public static void Delete(int id)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string StrSQL = "DELETE FROM Folder WHERE Id=" + id;
                SqlCommand command = new SqlCommand(StrSQL, con);
                DataBaseAccessUtilities.NonQueryRequest(command);
            }
        }

        public static void DeleteByPerson(int id)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string StrSQL = "DELETE FROM Folder WHERE IdPerson=" + id;
                SqlCommand command = new SqlCommand(StrSQL, con);
                DataBaseAccessUtilities.NonQueryRequest(command);
            }
        }
        // delete All Sub-Folder
        public static void DeleteGetChildsFolder(int pid)
        {
            SqlConnection con = null;
            try
            {
                using (con = DBConnection.GetConnection())
                {
                    con.Open();
                    string StrSQL = "SELECT Id FROM Folder WHERE IdParent=" + pid;
                    SqlCommand cmd = new SqlCommand(StrSQL, con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    int CurId;
                    if (dr != null)
                    {
                        while (dr.Read())
                        {
                            CurId = dr.GetInt32(0);
                            Delete(CurId);
                            DeleteGetChildsFolder(CurId);
                        }

                    }
                   
                }
            }
            catch (Exception ex)
            {
                throw new MyException("Erreur de la base de données", ex.Message, "DAL");
            }
            finally
            {
                con.Close();
            }
        }
        // select one record of table folder
        public static Folder SelectById(int id)
        {
            Folder folder = new Folder();

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    string StrSQL = "SELECT * FROM Folder WHERE Id = @Id";
                    SqlCommand command = new SqlCommand(StrSQL, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        folder.Id = Convert.ToInt32(dataReader["Id"]);
                        folder.Name = dataReader["Name"].ToString();
                        folder.Description = dataReader["Description"].ToString();
                        folder.IdPerson = Convert.ToInt32(dataReader["IdPerson"]);
                        folder.PathName = dataReader["PathName"].ToString();
                    }
                }
                catch (SqlException e)
                {
                    throw new MyException(e, "Database Error", e.Message, "DAL");
                }
                finally
                {
                    connection.Close();
                }
            }
            return folder;
        }
        // select all record of table folder
        public static List<Folder> SelectAll()
        {
            List<Folder> lstFolder = new List<Folder>();
            Folder folder;
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    string StrSQL = "SELECT * FROM Folder ORDER BY Name ASC";
                    SqlCommand command = new SqlCommand(StrSQL, connection);
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        folder = new Folder();
                        folder.Id = Convert.ToInt32(dataReader["Id"]);
                        folder.Name = dataReader["Name"].ToString();
                        folder.Description = dataReader["Description"].ToString();
                        folder.IdPerson = Convert.ToInt32(dataReader["IdPerson"]);
                        folder.PathName = dataReader["PathName"].ToString();
                        lstFolder.Add(folder);
                    }
                }
                catch (SqlException e)
                {
                    throw new MyException(e, "Erreur de la base de données", e.Message, "DAL");
                }
                finally
                {
                    connection.Close();
                }
            }
            return lstFolder;
        }

        public static List<Folder> SelectByPerson(int Id)
        {
            List<Folder> lstFolder = new List<Folder>();
            Folder folder;
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    string StrSQL = "SELECT * FROM Folder WHERE IdPerson=@IdPerson ORDER BY Name ASC";
                    SqlCommand command = new SqlCommand(StrSQL, connection);
                    command.Parameters.AddWithValue("@IdPerson", Id);
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        folder = new Folder();
                        folder.Id = Convert.ToInt32(dataReader["Id"]);
                        folder.Name = dataReader["Name"].ToString();
                        folder.Description = dataReader["Description"].ToString();
                        folder.IdPerson = Convert.ToInt32(dataReader["IdPerson"]);
                        folder.PathName = dataReader["PathName"].ToString();
                        lstFolder.Add(folder);
                    }
                }
                catch (SqlException e)
                {
                    throw new MyException(e, "Erreur de la base de données", e.Message, "DAL");
                }
                finally
                {
                    connection.Close();
                }
            }
            return lstFolder;
        }
        // Get Parent
        private static int GetParent(int id)
        {
            int idParent = 0;
            using (SqlConnection con = DBConnection.GetConnection())
            {
                con.Open();
                string StrSQL = "SELECT IdParent FROM Folder WHERE Id=" + id;
                SqlCommand cmd = new SqlCommand(StrSQL, con);
                idParent = Convert.ToInt32(DataBaseAccessUtilities.ScalarRequest(cmd));
            }
            return idParent;
        }
        // Get List Parent of Id folder Selected
        public static List<int> GetParents(int id)
        {
            bool Flag = true;
            int CurId = id;
            List<int> IdParents = new List<int>();
            while (Flag == true)
            {
                CurId = GetParent(CurId);
                if (CurId != 0)
                    IdParents.Add(CurId);
                else
                    Flag = false;
            }
            return IdParents;
        }
        // Get List Childs of Id folder Selected
        public static void GetChilds(int pid, List<int> IdChilds)
        {
            SqlConnection con = null;
            try
            {
                using (con = DBConnection.GetConnection())
                {
                    con.Open();
                    string StrSQL = "SELECT Id FROM Folder WHERE IdParent=" + pid;
                    SqlCommand cmd = new SqlCommand(StrSQL, con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    int CurId;
                    if (dr != null)
                    {
                        while (dr.Read())
                        {
                            CurId = dr.GetInt32(0);
                            IdChilds.Add(CurId);
                            GetChilds(CurId, IdChilds);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw new MyException(ex, "Erreur de la base de données", ex.Message, "DAL");
            }
            finally
            {
                con.Close();
            }
        }
    }
}
