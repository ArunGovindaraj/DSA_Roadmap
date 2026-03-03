// See https://aka.ms/new-console-template for more information
using DSARoadmap.ArrayAndStringProblems;
using DSARoadmap.Common.CommonServices;
using DSARoadmap.BinarySearch;
using DSARoadmap.DynamicProgramming;
using DSARoadmap.BoyerMooreVoting;
using DSARoadmap.PropelArrayChallenge;
using DSARoadmap.SortingAlgorithms;
using DSARoadmap.SolvingByLINQ;
using DSARoadmap.DSAProblemsTopicWise;
using DSARoadmap.Cache;
using DSARoadmap.InterviewProblems.Omnissa;

Console.WriteLine("DSA Roadmap!!!");
CommonServices commonServices = new CommonServices();
ArrayAndStringProblems arrayAndStringProblems = new ArrayAndStringProblems(commonServices);
BinarySearch binarySearch = new BinarySearch(commonServices);
DynamicProgramming dynamicProgramming = new DynamicProgramming(commonServices);
BoyerMooreVoting boyerMooreVoting = new BoyerMooreVoting(commonServices);
PropelArrayChallenge propelArrayChallenge = new PropelArrayChallenge(commonServices);
SortingAlgo sortingAlgo = new SortingAlgo(commonServices);
SolvingByLINQ solvingByLINQ = new SolvingByLINQ(commonServices);
ArrayProblems arrayProblems = new ArrayProblems(commonServices);
StringProblems stringProblems = new StringProblems(commonServices);
LinkedListProblems linkedListProblems = new LinkedListProblems(commonServices);
Console.WriteLine("NewsFeed!!!");
NewsFeed newsFeed = new NewsFeed();
string[] input = {
            "publish pub1 news1",
            "subscribe user1 pub1",
            "getrecentfeed user1 5"
        };

for (int i = 0; i < input.Length; i++)
{
    string[] parts = input[i].Split(' ');
    string command = parts[0].ToLower();

    switch (command)
    {
        case "publish":
            newsFeed.Publish(parts[1], parts[2]);
            break;

        case "subscribe":
            newsFeed.Subscribe(parts[1], parts[2]);
            break;

        case "unsubscribe":
            newsFeed.Unsubscribe(parts[1], parts[2]);
            break;

        case "getrecentfeed":
            int k = int.Parse(parts[2]);
            List<string> feed = newsFeed.GetRecentNews(parts[1], k);

            Console.Write("[");
            for (int j = 0; j < feed.Count; j++)
            {
                Console.Write(feed[j]);
            }
            Console.Write("]");
            break;
    }
}
