using Xunit;
using GildedRose.Console;
using System.Collections.Generic;


namespace GildedRose.Tests
{

    public class agedBrie
    {
        [Fact]
        public void agedBrie_Quality_afterOne_update()
        {
            //Given
            var app = new Inn
            {
                Items = new List<Item>{
            new Item{Name = "Aged Brie", SellIn = 2, Quality = 0}
        }
            };

            var expected = new Item { Name = "Aged Brie", SellIn = 1, Quality = 1 };

            //When
            app.UpdateQuality();

            var actual = app.Items[0];

            //Then

            Assert.Equal(expected.Quality, actual.Quality);
            Assert.Equal(expected.SellIn, actual.SellIn);
        }


        [Fact]
        public void agedBrie_Quality_AfterThree_update()
        {
            //Given
            var app = new Inn
            {
                Items = new List<Item>{
            new Item{Name = "Aged Brie", SellIn = 2, Quality = 0}
        }
            };

            var expected = new Item { Name = "Aged Brie", SellIn = -1, Quality = 4 };

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
        [Fact]
        public void agedBrie_Quality_After8_update()
        {
            //Given
            var app = new Inn
            {
                Items = new List<Item>{
            new Item{Name = "Aged Brie", SellIn = 2, Quality = 0}
        }
            };

            var expected = new Item { Name = "Aged Brie", SellIn = -6, Quality = 14 };

            //When
            for (int i = 0; i < 8; i++)
            {
                app.UpdateQuality();
            }


            var actual = app.Items[0];

            //Then

            Assert.Equal(expected.Quality, actual.Quality);
            Assert.Equal(expected.SellIn, actual.SellIn);
        }
    
      [Fact]
        public void agedBrie_Quality_above50()
        {
            //Given
            var app = new Inn
            {
                Items = new List<Item>{
            new Item{Name = "Aged Brie", SellIn = 0, Quality = 50}
        }
            };

            var expected = new Item { Name = "Aged Brie", SellIn = -3, Quality = 50 };

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


