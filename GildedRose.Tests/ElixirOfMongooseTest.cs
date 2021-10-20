using System.Collections.Generic;
using GildedRose.Console;
using Xunit;

namespace GildedRose.Tests
{
    public class ElixirOfMongooseTest
    {
         [Fact]
            public void Elixir_Quality_after1_updates()
            {
                //Given
                var app = new Inn
                {
                    Items = new List<Item>{
                     new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7}
                    }
                };

                var expected =   new Item {Name = "Elixir of the Mongoose", SellIn = 4, Quality = 6};

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
            public void Elixir_Quality_after7_updates()
            {
                //Given
                var app = new Inn
                {
                    Items = new List<Item>{
                     new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7}
                    }
                };

                var expected =   new Item {Name = "Elixir of the Mongoose", SellIn = -2, Quality = 0};

                //When
                for (int i = 0; i < 7; i++)
                {
                    app.UpdateQuality();
                }

                var actual = app.Items[0];

                //Then

                Assert.Equal(expected.Quality, actual.Quality);
                Assert.Equal(expected.SellIn, actual.SellIn);
            }

            public void Elixir_Quality_50()
            {
                //Given
                var app = new Inn
                {
                    Items = new List<Item>{
                     new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 50}
                    }
                };

                var expected =   new Item {Name = "Elixir of the Mongoose", SellIn = 2, Quality = 48};

                //When
                for (int i = 0; i < 3; i++)
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