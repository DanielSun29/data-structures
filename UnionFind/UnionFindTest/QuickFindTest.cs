using Newtonsoft.Json.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using UnionFind;

namespace UnionFindTest
{
    public class QuickFindTest
    {
        class FriendData
        {
            public string FriendA { get; set; }
            public string FriendB { get; set; }
        }
        [Fact]
        public void AreConnectedTest()
        {
            string[] elements = { "A", "B", "C", "D", "E" };

            QuickFind<string> QuickFind = new QuickFind<string>(elements);

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i == j)
                    {
                        Assert.True(QuickFind.AreConnected(elements[i], elements[j]));
                    }
                    else
                    {
                        Assert.False(QuickFind.AreConnected(elements[i], elements[j]));
                    }
                }
            }

            QuickFind.Union("A", "B");
            QuickFind.Union("B", "C");
            QuickFind.Union("C", "D");
            QuickFind.Union("D", "E");

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Assert.True(QuickFind.AreConnected(elements[i], elements[j]));
                }
            }
        }

        [Fact]
        public void FindTest()
        {
            string[] elements = { "A", "B", "C", "D", "E" };
            QuickFind<string> QuickFind = new QuickFind<string>(elements);

            for (int i = 0; i < 5; i++)
            {
                Assert.Equal(i, QuickFind.Find(elements[i]));
            }

            QuickFind.Union("A", "B");
            QuickFind.Union("B", "C");
            QuickFind.Union("C", "D");
            QuickFind.Union("D", "E");

            for (int i = 0; i < 5; i++)
            {
                Assert.Equal(0, QuickFind.Find(elements[i]));
            }
        }

        [Fact]
        public void FriendProblem() // Completed in console(program.cs)
        {

            // init
            string[] People = JsonSerializer.Deserialize<string[]>(File.ReadAllText("FriendsProblemVerticies.json"));
            FriendData[] friends = JsonSerializer.Deserialize<FriendData[]>(File.ReadAllText("FriendsProblemEdges.json"));

            QuickFind<string> QuickFind = new QuickFind<string>(People);
            foreach (var friend in friends)
            {
                QuickFind.Union(friend.FriendA, friend.FriendB);
            }

            // How many friend groups are there?

            int friendGroups = 0;
            List<int> seenGroups = new List<int>();

            foreach (var friend in friends)
            {
                int group = QuickFind.Find(friend.FriendA);
                if (!seenGroups.Contains(group))
                {
                    seenGroups.Add(group);
                    friendGroups++;
                }
            }

            Console.WriteLine($"There are {friendGroups} friend groups.");

            // Who is in the largest and the smallest friend group?

            int[] groupSizes = new int[People.Length]; // index is group id, value is size of group

            for (int i = 0; i < People.Length; i++)
            {
                int group = QuickFind.Find(People[i]);
                groupSizes[group]++;
            }
            for (int i = 0; i < groupSizes.Length; i++)
            {
                Console.WriteLine($"Group {i} has {groupSizes[i]} members.");
            }

            int maxGroupSize = groupSizes.Max();
            int minGroupSize = groupSizes.Min();
            int maxGroup = Array.IndexOf(groupSizes, maxGroupSize);
            int minGroup = Array.IndexOf(groupSizes, minGroupSize);

            Console.WriteLine($"The largest friend group is Group {maxGroup} with {maxGroupSize} members.");
            Console.WriteLine($"The smallest friend group is Group {minGroup} with {minGroupSize} members.");

            // Is Phoebe Friends with Rachel? Is Michael friends with Pam? Is Chandler friends with Creed?

            Console.WriteLine($"Phoebe and Rachel are friends: {QuickFind.AreConnected("Phoebe", "Rachel")}");
            Console.WriteLine($"Michael and Pam are friends: {QuickFind.AreConnected("Michael", "Pam")}");
            Console.WriteLine($"Chandler and Creed are friends: {QuickFind.AreConnected("Chandler", "Creed")}");

            // Who are the members of each set? Displayed by their values.

            for (int i = 0; i < People.Length; i++)
            {
                int group = QuickFind.Find(People[i]);
                Console.WriteLine($"{People[i]} is in group {group}.");
            }
        }
    }
}
