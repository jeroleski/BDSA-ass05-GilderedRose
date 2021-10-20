using System.Collections.Generic;
using GildedRose.Console;
using Xunit;

namespace GildedRose.Tests
{
    public class ConjuredTest
    {
         [Fact]
        public void ConjuredCake_Quality_after1_Update()
        {
            //Given
            var app = new Inn
            {
                Items = new List<Item>{
                      new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                }

            };

            var expected =   new Item {Name = "Conjured Mana Cake", SellIn = 2, Quality = 5};
                                        
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