using System;
using System.Collections.Generic;
using System.Text;

using System;

namespace Storage_HW4;

public class Warehouse
{
    private readonly string[] _items;

    public Warehouse(int capacity = 10)
    {
        if (capacity <= 0)
        {
            throw new ArgumentException("Storage has to be more then 0.");
        }

        _items = new string[capacity];

        for (int i = 0; i < _items.Length; i++)
        {
            _items[i] = string.Empty;
        }
    }

    public event Action<int, string>? OnItemChanged;

    

    public string this[int index]
    {
        get
        {
            ValidateIndex(index);
            return _items[index];
        }
        set
        {
            ValidateIndex(index);
            _items[index] = value;
            OnItemChanged?.Invoke(index, value);
        }
    }

    public int Capacity => _items.Length;

    private void ValidateIndex(int index)
    {
        if (index < 0 || index >= _items.Length)
        {
            throw new IndexOutOfRangeException("This index is already existing.");
        }
    }
}