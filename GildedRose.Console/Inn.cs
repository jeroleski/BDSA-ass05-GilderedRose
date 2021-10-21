using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace GildedRose.Console
{
    public class Inn
    {

        public static IList<Item> testList;
        public IList<Item> Items;
        public static void Main(string[] args)
        {

            System.Console.WriteLine("OMGHAI!");
            var app = new Inn()
            {
                Items = new List<Item>
                                          {
                                              new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                                              new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                                              new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                                              new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                              new Item
                                                  {
                                                      Name = "Backstage passes to a TAFKAL80ETC concert",
                                                      SellIn = 15,
                                                      Quality = 20
                                                  },
                                              new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                                          }

            };




            int updateTimes = 1;
            try
            {
                string input = System.Console.ReadLine();
                updateTimes = Int32.Parse(input);

            }
            catch (Exception)
            {

            }
            for (int i = 0; i < updateTimes; i++)
            {
                app.UpdateQuality();
                System.Console.WriteLine(app.ToString());
            }
            testList = app.Items;

        }


        public void UpdateQuality()
        {
            foreach (Item items in Items)
            {


                if (items.Name.Contains("Conjured"))
                {
                    items.Quality -= 2;
                    items.SellIn--;

                }
                else if (items.Name.Contains("Backstage passes to a"))
                {


                    if (items.SellIn <= 5)
                    {
                        items.Quality += 3;
                    }
                    else if (items.SellIn <= 10)
                    {
                        items.Quality += 2;
                    }
                    else
                    {
                        items.Quality++;
                    }
                    items.SellIn--;
                    if (items.SellIn <= 0)
                    {
                        items.Quality = 0;
                    }
                }
                else if (items.Name.Equals("Sulfuras, Hand of Ragnaros"))
                {
                    // no changes in this items quality  
                }
                else if (items.Name.Equals("Aged Brie"))
                {
                    items.Quality++;
                    items.SellIn--;
                    if (items.SellIn < 0)
                    {
                        items.Quality++;
                    }
                }
                else
                {
                    items.Quality--;
                    items.SellIn--;
                }

                if (items.Name != "Sulfuras, Hand of Ragnaros" && items.Quality > 50)
                {
                    items.Quality = 50;
                }
                else if (items.Quality < 0)
                {
                    items.Quality = 0;
                }

            }

        }


        public override string ToString()
        {
            var longestName = 9;
            var longestSellIn = 7;
            var longestQuality = 7;
            for (var i = 1; i < Items.Count; i++)
            {
                if (Items[i].Name.Length > longestName) longestName = Items[i].Name.Length;
                if (("" + Items[i].SellIn).Length > longestSellIn) longestSellIn = ("" + Items[i].SellIn).Length;
                if (("" + Items[i].Quality).Length > longestQuality) longestQuality = ("" + Items[i].Quality).Length;
            }

            var table = makeDashes(longestName + longestSellIn + longestQuality + 2) + "\n";
            table += extendString("Item Name", longestName, true) + "|" +
                     extendString("Sell In", longestSellIn, true) + "|" +
                     extendString("Quality", longestQuality, true) + "\n";
            table += makeDashes(longestName + longestSellIn + longestQuality + 2) + "\n";
            for (var i = 0; i < Items.Count; i++)
            {
                table += extendString(Items[i].Name, longestName, true) + "|" +
                         extendString("" + Items[i].SellIn, longestSellIn, false) + "|" +
                         extendString("" + Items[i].Quality, longestQuality, false) + "\n";
            }
            table += makeDashes(longestName + longestSellIn + longestQuality + 2) + "\n";

            return table;

            string extendString(string s, int length, bool front)
            {
                if (front) return s + new string(' ', length - s.Length);
                else return new string(' ', length - s.Length) + s;
            }

            string makeDashes(int length) => new string('-', length);
        }





    }






    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }


}