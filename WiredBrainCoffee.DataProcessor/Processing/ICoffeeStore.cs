using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiredBrainCoffee.DataProcessor.Model;

namespace WiredBrainCoffee.DataProcessor.Processing
{
    public interface ICoffeeStore
    {
        void Save(MachineDataItem coffeeItem);
        IDictionary<string, int> GetAll();

    }

    public class CoffeeStoreInMemory : ICoffeeStore
    {
        private readonly IDictionary<string, int> _countPerCoffeeType = new Dictionary<string, int>();

        public IDictionary<string, int> GetAll()
        {
            return _countPerCoffeeType;
        }

        public void Save(MachineDataItem coffeeItem)
        {
            if (!_countPerCoffeeType.ContainsKey(coffeeItem.CoffeeType))
            {
                _countPerCoffeeType.Add(coffeeItem.CoffeeType, 1);
            }
            else
            {
                _countPerCoffeeType[coffeeItem.CoffeeType]++;
            }
        }
    }
}
