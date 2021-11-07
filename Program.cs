/* Program.cs
   Copyright (C) 2021 Ivan Guerreschi
This file is part of ComicsCSharp.
Author: Ivan Guerreschi <ivanguerreschi86@gmail.com>
Maintainer: Ivan Guerreschi <ivanguerreschi86@gmail.com>e
ComicsCSharp is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
ComicsCSharp is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with ComicsCSharp.  If not, see <http://www.gnu.org/licenses/>. */

using System;
using System.IO;

Console.WriteLine("ComicsCSharp");

var loop = true;
const String path = @".\Comics.txt";

do
{
    Console.WriteLine(Menu());
    var input = Console.ReadLine();

    switch (input)
    {
        case "p":
            Print();
            continue;

        case "i":
            Input();
            continue;

        case "s":
            Search();
            continue;

        case "d":
            Delete();
            continue;

        case "t":
            Sort();
            continue;

        case "q":
            loop = false;
            break;
    }
} while (loop);

String Menu()
{
    return @"
[p] Print all Comics
[i] Enter Comics
[s] Search Comics
[d] Delete Comics
[t] Sort Comics
[q] Quit";
}
void Input()
{
    Console.WriteLine("Enter Number Comics");
    var number = Console.ReadLine();

    Console.WriteLine("Enter Name Comics");
    var name = Console.ReadLine();

    Console.WriteLine("Enter Title Comics");
    var title = Console.ReadLine();

    Console.WriteLine("Enter Date Comics");
    var date = Console.ReadLine();

    using (StreamWriter sw = new StreamWriter(path, true))
    {
        sw.WriteLine($"{number}:{name}:{title}:{date}");
        sw.Close();
    }
}

void Print()
{
    using (var sr = new StreamReader(path))
    {
        Console.WriteLine(sr.ReadToEnd());
        sr.Close();
    }
}

void Search()
{
    Console.WriteLine("Enter key search");
    var keySearch = Console.ReadLine();
    
    if (keySearch == null)
        keySearch = "";

    using (var sr = new StreamReader(path))
    {
        var stringRead = sr.ReadToEnd();
        if (stringRead.Contains(keySearch))
            Console.WriteLine(stringRead);
        sr.Close();
    }
}

void Delete()
{
    Console.WriteLine("Enter key search");
    var keyDelete = Console.ReadLine();

    var oldLines = File.ReadAllLines(path);
    var newLines = oldLines.Where(line => !line.Contains(keyDelete + ":"));
    File.WriteAllLines(path, newLines);
    RemoveBlankLine();
}

void RemoveBlankLine()
{
    var lines = File.ReadAllLines(path).Where(line => !string.IsNullOrWhiteSpace(line));
    File.WriteAllLines(path, lines);
}

void Sort()
{
    List<String> lines = new List<String>(File.ReadAllLines(path));
    lines.Sort();
    File.WriteAllLines(path, lines);
}