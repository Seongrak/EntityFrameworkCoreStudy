using EntiryFrameworkCoreStudy.Data;
using EntiryFrameworkCoreStudy.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntiryFrameworkCoreStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new EfStudyDbContext())
            {

                // Select
                // 1. DbSet<User> selectList = db.Users;
                // 2. var selectList = db.Users.ToList();
                // 3. IEnumerable<User> selectList = db.Users.AsEnumerable();
                // Linq to Sql
                // 4. IQueryable<User> selectList = from user in db.Users select user 

                // # IEnumerable vs IQueryable
                // Extension Query => available
                // Ienumberable => query => data => client(store) => slow ; can save server's cost
                // IQueryable => query => data => server(store) => fast ; might spend more server's cost

                List<User> selectList = db.Users.ToList();

                foreach (var item in selectList)
                {
                    Console.WriteLine(item.UserName);
                }

                // Insert
                // db.USers.Add(T);
                // db.SaveChange();

                db.Users.Add(new User
                {
                    UserId = 3,
                    UserName = "Mickey",
                    Birth="911111"
                }) ;

                db.SaveChanges();

                // Update
                // db.Entry(T).State = EntityState.Modified
                var user = new User { UserId = 1, UserName = "Rockie" }; // Rocky -> Rockie
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();

                // Delete
                var user2 = new User { UserId = 3 };
                db.Users.Remove(user2);
                db.SaveChanges();

                // .Where() - Store LIST!
                var list = db.Users.Where(u => u.UserName == "rocky");
                // When Only One Data Needed
                // .First(), .FirstOrDefault(), .Single(), .SingleOrDefault()
                // var user = db.Users.First(u => u.UserNAme =="rocky");

                // OrderBy()
                var list2 = db.Users.OrderBy(u => u.UserName).ToList();

                // JOIN
                var joinList = db.Users
                    .Include(u => u.Position)
                    .ToList();
                Console.WriteLine($"{user.UserId}, {user.Position.PositionName}");
              
            }
        }
    }


}
