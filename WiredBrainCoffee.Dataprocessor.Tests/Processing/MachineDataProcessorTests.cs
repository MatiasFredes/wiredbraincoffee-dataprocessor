using WiredBrainCoffee.DataProcessor.Model;
using WiredBrainCoffee.DataProcessor.Processing;

namespace WiredBrainCoffee.Dataprocessor.Tests.Processing;

public class MachineDataProcessorTests
{
    [Fact]
    public void ShouldHave2Capuccinos()
    {
        var showResult = new ShowResultConsole();
        var coffeStore = new CoffeeStoreInMemory();

        MachineDataProcessor machineDataProcessor = new MachineDataProcessor(coffeStore, showResult);

        machineDataProcessor.ProcessItems(
        [
            new MachineDataItem("Capuccino", new DateTime(2022, 10, 10, 9, 0, 0)),
            new MachineDataItem("Capuccino", new DateTime(2022, 10, 10, 9, 10, 0)),
            new MachineDataItem("Espresso", new DateTime(2022, 10, 10, 9, 15, 0)),
        ]);

        Assert.NotNull(coffeStore.GetAll());
        Assert.Equal(2, coffeStore.GetAll()["Capuccino"]);
    }
    [Fact]
    public void ShouldIgnoreItemsThatAreNotNewer()
    {
        var showResult = new ShowResultConsole();
        var coffeStore = new CoffeeStoreInMemory();

        MachineDataProcessor machineDataProcessor = new MachineDataProcessor(coffeStore, showResult);

        machineDataProcessor.ProcessItems(
        [
            new MachineDataItem("Capuccino", new DateTime(2022,10,10,9,0,0)),
            new MachineDataItem("Capuccino", new DateTime(2022, 10, 10, 8, 10, 0)),
            new MachineDataItem("Capuccino", new DateTime(2022, 10, 10, 8, 0, 0)),
        ]);

        Assert.NotNull(coffeStore.GetAll());
        Assert.Equal(1, coffeStore.GetAll()["Capuccino"]);
    }
}
