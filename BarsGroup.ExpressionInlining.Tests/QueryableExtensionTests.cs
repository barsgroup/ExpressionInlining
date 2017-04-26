namespace BarsGroup.ExpressionInlining.Tests
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using BarsGroup.ExpressionInlining.Extensions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class QueryableExtensionTests
    {
        [TestMethod]
        public void SelectInlined()
        {
            Expression<Func<int, string>> toString = i => i + ".00";

            var query = new[] {1, 2, 3}.AsQueryable();


            var result = query.Select(i => toString.Inline(i))
                              .BakeInlines()
                              .ToArray();


            CollectionAssert.AreEqual(new[] {"1.00", "2.00", "3.00"}, result);
        }

        [TestMethod]
        public void JoinInlined()
        {
            Expression<Func<int, string>> toString = i => i.ToString();

            var intQuery = new[] {1, 2, 3}.AsQueryable();
            var stringQuery = new[] {"1", "2", "3"}.AsQueryable();


            var joinResult = intQuery.Join(stringQuery, i => toString.Inline(i), s => s, (i, s) => string.Empty)
                                     .BakeInlines()
                                     .ToArray();


            Assert.AreEqual(intQuery.Count(), joinResult.Length);
        }

        [TestMethod]
        public void DslSyntax()
        {
            Expression<Func<int, string>> toString = i => i.ToString();

            var intQuery = new[] {1, 2, 3}.AsQueryable();
            var stringQuery = new[] {"1", "2", "3"}.AsQueryable();


            var result = (from i in intQuery
                          join s in stringQuery on toString.Inline(i) equals s
                          select toString.Inline(i) + s)
                .BakeInlines()
                .ToArray();


            CollectionAssert.AreEqual(new[] {"11", "22", "33"}, result);
        }
    }
}