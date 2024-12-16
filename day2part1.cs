using System;
using System.Collections.Generic;

class Program {
  public static void Main (string[] args) {
    List<int[]> listOfReports = new List<int[]> {};

    // Read the list.txt file and populate listOfReports with arrays
    foreach (string line in System.IO.File.ReadLines("list.txt")) {
      if (string.IsNullOrWhiteSpace(line)) continue;
      else {
        string[] parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int[] report = Array.ConvertAll(parts, int.Parse);

        // Add the array to the list
        listOfReports.Add(report);
      }
    }

    int safeReports = 0;
    
    foreach (int[] report in listOfReports) {
      bool valid = true;

      if (report[0] < report[1]) {
        //increasing increasing
        for (int i = 0; i < report.Length - 1; i++) {
          if (report[i] >= report[i + 1]) {
            valid = false;
            break;
          }
          // check diff is at most 3
          if (Math.Abs(report[i] - report[i + 1]) > 3) {
            valid = false;
            break;
          }
        }
      } else if (report[0] > report[1]) {
        //decreasing
        for (int i = 0; i < report.Length - 1; i++) {
          if (report[i] <= report[i + 1]) {
            valid = false;
            break;
          }
          //check if max difference is 3
          if (Math.Abs(report[i] - report[i + 1]) > 3) {
            valid = false;
            break;
          }
        }
      } else {
        //equal so invalid
        valid = false;
      }
      
      if (valid) safeReports++;
    }
    Console.WriteLine(safeReports);
  }
}
