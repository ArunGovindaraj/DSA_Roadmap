// See https://aka.ms/new-console-template for more information
using DSARoadmap.ArrayAndStringProblems;
using DSARoadmap.Common.CommonServices;
using DSA_Roadmap.BinarySearch;
using DSA_Roadmap.DynamicProgramming;
using DSA_Roadmap.BoyerMooreVoting;
using DSA_Roadmap.PropelArrayChallenge;

Console.WriteLine("DSA Roadmap!!!");
CommonServices commonServices = new CommonServices();
ArrayAndStringProblems arrayAndStringProblems = new ArrayAndStringProblems(commonServices);
BinarySearch binarySearch = new BinarySearch(commonServices);
DynamicProgramming dynamicProgramming = new DynamicProgramming(commonServices);
BoyerMooreVoting boyerMooreVoting = new BoyerMooreVoting(commonServices);
PropelArrayChallenge propelArrayChallenge = new PropelArrayChallenge(commonServices);