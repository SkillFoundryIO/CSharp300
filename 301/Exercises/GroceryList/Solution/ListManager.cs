namespace GroceryList
{
    public class ListManager
    {
        private List<GroceryItem> _groceryList;

        public ListManager()
        {
            _groceryList = new List<GroceryItem>();
        }

        public void AddItem(GroceryItem item)
        {
            _groceryList.Add(item);
        }

        public GroceryItem RemoveItem(int number)
        {
            int index = number - 1;

            var item = _groceryList[index];
            _groceryList.RemoveAt(index);

            return item;
        }

        public int ItemCount { get { return _groceryList.Count; } }

        public void DisplayItems()
        {
            ConsoleIO.DisplayItems(_groceryList);
        }
    }
}
