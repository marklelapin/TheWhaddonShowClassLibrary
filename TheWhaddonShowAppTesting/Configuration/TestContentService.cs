using Microsoft.VisualStudio.TestPlatform.Utilities;
using MyClassLibrary.Extensions;
using MyClassLibrary.LocalServerMethods;
using MyClassLibrary.Tests.LocalServerMethods;
using MyClassLibrary.Tests.LocalServerMethods.Interfaces;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWhaddonShowClassLibrary.Models;

namespace TheWhaddonShowTesting.Configuration
{
    public class TestContentService<T> : ITestContent<T> where T : LocalServerIdentityUpdate
    {

        public List<List<T>> Generate(int quantity, string testType = "Default", List<Guid>? overrideIds = null, DateTime? overrideCreated = null)
        {
            List<List<T>> output = new List<List<T>>();

            for (int i = 0; i < quantity; i++)
            {
                List<Guid> draftIds = overrideIds ?? GenerateDraftIds(20);
                draftIds.Sort((x, y) => x.CompareTo(y));
                output.Add(GenerateList(testType, draftIds, overrideCreated));

                CreationDelay(200); //ensures that each new lists don't have the same created datetime which they might if not left in.
            }

            return output;
        }

        public List<Guid> ListIds(List<T> updates)
        {
            return updates.Select(x => x.Id).ToList();
        }

        private List<Guid> GenerateDraftIds(int quantity)
        {
            return Guid.NewGuid().GenerateList(quantity);
        }


        private List<T> GenerateList(string testType, List<Guid> draftIds, DateTime? overrideCreated = null)
        {
            DateTime DateNow = overrideCreated ?? DateTime.Now;

            DateTime created = new DateTime(DateNow.Year, DateNow.Month, DateNow.Day, DateNow.Hour, DateNow.Minute, DateNow.Second, 0, DateTimeKind.Unspecified);

            switch (typeof(T).Name)
            {
                case "TestUpdate": return ConvertToListT(GenerateTestUpdateLists(testType, draftIds, created));

                case "PartUpdate": return ConvertToListT(GeneratePartUpdateLists(testType, draftIds, created));

                case "PersonUpdate": return ConvertToListT(GeneratePersonUpdateLists(testType, draftIds, created));

                case "ScriptItemUpdate": return ConvertToListT(GenerateScriptItemUpdateLists(testType, draftIds, created));

                default: throw new NotImplementedException("The update type doesn't appear in the GeneratList function of WhaddowShow_TestContentService");
            };
        }

        private List<T> ConvertToListT<S>(List<S> listToConvert)
        {
            string json = JsonSerializer.Serialize(listToConvert);

            List<T> output = JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();

            return output;
        }

