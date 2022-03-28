

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

Console.WriteLine("Svar del 1: " + sumRisk);
Console.WriteLine();


//Del 2 --------------------------------------------------------------------------------------
//

bool[][] visitedBasin = new bool[field.Length][]; //bools för om man 
bool[][] goingToAddBasin = new bool[field.Length][]; //bools för att urskilja de man ska lägga till i visited, från de man har kvar att lägga till
int[] threeLargestBasins = new int[3] { 0, 0, 0 };

for (int i = 0; i < visitedBasin.Length; i++)
{
    visitedBasin[i] = new bool[field.Length];
    goingToAddBasin[i] = new bool[field.Length];
}

for (int x = 0; x < field.Length; x++)
{
    for (int y = 0; y < field.Length; y++)
    {
        if (x == 0) //Översta raden
        {
            if (y == 0) //Längst till vänster
            {
                if (field[x][y] < field[x][y + 1] && field[x][y] < field[x + 1][y] && visitedBasin[x][y] != true)
                {
                    goingToAddBasin[x][y] = true;
                    AddAllInBasin();
                    CountAllInBasin();
                }
            }
            else if (y == 99) //Längst till höger
            {
                if (field[x][y] < field[x][y - 1] && field[x][y] < field[x + 1][y] && visitedBasin[x][y] != true)
                {
                    goingToAddBasin[x][y] = true;
                    AddAllInBasin();
                    CountAllInBasin();
                }
            }
            else if (field[x][y] < field[x][y - 1] && field[x][y] < field[x][y + 1] && field[x][y] < field[x + 1][y] && visitedBasin[x][y] != true)
            {
                goingToAddBasin[x][y] = true;
                AddAllInBasin();
                CountAllInBasin();
            }
        }
        else if (x == field.Length - 1) //Nedersta raden
        {
            if (y == 0) //Längst till vänster
            {
                if (field[x][y] < field[x][y + 1] && field[x][y] < field[x - 1][y] && visitedBasin[x][y] != true)
                {
                    goingToAddBasin[x][y] = true;
                    AddAllInBasin();
                    CountAllInBasin();
                }
            }
            else if (y == 99) //Längst till höger
            {
                if (field[x][y] < field[x][y - 1] && field[x][y] < field[x - 1][y] && visitedBasin[x][y] != true)
                {
                    goingToAddBasin[x][y] = true;
                    AddAllInBasin();
                    CountAllInBasin();
                }
            }
            else if (field[x][y] < field[x][y - 1] && field[x][y] < field[x][y + 1] && field[x][y] < field[x - 1][y] && visitedBasin[x][y] != true)
            {
                goingToAddBasin[x][y] = true;
                AddAllInBasin();
                CountAllInBasin();
            }
        }
        else //Inte översta eller nedersta raden
        {
            if (y == 0) //Längst till vänster
            {
                if (field[x][y] < field[x][y + 1] && field[x][y] < field[x - 1][y] && field[x][y] < field[x + 1][y] && visitedBasin[x][y] != true)
                {
                    goingToAddBasin[x][y] = true;
                    AddAllInBasin();
                    CountAllInBasin();
                }
            }
            else if (y == 99) //Längst till höger
            {
                if (field[x][y] < field[x][y - 1] && field[x][y] < field[x - 1][y] && field[x][y] < field[x + 1][y] && visitedBasin[x][y] != true)
                {
                    goingToAddBasin[x][y] = true;
                    AddAllInBasin();
                    CountAllInBasin();
                }
            }
            else if (field[x][y] < field[x][y - 1] && field[x][y] < field[x][y + 1] && field[x][y] < field[x - 1][y] && field[x][y] < field[x + 1][y] && visitedBasin[x][y] != true)
            {
                goingToAddBasin[x][y] = true;
                AddAllInBasin();
                CountAllInBasin();
            }
        }
    }
} //För varje lägsta punkt

Console.WriteLine("Svar del 2: " + (threeLargestBasins[0] * threeLargestBasins[1] * threeLargestBasins[2]));
Console.ReadKey();

