using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantsGuideToTheGalaxy
{
    public abstract class NumeralConverter
    {
        public abstract double Convert(string numeral);
    }

    public abstract class NumeralConverterWithSymbolTable<TSymbolValue>: NumeralConverter
    {
        public IDictionary<string, TSymbolValue> SymbolsValueTable { get; private set; }

        public NumeralConverterWithSymbolTable()
        {
            SymbolsValueTable = new Dictionary<string, TSymbolValue>();
        }

        public void AddSymbolValue(string symbol, TSymbolValue value)
        {
            SymbolsValueTable.Add(symbol, value);
        }

        public void RemoveSymbolValue(string symbol, TSymbolValue value)
        {
            if (SymbolsValueTable.ContainsKey(symbol))
            {
                SymbolsValueTable.Remove(symbol);
            }
        }
    }

    public abstract class NumeralConverterWithSymbolTableAndMultiplierTable<TSymbolValue>:
        NumeralConverterWithSymbolTable<TSymbolValue>
    {
        public IDictionary<string, double> MultipliersValueTable { get; private set; }

        public NumeralConverterWithSymbolTableAndMultiplierTable()
        {
            MultipliersValueTable = new Dictionary<string, double>();
        }

        public void AddMultiplierValue(string symbol, double value)
        {
            MultipliersValueTable.Add(symbol, value);
        }

        public void RemoveMultiplierValue(string symbol, double value)
        {
            if (MultipliersValueTable.ContainsKey(symbol))
            {
                MultipliersValueTable.Remove(symbol);
            }
        }
    }
}
