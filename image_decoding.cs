// https://open.kattis.com/problems/imagedecoding

// the solution is not acceptable yet

using System;

public class RunLengthDecoding
{
    static string[] pixels = new string[] { "#", "." };
    static int pixelIndex = 0;
    static int numberOfLines = 0;
    static bool isError = false;
    static bool isStartOfLine = true;
    static bool isFirstLine = false;
    static int pixelsToFill = 0;

    public static string Decode(String[] line)
    {
        string decodedLine = "";
        int pixelsInRow = 0;


        if(line[0] == pixels[0] || line[0] == pixels[1])
        {
            if (isStartOfLine)
                pixelIndex = line[0] == pixels[0] ? 0 : 1;
            for (int i = 1; i < line.Length; i++)
            {
                int pixelCount = int.Parse(line[i]);
                pixelsInRow += pixelCount;
                decodedLine += new string(char.Parse(pixels[pixelIndex]), pixelCount);
                pixelIndex = (pixelIndex + 1) % 2;
            }
            numberOfLines--;
            if (isFirstLine)
            {
                pixelsToFill = pixelsInRow;
                isFirstLine = false;
            }
            if (!isError)
                isError = pixelsToFill != pixelsInRow;
            isStartOfLine = true;
        }
        if(numberOfLines == 0)
        {
            if (isError)
                decodedLine += "\nError decoding image";
            decodedLine += "\n";
            Reset();
        }
        return decodedLine;
    }

    public static void Reset()
    {
        isStartOfLine = true;
        isError = false;
        isFirstLine = false;
        pixelsToFill = 0;
    }

    public static void Main(String[] args)
    {
        string result = "";
        string decodedLine = "";
        string line;
        int number;

        while ((line = Console.ReadLine()) != null)
        {
            String[] lineToDecode = line.Split();

            if (int.TryParse(lineToDecode[0], out number))
            {
                if(number == 0)
                {
                    Reset();
                    break;
                }
                else //if(number > 0 && number < 100)
                {
                    numberOfLines = number;
                    isFirstLine = true;
                }
            }
            else
            {
                decodedLine = Decode(lineToDecode);
                result += decodedLine + "\n";
            }
        }
        Console.WriteLine(result);
    }
}

/*
Sample Input:

12
# 8 2 4 4 3
. 1 2 4 2 2 2 6 1 1
. 1 2 5 2 1 2 6 1 1
. 1 2 5 1 2 2 6 1 1
. 1 2 4 2 2 2 6 1 1
. 1 7 3 2 6 1 1
. 1 2 4 2 2 2 6 1 1
. 1 2 5 2 1 2 6 1 1
. 1 2 5 2 2 2 5 1 1
. 1 2 5 2 2 2 4 2 1
. 1 2 4 2 4 2 3 1 2
# 7 8 2 4
35
. 11 7 12
. 10 10 10
. 10 10 10
. 9 12 9
. 9 12 9
. 9 12 9
. 9 12 9
. 9 12 9
. 9 4 1 7 9
. 9 2 5 5 9
. 10 12 8
. 10 12 8
. 9 7 2 5 7
. 8 3 1 3 3 6 6
. 7 3 9 5 7
. 7 3 9 6 5
. 6 4 9 7 4
. 6 4 10 6 4
. 5 4 11 7 3
. 5 4 12 6 3
. 4 4 13 6 3
. 4 4 13 6 3
. 4 4 13 6 3
. 4 4 13 6 3
. 4 4 12 7 3
. 3 1 2 3 11 8 2
# 4 3 4 9 8 2
# 4 4 4 8 1 5 2 2
# 2 6 4 7 2 6 3
# 2 7 3 6 3 7 2
# 2 8 3 3 5 7 2
# 1 9 11 5 4
# 4 6 11 3 4 2
. 1 25 4
. 5 6 8 6 5
0

Sample Output:
########..####....###
.##....##..##......#.
.##.....##.##......#.
.##.....#..##......#.
.##....##..##......#.
.#######...##......#.
.##....##..##......#.
.##.....##.##......#.
.##.....##..##.....#.
.##.....##..##....##.
.##....##....##...#..
#######........##....

...........#######............
..........##########..........
..........##########..........
.........############.........
.........############.........
.........############.........
.........############.........
.........############.........
.........####.#######.........
.........##.....#####.........
..........############........
..........############........
.........#######..#####.......
........###.###...######......
.......###.........#####.......
.......###.........######.....
......####.........#######....
......####..........######....
.....####...........#######...
.....####............######...
....####.............######...
....####.............######...
....####.............######...
....####.............######...
....####............#######...
...#..###...........########..
####...####.........########..
####....####........#.....##..
##......####.......##......###
##.......###......###.......##
##........###...#####.......##
#.........###########.....####
####......###########...####..
.#########################....
.....######........######.....
Error decoding image
*/