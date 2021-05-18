//using DSSGEDAdmin.Models.Entities;
//using DSSGEDAdmin.Utilities.DataAccess;
//using DSSGEDAdmin.Utilities.DatabaseConnection;
//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Threading.Tasks;

//namespace DSSGEDAdmin.Models.DAL
//{
//    public class DAL_DocTypeCustomField
//    {
//        // Add DocTypeCustomField
//        public static void Add(DocTypeCustomField docTypeCustomField,string DBName)
//        {
//            using (SqlConnection con = DBConnection.GetConnection(DBName))
//            {
//                string StrSQL = "INSERT INTO DocTypeCustomField (Name, Type, AcceptNull,DefaultValue,IdDocumentType,ValueList) VALUES(@Name,@Type, @AcceptNull,@DefaultValue,@IdDocumentType,@ValueList)";
//                SqlCommand cmd = new SqlCommand(StrSQL, con);
//                cmd.Parameters.AddWithValue("@Name", docTypeCustomField.Name ?? (object)DBNull.Value);
//                cmd.Parameters.AddWithValue("@Type", docTypeCustomField.Type ?? (object)DBNull.Value);
//                cmd.Parameters.AddWithValue("@AcceptNull", docTypeCustomField.AcceptNull);
//                cmd.Parameters.AddWithValue("@DefaultValue", docTypeCustomField.DefaultValue ?? (object)DBNull.Value);
//                cmd.Parameters.AddWithValue("@IdDocumentType", docTypeCustomField.IdDocumentType);
//                cmd.Parameters.AddWithValue("@ValueList", docTypeCustomField.ValueList ?? (object)DBNull.Value);
//                DataBaseAccessUtilities.NonQueryRequest(cmd);
//            }
//        }
//        // Update DocTypeCustomField
//        public static void Update(int id, DocTypeCustomField docTypeCustomField,string DBName)
//        {
//            using (SqlConnection con = DBConnection.GetConnection(DBName))
//            {
//                string StrSQL = "UPDATE DocTypeCustomField SET Name=@Name, Type=@Type, AcceptNull=@AcceptNull,DefaultValue=@DefaultValue ,IdDocumentType=@IdDocumentType,ValueList=@ValueList WHERE Id = @CurId";
//                SqlCommand cmd = new SqlCommand(StrSQL, con);
//                cmd.Parameters.AddWithValue("@CurId", id);
//                cmd.Parameters.AddWithValue("@Name", docTypeCustomField.Name ?? (object)DBNull.Value);
//                cmd.Parameters.AddWithValue("@Type", docTypeCustomField.Type ?? (object)DBNull.Value);
//                cmd.Parameters.AddWithValue("@AcceptNull", docTypeCustomField.AcceptNull);
//                cmd.Parameters.AddWithValue("@DefaultValue", docTypeCustomField.DefaultValue ?? (object)DBNull.Value);
//                cmd.Parameters.AddWithValue("@IdDocumentType", docTypeCustomField.IdDocumentType);
//                cmd.Parameters.AddWithValue("@ValueList", docTypeCustomField.ValueList ?? (object)DBNull.Value);
//                DataBaseAccessUtilities.NonQueryRequest(cmd);
//            }
//        }
//        // Delete DocTypeCustomField
//        public static void Delete(int id,string DBName)
//        {
//            using (SqlConnection con = DBConnection.GetConnection(DBName))
//            {
//                string StrSQL = "DELETE FROM DocTypeCustomField WHERE Id=" + id;
//                SqlCommand command = new SqlCommand(StrSQL, con);
//                DataBaseAccessUtilities.NonQueryRequest(command);
//            }
//        }
//        // select one record of table DocTypeCustomField
//        public static DocTypeCustomField SelectById(int id,string DBName)
//        {
//            DocTypeCustomField docTypeCustomField = new DocTypeCustomField();

//            using (SqlConnection connection = DBConnection.GetConnection(DBName))
//            {
//                try
//                {
//                    connection.Open();
//                    string StrSQL = "SELECT * FROM DocTypeCustomField WHERE Id = @Id";
//                    SqlCommand command = new SqlCommand(StrSQL, connection);
//                    command.Parameters.AddWithValue("@Id", id);
//                    SqlDataReader dataReader = command.ExecuteReader();
//                    if (dataReader.Read())
//                    {
//                        docTypeCustomField.Id = Convert.ToInt32(dataReader["Id"]);
//                        docTypeCustomField.Name = dataReader["Name"].ToString();
//                        docTypeCustomField.Type = dataReader["Type"].ToString();
//                        docTypeCustomField.AcceptNull = Convert.ToBoolean(dataReader["AcceptNull"].ToString());
//                        docTypeCustomField.DefaultValue = dataReader["DefaultValue"].ToString();
//                        docTypeCustomField.IdDocumentType = Convert.ToInt32(dataReader["IdDocumentType"]);
//                        docTypeCustomField.ValueList = dataReader["ValueList"].ToString();
//                    }
//                }
//                catch (SqlException e)
//                {
//                    throw new MyException(e, "Database Error", e.Message, "DAL");
//                }
//                finally
//                {
//                    connection.Close();
//                }
//            }
//            return docTypeCustomField;
//        }
//        // select all record of table DocTypeCustomField
//        public static List<DocTypeCustomField> SelectAll(string DBName)
//        {
//            List<DocTypeCustomField> lstDocTypeCustomField = new List<DocTypeCustomField>();
//            DocTypeCustomField docTypeCustomField;
//            using (SqlConnection connection = DBConnection.GetConnection(DBName))
//            {
//                try
//                {
//                    connection.Open();
//                    string StrSQL = "SELECT * FROM DocTypeCustomField";
//                    SqlCommand command = new SqlCommand(StrSQL, connection);
//                    SqlDataReader dataReader = command.ExecuteReader();
//                    while (dataReader.Read())
//                    {
//                        docTypeCustomField = new DocTypeCustomField();
//                        docTypeCustomField.Id = Convert.ToInt32(dataReader["Id"]);
//                        docTypeCustomField.Name = dataReader["Name"].ToString();
//                        docTypeCustomField.Type = dataReader["Type"].ToString();
//                        docTypeCustomField.AcceptNull = Convert.ToBoolean(dataReader["AcceptNull"].ToString());
//                        docTypeCustomField.DefaultValue = dataReader["DefaultValue"].ToString();
//                        docTypeCustomField.IdDocumentType = Convert.ToInt32(dataReader["IdDocumentType"]);
//                        docTypeCustomField.ValueList = dataReader["ValueList"].ToString();
//                        lstDocTypeCustomField.Add(docTypeCustomField);
//                    }
//                }
//                catch (SqlException e)
//                {
//                    throw new MyException(e, "Erreur de la base de données", e.Message, "DAL");
//                }
//                finally
//                {
//                    connection.Close();
//                }
//            }
//            return lstDocTypeCustomField;
//        }
//    }
//}
