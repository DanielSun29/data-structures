using System.Runtime.CompilerServices;
using System.Text.Json;

namespace UnionFind
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FriendProblem();
        }

        class FriendData
        {
            public string FriendA { get; set; }
            public string FriendB { get; set; }
        }

        public static void FriendProblem()
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
