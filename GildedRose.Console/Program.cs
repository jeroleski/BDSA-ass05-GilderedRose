﻿using System.Collections.Generic;

namespace GildedRose.Console
{
    static class Program
    {
        static void Main(string[] args)
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

            app.UpdateQuality();

            System.Console.WriteLine(app.ToString());

            System.Console.ReadKey();
        }

        public static void ChangeQuality(this Item item, int amount)
        {
            int newQuality = item.Quality + amount;
            if (newQuality >= 0 && newQuality <= 50) {item.Quality = newQuality;}
            else {
                if (newQuality > 50) {item.Quality = 50;}
                if (newQuality < 0) {item.Quality = 0;}
            }
        }
        public static bool IsAgedBrie(this Item item) => item.Name.ToLower().Contains("aged brie");
        public static bool IsBackstagePass(this Item item) => item.Name.ToLower().Contains("backstage pass");
        public static bool IsSulfuras(this Item item) => item.Name.ToLower().Contains("sulfuras");
        public static bool IsConjured(this Item item) => item.Name.ToLower().Contains("conjured");

        public static bool IsExpired(this Item item) => item.SellIn < 0;
    }
}