using System;

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBInsert
{
    public class BulkInserter : IInserter
    {
        public void InsertTitles(SqlConnection sqlConn, List<Title> allTitles)
        {
            DataTable titleTable = new DataTable("Titles");

            titleTable.Columns.Add("tconst", typeof(string));
            titleTable.Columns.Add("primaryTitle", typeof(string));
            titleTable.Columns.Add("originalTitle", typeof(string));
            titleTable.Columns.Add("startYear", typeof(int));
            titleTable.Columns.Add("endYear", typeof(int));

            foreach (Title title in allTitles) { 
                DataRow titleRow = titleTable.NewRow();
                titleRow["tconst"] = title.tconst;
                titleRow["primaryTitle"] = title.primaryTitle;
                titleRow["originalTitle"] = title.originalTitle;
                if (title.startYear == null)
                {
                    titleRow["startYear"] = DBNull.Value;
                }
                else
                {
                    titleRow["startYear"] = title.startYear;
                }
                if (title.endYear == null)
                {
                    titleRow["endYear"] = DBNull.Value;
                } else
                {
                    titleRow["endYear"] = title.endYear;
                }

                titleTable.Rows.Add(titleRow);
            }
            SqlBulkCopy bulkCopy = new SqlBulkCopy(sqlConn, 
                SqlBulkCopyOptions.KeepNulls,null);
            bulkCopy.DestinationTableName = "Titles";
            bulkCopy.BulkCopyTimeout = 0;
            bulkCopy.WriteToServer(titleTable);
        }
    }
}
