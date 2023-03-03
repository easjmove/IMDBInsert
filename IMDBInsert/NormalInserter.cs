using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBInsert
{
    public class NormalInserter : IInserter
    {
        public void InsertTitles(SqlConnection sqlConn, List<Title> allTitles)
        {
            foreach (Title title in allTitles)
            {
                SqlCommand sqlComm = new SqlCommand(
                        "INSERT INTO [dbo].[Titles]([tconst],[primaryTitle]," +
                        "[originalTitle],[startYear],[endYear])" +
                        " VALUES (" +
                        "'" + title.tconst + "'," +
                        "'" + title.primaryTitle.Replace("'", "''") + "'," +
                        "'" + title.originalTitle.Replace("'", "''") + "'," +
                        "" + title.startYear + "," +
                        "" + (title.endYear is null ? "NULL" : title.endYear) + ");", sqlConn);
                sqlComm.ExecuteNonQuery();
            }
        }
    }
}
