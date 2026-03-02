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