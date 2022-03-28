

string filePath = @"C:\Users\Tomas\source\repos\ConsoleApp45\ConsoleApp45\TextFile1.txt";
string[] fieldString = File.ReadAllLines(filePath);
int[][] field = new int[fieldString.Length][];
int temp = 0;
int sumRisk = 0;

for (int i = 0; i < fieldString.Length; i++)
{
    field[i] = new int[fieldString[i].Length];
    int j = 0;

    foreach (char c in fieldString[i])
    {
        string tempString = Convert.ToString(c);
        temp = Convert.ToInt32(tempString);
        field[i][j] = temp;
        j++;
    }
}

for (int x = 0; x < field.Length; x++)
{
    for (int y = 0; y < field.Length; y++)
    {
        if (x == 0) //Översta raden
        {
            if (y == 0) //Längst till vänster
            {
                if (field[x][y] < field[x][y + 1] && field[x][y] < field[x + 1][y])
                {
                    sumRisk += field[x][y] + 1;
                }

            }
            else if (y == 99) //Längst till höger
            {
                if (field[x][y] < field[x][y - 1] && field[x][y] < field[x + 1][y])
                {
                    sumRisk += field[x][y] + 1;
                }
            }
            else if (field[x][y] < field[x][y - 1] && field[x][y] < field[x][y + 1] && field[x][y] < field[x + 1][y])
            {
                sumRisk += field[x][y] + 1;
            }
        }
        else if (x == field.Length - 1) //Nedersta raden
        {
            if (y == 0) //Längst till vänster
            {
                if (field[x][y] < field[x][y + 1] && field[x][y] < field[x - 1][y])
                {
                    sumRisk += field[x][y] + 1;
                }
            }
            else if (y == 99) //Längst till höger
            {
                if (field[x][y] < field[x][y - 1] && field[x][y] < field[x - 1][y])
                {
                    sumRisk += field[x][y] + 1;
                }
            }
            else if (field[x][y] < field[x][y - 1] && field[x][y] < field[x][y + 1] && field[x][y] < field[x - 1][y])
            {
                sumRisk += field[x][y] + 1;
            }
        }
        else //Inte översta eller nedersta raden
        {
            if (y == 0) //Längst till vänster
            {
                if (field[x][y] < field[x][y + 1] && field[x][y] < field[x - 1][y] && field[x][y] < field[x + 1][y])
                {
                    sumRisk += field[x][y] + 1;
                }
            }
            else if (y == 99) //Längst till höger
            {
                if (field[x][y] < field[x][y - 1] && field[x][y] < field[x - 1][y] && field[x][y] < field[x + 1][y])
                {
                    sumRisk += field[x][y] + 1;
                }
            }
            else if (field[x][y] < field[x][y - 1] && field[x][y] < field[x][y + 1] && field[x][y] < field[x - 1][y] && field[x][y] < field[x + 1][y])
            {
                sumRisk += field[x][y] + 1;
            }
        }
    }
}

Console.WriteLine(sumRisk);
Console.ReadKey();


//Del 2 --------------------------------------------------------------------------------------
//

//bool[][] visitedBasin = new bool[field.Length][];
//int[] threeLargestBasins = new int[3];

//for (int i = 0; i < visitedBasin.Length; i++)
//{
//    visitedBasin[i] = new bool[field.Length];
//}

//for (int x = 0; x < field.Length; x++)
//{
//    for (int y = 0; y < field.Length; y++)
//    {
//        if (field[x][y] == 9)
//        {
//            for(int z = y; z > 0; z--) //Går åt vänster
//            {
//                for(int d = x; d<field.Length-x;d++)//Går ner
//                {
//                    if (field[d][z] == 9)
//                    {
//                        continue;
//                    }
//                    else if(visitedBasin[d][z] == false)
//                    {
//                        visitedBasin[d][z] = true;
//                    }

//                }
//                for (int d = x; d > 0; d--)//Går upp
//                {
//                    if (field[d][z] == 9)
//                    {
//                        continue;
//                    }
//                    else if(visitedBasin[d][z] == false)
//                    {
//                        visitedBasin[d][z] = true;
//                    }
//                }
//            }
//        }
//    }
//}