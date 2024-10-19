int[] arr1 = {1, 2, 3};
int[] arr2 = arr1; // Hanya alamat memori dari arr1 yang disalin ke arr2
arr2[1] = 4;

Console.WriteLine(arr1[1]); // output: 4