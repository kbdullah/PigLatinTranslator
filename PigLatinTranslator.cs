using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigLatinTranslator
{
    public class PigLatinTranslator
    {
        char[] _vowels = new char[] { 'a', 'e', 'i', 'o', 'u', 'y' };

        public PigLatinTranslator()
        {
        }

        public String PigLatinTranslate(String phrase)
        {
            // take in full string of user input
            String[] words = phrase.Split(' ');
            String translatedPhrase = String.Empty;

            foreach(var word in words)
            {
                // does the word have letters?
                var hasLetters = word.Any(c => char.IsLetter(c));
                // set the translated word to the same word by default
                var translatedWord = word;
                // if the word has letters, translate the word to pig latin
                if(hasLetters)
                {
                    translatedWord = SingleWordPigLatinTranslate(word);
                }
                translatedPhrase += translatedWord;
                translatedPhrase += " ";
            }

            // remove trailing whitespace
            translatedPhrase = translatedPhrase.TrimEnd(' ');

            return translatedPhrase;
        }

        private String SingleWordPigLatinTranslate(String word)
        {
            String puncSubStr;
            word = SeparatePunctuation(word, out puncSubStr);
            // does the word begin with a capital letter?
            // find the first character of the word
            var firstChar = word.First();
            var firstCharUpper = char.IsUpper(firstChar);
            // lower case the word
            word = word.ToLower();
            // does the word contain consonants
            var containsConsonants = ContainsConsonants(word);
            // default to "no consonants" standard where prefix is empty and word is stem
            String prefix = String.Empty;
            String stem = word;
            String suffix = "yay";
            // if we contain consonants, separate the word into the prefix and stem
            if (containsConsonants)
            {
                // find the index of the first vowel
                var firstVowel = word.First(c => _vowels.Contains(c));
                var indexOfFirstVowel = word.IndexOf(firstVowel);
                // take the substring to find the prefix
                prefix = word.Substring(0, indexOfFirstVowel);
                // take the substring to find the stem
                stem = word.Substring(indexOfFirstVowel, word.Length - prefix.Length);
                // set the suffix to "ay"
                suffix = "ay";
            }
            // reverse the order of the string and the prefix, then append pig latin suffix ay/yay, and last add punctuation
            var translation = stem + prefix + suffix + puncSubStr;
            // if the first letter was capitalized, then capitalize the first letter of the translation
            if (firstCharUpper)
            {
                translation = CapitalizeFirstCharacter(translation);
            }

            return translation;
        }

        private bool ContainsConsonants(String word)
        {
            var consonantFlag = false;
            var lowerWord = word.ToLower();

            foreach (char c in lowerWord)
            {
                if (!_vowels.Contains(c))
                {
                    consonantFlag = true;
                    break;
                }
            }

            return consonantFlag;
        }

        private String CapitalizeFirstCharacter(String word)
        {
            // identify the first character
            var firstChar = word[0];
            // separate the rest of the word from the first character
            var suffix = word.Substring(1, word.Length - 1);
            // upper case the first character
            firstChar = char.ToUpper(firstChar);
            // add back the rest of the word to the first character
            word = firstChar + suffix;

            return word;
        }

        /// <summary>
        /// Returns any terminating punctuation. Otherwise, returns String.Empty
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        private String SeparatePunctuation(String word, out String puncSubStr)
        {
            puncSubStr = String.Empty;
            // is there any punctuation? 
            var anyPunc = word.Any(c => char.IsPunctuation(c));
            if (anyPunc)
            {
                // isolate any leading/trailing punctuation
                var firstPunc = word.First(c => char.IsPunctuation(c));
                // find the index of the punctuation
                var indexOfFirstPunc = word.IndexOf(firstPunc);
                // isolate the punctuation and anything after it
                puncSubStr = word.Substring(indexOfFirstPunc);
                // 
                word = word.Substring(0, indexOfFirstPunc);
            }

            return word;
        }
    }

    
}
