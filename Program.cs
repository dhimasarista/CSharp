using Algorithms;

int[] arr = {1,2,3,4,4,5,6,6,7,7,8,9,10};

var search = new FastSearcher();
int find = search.FindIndex(arr, 4);
Console.WriteLine($"Ditemukan di index: {find}");