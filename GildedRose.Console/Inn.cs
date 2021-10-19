using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Inn
    {
        public IList<Item> Items {get; init;}

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
                            Items[i].Quality -= 1;
                        }
                    }
                }
                else
                {   //A quality can never extend 50
                    if (Items[i].Quality < 50)
                    {   //Standart Special items quality increaese
                        Items[i].Quality += 1;
                        
                        //Backstage passes has extra quality increases
                        if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                        {   //If the concert is within 10 days
                            if (Items[i].SellIn <= 10)
                            {
                                if (Items[i].Quality < 50)
                                {   //The quality rises by 2 (the one before and this one)
                                    Items[i].Quality += 1;
                                }
                            }
                            //If the concert is within 5 days
                            if (Items[i].SellIn <= 5)
                            {
                                if (Items[i].Quality < 50)
                                {   //The quality rises by 3 (two before and this one)
                                    Items[i].Quality += 1;
                                }
                            }
                        }
                    }
                }
                
                //Conjured items degrade double (one extra amount)
                if (Items[i].Name == "Conjured Mana Cake")
                {
                    if (Items[i].Quality > 0)
                    {
                        Items[i].Quality -= 1;
                    }
                }

                //ALL items selling days will decrease
                //exept Sulfuras which never has to be sold
                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].SellIn -= 1;
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
                                    Items[i].Quality -= 1;
                                    
                                    //Conjured items furthermore decreases double (-4 total) if it it is expired
                                    if (Items[i].Name == "Conjured Mana Cake")
                                    {
                                        if (Items[i].Quality > 0)
                                        {
                                            Items[i].Quality -= 1;
                                        }
                                    }
                                }
                            }
                        }   //For Backstage Passes
                        else
                        {   //The quality will drop to 0
                            Items[i].Quality = 0;
                        }
                    }   //For Aged Brie
                    else
                    {
                        if (Items[i].Quality < 50)
                        {   //Aged Brie quality rises after experation
                            Items[i].Quality += 1;
                        }
                    }
                }
            }
        }

        

        private bool IsAgedBrie(Item item) => item.Name.ToLower().Contains("aged brie");
        private bool IsBackstagePass(Item item) => item.Name.ToLower().Contains("backstage pass");
        private bool IsConjured(Item item) => item.Name.ToLower().Contains("conjured");

        public override string ToString()
        {
            var longestName = 9;
            var longestSellIn = 7;
            var longestQuality = 7;
            for (var i = 1; i < Items.Count; i++)
            {
                if (Items[i].Name.Length > longestName) longestName = Items[i].Name.Length;
                if ((""+Items[i].SellIn).Length > longestSellIn) longestSellIn = (""+Items[i].SellIn).Length;
                if ((""+Items[i].Quality).Length > longestQuality) longestQuality = (""+Items[i].Quality).Length;
            }

            var table = extendString("Item Name", longestName, true) + "|" + 
                        extendString("Sell In", longestSellIn, true) + "|" + 
                        extendString("Quality", longestQuality, true) + "\n";
            table += makeDashes(longestName + longestSellIn + longestQuality + 2) + "\n";
            for (var i = 0; i < Items.Count; i++)
            {
                table += extendString(Items[i].Name, longestName, true) + "|" + 
                        extendString(""+Items[i].SellIn, longestSellIn, false) + "|" + 
                        extendString(""+Items[i].Quality, longestQuality, false) + "\n";
            }
            table += makeDashes(longestName + longestSellIn + longestQuality + 2) + "\n";

            return table;

            string extendString(string s, int length, bool front)
            {
                if (front) return s + new string (' ', length - s.Length);
                else return new string (' ', length - s.Length) + s;
            }

            string makeDashes(int length) => new string('-', length);
        }
    }
}