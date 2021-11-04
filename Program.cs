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
[s] Search Commics
[q] Quit";
}
void Input()
{
    Console.WriteLine("Enter Name Comics");
    var name = Console.ReadLine();

    Console.WriteLine("Enter Title Comics");
    var title = Console.ReadLine();

    Console.WriteLine("Enter Number Comics");
    var number = Console.ReadLine();

    Console.WriteLine("Enter Date Comics");
    var date = Console.ReadLine();

    using (StreamWriter sw = new StreamWriter(
        "C:\\Users\\ivang\\Documents\\Development\\C#\\ComicsCSharp\\Test.txt",
        true))
    {
        sw.WriteLine($"{name}:{title}:{number}:{date}");
        sw.Close();
    }
}

void Print()
{
    using (var sr = new StreamReader(
        "C:\\Users\\ivang\\Documents\\Development\\C#\\ComicsCSharp\\Test.txt"))
    {
        var stringRead = "";
        while ((stringRead = sr.ReadLine()) != null)
            Console.WriteLine(stringRead);
        sr.Close();
    }
}

void Search()
{
    Console.WriteLine("Enter key search");
    var keySearch = Console.ReadLine();

    using (var sr = new StreamReader(
        "C:\\Users\\ivang\\Documents\\Development\\C#\\ComicsCSharp\\Test.txt"))
    {
        var stringRead = "";
        while ((stringRead = sr.ReadLine()) != null)
            if (stringRead.Contains(keySearch))
                Console.WriteLine(stringRead);
        sr.Close();
    }
}