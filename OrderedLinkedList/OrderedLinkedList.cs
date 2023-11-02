
namespace OrderedLinkedList
{
    public class OrderedLinkedList
    {
        private Node? _first;
        private Node? _last;
        private int _count;

        public bool IsEmpty() => _first == null;

        public void Insert(string newItem)
        {
            var newNode = new Node(newItem);
            Node? previous = null;
            Node? current = _first;

            while (current != null && string.CompareOrdinal(newItem, current.Item) > 0)
            {
                previous = current;
                current = current.Next;
            }

            if (previous == null) // Inserting at the beginning
            {
                newNode.Next = _first;
                _first = newNode;
                if (_first.Next == null) // List was empty before inserting
                    _last = _first;
            }
            else // Inserting in the middle or end
            {
                previous.Next = newNode;
                newNode.Next = current;
                if (current == null) // Inserting at the end
                    _last = newNode;
            }
            _count++; // Increase the size of the list
        }

        public void Remove(string itemToRemove)
        {
            Node? previous = null;
            Node? current = _first;

            while (current != null && string.CompareOrdinal(itemToRemove, current.Item) != 0)
            {
                previous = current;
                current = current.Next;
            }

            if (current == null) // Item to remove was not found
                return;

            if (previous == null) // Removing the first item
                _first = _first?.Next;
            else // Removing middle or last item
                previous.Next = current.Next;

            if (current.Next == null) // Removing the last item
                _last = previous;

            _count--; // Decrease the size of the list
        }

        public void Display()
        {
            Node? current = _first;
            while (current != null)
            {
                Console.WriteLine(current.Item);
                current = current.Next;
            }
        }

        public bool Search(string itemToSearch)
        {
            Node? current = _first;
            while (current != null)
            {
                int comparison = string.CompareOrdinal(itemToSearch, current.Item);
                if (comparison == 0)
                    return true;
                if (comparison < 0)
                    break; // Because the list is ordered, no need to continue
                current = current.Next;
            }
            return false;
        }

        public void Clear()
        {
            _first = null;
            _last = null;
            _count = 0;
        }

        public int Size()
        {
            return _count;
        }

        public int IndexOf(string itemToFind)
        {
            Node? current = _first;
            int index = 0;
            while (current != null)
            {
                if (string.CompareOrdinal(itemToFind, current.Item) == 0)
                    return index;
                current = current.Next;
                index++;
            }
            return -1; // Item not found
        }
    }
}
