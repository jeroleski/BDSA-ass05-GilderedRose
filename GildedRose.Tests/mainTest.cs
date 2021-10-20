using System.Collections.Generic;
using System.IO;
using GildedRose.Console;
using Xunit;

namespace GildedRose.Tests
{
    public class mainTest
    {
      [Fact]
      public void TestName()
      {
      //Given
      Inn.Main(new string[0]);
      var expected = "working";
       
      //When
        var actual = Inn.testString;
      
      //Then
      Assert.Equal(expected,actual);
      }
    }
}