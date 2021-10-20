using System.Collections.Generic;
using GildedRose.Console;
using Xunit;

namespace GildedRose.Tests
{
    public class SulfurasTest
    {
        [Fact]
            public void DexterityVest_Quality_after1_updates()
            {
                //Given
                var app = new Inn
                {
                    Items = new List<Item>{
                     new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80}
                    }
                };

                var expected =   new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80};

                //When
                for (int i = 0; i < 1; i++)
                {
                    app.UpdateQuality();
                }

                var actual = app.Items[0];

                //Then

                Assert.Equal(expected.Quality, actual.Quality);
                Assert.Equal(expected.SellIn, actual.SellIn);
            }

            [Fact]
            public void Sulfuras_Quality_after1_updates()
            {
                //Given
                var app = new Inn
                {
                    Items = new List<Item>{
                     new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80}
                    }
                };

                var expected =   new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80};

                //When
                for (int i = 0; i < 1; i++)
                {
                    app.UpdateQuality();
                }

                var actual = app.Items[0];

                //Then

                Assert.Equal(expected.Quality, actual.Quality);
                Assert.Equal(expected.SellIn, actual.SellIn);
            }
    }
}