
namespace Solid1;
//Принцип єдиного обов'язку(розподілення класів)
class Item
{

}

class Order
{
    public IList<Item> ItemList { get; set; }

    public Order()
    {
        ItemList = new List<Item>();
    }

    public Order(IList<Item> list)
    {
        ItemList = list;
    }
}

class OrderManager
{
    public void GetItems(Order order) {/*...*/}
    public void GetItemCount(Order order) {/*...*/}
    public void AddItem(Item item, Order order) {/*...*/}
    public void DeleteItem(Item item, Order order) {/*...*/}
}

class OrderPriceCalculator
{
    public void CalculateTotalSum(List<Item> items) {/*...*/}
}

class OrderDisplayer
{
    public void PrintOrder(Order order) {/*...*/}
    public void ShowOrder(Order order) {/*...*/}
}

class OrderStorageManager
{
    public void LoadOrder(Order order) {/*...*/}
    public void SaveOrder(Order order) {/*...*/}
    public void UpdateOrder(Order order) {/*...*/}
    public void DeleteOrder(Order order) {/*...*/}
}

class Program
{
    static void Main()
    {
    }
}