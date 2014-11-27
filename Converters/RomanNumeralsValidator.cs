using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Converters
{
    public class RomanNumeralsValidator
    {
        private List<string> romanNumeralsInvalidatePatterns = new List<string>()
        {
            // Invalid symbols
            "[^IVXLCDM]",

            // The symbols "I", "X", "C", and "M" can be repeated three times in succession, but no more.
            "I{4,}", "X{4,}", "C{4,}", "M{4,}",

            // "D", "L", and "V" can never be repeated
            "D{2,}", "L{2,}", "V{2,}",

            // "I" can be subtracted from "V" and "X" only
            "IL", "IC", "ID", "IM",

            // "X" can be subtracted from "L" and "C" only
            "XD", "XM",

            // "V", "L", and "D" can never be subtracted
            "VX", "VL", "VC", "VD", "VM", "LC", "LD", "LM", "DM"
        };

        public bool IsValid(string romanNumeral)
        {
            foreach (var invalidatePattern in romanNumeralsInvalidatePatterns)
            {
                if (SymbolMatchWithInvalidatePattern(romanNumeral, invalidatePattern))
                    return false; // the numeral is not valid
            }

            return true; // great! we have a valid numeral
        }

        private bool SymbolMatchWithInvalidatePattern(string romanNumeral, string invalidatePattern)
        {
            return Regex.IsMatch(romanNumeral, invalidatePattern);
        }
    }
}
