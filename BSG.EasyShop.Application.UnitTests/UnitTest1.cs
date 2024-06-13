namespace BSG.EasyShop.Application.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(2,Add(1,1));

        }

        [Fact]
        public void Test2()
        {
            Assert.Equal(0, Add(2, -2));

        }

        [Fact]
        public void Test3()
        {
            Assert.Equal(6, Add(2, 4));

        }

        int Add(int x, int y)
        {
            return x + y;
        }
    }
}