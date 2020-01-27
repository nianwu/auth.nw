using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace mysqltest
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            using var db = new TestDbContext();
            var users = await db.Users.ToListAsync();
            Console.WriteLine(users.Count);
        }
    }
}