        private List<TestUpdate> GenerateTestUpdateLists(string testType, List<Guid> draftIds, DateTime createdDate)
        {
            List<TestUpdate> output;

            switch (testType)
            {
                case "Default":

                    output = new List<TestUpdate>()
                        {
                            new TestUpdate(draftIds[1], createdDate, "mcarter", DateTime.Parse("2023-03-01 09:02:00.000"), true, "Bob", "Hoskins", DateTime.Parse("1934-05-02 00:00:00.000"), new List<string> { "Chips", "Strawberries" }),
                            new TestUpdate(draftIds[1], createdDate.AddSeconds(1), "mcarter", DateTime.Parse("2023-03-02 09:02:00.000"), true, "Bob", "Hoskins", DateTime.Parse("1934-05-02 00:00:00.000"), new List<string> { "Chips" }),
                            new TestUpdate(draftIds[1], createdDate.AddSeconds(2), "mcarter", DateTime.Parse("2023-04-01 09:02:00.000"), true, "Bob", "Hoskins", DateTime.Parse("1956-12-24 00:00:00.000"), new List<string> { "Chips", "Strawberries", "Tiramisu" }),
                            new TestUpdate(draftIds[2], createdDate.AddSeconds(3), "mcarter", DateTime.Parse("2023-03-01 09:02:00.000"), true, "Tracey", "Emin", DateTime.Parse("1999-12-31 00:00:00.000"), new List<string> { "Cake" }),
                            new TestUpdate(draftIds[2], createdDate.AddSeconds(4), "mcarter", null, false, "Tracey", "Emin", DateTime.Parse("1999-12-31 00:00:00.000"), new List<string> { "Cake" }),
                            new TestUpdate(draftIds[3], createdDate.AddSeconds(5), "mcarter", null, true, "Jim", "Broadbent", DateTime.Parse("2010-06-04 00:00:00.000"), new List<string> { "Peas","Carrots" }),
                            new TestUpdate(draftIds[4], createdDate.AddSeconds(6), "mcarter", null, true, "Mark", "Carter", DateTime.Parse("1978-07-02 00:00:00.000"), new List<string> { "Burger","Chicken","Chocolate" }),
                            new TestUpdate(draftIds[4], createdDate.AddSeconds(7), "mcarter", null, true, "Mark", "Carter", DateTime.Parse("1978-07-02 00:00:00.000"), new List<string> { "Burger","Chicken","Chocolate","Lindor Balls" })
                        };
                    break;

                case "Unsorted":
                    output = new List<TestUpdate>()
                            {
                                new TestUpdate(draftIds[1], createdDate, "mcarter", DateTime.Parse("2023-03-01 09:02:00.000"), true, "Bob", "Hoskins", DateTime.Parse("1934-05-02 00:00:00.000"), new List<string> { "Chips", "Strawberries" }),
                                new TestUpdate(draftIds[1], createdDate.AddSeconds(2), "mcarter", DateTime.Parse("2023-04-01 09:02:00.000"), true, "Bob", "Hoskins", DateTime.Parse("1956-12-24 00:00:00.000"), new List<string> { "Chips", "Strawberries", "Tiramisu" }),
                                new TestUpdate(draftIds[2], createdDate.AddSeconds(3), "mcarter", DateTime.Parse("2023-03-01 09:02:00.000"), true, "Tracey", "Emin", DateTime.Parse("1999-12-31 00:00:00.000"), new List<string> { "Cake" }),
                                new TestUpdate(draftIds[3], createdDate.AddSeconds(5), "mcarter", null, true, "Jim", "Broadbent", DateTime.Parse("2010-06-04 00:00:00.000"), new List<string> { "Peas","Carrots" }),
                                new TestUpdate(draftIds[4], createdDate.AddSeconds(6), "mcarter", null, true, "Mark", "Carter", DateTime.Parse("1978-07-02 00:00:00.000"), new List<string> { "Burger","Chicken","Chocolate" }),
                                new TestUpdate(draftIds[4], createdDate.AddSeconds(7), "mcarter", null, true, "Mark", "Carter", DateTime.Parse("1978-07-02 00:00:00.000"), new List<string> { "Burger","Chicken","Chocolate","Lindor Balls" }),
                                new TestUpdate(draftIds[2], createdDate.AddSeconds(4), "mcarter", null, false, "Tracey", "Emin", DateTime.Parse("1999-12-31 00:00:00.000"), new List<string> { "Cake" }),
                                new TestUpdate(draftIds[1], createdDate.AddSeconds(8), "mcarter", DateTime.Parse("2023-03-02 09:02:00.000"), true, "Bob", "Hoskins", DateTime.Parse("1934-05-02 00:00:00.000"), new List<string> { "Raspberries" }),
                                new TestUpdate(draftIds[1], createdDate.AddSeconds(1), "mcarter", DateTime.Parse("2023-03-02 09:02:00.000"), true, "Bob", "Hoskins", DateTime.Parse("1934-05-02 00:00:00.000"), new List<string> { "Chips" })
                             };
                    break;
                case "SortedByCreated":
                    output = new List<TestUpdate>()
                            {
                                new TestUpdate(draftIds[1], createdDate, "mcarter", DateTime.Parse("2023-03-01 09:02:00.000"), true, "Bob", "Hoskins", DateTime.Parse("1934-05-02 00:00:00.000"), new List<string> { "Chips", "Strawberries" }),
                                new TestUpdate(draftIds[1], createdDate.AddSeconds(1), "mcarter", DateTime.Parse("2023-03-02 09:02:00.000"), true, "Bob", "Hoskins", DateTime.Parse("1934-05-02 00:00:00.000"), new List<string> { "Chips" }),
                                new TestUpdate(draftIds[1], createdDate.AddSeconds(2), "mcarter", DateTime.Parse("2023-04-01 09:02:00.000"), true, "Bob", "Hoskins", DateTime.Parse("1956-12-24 00:00:00.000"), new List<string> { "Chips", "Strawberries", "Tiramisu" }),
                                new TestUpdate(draftIds[2], createdDate.AddSeconds(3), "mcarter", DateTime.Parse("2023-03-01 09:02:00.000"), true, "Tracey", "Emin", DateTime.Parse("1999-12-31 00:00:00.000"), new List<string> { "Cake" }),
                                new TestUpdate(draftIds[2], createdDate.AddSeconds(4), "mcarter", null, false, "Tracey", "Emin", DateTime.Parse("1999-12-31 00:00:00.000"), new List<string> { "Cake" }),
                                new TestUpdate(draftIds[3], createdDate.AddSeconds(5), "mcarter", null, true, "Jim", "Broadbent", DateTime.Parse("2010-06-04 00:00:00.000"), new List<string> { "Peas","Carrots" }),
                                new TestUpdate(draftIds[4], createdDate.AddSeconds(6), "mcarter", null, true, "Mark", "Carter", DateTime.Parse("1978-07-02 00:00:00.000"), new List<string> { "Burger","Chicken","Chocolate" }),
                                new TestUpdate(draftIds[4], createdDate.AddSeconds(7), "mcarter", null, true, "Mark", "Carter", DateTime.Parse("1978-07-02 00:00:00.000"), new List<string> { "Burger","Chicken","Chocolate","Lindor Balls" }),
                                new TestUpdate(draftIds[1], createdDate.AddSeconds(8), "mcarter", DateTime.Parse("2023-03-02 09:02:00.000"), true, "Bob", "Hoskins", DateTime.Parse("1934-05-02 00:00:00.000"), new List<string> { "Raspberries" })
                            };
                    break;
                case "SortedById":
                    output = new List<TestUpdate>()
                            {
                                new TestUpdate(draftIds[1], createdDate, "mcarter", DateTime.Parse("2023-03-01 09:02:00.000"), true, "Bob", "Hoskins", DateTime.Parse("1934-05-02 00:00:00.000"), new List<string> { "Chips", "Strawberries" }),
                                new TestUpdate(draftIds[1], createdDate.AddSeconds(2), "mcarter", DateTime.Parse("2023-04-01 09:02:00.000"), true, "Bob", "Hoskins", DateTime.Parse("1956-12-24 00:00:00.000"), new List<string> { "Chips", "Strawberries", "Tiramisu" }),
                                new TestUpdate(draftIds[1], createdDate.AddSeconds(8), "mcarter", DateTime.Parse("2023-03-02 09:02:00.000"), true, "Bob", "Hoskins", DateTime.Parse("1934-05-02 00:00:00.000"), new List<string> { "Raspberries" }),
                                new TestUpdate(draftIds[1], createdDate.AddSeconds(1), "mcarter", DateTime.Parse("2023-03-02 09:02:00.000"), true, "Bob", "Hoskins", DateTime.Parse("1934-05-02 00:00:00.000"), new List<string> { "Chips" }),
                                new TestUpdate(draftIds[2], createdDate.AddSeconds(3), "mcarter", DateTime.Parse("2023-03-01 09:02:00.000"), true, "Tracey", "Emin", DateTime.Parse("1999-12-31 00:00:00.000"), new List<string> { "Cake" }),
                                new TestUpdate(draftIds[2], createdDate.AddSeconds(4), "mcarter", null, false, "Tracey", "Emin", DateTime.Parse("1999-12-31 00:00:00.000"), new List<string> { "Cake" }),
                                new TestUpdate(draftIds[3], createdDate.AddSeconds(5), "mcarter", null, true, "Jim", "Broadbent", DateTime.Parse("2010-06-04 00:00:00.000"), new List<string> { "Peas","Carrots" }),
                                new TestUpdate(draftIds[4], createdDate.AddSeconds(6), "mcarter", null, true, "Mark", "Carter", DateTime.Parse("1978-07-02 00:00:00.000"), new List<string> { "Burger","Chicken","Chocolate" }),
                                new TestUpdate(draftIds[4], createdDate.AddSeconds(7), "mcarter", null, true, "Mark", "Carter", DateTime.Parse("1978-07-02 00:00:00.000"), new List<string> { "Burger","Chicken","Chocolate","Lindor Balls" })
                            };
                    break;
                case "History":
                    output = new List<TestUpdate>()
                            {
                                new TestUpdate(draftIds[1], createdDate, "mcarter", DateTime.Parse("2023-03-01 09:02:00.000"), true, "Bob", "Hoskins", DateTime.Parse("1934-05-02 00:00:00.000"), new List<string> { "Chips", "Strawberries" }),
                                new TestUpdate(draftIds[1], createdDate.AddSeconds(1), "mcarter", DateTime.Parse("2023-03-02 09:02:00.000"), true, "Bob", "Hoskins", DateTime.Parse("1934-05-02 00:00:00.000"), new List<string> { "Chips" }),
                                new TestUpdate(draftIds[1], createdDate.AddSeconds(2), "mcarter", DateTime.Parse("2023-04-01 09:02:00.000"), true, "Bob", "Hoskins", DateTime.Parse("1956-12-24 00:00:00.000"), new List<string> { "Chips", "Strawberries", "Tiramisu" }),
                                new TestUpdate(draftIds[1], createdDate.AddSeconds(8), "mcarter", DateTime.Parse("2023-03-02 09:02:00.000"), true, "Bob", "Hoskins", DateTime.Parse("1934-05-02 00:00:00.000"), new List<string> { "Raspberries" }),
                                new TestUpdate(draftIds[2], createdDate.AddSeconds(3), "mcarter", DateTime.Parse("2023-03-01 09:02:00.000"), true, "Tracey", "Emin", DateTime.Parse("1999-12-31 00:00:00.000"), new List<string> { "Cake" }),
                                new TestUpdate(draftIds[2], createdDate.AddSeconds(4), "mcarter", null, false, "Tracey", "Emin", DateTime.Parse("1999-12-31 00:00:00.000"), new List<string> { "Cake" }),
                                new TestUpdate(draftIds[3], createdDate.AddSeconds(5), "mcarter", null, true, "Jim", "Broadbent", DateTime.Parse("2010-06-04 00:00:00.000"), new List<string> { "Peas","Carrots" }),
                                new TestUpdate(draftIds[4], createdDate.AddSeconds(6), "mcarter", null, true, "Mark", "Carter", DateTime.Parse("1978-07-02 00:00:00.000"), new List<string> { "Burger","Chicken","Chocolate" }),
                                new TestUpdate(draftIds[4], createdDate.AddSeconds(7), "mcarter", null, true, "Mark", "Carter", DateTime.Parse("1978-07-02 00:00:00.000"), new List<string> { "Burger","Chicken","Chocolate","Lindor Balls" })
                            };
                    break;
                case "Latest":
                    output = new List<TestUpdate>()
                            {
                                new TestUpdate(draftIds[1], createdDate.AddSeconds(8), "mcarter", DateTime.Parse("2023-03-02 09:02:00.000"), true, "Bob", "Hoskins", DateTime.Parse("1934-05-02 00:00:00.000"), new List<string> { "Raspberries" }),
                                 new TestUpdate(draftIds[3], createdDate.AddSeconds(5), "mcarter", null, true, "Jim", "Broadbent", DateTime.Parse("2010-06-04 00:00:00.000"), new List<string> { "Peas","Carrots" }),
                                new TestUpdate(draftIds[4], createdDate.AddSeconds(7), "mcarter", null, true, "Mark", "Carter", DateTime.Parse("1978-07-02 00:00:00.000"), new List<string> { "Burger","Chicken","Chocolate","Lindor Balls" })
                            };
                    break;
                case "SyncTesting":
                    output = new List<TestUpdate>()
                        {
                            new TestUpdate(draftIds[1], createdDate, "mcarter", null, true, "Bob", "Hoskins", DateTime.Parse("1934-05-02 00:00:00.000"), new List<string> { "Chips", "Strawberries" }),
                            new TestUpdate(draftIds[1], createdDate.AddSeconds(1), "mcarter", null, true, "Bob", "Hoskins", DateTime.Parse("1934-05-02 00:00:00.000"), new List<string> { "Chips" }),
                            new TestUpdate(draftIds[1], createdDate.AddSeconds(2), "mcarter", null, true, "Bob", "Hoskins", DateTime.Parse("1956-12-24 00:00:00.000"), new List<string> { "Chips", "Strawberries", "Tiramisu" }),
                            new TestUpdate(draftIds[2], createdDate.AddSeconds(3), "mcarter", null, true, "Tracey", "Emin", DateTime.Parse("1999-12-31 00:00:00.000"), new List<string> { "Cake" }),
                            new TestUpdate(draftIds[2], createdDate.AddSeconds(4), "mcarter", null, false, "Tracey", "Emin", DateTime.Parse("1999-12-31 00:00:00.000"), new List<string> { "Cake" }),
                            new TestUpdate(draftIds[3], createdDate.AddSeconds(5), "mcarter", null, true, "Jim", "Broadbent", DateTime.Parse("2010-06-04 00:00:00.000"), new List<string> { "Peas","Carrots" }),
                            new TestUpdate(draftIds[4], createdDate.AddSeconds(6), "mcarter", null, true, "Mark", "Carter", DateTime.Parse("1978-07-02 00:00:00.000"), new List<string> { "Burger","Chicken","Chocolate" }),
                            new TestUpdate(draftIds[4], createdDate.AddSeconds(7), "mcarter", null, true, "Mark", "Carter", DateTime.Parse("1978-07-02 00:00:00.000"), new List<string> { "Burger","Chicken","Chocolate","Lindor Balls" })
                        };
                    break;
                default: throw new NotImplementedException();
            }

            return output;

        }

