namespace BarsGroup.ExpressionInlining.Tests
{
    using System;
    using System.Linq.Expressions;
    using BarsGroup.ExpressionInlining;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ExpressionInlinerTests
    {
        [TestMethod]
        public void BasicInlining()
        {
            Expression<Func<int, int>> multiplyByTwo = i => i * 2;
            Expression<Func<int, int>> multiplyByEight = i => multiplyByTwo.Inline(i) * 4;


            multiplyByEight = ExpressionInliner.Bake(multiplyByEight);


            Assert.AreEqual(80, multiplyByEight.Compile()(10));
        }
    }
}