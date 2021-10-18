using Xunit;
using GildedRose.Console;
using System.Collections.Generic;

namespace GildedRose.Tests
{
    public class TestBackstagePasses
    {
        [Fact]
        public void BackstagePasses_quality_increases_by_1_when_updating_1_time()
        {
            var inn = new Inn() {
                Items = new List<Item> {
                    new Item{Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 10}
                }
            };

            inn.UpdateQuality();

            Assert.Equal(11, inn.Items[0].Quality);
        }

        [Fact]
        public void BackstagePasses_quality_increases_by_3_when_updating_3_time()
        {
            var inn = new Inn() {
                Items = new List<Item> {
                    new Item{Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 10}
                }
            };

            inn.UpdateQuality();
            inn.UpdateQuality();
            inn.UpdateQuality();

            Assert.Equal(13, inn.Items[0].Quality);
        }

        [Fact]
        public void BackstagePasses_quality_wont_increase_past_50()
        {
            var inn = new Inn() {
                Items = new List<Item> {
                    new Item{Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 49}
                }
            };

            inn.UpdateQuality();
            inn.UpdateQuality();

            Assert.Equal(50, inn.Items[0].Quality);
        }

        [Fact]
        public void BackstagePasses_quality_increases_by_2_when_less_than_10_days_left()
        {
            var inn = new Inn() {
                Items = new List<Item> {
                    new Item{Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 8, Quality = 10}
                }
            };

            inn.UpdateQuality();

            Assert.Equal(12, inn.Items[0].Quality);
        }

        [Fact]
        public void BackstagePasses_quality_increases_by_3_when_less_than_5_days_left()
        {
            var inn = new Inn() {
                Items = new List<Item> {
                    new Item{Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 3, Quality = 10}
                }
            };

            inn.UpdateQuality();

            Assert.Equal(13, inn.Items[0].Quality);
        }

        [Fact]
        public void BackstagePasses_quality_drops_to_0_after_expired()
        {
            var inn = new Inn() {
                Items = new List<Item> {
                    new Item{Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 3, Quality = 10}
                }
            };

            inn.UpdateQuality();
            inn.UpdateQuality();
            inn.UpdateQuality();
            inn.UpdateQuality();

            Assert.Equal(0, inn.Items[0].Quality);
        }
    }
}