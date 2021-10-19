using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Item
    {
        public string Name { get; set; }
        
        public int SellIn { get; set; }
        
        public int Quality { get; set; }
        /*public string Name { get; init; }

        public int SellIn {
            get {return SellIn;}
            set {if (value >= 0) {SellIn = value;}}
            }
        
        public int Quality {
            get {return Quality;}
            set {if (value >= 0 && value <= 50) {Quality = value;}
                else {
                    if (value > 50) {Quality = 50;}
                    if (value < 0) {Quality = 0;}
                }}
            }*/
    }

}