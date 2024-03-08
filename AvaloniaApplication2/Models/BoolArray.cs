using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AvaloniaApplication2.ViewModels;
using ReactiveUI;

namespace AvaloniaApplication2.Models;

public class BoolArray : ReactiveObject
{
    private List<ReactiveBool> _items;
    public BoolArray(int count)
    {
        _items = new List<ReactiveBool>();
        _items.AddRange(Enumerable.Repeat<ReactiveBool>(new ReactiveBool(false), count));
    }

    public List<ReactiveBool> Items
    {
        get => _items;
        set => this.RaiseAndSetIfChanged(ref _items, value);
    }
    
    public string ToHex()
    {
        return new BitArray(_items.Select(x => x.Value).ToArray()).ConvertToHexadecimal();
    }
}