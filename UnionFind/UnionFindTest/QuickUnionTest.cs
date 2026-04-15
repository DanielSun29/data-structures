using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using UnionFind;

namespace UnionFindTest
{
    public class QuickUnionTest
    {
        [Fact]
        public void AreConnectedTest()
        {
            string[] elements = { "A", "B", "C", "D", "E" };

            QuickUnion<string> QuickUnion = new QuickUnion<string>(elements);

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i == j)
                    {
                        Assert.True(QuickUnion.AreConnected(elements[i], elements[j]));
                    }
                    else
                    {
                        Assert.False(QuickUnion.AreConnected(elements[i], elements[j]));
                    }
                }
            }

            QuickUnion.Union("A", "B");
            QuickUnion.Union("B", "C");
            QuickUnion.Union("C", "D");
            QuickUnion.Union("D", "E");

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Assert.True(QuickUnion.AreConnected(elements[i], elements[j]));
                }
            }
        }

        [Fact]
        public void FindTest()
        {
            string[] elements = { "A", "B", "C", "D", "E" };
            QuickUnion<string> QuickUnion = new QuickUnion<string>(elements);

            for (int i = 0; i < 5; i++)
            {
                Assert.Equal(i, QuickUnion.Find(elements[i]));
            }

            QuickUnion.Union("A", "B");
            QuickUnion.Union("B", "C");
            QuickUnion.Union("C", "D");
            QuickUnion.Union("D", "E");

            for (int i = 0; i < 5; i++)
            {
                Assert.Equal(4, QuickUnion.Find(elements[i]));
            }
        }
    }
}
