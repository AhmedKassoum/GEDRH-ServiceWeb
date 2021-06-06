using DSSGEDAdmin.Models.Entities;
using DSSGEDAdmin.Utilities.DataAccess;
using DSSGEDAdmin.Utilities.DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace DSSGEDAdmin.Models.DAL
{
    public class DAL_Document
    {
        // Add document
        public static void Add(Document document)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string StrSQL = "INSERT INTO Document (IdDocumentType, IdDocumentFolder, Reference, Title,FilePath,HasHardCopy,AddingDate,Langage,Tags,Description,CustomFields) VALUES(@IdDocumentType,@IdDocumentFolder, @Reference,@Title,@FilePath,@HasHardCopy,@AddingDate,@Langage,@Tags,@Description,@CustomFields)";
                SqlCommand cmd = new SqlCommand(StrSQL, con);
                cmd.Parameters.AddWithValue("@IdDocumentType", document.IdDocumentType);
                cmd.Parameters.AddWithValue("@IdDocumentFolder", document.IdDocumentFolder);
                cmd.Parameters.AddWithValue("@Reference", document.Reference);
                cmd.Parameters.AddWithValue("@Title", document.Title ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@FilePath", document.FilePath ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@HasHardCopy", document.HasHardCopy ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@AddingDate", document.AddingDate);
                cmd.Parameters.AddWithValue("@Langage", document.Langage ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Tags", document.Tags ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Description", document.Description ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@CustomFields", document.CustomFields ?? (object)DBNull.Value);
                DataBaseAccessUtilities.NonQueryRequest(cmd);
            }
        }
        // Update Document
        public static void Update(int id, Document document)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string StrSQL = "UPDATE Document SET Title=@Title,FilePath=@FilePath, AddingDate=@AddingDate ,HasHardCopy=@HasHardCopy,Langage=@Langage WHERE Id = @CurId";
                SqlCommand cmd = new SqlCommand(StrSQL, con);
                cmd.Parameters.AddWithValue("@CurId", id);
                cmd.Parameters.AddWithValue("@Title", document.Title ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@FilePath", document.FilePath ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@HasHardCopy", document.HasHardCopy ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Langage", document.Langage ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@AddingDate", document.AddingDate);
                DataBaseAccessUtilities.NonQueryRequest(cmd);
            }
        }
        // Delete document
        public static void Delete(int id)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string StrSQL = "DELETE FROM Document WHERE Id=" + id;
                SqlCommand command = new SqlCommand(StrSQL, con);
                DataBaseAccessUtilities.NonQueryRequest(command);
            }
        }
        public static void DeleteByDocument(int id)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string StrSQL = "DELETE FROM Document WHERE IdDocumentFolder=" + id;
                SqlCommand command = new SqlCommand(StrSQL, con);
                DataBaseAccessUtilities.NonQueryRequest(command);
            }
        }
        // select one record of table document
        public static Document SelectById(int id)
        {
            Document document = new Document();

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    string StrSQL = "SELECT * FROM Document WHERE Id = @Id";
                    SqlCommand command = new SqlCommand(StrSQL, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    SqlDataReader rdr = command.ExecuteReader();
                    if (rdr.Read())
                    {
                        document.Id = Convert.ToInt32(rdr["Id"]);
                        document.IdDocumentType = Convert.ToInt32(rdr["IdDocumentType"]);
                        document.IdDocumentFolder = Convert.ToInt32(rdr["IdDocumentFolder"]);
                        document.Reference = rdr["Reference"].ToString();
                        document.Title = rdr["Title"].ToString();
                        document.FilePath = rdr["FilePath"].ToString();
                        document.HasHardCopy = rdr["HasHardCopy"].ToString();
                        document.AddingDate = Convert.ToDateTime(rdr["AddingDate"]);
                        document.Langage = rdr["Langage"].ToString();
                        document.Tags = rdr["Tags"].ToString();
                        document.Description = rdr["Description"].ToString();
                        document.CustomFields = rdr["CustomFields"].ToString();
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
            return document;
        }

        public static Document GetEntityFromDataRow(DataRow dataRow)
        {
            Document document = new Document();
            document = new Document();
            document.Id = Convert.ToInt32(dataRow["Id"]);
            document.IdDocumentType = Convert.ToInt32(dataRow["IdDocumentType"]);
            document.IdDocumentFolder = Convert.ToInt32(dataRow["IdDocumentFolder"]);
            document.Reference = dataRow["Reference"].ToString();
            document.Title = dataRow["Title"].ToString();
            document.FilePath = dataRow["FilePath"].ToString();
            document.HasHardCopy = dataRow["HasHardCopy"].ToString();
            document.AddingDate = Convert.ToDateTime(dataRow["AddingDate"]);
            document.Langage = dataRow["Langage"].ToString();
            document.Tags = dataRow["Tags"].ToString();
            document.Description = dataRow["Description"].ToString();
            document.CustomFields = dataRow["CustomFields"].ToString();
            document.DocType = DAL_DocumentType.SelectById(document.IdDocumentType);
            document.Folder = DAL_Folder.SelectById(document.IdDocumentFolder);
            return document;
        }

        public static List<Document> GetListFromDataTable(DataTable dt)
        {
            List<Document> list = new List<Document>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                    list.Add(GetEntityFromDataRow(dr));
            }
            return list;
        }

        // select all record of table document
        public static List<Document> SelectAll()
        {
            List<Document> lstDocument = new List<Document>();
            DataTable dataTable;
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    string StrSQL = "SELECT * FROM Document";
                    SqlCommand command = new SqlCommand(StrSQL, connection);
                    dataTable = DataBaseAccessUtilities.SelectRequest(command);
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

            return GetListFromDataTable(dataTable);
        }

        public static List<Document> SelectByPersonId(int Id)
        {
            List<Document> lstDocument = new List<Document>();
            DataTable dataTable;
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    string StrSQL = "select Document.Id,Document.Title,Document.Reference,Document.MediaType,Document.FileFormat,Document.FilePath,Document.HasHardCopy,Document.AddingDate,Document.Langage,Document.Tags,Document.IdDocumentFolder,Document.IdDocumentType,Document.Description,Document.CustomFields  from Document,Folder where Document.IdDocumentFolder=Folder.Id and Folder.IdPerson=@IdPerson";
                    SqlCommand command = new SqlCommand(StrSQL, connection);
                    command.Parameters.AddWithValue("@Idperson", Id);
                    dataTable = DataBaseAccessUtilities.SelectRequest(command);
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

            return GetListFromDataTable(dataTable);
        }

        // select all record of table document with Id Folder selected
        public static List<Document> SelectAllDocumentByFolder(int IdFolder)
        {
            List<Document> lstDocument = new List<Document>();
            DataTable dataTable;
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    string StrSQL = "SELECT * FROM Document WHERE IdDocumentFolder = @IdFolder";
                    SqlCommand command = new SqlCommand(StrSQL, connection);
                    command.Parameters.AddWithValue("@IdFolder", IdFolder);
                    dataTable = DataBaseAccessUtilities.SelectRequest(command);
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
            return GetListFromDataTable(dataTable);
        }

        public static List<Document> SelectAllDocumentByDocType(int IdDocType)
        {
            List<Document> lstDocument = new List<Document>();
            DataTable dataTable;
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    string StrSQL = "SELECT * FROM Document WHERE IdDocumentType = @IdDocumentType";
                    SqlCommand command = new SqlCommand(StrSQL, connection);
                    command.Parameters.AddWithValue("@IdDocumentType", IdDocType);
                    dataTable = DataBaseAccessUtilities.SelectRequest(command);
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
            return GetListFromDataTable(dataTable);
        }

        public static List<Document> SelectAllByFolderAndDocType(int IdDocType, int IdFolder)
        {
            List<Document> lstDocument = new List<Document>();
            DataTable dataTable;
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    string StrSQL = "SELECT * FROM Document WHERE IdDocumentType = @IdDocumentType and IdDocumentFolder=@IdDocumentFolder";
                    SqlCommand command = new SqlCommand(StrSQL, connection);
                    command.Parameters.AddWithValue("@IdDocumentType", IdDocType);
                    command.Parameters.AddWithValue("@IdDocumentFolder", IdFolder);
                    dataTable = DataBaseAccessUtilities.SelectRequest(command);
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
            return GetListFromDataTable(dataTable);
        }
    }
}
