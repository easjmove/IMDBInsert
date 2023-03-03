using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBInsert
{
    public class EFInserter : IInserter

    {
        public void InsertTitles(SqlConnection sqlConn, List<Title> allTitles)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ImdbDBContext>();
            optionsBuilder.UseSqlServer(sqlConn.ConnectionString);
            ImdbDBContext context = new ImdbDBContext(optionsBuilder.Options);

            //foreach(Title title in allTitles)
            //{
            //    context.titles.Add(title);
            //}
            context.BulkInsert(allTitles);
        }
    }
}
