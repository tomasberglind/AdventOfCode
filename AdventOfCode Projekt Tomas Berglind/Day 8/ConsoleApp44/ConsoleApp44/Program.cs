//KAN variera beroende på filepath och användares dator
string filePath = @"C:\Users\Tomas\source\repos\ConsoleApp44\ConsoleApp44\TextFile1.txt";

string[] lines = File.ReadAllLines(filePath);

//int amountOfSpecialNumbers = 0;  //från del 1
string[] index = new string[10];
int sumOfOutput = 0;
string templine;
string outputInString;



foreach (string line in lines) //Går genom varje rad
{
    //Nollställer inför varje ny rad
    outputInString = "";
    int tempSum = 0;
    for (int i = 0; i < 10; i++) 
    {
        index[i] = "x";
    }


    do //Loopar raden, fram tills att alla "ord" blivit översatta till siffror, kan ta några varv
    {
        foreach (string word in line.Split(' ')) //Går genom varje bokstavskombination på den raden
        {
            WhatNumberIsThis(word);
        }
    } while (AreAllIndexFilled());
    

    templine = line.Substring(line.IndexOf('|') + 2); //Urskiljer endast de 4 sista siffrorna sparar i en sträng
    //amountOfSpecialNumbers += Translate(templine);  //Från del 1, används ej i del 2

    foreach (string word in templine.Split(' ')) //Översätter de 4 sista siffrorna, lägger ihop dem till en sträng, den strängen blir sen en int. dessa slås ihop
    {
        outputInString += Translate(word); //Strängen som skickas in är ex. "be" "abgef" osv. returnen blir exempelvis, "1" "2" "3" "4".  +=strängas ihop till "1234"
 
        tempSum = Convert.ToInt32(outputInString); //omvandlar till int, 1234
    }
    sumOfOutput += tempSum; 
}

Console.WriteLine(sumOfOutput);
Console.ReadKey();

bool AreAllIndexFilled()
{
    int counter = 0;
    for (int i = 0; i < index.Length; i++)
    {
        if (index[i] != "x")
        {
            counter++;
        }
    }
    if (counter == 10)
    {
        return false;
    }
    else
    {
        return true;
    }
}

static int GetAmountOfMatchingLetters(string word, string index)
{
    int matches = 0;
    foreach (char letter in index)
    {
        if (word.Contains(letter))
        {
            matches++;
        }
    }

    return matches;
}

void WhatNumberIsThis(string word)
{
    if (word.Length == 2 && index[1] == "x")
    {
        index[1] = word;
    }
    else if (word.Length == 3 && index[7] == "x")
    {
        index[7] = word;
    }
    else if (word.Length == 4 && index[4] == "x")
    {
        index[4] = word;
    }
    else if (word.Length == 7 && index[8] == "x")
    {
        index[8] = word;
    }
    else
    {
        if (index[3] == "x" && word.Length == 5 && GetAmountOfMatchingLetters(word, index[1]) == 2)
        {
            index[3] = word;
        }
        else if (index[9] == "x" && word.Length == 6 && GetAmountOfMatchingLetters(word, index[3]) == 5)
        {
            index[9] = word;
        }
        else if (index[5] == "x" && word.Length == 5 && GetAmountOfMatchingLetters(word, index[6]) == 5)
        {
            index[5] = word;
        }
        else if (index[6] == "x" && word.Length == 6 && GetAmountOfMatchingLetters(word, index[3]) == 4 && GetAmountOfMatchingLetters(word, index[1]) == 1)
        {
            index[6] = word;
        }
        else if (index[2] == "x" && word.Length == 5 && GetAmountOfMatchingLetters(word, index[1]) == 1 && GetAmountOfMatchingLetters(word, index[5]) == 3)
        {
            index[2] = word;
        }
        else if (index[0] == "x" && word.Length == 6 && GetAmountOfMatchingLetters(word, index[1]) == 2 && GetAmountOfMatchingLetters(word, index[3]) == 4)
        {
            index[0] = word;
        }
    }
}

string Translate(string word) //del 1. Hittar orden med de unika längderna   -- Del 2. Uppdaterar så att man translatear alla inkommande textkombos. Metoden går från att returna int till att returna string
{
    //int counter = "";

    //foreach (string word in line.Split(' '))
    //{
    //    if (word.Length == 2 || word.Length == 3 || word.Length == 4|| word.Length == 7)
    //    {
    //        counter++; //1 ++
    //    }
    //}
    //return counter;
    //----------------------------------Ovan del 1

    string output = "";
    int charMatches = 0;

    if (word.Length == 2)
    {
        output += "1"; //1

    }
    else if (word.Length == 3)
    {
        output += "7";
    }
    else if (word.Length == 4)
    {
        output += "4";
    }
    else if (word.Length == 7)
    {
        output += "8";
    }
    else if (word.Length == 5)
    {
        foreach (char c in index[2])
        {
            if (word.Contains(c))
            {
                charMatches++;
            }
        }
        if (charMatches == 5)
        {
            output += "2";
        }
        else
        {
            charMatches = 0;
        }

        foreach (char c in index[3])
        {
            if (word.Contains(c))
            {
                charMatches++;
            }
        }
        if (charMatches == 5)
        {
            output += "3";
        }
        else
        {
            charMatches = 0;
        }

        foreach (char c in index[5])
        {
            if (word.Contains(c))
            {
                charMatches++;
            }
        }
        if (charMatches == 5)
        {
            output += "5";
        }
        else
        {
            charMatches = 0;
        }
    }
    else if (word.Length == 6)
    {
        foreach (char c in index[0])
        {
            if (word.Contains(c))
            {
                charMatches++;
            }
        }
        if (charMatches == 6)
        {
            output += "0";
        }
        else
        {
            charMatches = 0;
        }

        foreach (char c in index[6])
        {
            if (word.Contains(c))
            {
                charMatches++;
            }
        }
        if (charMatches == 6)
        {
            output += "6";
        }
        else
        {
            charMatches = 0;
        }

        foreach (char c in index[9])
        {
            if (word.Contains(c))
            {
                charMatches++;
            }
        }
        if (charMatches == 6)
        {
            output += "9";
        }
        else
        {
            charMatches = 0;
        }
    }
    return output;
}
