using System.Data.SqlClient;

namespace IMDBInsert
{
    public interface IInserter
    {
        void InsertTitles(SqlConnection sqlConn, List<Title> allTitles);
    }
}