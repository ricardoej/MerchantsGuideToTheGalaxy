using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converters
{
    public abstract class NumeralConverterWithoutSymbolTable
    {
        public abstract double Convert(string numeral);
    }

    public abstract class NumeralConverterWithSymbolTable<TSymbolValue>: NumeralConverterWithoutSymbolTable
    {
        protected IDictionary<string, TSymbolValue> SymbolsValueTable { get; private set; }

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

    public abstract class NumeralConverterWithSymbolTableAndMultiplierTable<TSymbolValue, TMultiplierValue>:
        NumeralConverterWithSymbolTable<TSymbolValue>
    {
        protected IDictionary<string, TMultiplierValue> MultipliersValueTable { get; private set; }

        public NumeralConverterWithSymbolTableAndMultiplierTable()
        {
            MultipliersValueTable = new Dictionary<string, TMultiplierValue>();
        }

        public void AddMultiplierValue(string symbol, TMultiplierValue value)
        {
            MultipliersValueTable.Add(symbol, value);
        }

        public void RemoveMultiplierValue(string symbol, TMultiplierValue value)
        {
            if (MultipliersValueTable.ContainsKey(symbol))
            {
                MultipliersValueTable.Remove(symbol);
            }
        }
    }
}
