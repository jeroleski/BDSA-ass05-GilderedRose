using System.Collections.Generic;
using GildedRose.Console;
using Xunit;

namespace GildedRose.Tests
{
    public class mainTest
    {
      //remove the try from line 40-49 in inn
      [Fact]
      public void TestofMain()
      {
      //Given
      var expected = new List<Item>
                                          {
                                              new Item {Name = "+5 Dexterity Vest", SellIn = 9, Quality = 19},
                                              new Item {Name = "Aged Brie", SellIn = 1, Quality = 1},
                                              new Item {Name = "Elixir of the Mongoose", SellIn = 4, Quality = 6},
                                              new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                              new Item
                                                  {
                                                      Name = "Backstage passes to a TAFKAL80ETC concert",
                                                      SellIn = 14,
                                                      Quality = 21
                                                  },
                                              new Item {Name = "Conjured Mana Cake", SellIn = 2, Quality = 4}
                                          };
                                          
       Inn.RunInn("1");
        var actual = Inn.testList;
      
      //Then
       Assert.Collection(actual,
                tag => Assert.Equal(expected[0].Quality, tag.Quality),
                tag => Assert.Equal(expected[1].Quality, tag.Quality),
                tag => Assert.Equal(expected[2].Quality, tag.Quality),
                tag => Assert.Equal(expected[3].Quality, tag.Quality),
                tag => Assert.Equal(expected[4].Quality, tag.Quality),
                tag => Assert.Equal(expected[5].Quality, tag.Quality)
            );
      
      }
    }
}