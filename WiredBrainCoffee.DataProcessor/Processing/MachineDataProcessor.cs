using WiredBrainCoffee.DataProcessor.Model;

namespace WiredBrainCoffee.DataProcessor.Processing
{
    public class MachineDataProcessor
    {
        private ICoffeeStore _coffeeStore;
        private IShowResult _showResult;

        public MachineDataProcessor(ICoffeeStore coffeeStore, IShowResult showResult)
        {
            _coffeeStore = coffeeStore;
            _showResult = showResult;
        }
        public void ProcessItems(MachineDataItem[] dataItems)
        {
            if(dataItems is null || dataItems.Length == 0) return;

            ProcessItem(dataItems[0]);
            for (int i = 1; i < dataItems.Length; i++)
            {
                MachineDataItem? dataItem = dataItems[i];
                
                if (dataItem.CreatedAt > dataItems[i -1].CreatedAt) 
                {
                    ProcessItem(dataItem);
                }
            }

            ShowResult();
        }

        private void ProcessItem(MachineDataItem dataItem)
        {
            _coffeeStore.Save(dataItem);
        }

        private void ShowResult()
        {
            foreach (var entry in _coffeeStore.GetAll())
            {
                var line = $"{entry.Key}:{entry.Value}";
                _showResult.Message = line;
                _showResult.ShowResult();
            }
        }
    }
}
