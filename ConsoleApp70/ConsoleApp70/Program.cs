using System;
using System.IO;

class PolybiusCipher
{
  
    private static readonly string[,] polybiusSquare = new string[5, 5]
    {
        { "A", "B", "C", "D", "E" },
        { "F", "G", "H", "IJ", "K" },
        { "L", "M", "N", "O", "P" },
        { "Q", "R", "S", "T", "U" },
        { "V", "W", "X", "Y", "Z" }
    };

    public static string Encrypt(string text)
    {
        text = text.ToUpper();
        string encryptedText = "";

        foreach (char c in text)
        {
            if (c == ' ') 
                continue;

            bool found = false;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (polybiusSquare[i, j].Contains(c.ToString()))
                    {
                        encryptedText += $"{i + 1}{j + 1} ";
                        found = true;
                        break;
                    }
                }
                if (found) break;
            }

            if (!found) 
                encryptedText += $"? ";
        }

        return encryptedText.Trim();
    }

    public static string Decrypt(string encryptedText)
    {
        string[] pairs = encryptedText.Split(' ');
        string decryptedText = "";

        foreach (string pair in pairs)
        {
            if (pair.Length != 2 || !int.TryParse(pair, out int number)) 
                continue;

            int row = (number / 10) - 1;
            int col = (number % 10) - 1;

            if (row >= 0 && row < 5 && col >= 0 && col < 5)
                decryptedText += polybiusSquare[row, col];
        }

        return decryptedText;
    }

    
    public static void SaveToFile(string text, string filePath)
    {
        File.WriteAllText(filePath, text);
    }

    
    public static string ReadFromFile(string filePath)
    {
        return File.ReadAllText(filePath);
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Введите текст для шифрования:");
        string inputText = Console.ReadLine();

      
        string encryptedText = Encrypt(inputText);
        Console.WriteLine($"Зашифрованный текст: {encryptedText}");

       
        SaveToFile(encryptedText, "encrypted.txt");
        Console.WriteLine("Зашифрованный текст сохранён в файл.");

        
        string fileContent = ReadFromFile("encrypted.txt");
        Console.WriteLine($"Прочитанный из файла текст: {fileContent}");

       
        string decryptedText = Decrypt(fileContent);
        Console.WriteLine($"Расшифрованный текст: {decryptedText}");
    }
}