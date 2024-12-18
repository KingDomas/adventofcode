using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program {
  public static void Main(string[] args) {
    //read every line from list.txt and split them into seperate strings and add to a list
    //find every instance of mul(x,y) occuring where x and y are integers. make sure it case correct, e.g mul(x,y without a closing bracket wouldnt count
    //for every instance of mul(x,y), add the product of x and y to a total
    //output the total once every line has been read

    List<string> list = new List<string>();
    
    foreach (string line in System.IO.File.ReadLines("list.txt")) {
      list.Add(line);
    }

    string pattern = @"mul\((\d+),(\d+)\)";
    int total = 0;
    foreach (string line in list) {
      //we'll use regex to find every instance of mul(x,y)
      MatchCollection matches = Regex.Matches(line, pattern);

      foreach (Match match in matches) {
        //extract the integers x and y
        int x = int.Parse(match.Groups[1].Value);
        int y = int.Parse(match.Groups[2].Value);

        //add the product of x and y to the total
        total += x * y;
      }
    }

    //output total

    Console.WriteLine(total);
  }
}
