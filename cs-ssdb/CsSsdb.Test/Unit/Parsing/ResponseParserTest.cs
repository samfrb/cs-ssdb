using System;
using System.Text;
using CsSsdb.Parsing;
using Xunit;

namespace CsSsdb.Test.Unit.Parsing
{
    public class ResponseParserTest
    {
        [Fact]
        public void ReadSize_ValidInput_Read()
        {
            byte[] correctData = Encoding.UTF8.GetBytes("12\n");

            int size = ResponseParser.ReadSize(correctData, 0, out var stopIndex);

            Assert.Equal(12, size);
            Assert.Equal(2, stopIndex);
        }
        
        [Fact]
        public void ReadSize_Offset_SmallerThan0()
        {
            Exception ex = Assert.Throws<IndexOutOfRangeException>(() => ResponseParser.ReadSize(new byte[1], -1, out var _));
            Assert.Equal("The offset must be in the bound of the array", ex.Message);
        }
        
        [Fact]
        public void ReadSize_Offset_EqualToLength()
        {
            byte[] arrayLength2 = new byte[2];
            Exception ex = Assert.Throws<IndexOutOfRangeException>(() => ResponseParser.ReadSize(arrayLength2, 2, out var _));
            Assert.Equal("The offset must be in the bound of the array", ex.Message);
        }
        
        [Fact]
        public void ReadSize_Offset_GreaterThanLength()
        {
            byte[] arrayLength2 = new byte[2];
            Exception ex = Assert.Throws<IndexOutOfRangeException>(() => ResponseParser.ReadSize(arrayLength2, 3, out var _));
            Assert.Equal("The offset must be in the bound of the array", ex.Message);
        }

        [Fact]
        public void ReadSize_InvalidCharacter_ReturnsMinusOne()
        {
            byte[] correctData = Encoding.UTF8.GetBytes("A\n");

            int size = ResponseParser.ReadSize(correctData, 0, out var stopIndex);

            Assert.Equal(-1, size);
            Assert.Equal(0, stopIndex);
        }
        
        [Fact]
        public void ReadSize_NoReturn_ReturnsMinusOne()
        {
            byte[] correctData = Encoding.UTF8.GetBytes("14");

            int size = ResponseParser.ReadSize(correctData, 0, out var stopIndex);

            Assert.Equal(-1, size);
            Assert.Equal(2, stopIndex);
        }
    }
}