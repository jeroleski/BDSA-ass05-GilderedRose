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

                //ALL items selling days will decrease
                //exept Sulfuras which never has to be sold
                if (! item.IsSulfuras())
                {
                    item.SellIn -= 1;
                }
                
                //Aged Brie increases in quality
                if (item.IsAgedBrie())
                {
                    item.ChangeQuality(1);
                }//Backstage passes increases in quality
                else if (item.IsBackstagePass())
                {
                    //But after the concert the quality will drop to 0
                    if (item.SellIn < 0)
                    {
                        item.Quality = 0;
                    }//If the concert is within 5 days the quality rises by 3
                    else if (item.SellIn <= 5)
                    {
                        item.ChangeQuality(3);
                    }//If the concert is within 10 days the quality rises by 2
                    else if (item.SellIn <= 10)
                    {
                        item.ChangeQuality(2);
                    }//If there are more than 10 days to the concert he quality only rises by 1
                    else
                    {
                        item.ChangeQuality(1);
                    }
                }//Conjured items degrade double from standart items
                else if (item.IsConjured())
                {   //But only if they are not expired
                    if (! item.IsExpired())
                    {
                        item.ChangeQuality(-2);
                    }//For they decrease even more if they are
                    else
                    {
                        item.ChangeQuality(-4);
                    }
                }//NORMAL items, which decreases in value
                else if (! item.IsSulfuras())
                {   //Before they expire
                    if (! item.IsExpired())
                    {
                        item.ChangeQuality(-1);
                    } //and double after they expuire
                    else
                    {
                        item.ChangeQuality(-2);
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

            var table = makeDashes(longestName + longestSellIn + longestQuality + 2) + "\n";
            table += extendString("Item Name", longestName, true) + "|" + 
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
                if (front) return s + new string(' ', length - s.Length);
                else return new string(' ', length - s.Length) + s;
            }

            string makeDashes(int length) => new string('-', length);
        }
    }
}