        private List<PartUpdate> GeneratePartUpdateLists(string testType, List<Guid> draftIds, DateTime createdDate)
        {
            List<PartUpdate> output;

            switch (testType)
            {
                case "Default":

                    output = new List<PartUpdate>()
                    {
                            new PartUpdate(draftIds[1], createdDate              , "mcarter", DateTime.Parse("2023-03-01 09:02:00.000"), true , "Dellboy", new List<string> { "Trotter", "Main" }, Guid.NewGuid()),
                            new PartUpdate(draftIds[1], createdDate.AddSeconds(1), "mcarter", DateTime.Parse("2023-03-02 09:02:00.000"), true , "Dellboy", new List<string> { "Trotter", "Main" }, Guid.NewGuid()),
                            new PartUpdate(draftIds[1], createdDate.AddSeconds(2), "mcarter", DateTime.Parse("2023-04-01 09:02:00.000"), true , "Dellboy", new List<string> { "Trotter", "Main" }, Guid.NewGuid()),
                            new PartUpdate(draftIds[2], createdDate.AddSeconds(3), "mcarter", DateTime.Parse("2023-03-01 09:02:00.000"), true , "Rodney", new List<string> { "Trotter", "Main" }, Guid.NewGuid()),
                            new PartUpdate(draftIds[2], createdDate.AddSeconds(4), "mcarter", null                                     , false, "Rodney", new List<string> { "Trotter", "Side" }, Guid.NewGuid()),
                            new PartUpdate(draftIds[3], createdDate.AddSeconds(5), "mcarter", null                                     , true , "Uncle Albert", new List<string>()              , Guid.NewGuid()),
                            new PartUpdate(draftIds[4], createdDate.AddSeconds(6), "mcarter", null                                     , true , "Boycie", new List<string> { "Side" }           , Guid.NewGuid()),
                            new PartUpdate(draftIds[4], createdDate.AddSeconds(7), "mcarter", null                                     , true , "Boycie", new List<string> { "Side" }           , Guid.NewGuid())
                        };
                    break;

                default: throw new NotImplementedException();
            }

            return output;

        }


