using Xunit;
using GildedRose.Console;
using System.Collections.Generic;

namespace GildedRose.Tests
{
    public class TestSulfuras
    {
        [Fact]
        public void Conjured_quality_drops_by_2_when_updating_1_time()
        {
            var inn = new Inn() {
                Items = new List<Item> {
                    new Item{Name = "Conjured Mana Cake", SellIn = 4, Quality = 7}
                }
            };

            inn.UpdateQuality();

            Assert.Equal(5, inn.Items[0].Quality);
        }

        [Fact]
        public void Conjured_quality_drops_by_6_when_updating_3_times()
        {
            var inn = new Inn() {
                Items = new List<Item> {
                    new Item{Name = "Conjured Mana Cake", SellIn = 4, Quality = 7}
                }
            };

            inn.UpdateQuality();
            inn.UpdateQuality();
            inn.UpdateQuality();


            Assert.Equal(1, inn.Items[0].Quality);
        }

        [Fact]
        public void Conjured_quality_wont_drop_below_0()
        {
            var inn = new Inn() {
                Items = new List<Item> {
                    new Item{Name = "Conjured Mana Cake", SellIn = 4, Quality = 7}
                }
            };

            inn.UpdateQuality();
            inn.UpdateQuality();
            inn.UpdateQuality();
            inn.UpdateQuality();

            Assert.Equal(0, inn.Items[0].Quality);
        }

        [Fact]
        public void Conjured_quality_drops_double_when_expired()
        {
            var inn = new Inn() {
                Items = new List<Item> {
                    new Item{Name = "Conjured Mana Cake", SellIn = 0, Quality = 20}
                }
            };

            inn.UpdateQuality();

            Assert.Equal(16, inn.Items[0].Quality);
        }
    }
}