void AddAllInBasin() //Om grannen är bool goingtoadd true, och man själv inte är en nia, så blir man också true
{
    int counter = 1; // +1 om man hittar en granne, går denna ner till 0 så aka man ha hittat alla

    do
    {
        for (int x = 0; x < field.Length; x++)
        {
            for (int y = 0; y < field.Length; y++)
            {
                if (field[x][y] != 9 && goingToAddBasin[x][y] != true && visitedBasin[x][y] != true)//Inga nior och inte räkna med de som räknats in tidigare
                {
                    if (x == 0) //Översta raden
                    {
                        if (y == 0) //Längst till vänster
                        {
                            if (goingToAddBasin[x][y + 1] == true || goingToAddBasin[x + 1][y] == true)
                            {
                                goingToAddBasin[x][y] = true;
                                counter++;
                            }
                        }
                        else if (y == 99) //Längst till höger
                        {
                            if (goingToAddBasin[x][y - 1] == true || goingToAddBasin[x + 1][y] == true)
                            {
                                goingToAddBasin[x][y] = true;
                                counter++;
                            }
                        }
                        else if (goingToAddBasin[x][y + 1] == true || goingToAddBasin[x][y - 1] == true || goingToAddBasin[x + 1][y] == true)
                        {
                            goingToAddBasin[x][y] = true;
                            counter++;
                        }
                    }
                    else if (x == 99) //Nedersta raden
                    {
                        if (y == 0) //Längst till vänster
                        {
                            if (goingToAddBasin[x][y + 1] == true || goingToAddBasin[x - 1][y] == true)
                            {
                                goingToAddBasin[x][y] = true;
                                counter++;
                            }
                        }
                        else if (y == 99) //Längst till höger
                        {
                            if (goingToAddBasin[x][y - 1] == true || goingToAddBasin[x - 1][y] == true)
                            {
                                goingToAddBasin[x][y] = true;
                                counter++;
                            }
                        }
                        else if (goingToAddBasin[x][y + 1] == true || goingToAddBasin[x][y - 1] == true || goingToAddBasin[x - 1][y] == true)
                        {
                            goingToAddBasin[x][y] = true;
                            counter++;
                        }
                    }
                    else //Inte översta eller nedersta raden
                    {
                        if (y == 0) //Längst till vänster
                        {
                            if (goingToAddBasin[x][y + 1] == true || goingToAddBasin[x + 1][y] == true || goingToAddBasin[x - 1][y] == true)
                            {
                                goingToAddBasin[x][y] = true;
                                counter++;
                            }
                        }
                        else if (y == 99) //Längst till höger
                        {
                            if (goingToAddBasin[x][y - 1] == true || goingToAddBasin[x + 1][y] == true || goingToAddBasin[x - 1][y] == true)
                            {
                                goingToAddBasin[x][y] = true;
                                counter++;
                            }
                        }
                        else if (goingToAddBasin[x][y + 1] == true || goingToAddBasin[x][y - 1] == true || goingToAddBasin[x + 1][y] == true || goingToAddBasin[x - 1][y] == true)
                        {
                            goingToAddBasin[x][y] = true;
                            counter++;
                        }
                    }
                }
            }
        }
        counter--;
    } while (counter != 0);
}

void CountAllInBasin() //För varje goingToAddToBasin -> +1 på en räknare & lägger den som visited istället
{
    int counter = 0;

    for (int x = 0; x < field.Length; x++)
    {
        for (int y = 0; y < field.Length; y++)
        {
            if (goingToAddBasin[x][y] == true)
            {
                counter++;
                goingToAddBasin[x][y] = false;
                visitedBasin[x][y] = true;
            }
        }
    }

    int temp = 0;


    if (counter > threeLargestBasins[2])
    {
        threeLargestBasins[2] = counter;
    }
    
    if (threeLargestBasins[2] > threeLargestBasins[1])
    {
        temp = threeLargestBasins[1];
        threeLargestBasins[1] = threeLargestBasins[2];
        threeLargestBasins[2] = temp;
    }
    if (threeLargestBasins[0] < threeLargestBasins[1])
    {
        temp = threeLargestBasins[0];
        threeLargestBasins[0] = threeLargestBasins[1];
        threeLargestBasins[1] = temp;
    }
}
