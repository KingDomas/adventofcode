using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program {
  public static void Main(string[] args) {
    List<string> list = new List<string>();

    foreach (string line in System.IO.File.ReadLines("list.txt")) {
      list.Add(line);
    }

    
    string mulPattern = @"mul\((\d+),(\d+)\)";
    string doPattern = @"do\(\)";
    string dontPattern = @"don't\(\)";

    int total = 0;
    bool canAdd = true;

    foreach (string line in list) {
      List<string> commands = new List<string>();

      //using regex to find all the functions in the txt
      MatchCollection mulMatches = Regex.Matches(line, mulPattern);
      MatchCollection doMatches = Regex.Matches(line, doPattern);
      MatchCollection dontMatches = Regex.Matches(line, dontPattern);

      //adding each command to a list in the order they appear
      int mulIndex = 0, doIndex = 0, dontIndex = 0;
      while (mulIndex < mulMatches.Count || doIndex < doMatches.Count || dontIndex < dontMatches.Count) {
        int nextMul = mulIndex < mulMatches.Count ? mulMatches[mulIndex].Index : int.MaxValue;
        int nextDo = doIndex < doMatches.Count ? doMatches[doIndex].Index : int.MaxValue;
        int nextDont = dontIndex < dontMatches.Count ? dontMatches[dontIndex].Index : int.MaxValue;

        if (nextMul <= nextDo && nextMul <= nextDont) {
          commands.Add(mulMatches[mulIndex].Value);
          mulIndex++;
        } else if (nextDo <= nextMul && nextDo <= nextDont) {
          commands.Add("do()");
          doIndex++;
        } else {
          commands.Add("don't()");
          dontIndex++;
        }
      }

      //check whether the commands are valid
      foreach (string command in commands) {
        if (command == "do()") {
          canAdd = true;
        } else if (command == "don't()") {
          canAdd = false;
        } else if (command.StartsWith("mul(") && canAdd) {
        //extract the integers x and y
          Match mulMatch = Regex.Match(command, mulPattern);
          if (mulMatch.Success) {
            int x = int.Parse(mulMatch.Groups[1].Value);
            int y = int.Parse(mulMatch.Groups[2].Value);

          //add the product of x and y to the total
            total += x * y;
          }
        }
      }
    }

    //output total
    Console.WriteLine(total);
  }
}
