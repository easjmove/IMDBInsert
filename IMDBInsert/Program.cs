using IMDBInsert;
using System.Data.SqlClient;

DateTime before = DateTime.Now;
List<Title> titles = new List<Title>();
foreach (string line in System.IO.File.ReadLines(@"C:\Users\zealand\Documents\lektor\title.basics.tsv")
    .Skip(1).Take(10000))
{
    string[] values = line.Split('\t');
    if (values.Length != 9)
    {
        titles.Add(new Title() { tconst = values[0],
            primaryTitle = values[2],
            originalTitle= values[3] });
    }
}
DateTime after = DateTime.Now;

Console.WriteLine(after - before);

SqlConnection sqlConn = new SqlConnection(
    "server=localhost;database=IMDB,User ID=imdbuser;password=superSecret");