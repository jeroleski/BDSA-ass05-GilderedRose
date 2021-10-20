using System.Collections.Generic;
using GildedRose.Console;
using Xunit;

namespace GildedRose.Tests
{
    public class Backstage_passesTest
    {

        [Fact]
        public void Backstage_Quality_after1_updates()
        {
            //Given
            var app = new Inn
            {
                Items = new List<Item>{
                     new Item
                                            {
                                                Name = "Backstage passes to a TAFKAL80ETC concert",
                                                SellIn = 15,
                                                Quality = 20
                                            }
                                        }

            };

            var expected =  new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 14,
                Quality = 21
            };
                                        
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
        public void Backstage_Quality_on8_SellIn()
        {
            //Given
            var app = new Inn
            {
                Items = new List<Item>{
                     new Item
                                            {
                                                Name = "Backstage passes to a TAFKAL80ETC concert",
                                                SellIn = 15,
                                                Quality = 20
                                            }
                                        }

            };

            var expected =  new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 8,
                Quality = 29
            };
                                        
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
          [Fact]
        public void Backstage_Quality_on1_SellIn()
        {
            //Given
            var app = new Inn
            {
                Items = new List<Item>{
                     new Item
                                            {
                                                Name = "Backstage passes to a TAFKAL80ETC concert",
                                                SellIn = 15,
                                                Quality = 20
                                            }
                                        }

            };

            var expected =  new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 1,
                Quality = 47
            };
                                        
            //When
            for (int i = 0; i < 14; i++)
            {
                app.UpdateQuality();
            }

            var actual = app.Items[0];

            //Then

            Assert.Equal(expected.Quality, actual.Quality);
            Assert.Equal(expected.SellIn, actual.SellIn);
        }
        [Fact]
        public void Backstage_Quality_onNegative1_SellIn()
        {
            //Given
            var app = new Inn
            {
                Items = new List<Item>{
                     new Item
                                            {
                                                Name = "Backstage passes to a TAFKAL80ETC concert",
                                                SellIn = 15,
                                                Quality = 20
                                            }
                                        }

            };

            var expected =  new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = -1,
                Quality = 0
            };
                                        
            //When
            for (int i = 0; i < 16; i++)
            {
                app.UpdateQuality();
            }

            var actual = app.Items[0];

            //Then

            Assert.Equal(expected.Quality, actual.Quality);
            Assert.Equal(expected.SellIn, actual.SellIn);
        }
          [Fact]
        public void Backstage_Quality_above50()
        {
            //Given
            var app = new Inn
            {
                Items = new List<Item>{
                     new Item
                                            {
                                                Name = "Backstage passes to a TAFKAL80ETC concert",
                                                SellIn = 15,
                                                Quality = 40
                                            }
                                        }

            };

            var expected =  new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = -1,
                Quality = 0
            };
                                        
            //When
            for (int i = 0; i < 16; i++)
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