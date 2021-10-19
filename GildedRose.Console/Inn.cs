using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Inn
    {
        public IList<Item> Items {get; init;}

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                var item = Items[i];
                //NORMAL items, which decreases in value
                if (! item.IsAgedBrie() && ! item.IsBackstagePass())
                {   //Sulfuras never decreases
                    if (! item.IsSulfuras())
                    {   //Standard degrades
                        //Extension method checks for non-negative setting
                        item.ChangeQuality(-1);
                    }
                }
                else
                {   //Standart Special items quality increaese
                    item.ChangeQuality(1);
                    
                    //Backstage passes has extra quality increases
                    if (item.IsBackstagePass())
                    {   //If the concert is within 10 days
                        if (item.SellIn <= 10)
                        {   //The quality rises by 2 (the one before and this one)
                            item.ChangeQuality(1);
                            
                        }
                        //If the concert is within 5 days
                        if (item.SellIn <= 5)
                        {   //The quality rises by 3 (two before and this one)
                            item.ChangeQuality(1);
                        }
                    }
                }
                
                //Conjured items degrade double (one extra amount)
                if (item.IsConjured())
                {
                    item.ChangeQuality(-1);
                }

                //ALL items selling days will decrease
                //exept Sulfuras which never has to be sold
                if (! item.IsSulfuras())
                {
                    item.SellIn -= 1;
                }
                
                //If a experation date is expired
                if (item.IsExpired())
                {   //And it is not Aged Brie
                    if (! item.IsAgedBrie())
                    {   //And it is not Backstage Passes
                        if (! item.IsBackstagePass())
                        {   //And the item is not Sulfuras
                            if (! item.IsSulfuras())
                            {   //The quality decreases an extra amount
                                item.ChangeQuality(-1);
                                
                                //Conjured items furthermore decreases double (-4 total) if it it is expired
                                if (item.IsConjured())
                                {
                                    item.ChangeQuality(-1);
                                }
                            }
                            
                        }   //For Backstage Passes
                        else
                        {   //The quality will drop to 0
                            item.Quality = 0;
                        }
                    }   //For Aged Brie
                    else
                    {   //Quality rises after experation
                        item.ChangeQuality(1);
                    }
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