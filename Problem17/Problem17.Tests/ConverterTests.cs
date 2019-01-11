using System;
using Xunit;

namespace Problem17.Tests
{
    public class ConverterTests
    {
        [Fact]
        public void SimpleDigitsTest()
        {
            var converter = new NumberToWordConverter();
            Assert.Equal(4, converter.GetNumberLengthInWords(0));
            Assert.Equal(3,converter.GetNumberLengthInWords(1));
            Assert.Equal(3, converter.GetNumberLengthInWords(2));
            Assert.Equal(5, converter.GetNumberLengthInWords(3));
            Assert.Equal(4, converter.GetNumberLengthInWords(4));
            Assert.Equal(4, converter.GetNumberLengthInWords(5));
            Assert.Equal(3, converter.GetNumberLengthInWords(6));
            Assert.Equal(5, converter.GetNumberLengthInWords(7));
            Assert.Equal(5, converter.GetNumberLengthInWords(8));
            Assert.Equal(4, converter.GetNumberLengthInWords(9));            
        }

        [Fact]
        public void Tens()
        {
            var converter = new NumberToWordConverter();
            Assert.Equal("ten".Length, converter.GetNumberLengthInWords(10));
            Assert.Equal("eleven".Length, converter.GetNumberLengthInWords(11));
            Assert.Equal("twelve".Length, converter.GetNumberLengthInWords(12));
            Assert.Equal("thirteen".Length, converter.GetNumberLengthInWords(13));
            Assert.Equal("fourteen".Length, converter.GetNumberLengthInWords(14));
            Assert.Equal("fifteen".Length, converter.GetNumberLengthInWords(15));
            Assert.Equal("sixteen".Length, converter.GetNumberLengthInWords(16));
            Assert.Equal("seventeen".Length, converter.GetNumberLengthInWords(17));
            Assert.Equal("eighteen".Length, converter.GetNumberLengthInWords(18));
            Assert.Equal("nineteen".Length, converter.GetNumberLengthInWords(19));
        }

        [Fact]
        public void TwoDigitZeroes()
        {
            var converter = new NumberToWordConverter();
            Assert.Equal("twenty".Length, converter.GetNumberLengthInWords(20));
            Assert.Equal("thirty".Length, converter.GetNumberLengthInWords(30));
            Assert.Equal("forty".Length, converter.GetNumberLengthInWords(40));
            Assert.Equal("fifty".Length, converter.GetNumberLengthInWords(50));
            Assert.Equal("sixty".Length, converter.GetNumberLengthInWords(60));
            Assert.Equal("seventy".Length, converter.GetNumberLengthInWords(70));
            Assert.Equal("eighty".Length, converter.GetNumberLengthInWords(80));
            Assert.Equal("ninety".Length, converter.GetNumberLengthInWords(90));
        }

        [Fact]
        public void LargeNumbers()
        {
            var converter = new NumberToWordConverter();
            Assert.Equal("onehundred".Length, converter.GetNumberLengthInWords(100));
            Assert.Equal("onethousand".Length, converter.GetNumberLengthInWords(1000));
        }
    }
}
