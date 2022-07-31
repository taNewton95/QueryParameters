﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryParameters.AspNetCore.Mvc.Parsers
{
    internal class StringParser
    {

        public readonly string InputString;

        private int LastMatchIndex = -1, IterationIndex = 0;

        public string CurrentString { get; private set; }
        public char? MatchedChar { get; private set; }

        public StringParser(string inputString)
        {
            InputString = inputString;
        }

        public bool Next(char delimiter, bool includeFinal = true)
        {
            return Next(new HashSet<char>(new[] { delimiter }), includeFinal: includeFinal);
        }

        public bool Next(HashSet<char> delimiters, bool includeFinal = true)
        {
            if (IterationIndex >= InputString.Length) return false;

            while (IterationIndex < InputString.Length)
            {
                var currentChar = InputString[IterationIndex];

                IterationIndex++;

                if (delimiters.Contains(currentChar))
                {
                    var calculatedLastMatchIndex = Math.Max(LastMatchIndex, 0);

                    LastMatchIndex = IterationIndex;
                    MatchedChar = currentChar;
                    CurrentString = InputString.Substring(calculatedLastMatchIndex, IterationIndex - 1 - calculatedLastMatchIndex);

                    if (!string.IsNullOrEmpty(CurrentString))
                    {
                        return true;
                    }
                }
            }

            MatchedChar = null;

            if (LastMatchIndex >= InputString.Length)
            {
                CurrentString = null;
            }
            else
            {
                CurrentString = InputString.Substring(LastMatchIndex, InputString.Length - LastMatchIndex);

                if (includeFinal) return true;
            }

            return false;
        }

    }
}