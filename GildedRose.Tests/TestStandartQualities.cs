using Xunit;
using GildedRose.Console;
using System.Collections.Generic;

namespace GildedRose.Tests
{
    public class TestStandartQualities
    {
        [Fact]
        public void Quality_drops_by_1_when_updating_1_time()
        {
            var inn = new Inn() {
                Items = new List<Item> {
                    new Item{Name = "Sour Socks", SellIn = 10, Quality = 5}
                }
            };

            inn.UpdateQuality();

            Assert.Equal(4, inn.Items[0].Quality);
        }

        [Fact]
        public void Quality_drops_by_3_when_updating_3_times()
        {
            var inn = new Inn() {
                Items = new List<Item> {
                    new Item{Name = "Sour Socks", SellIn = 10, Quality = 5}
                }
            };

            inn.UpdateQuality();
            inn.UpdateQuality();
            inn.UpdateQuality();


            Assert.Equal(2, inn.Items[0].Quality);
        }

        [Fact]
        public void Quality_wont_drop_below_0()
        {
            var inn = new Inn() {
                Items = new List<Item> {
                    new Item{Name = "Sour Socks", SellIn = 10, Quality = 5}
                }
            };

            inn.UpdateQuality();
            inn.UpdateQuality();
            inn.UpdateQuality();
            inn.UpdateQuality();
            inn.UpdateQuality();
            inn.UpdateQuality();

            Assert.Equal(0, inn.Items[0].Quality);
        }

        [Fact]
        public void Quality_drops_double_when_expired()
        {
            var inn = new Inn() {
                Items = new List<Item> {
                    new Item{Name = "Holey Hats", SellIn = 0, Quality = 8}
                }
            };

            inn.UpdateQuality();

            Assert.Equal(6, inn.Items[0].Quality);
        }

        [Fact]
        public void SellIn_drops_by_1_when_updating_1_time()
        {
            var inn = new Inn() {
                Items = new List<Item> {
                    new Item{Name = "Sour Socks", SellIn = 10, Quality = 5}
                }
            };

            inn.UpdateQuality();

            Assert.Equal(9, inn.Items[0].SellIn);
        }

        [Fact]
        public void SellIn_drops_by_3_when_updating_3_times()
        {
            var inn = new Inn() {
                Items = new List<Item> {
                    new Item{Name = "Holey Hats", SellIn = 0, Quality = 8}
                }
            };

            inn.UpdateQuality();
            inn.UpdateQuality();
            inn.UpdateQuality();

            Assert.Equal(-3, inn.Items[0].SellIn);
        }
    }
}