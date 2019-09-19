using System.Text;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace PadawansTask8
{
    public static class WordsManipulation
    {
        public static void RemoveDuplicateWords(ref string text)
        {   
            string[] words = text.Split(new char[] { '.', ',', '!', '?', '-', ':', ';', ' ' }).Distinct().ToArray();
            int index;
            foreach (var item in words)
            {
                index=text.IndexOf(item)+item.Length;
                string beforeSeparator;
                string afterSeparator;
                beforeSeparator=text.Substring(0,index);
                afterSeparator=text.Substring(index,text.Length-index);
                text = text.Substring(0, index) + text.Substring(index, text.Length - index).Replace(item, "");
            }
        }
    }
}