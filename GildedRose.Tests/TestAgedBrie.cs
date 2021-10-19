using Xunit;
using GildedRose.Console;
using System.Collections.Generic;

namespace GildedRose.Tests
{
    public class TestAgedBrie
    {
        [Fact]
        public void AgedBrie_quality_increases_by_1_when_updating_1_time()
        {
            var inn = new Inn() {
                Items = new List<Item> {
                    new Item{Name = "Aged Brie", SellIn = 4, Quality = 45}
                }
            };

            inn.UpdateQuality();

            Assert.Equal(46, inn.Items[0].Quality);
        }

        [Fact]
        public void AgedBrie_quality_increases_by_3_when_updating_3_times()
        {
            var inn = new Inn() {
                Items = new List<Item> {
                    new Item{Name = "Aged Brie", SellIn = 4, Quality = 45}
                }
            };

            inn.UpdateQuality();
            inn.UpdateQuality();
            inn.UpdateQuality();

            Assert.Equal(48, inn.Items[0].Quality);
        }

        [Fact]
        public void AgedBrie_quality_wont_increase_past_50()
        {
            var inn = new Inn() {
                Items = new List<Item> {
                    new Item{Name = "Aged Brie", SellIn = 4, Quality = 45}
                }
            };

            inn.UpdateQuality();
            inn.UpdateQuality();
            inn.UpdateQuality();
            inn.UpdateQuality();
            inn.UpdateQuality();
            inn.UpdateQuality();

            Assert.Equal(50, inn.Items[0].Quality);
        }
    }
}