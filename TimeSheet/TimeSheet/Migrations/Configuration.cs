namespace TimeSheet.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TimeSheet.Models.dbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TimeSheet.Models.dbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Associates.AddOrUpdate(x => x.AssociateID,
                new Associate()
                {
                    AssociateID = 1,
                    FirstName = "Frank Herbert",
                    Address = "7 Bennegeserette Lake Rd.",
                    City = "Dune",
                    State = "California",
                    Zipcode = "90210",
                    PhoneNumber = "123-456-7891",
                    Email = "Paul@ Freeman.com",
                    ValidUser = 1
                },
                new Associate()
                {
                    AssociateID = 2,
                    FirstName = "J.R.R. Tolkien",
                    Address = "End of Bagshot Row",
                    City = "Hobbiton",
                    State = "The Shire",
                    Zipcode = "34913",
                    PhoneNumber = "123-456-7891",
                    Email = "valor@gondor.com",
                    ValidUser = 1
                },
                new Associate()
                {
                    AssociateID = 3,
                    FirstName = "George R. R. Martin",
                    Address = "Castle Black",
                    City = "The Wall",
                    State = "Westeros",
                    Zipcode = "34913",
                    PhoneNumber = "123-456-7891",
                    Email = "George@winteriscoming.com",
                    ValidUser = 1
                }

       );
           
            context.Clients.AddOrUpdate(x => x.ClientID,
                 new Client()
                 {
                     ClientID = 1,
                     CompanyName = "Lothlorien Health",
                     ContactName = "Galadriel",
                     Address = "LothLorian Forest",
                     State = "Middle Earth",
                     City = "Mound City",
                     Zipcode = "12345",
                     PhoneNumber = "435-243-5543",
                     Email = "Gandalf@Zazaddum.com"
                 },
                 new Client()
                 {
                     ClientID = 2,
                     CompanyName = "Backwater Health",
                     ContactName = "Jo Jo",
                     Address = "22 Styx Ave",
                     State = "Indiana",
                     City = "Small Town",
                     Zipcode = "12345",
                     PhoneNumber = "435-243-5543",
                     Email = "bh@run.com"
                 }
                 );
 
            
            context.TimeLogs.AddOrUpdate(x => x.LogID,
              new TimeLog()
              {
                  LogID = 1,
                  TimeStamp = DateTime.Now,
                  AssociateID = 1,
                  ClientID = 1,
                  WorkDate = DateTime.Now,
                  NumberHours = 52,
                  WorkType = "Abstract",
                  JobNote = "Nothing extraordinary"
              },
                new TimeLog()
                {
                    LogID = 2,
                    TimeStamp = DateTime.Now,
                    AssociateID = 3,
                    ClientID = 1,
                    WorkDate = DateTime.Now,
                    NumberHours = 27,
                    WorkType = "Abstract",
                    JobNote = "Nothing extraordinary"
                },
                new TimeLog()
                {
                    LogID = 3,
                    TimeStamp = DateTime.Now,
                    AssociateID = 2,
                    ClientID = 1,
                    WorkDate = DateTime.Now,
                    NumberHours = 15,
                    WorkType = "Abstract",
                    JobNote = "Nothing extraordinary"
                }
              );
        }
    }
}
