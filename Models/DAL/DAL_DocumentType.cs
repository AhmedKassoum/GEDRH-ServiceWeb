using DSSGEDAdmin.Models.Entities;
using DSSGEDAdmin.Utilities.DataAccess;
using DSSGEDAdmin.Utilities.DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DSSGEDAdmin.Models.DAL
{
    public class DAL_DocumentType
    {
        // Add DocumentType
        public static void Add(DocumentType documentType)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string StrSQL = "INSERT INTO DocumentType (Name,Description) VALUES(@Name,@Description)";
                SqlCommand cmd = new SqlCommand(StrSQL, con);
                cmd.Parameters.AddWithValue("@Name", documentType.Name ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Description", documentType.Description ?? (object)DBNull.Value);
                DataBaseAccessUtilities.NonQueryRequest(cmd);
            }
        }
        // Update DocumentType
        public static void Update(int id, DocumentType documentType)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string StrSQL = "UPDATE DocumentType SET  Name=@Name, Description=@Description WHERE Id = @CurId";
                SqlCommand cmd = new SqlCommand(StrSQL, con);
                cmd.Parameters.AddWithValue("@CurId", id);
                cmd.Parameters.AddWithValue("@Name", documentType.Name ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Description", documentType.Description ?? (object)DBNull.Value);
                DataBaseAccessUtilities.NonQueryRequest(cmd);
            }
        }
        // Delete DocumentType
        public static string Delete(int Id)
        {
            string message = "";
            int i = 0;
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    string StrSQL = "DELETE FROM DocumentType WHERE Id=@CurId AND Id NOT IN (SELECT IdDocumentType FROM Document)";
                    SqlCommand command = new SqlCommand(StrSQL, con);
                    command.Parameters.AddWithValue("@CurId", Id);
                    i = DataBaseAccessUtilities.NonQueryRequest(command);
                    if (i != 0)
                        message = "Supprimer avec succès";
                    else
                        message = "Ce Type de document contient des documents.";

                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return message;
        }
        // select one record of table DocumentType
        public static DocumentType SelectById(int id)
        {
            DocumentType documentType = new DocumentType();

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    string StrSQL = "SELECT * FROM DocumentType WHERE Id = @Id";
                    SqlCommand command = new SqlCommand(StrSQL, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        documentType.Id = Convert.ToInt32(dataReader["Id"]);
                        documentType.Name = dataReader["Name"].ToString();
                        documentType.Description = dataReader["Description"].ToString();
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
            return documentType;
        }
        // select all record of table DocumentType
        public static List<DocumentType> SelectAll()
        {
            List<DocumentType> lstDocumentType = new List<DocumentType>();
            DocumentType documentType;
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    string StrSQL = "SELECT * FROM DocumentType";
                    SqlCommand command = new SqlCommand(StrSQL, connection);
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        documentType = new DocumentType();
                        documentType.Id = Convert.ToInt32(dataReader["Id"]);
                        documentType.Name = dataReader["Name"].ToString();
                        documentType.Description = dataReader["Description"].ToString();
                        documentType.tabDocuments = new List<Document>();
                        documentType.tabDocuments = DAL_Document.SelectByDocType(documentType.Id);
                        lstDocumentType.Add(documentType);
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
            return lstDocumentType;
        }
    }
}