        private List<ScriptItemUpdate> GenerateScriptItemUpdateLists(string testType, List<Guid> draftIds, DateTime createdDate)
        {
            List<ScriptItemUpdate> output;

            switch (testType)
            {
                case "Default":

                    output = new List<ScriptItemUpdate>()
                    {
                            new ScriptItemUpdate(draftIds[1], createdDate              , "mcarter", DateTime.Parse("2023-03-01 09:02:00.000"), true , Guid.NewGuid(), 1, "Synopsis" ,"He said something",new List<Guid> { Guid.NewGuid() },null),
                            new ScriptItemUpdate(draftIds[1], createdDate.AddSeconds(1), "mcarter", DateTime.Parse("2023-03-02 09:02:00.000"), true , Guid.NewGuid(), 1, "Synopsis","He said something" ,new List<Guid> { Guid.NewGuid() },null),
                            new ScriptItemUpdate(draftIds[1], createdDate.AddSeconds(2), "mcarter", DateTime.Parse("2023-04-01 09:02:00.000"), true , Guid.NewGuid(), 1, "Synopsis","He said something" ,null,null),
                            new ScriptItemUpdate(draftIds[2], createdDate.AddSeconds(3), "mcarter", DateTime.Parse("2023-03-01 09:02:00.000"), true , Guid.Empty          , 2, "Dialogue" ,"No he didnt",new List<Guid> { Guid.NewGuid() },null),
                            new ScriptItemUpdate(draftIds[2], createdDate.AddSeconds(4), "mcarter", null                                     , false, Guid.Empty          , 1, "Action","yes he did"   ,new List<Guid> { Guid.NewGuid() },null),
                            new ScriptItemUpdate(draftIds[3], createdDate.AddSeconds(5), "mcarter", null                                     , true , Guid.NewGuid(), 3, "Action"   ,"He said something", null,null),
                            new ScriptItemUpdate(draftIds[4], createdDate.AddSeconds(6), "mcarter", null                                     , true , draftIds[2]   , 1, "Dialogue","He said something" ,null,new List<string> {"hello","goodbye"}),
                            new ScriptItemUpdate(draftIds[4], createdDate.AddSeconds(7), "mcarter", null                                     , true , draftIds[2]   , 4, "Dialogue","He said something" ,null, new List<string> {"hello","goodbye"})
                        };
                    break;

                default: throw new NotImplementedException();
            }

            return output;

        }


