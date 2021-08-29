using System;
using System.Linq;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsoleTestAppBd
{
    public class Program
    {
        static void Main(string[] args)
        {
            User c;
            Console.WriteLine("Hi");
            var context = new SocialNetworkDbContextFactory().CreateDbContext(new []{""});
            c = context.Users.FirstOrDefault();
            Console.WriteLine("Hi1");
            Console.WriteLine($"User: {c?.FirstName}");
        }
    }
}
