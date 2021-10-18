using System.Collections.Generic;

namespace GildedRose.Console
{
    class Program
    {
        IList<Item> Items;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
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

            app.UpdateQuality();

            System.Console.ReadKey();

        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {   //NORMAL items, which decreases in value
                if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                {   //only if the quality is positive
                    if (Items[i].Quality > 0)
                    {   //Sulfuras never decreases
                        if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                        {   //Standard degrades
                            Items[i].Quality = Items[i].Quality - 1;
                        }
                    }
                }
                else
                {   //A quality can never extend 50
                    if (Items[i].Quality < 50)
                    {   //Standart Special items quality increaese
                        Items[i].Quality = Items[i].Quality + 1;
                        
                        //Backstage passes has extra quality increases
                        if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                        {   //If the concert is within 10 days
                            if (Items[i].SellIn < 11)
                            {
                                if (Items[i].Quality < 50)
                                {   //The quality rises by 2 (the one before and this one)
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }
                            //If the concert is within 5 days
                            if (Items[i].SellIn < 6)
                            {
                                if (Items[i].Quality < 50)
                                {   //The quality rises by 3 (two before and this one)
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                //ALL items selling days will decrease
                //exept Sulfuras never has to be sold
                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }
                
                //If a experation date is expired
                if (Items[i].SellIn < 0)
                {   //And it is not Aged Brie
                    if (Items[i].Name != "Aged Brie")
                    {   //And it is not Backstage Passes
                        if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                        {   //And the quality is still positive
                            if (Items[i].Quality > 0)
                            {   //And the item is not Sulfuras
                                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                                {   //The quality decreases an extra amount
                                    Items[i].Quality = Items[i].Quality - 1;
                                }
                            }
                        }   //For Backstage Passes
                        else
                        {   //The quality will drop to 0
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }   //For Aged Brie
                    else
                    {
                        if (Items[i].Quality < 50)
                        {   //Aged Brie quality rises after experation
                            Items[i].Quality = Items[i].Quality + 1;
                        }
                    }
                }
            }
        }

    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}