using Xunit;
using GildedRose.Console;
using System.Collections.Generic;

namespace GildedRose.Tests
{
    public class TestSulfuras
    {
        [Fact]
        public void Sulfuras_quality_never_drops()
        {
            var inn = new Inn() {
                Items = new List<Item> {
                    new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 2, Quality = 80}
                }
            };

            inn.UpdateQuality();
            inn.UpdateQuality();

            Assert.Equal(80, inn.Items[0].Quality);
        }

        [Fact]
        public void Sulfuras_SellIn_never_drops()
        {
            var inn = new Inn() {
                Items = new List<Item> {
                    new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 2, Quality = 80}
                }
            };

            inn.UpdateQuality();

            Assert.Equal(2, inn.Items[0].SellIn);
        }
    }
}