        private List<PersonUpdate> GeneratePersonUpdateLists(string testType, List<Guid> draftIds, DateTime createdDate)
        {
            List<PersonUpdate> output;

            switch (testType)
            {
                case "Default":

                    output = new List<PersonUpdate>()
                    {
                            new PersonUpdate(draftIds[1], createdDate              , "mcarter", DateTime.Parse("2023-03-01 09:02:00.000"), true , "Mark","Carter"    ,"marklelapin@hotmail.co.uk","sdfj", true,true,true,true,true, new List<string> { "Blah", "Male" }),
                            new PersonUpdate(draftIds[1], createdDate.AddSeconds(1), "mcarter", DateTime.Parse("2023-03-02 09:02:00.000"), true , "Mark","Carter"    ,"marklelapin@hotmail.co.uk",null  , true,true,null,true,true, new List<string> { "Blah", "Male" }),
                            new PersonUpdate(draftIds[1], createdDate.AddSeconds(2), "mcarter", DateTime.Parse("2023-04-01 09:02:00.000"), true , "Mark","Carter"    ,"marklelapin@hotmail.co.uk",null  , true,true,null,true,true, new List<string> { "Blah", "Male" }),
                            new PersonUpdate(draftIds[2], createdDate.AddSeconds(3), "mcarter", DateTime.Parse("2023-03-01 09:02:00.000"), true , "Shirley","Vincent",null                       ,null  , true,true,null,true,false,new List<string> { "Female", "Main" }),
                            new PersonUpdate(draftIds[2], createdDate.AddSeconds(4), "mcarter", null                                     , false, "Shirley","Vincent",null                       ,null  , true,true,true,true,true, new List<string> { "Female", "Side" }),
                            new PersonUpdate(draftIds[3], createdDate.AddSeconds(5), "mcarter", null                                     , true , "Richard","Boateng",null                       ,null  , null,null,null,null,null, null),
                            new PersonUpdate(draftIds[4], createdDate.AddSeconds(6), "mcarter", null                                     , true , "George",null      ,"danger@nuclearplant.co.uk",null  , true,true,true,true,true, new List<string> { "Vegetarian" }),
                            new PersonUpdate(draftIds[4], createdDate.AddSeconds(7), "mcarter", null                                     , true , "George",null      ,"danger@nuclearplant.co.uk",null  , null,true,true,true,true, new List<string> { "Vegetarian" })
                        };
                    break;

                default: throw new NotImplementedException();
            }

            return output;

        }




        async static private void CreationDelay(int milliSeconds)
        {
            await Task.Delay(milliSeconds);
        }

    }
}
