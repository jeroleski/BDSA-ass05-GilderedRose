using Xunit;
using GildedRose.Console;
using System.Collections.Generic;

namespace GildedRose.Tests
{
    public class Test
    {
        [Fact]
        public void IsAgedBrie_returns_true_when_given_aGED_briE()
        {
            var i = new Item {Name = "aGED briE"};

            var isAgedBrie = i.IsAgedBrie();

            Assert.True(isAgedBrie);
        }

        [Fact]
        public void IsAgedBrie_returns_false_when_given_a_regular_cheese()
        {
            var i = new Item {Name = "a regular cheese"};

            var isAgedBrie = i.IsAgedBrie();

            Assert.False(isAgedBrie);
        }

        [Fact]
        public void IsBackstagePass_returns_true_when_given_Two_Backstage_passes_FOR_Backstreet_Bois()
        {
            var i = new Item {Name = "Two Backstage passes FOR Backstreet Bois"};

            var isBackstagePass = i.IsBackstagePass();

            Assert.True(isBackstagePass);
        }

        [Fact]
        public void IsBackstagePass_returns_false_when_given_a_regular_passport()
        {
            var i = new Item {Name = "an international traweling passport"};

            var isBackstagePass = i.IsBackstagePass();

            Assert.False(isBackstagePass);
        }

        [Fact]
        public void IsSulfuras_returns_true_when_given_SULFURASSS_HAND_OF_RAGNAROS()
        {
            var i = new Item {Name = "SULFURASSS!!! HAND OFRAGNAROS!"};

            var isSulfuras = i.IsSulfuras();

            Assert.True(isSulfuras);
        }

        [Fact]
        public void IsSulfuras_returns_false_when_given_a_hammer_from_my_dads_toolbox()
        {
            var i = new Item {Name = "a hammer from my dads toolbox"};

            var isSulfuras = i.IsSulfuras();

            Assert.False(isSulfuras);
        }

        [Fact]
        public void IsConjured_returns_true_when_given_c_On_JuR_EdCoKKaCola()
        {
            var i = new Item {Name = "c On JuR EdCoKKaCola"};

            var isConjured = i.IsConjured();

            Assert.True(isConjured);
        }

        [Fact]
        public void IsConjured_returns_false_when_given_a_spirit_in_a_bottle()
        {
            var i = new Item {Name = "a spirit in a bottle"};

            var isConjured = i.IsConjured();

            Assert.False(isConjured);
        }

        [Fact]
        public void ChangeQuality_returns_4_given_6_minus_2()
        {
            var i = new Item {Quality = 6};

            i.ChangeQuality(-2);

            Assert.Equal(4, i.Quality);
        }

        [Fact]
        public void ChangeQuality_returns_0_given_6_minus_8()
        {
            var i = new Item {Quality = 6};

            i.ChangeQuality(-8);

            Assert.Equal(0, i.Quality);
        }

        [Fact]
        public void ChangeQuality_returns_47_given_45_plus_2()
        {
            var i = new Item {Quality = 45};

            i.ChangeQuality(2);

            Assert.Equal(47, i.Quality);
        }

        [Fact]
        public void ChangeQuality_returns_50_given_45_plus_7()
        {
            var i = new Item {Quality = 45};

            i.ChangeQuality(7);

            Assert.Equal(50, i.Quality);
        }

        [Fact]
        public void IsExpired_returns_false_when_given_a_positive_numer_of_days()
        {
            var i = new Item {SellIn = 2};

            var isExpired = i.IsExpired();

            Assert.False(isExpired);
        }

        [Fact]
        public void IsExpired_returns_true_when_given_a_non_positive_number_of_days()
        {
            var i = new Item {SellIn = -1};

            var isExpired = i.IsExpired();

            Assert.True(isExpired);
        }

        [Fact]
        public void ToString_makes_a_nice_table_with_1_item()
        {
            var inn = new Inn() {
                Items = new List<Item> {
                    new Item{Name = "Sword", SellIn = 2, Quality = 14}
                }
            };

            var table = "Item Name|Sell In|Quality" + "\n" + 
                        "-------------------------" + "\n" +
                        "Sword    |      2|     14" + "\n" + 
                        "-------------------------" + "\n";

            Assert.Equal(table, inn.ToString());
        }

        [Fact]
        public void ToString_makes_simple_table_with_no_items()
        {
            var inn = new Inn() {
                Items = new List<Item> ()
            };

            var table = "Item Name|Sell In|Quality" + "\n" + 
                        "-------------------------" + "\n" +
                        "-------------------------" + "\n";

            Assert.Equal(table, inn.ToString());
        }

        [Fact]
        public void ToString_makes_an_even_nicer_table_with_2_longer_items()
        {
            var inn = new Inn() {
                Items = new List<Item> {
                    new Item{Name = "Sword", SellIn = 2, Quality = 14},
                    new Item{Name = "Bow With 24 Arrows", SellIn = 7, Quality = 9}
                }
            };

            var table = "Item Name         |Sell In|Quality" + "\n" + 
                        "----------------------------------" + "\n" +
                        "Sword             |      2|     14" + "\n" + 
                        "Bow With 24 Arrows|      7|      9" + "\n" + 
                        "----------------------------------" + "\n";

            Assert.Equal(table, inn.ToString());
        }
    }
}