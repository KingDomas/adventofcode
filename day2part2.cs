//used a function here instead

using System;
using System.Collections.Generic;

class Program {
  public static void Main(string[] args) {
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
      bool valid = CheckIfValid(report);

      if (valid) {
        safeReports++;
      } else {
        // Try removing one element and check if it becomes valid
        bool foundSafe = false;
        for (int i = 0; i < report.Length; i++) {
        // Create a new report with one element removed
        int[] newReport = new int[report.Length - 1];
        Array.Copy(report, 0, newReport, 0, i);  // Copy elements before the removed one
        Array.Copy(report, i + 1, newReport, i, report.Length - i - 1);  // Copy elements after the removed one

        if (CheckIfValid(newReport)) {
          foundSafe = true;
          break;
        }
      }

      if (foundSafe) {
        safeReports++;
      }
    }
  }
  Console.WriteLine(safeReports);
}

static bool CheckIfValid(int[] report) {
  bool valid = true;

  if (report[0] < report[1]) {
    // increasing sequence
    for (int i = 0; i < report.Length - 1; i++) {
      if (report[i] >= report[i + 1]) {
        valid = false;
        break;
      }
      // check if diff is at most 3
      if (Math.Abs(report[i] - report[i + 1]) > 3) {
        valid = false;
        break;
      }
    }
  } else if (report[0] > report[1]) {
    // decreasing sequence
    for (int i = 0; i < report.Length - 1; i++) {
      if (report[i] <= report[i + 1]) {
        valid = false;
        break;
      }
      // check if max difference is 3
      if (Math.Abs(report[i] - report[i + 1]) > 3) {
        valid = false;
        break;
      }
    }
  } else {
  // equal values, so invalid
    valid = false;
  }

  return valid;
  }
}
