using System.Collections.Generic;
using GildedRose.Console;
using Xunit;

namespace GildedRose.Tests
{
    public class DexterityVest
    {
        public class agedBrie
        {
            [Fact]
            public void DexterityVest_Quality_afterOne_update()
            {
                //Given
                var app = new Inn
                {
                    Items = new List<Item>{
                    new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20}
                    }
                };

                var expected = new Item { Name = "+5 Dexterity Vest", SellIn = 9, Quality = 19 };

                //When
                app.UpdateQuality();

                var actual = app.Items[0];

                //Then

                Assert.Equal(expected.Quality, actual.Quality);
                Assert.Equal(expected.SellIn, actual.SellIn);
            }
            [Fact]
            public void DexterityVest_QualitycanotBeNegative_after21_updates()
            {
                //Given
                var app = new Inn
                {
                    Items = new List<Item>{
                    new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20}
                    }
                };

                var expected = new Item { Name = "+5 Dexterity Vest", SellIn = -11, Quality = 0 };

                //When
                for (int i = 0; i < 21; i++)
                {
                    app.UpdateQuality();
                }

                var actual = app.Items[0];

                //Then

                Assert.Equal(expected.Quality, actual.Quality);
                Assert.Equal(expected.SellIn, actual.SellIn);
            }
[Fact]
            public void DexterityVest_Quality_above50()
            {
                //Given
                var app = new Inn
                {
                    Items = new List<Item>{
                    new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 50}
                    }
                };

                var expected = new Item { Name = "+5 Dexterity Vest", SellIn = -50, Quality = 0 };

                //When
                for (int i = 0; i < 60; i++)
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
}
