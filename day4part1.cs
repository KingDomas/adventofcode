//By far the most difficult one so far due to having to think about the logic required for it to work and making sure all the checks stay within the boundaries of the List so the program doesn't crash.

using System;
using System.Collections.Generic;

class Program {
    //Method to find number of XMAS's in the list
    public static int findXMAS(List<string> arr) {
        int count = 0;
        //Each character in each line should be checked to see whether it is an X.
        //If it is an X, there are several possibilities. MAS coming after the X, SAM coming before the X, MAS above the X, MAS below the X, and MAS going diagonally up to the left, diagonally up to the right, diagonally down to the left, and diagonally down to the right

        int row = 0;
        foreach (string line in arr) {
            int column = 0;
            foreach (char character in line) {
                if (character == 'X') {
                    //Character is an X
                    //Case 1: MAS coming after the X
                    if (column <= line.Length-4 && line[column+1] == 'M' && line[column+2] == 'A' && line[column+3] == 'S') {
                        count++;
                    }
                    //Case 2: SAM coming before the X
                    if (column >= 3 && line[column-1] == 'M' && line[column-2] == 'A' && line[column-3] == 'S') {
                        count++;
                    }
                    //Case 3: MAS above the X
                    if (row >= 3 && arr[row-1][column] == 'M' && arr[row-2][column] == 'A' && arr[row-3][column] == 'S') {
                        count++;
                    }
                    //Case 4: MAS below the X
                    if (row <= arr.Count-4 && arr[row+1][column] == 'M' && arr[row+2][column] == 'A' && arr[row+3][column] == 'S') {
                        count++;
                    }
                    //Case 5: MAS going diagonally up to the left
                    if (row >= 3 && column >= 3 && arr[row-1][column-1] == 'M' && arr[row-2][column-2] == 'A' && arr[row-3][column-3] == 'S') {
                        count++;
                    }
                    //Case 6: MAS going diagonally up to the right
                    if (row >= 3 && column <= line.Length-4 && arr[row-1][column+1] == 'M' && arr[row-2][column+2] == 'A' && arr[row-3][column+3] == 'S') {
                        count++;
                    }
                    //Case 7: MAS going diagonally down to the left
                    if (row <= arr.Count-4 && column >= 3 && arr[row+1][column-1] == 'M' && arr[row+2][column-2] == 'A' && arr[row+3][column-3] == 'S') {
                        count++;
                    }
                    //Case 8: MAS going diagonally down to the right
                    if (row <= arr.Count-4 && column <= line.Length-4 && arr[row+1][column+1] == 'M' && arr[row+2][column+2] == 'A' && arr[row+3][column+3] == 'S') {
                        count++;
                    }
                }
                column++;
            }
            row++;
        }
        return count;
    }
    
    public static void Main(string[] args) {
        //Create a list an append everything from list.txt to it
        List<string> list = new List<string>();
        foreach (string line in System.IO.File.ReadLines("list.txt")) {
            list.Add(line);
        }

        //Output the number of XMAS's in the list
        Console.WriteLine(findXMAS(list));
    }
}
