using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBInsert
{
    public class PreparedInserter : IInserter
    {
        public void InsertTitles(SqlConnection sqlConn, List<Title> allTitles)
        {
            SqlCommand sqlComm = new SqlCommand(
                        "INSERT INTO [dbo].[Titles]([tconst],[primaryTitle]," +
                        "[originalTitle],[startYear],[endYear])" +
                        " VALUES (" +
                        "@tconst," +
                        "@primaryTitle," +
                        "@originalTitle," +
                        "@startYear," +
                        "@endYear);", sqlConn);

            SqlParameter tconstPar = new SqlParameter("@tconst", SqlDbType.Text, 50);
            sqlComm.Parameters.Add(tconstPar);

            SqlParameter primaryTitlePar = new SqlParameter("@primaryTitle", SqlDbType.Text, 250);
            sqlComm.Parameters.Add(primaryTitlePar);

            SqlParameter originalTitlePar = new SqlParameter("@originalTitle", SqlDbType.Text, 250);
            sqlComm.Parameters.Add(originalTitlePar);

            SqlParameter startYearPar = new SqlParameter("@startYear", SqlDbType.Int);
            sqlComm.Parameters.Add(startYearPar);

            SqlParameter endYearPar = new SqlParameter("@endYear", SqlDbType.Int);
            sqlComm.Parameters.Add(endYearPar);

            sqlComm.Prepare();

            foreach (Title title in allTitles)
            {
                tconstPar.Value = title.tconst;
                primaryTitlePar.Value = title.primaryTitle;
                originalTitlePar.Value = title.originalTitle;
                startYearPar.Value = title.startYear;
                if (title.endYear == null)
                {
                    endYearPar.Value = DBNull.Value;
                }
                else
                {
                    endYearPar.Value = title.endYear;
                }

                sqlComm.ExecuteNonQuery();
            }
        }
    }
}
