using IMDBInsert;
using System.Data.SqlClient;

Console.WriteLine("Press 1 for delete, 2 for normal insert, 3 for prepared insert");
string action = Console.ReadLine();


DateTime before = DateTime.Now;
List<Title> titles = new List<Title>();
foreach (string line in System.IO.File.ReadLines(@"C:\temp\title.basics.tsv\data.tsv")
    .Skip(1).Take(10000))
{
    string[] values = line.Split('\t');
    if (values.Length == 9)
    {
        int endYear = 0;
        bool canParse = int.TryParse(values[6], out endYear);
        int? actualEndYear = null;
        if (endYear != 0)
        {
            actualEndYear = endYear;
        }

        titles.Add(new Title()
        {
            tconst = values[0],
            primaryTitle = values[2],
            originalTitle = values[3],
            startYear = int.Parse(values[5]),
            endYear = actualEndYear
        });

    }
}
DateTime after = DateTime.Now;

Console.WriteLine("Read lines in : " + (after - before));

Console.WriteLine("Amount of titles: " + titles.Count());

before = DateTime.Now;

using (SqlConnection sqlConn = new SqlConnection(
    "server=localhost;database=IMDB;User ID=imdbuser;password=superSecret"))
{
    sqlConn.Open();

    switch (action)
    {
        case "1":
            DeleteTitles(sqlConn);
            break;
        case "2":
            IInserter inserter = new NormalInserter();
            inserter.InsertTitles(sqlConn, titles);
            break;
        case "3":
            IInserter inserter2 = new PreparedInserter();
            inserter2.InsertTitles(sqlConn, titles);
            break;
    }
    DeleteTitles(sqlConn);
}
after = DateTime.Now;

Console.WriteLine("Inserted in : " + (after - before));

void DeleteTitles(SqlConnection sqlConn)
{
    SqlCommand sqlComm = new SqlCommand("DELETE FROM Titles", sqlConn);
    sqlComm.ExecuteNonQuery();
}