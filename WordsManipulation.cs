using System.Text;
using System;

namespace PadawansTask8
{
    public static class WordsManipulation
    {
        public static void RemoveDuplicateWords(ref string text)
        {
            if (text == null)
                throw new ArgumentNullException();
            if (text == "")
                throw new ArgumentException();
            char[] textchar = text.ToCharArray();
            //массив слов string 
            string[] word = new string[0];
            // массив индексов начала слов word в массиве array
            int[] intword = new int[0];
            int FirstLetterOfWord = 0;
            int lastLetterOfWord = 0;
            int indexWord = 0;
            //Медод сохраненияя слова и индекса его певого символа в массиве
            void Saveword(int first, int last, char[] arraychar, string[] Word)
            {
                char[] temp = new char[last - first];
                for (int i = 0; i < (last - first); i++)
                {
                    temp[i] = arraychar[i + first];
                }
                Word[indexWord] = new string(temp);
                intword[indexWord] = first;
                indexWord++;
            }
            //удаление слов и смещение cимволов 
            void delete(int longword, int index)
            {
                for (int i = intword[index]; i < textchar.Length - longword; i++)
                {
                    if (intword[index] + longword + 1 != textchar.Length - 1)
                    {
                        textchar[i] = textchar[i + longword];
                    }
                }
                Array.Resize(ref textchar, textchar.Length - longword);
                for (int i = index; i <= word.Length - 1; i++)
                {
                    if (i + 1 <= (word.Length - 1))
                    {
                        word[i] = word[i + 1];
                        intword[i] = intword[i + 1] - longword;
                    }
                }
                Array.Resize(ref word, word.Length - 1);
                Array.Resize(ref intword, intword.Length - 1);
            } 
            //Сравнивание int символа с числом являющимся кодом числа в Юникоде 
            for (int i = 0; i < textchar.Length; i++)
            {
                if (i == 0 && ((65 <= (int)textchar[i] && (int)textchar[i] <= 90)
                    || (97 <= (int)textchar[i] && (int)textchar[i] <= 122)))
                //char.IsLetter(textchar[i]))
                {
                    FirstLetterOfWord = i;
                }
                if (i != 0)
                {

                    if// (char.IsLetter(textchar[i])&&!char.IsLetter(textchar[i-1]))
                    (((65 <= (int)textchar[i] && (int)textchar[i] <= 90)
                    || (97 <= (int)textchar[i] && (int)textchar[i] <= 122))
                    && (((int)(textchar[i - 1]) == 59)
                    || ((int)(textchar[i - 1]) == 46)
                    || ((int)(textchar[i - 1]) == 44)
                    || ((int)(textchar[i - 1]) == 32)
                    || ((int)(textchar[i - 1]) == 45)
                    || ((int)(textchar[i - 1]) == 33)
                    || ((int)(textchar[i - 1]) == 63)))
                    {
                        FirstLetterOfWord = i;
                    }
                    if ((i == (textchar.Length - 1))
                        && ((65 <= (int)textchar[i] && (int)textchar[i] <= 90)
                    || (97 <= (int)textchar[i] && (int)textchar[i] <= 122)))
                    //&&char.IsLetter(textchar[i]))
                    {
                        lastLetterOfWord = i + 1;
                        Array.Resize(ref intword, intword.Length + 1);
                        Array.Resize(ref word, word.Length + 1);
                        Saveword(FirstLetterOfWord, lastLetterOfWord, textchar, word);
                    }
                    if ((((int)(textchar[i]) == 59)
                    || ((int)(textchar[i]) == 46)
                    || ((int)(textchar[i]) == 44)
                    || ((int)(textchar[i]) == 32)
                    || ((int)(textchar[i]) == 45)
                    || ((int)(textchar[i]) == 33)
                    || ((int)(textchar[i]) == 63))

                    &&
                    ((65 <= (int)textchar[i - 1]
                    && (int)textchar[i - 1] <= 90)
                    || (97 <= (int)textchar[i - 1]
                    && (int)textchar[i - 1] <= 122)))
                    //!char.IsLetter(textchar[i])&&char.IsLetter(textchar[i-1]))
                    {
                        lastLetterOfWord = i;
                        Array.Resize(ref intword, intword.Length + 1);
                        Array.Resize(ref word, word.Length + 1);
                        Saveword(FirstLetterOfWord, lastLetterOfWord, textchar, word);
                    }
                }

            }
            bool ch = true;
            do
            {
                ch = true;
                for (int i = 0; i < word.Length; i++)
                {
                    for (int j = word.Length - 1; j >= 1; j--)
                    {
                        if (string.Equals(word[i], word[j]) && i != j)
                        {

                            delete(word[j].Length, j);
                            ch = false;
                            break;
                        }
                    }
                    if (ch == false)
                    {
                        break;
                    }
                }
            } while (ch == false);
            text = new string(textchar);

        }
    }
}