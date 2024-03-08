using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AvaloniaApplication2.Models;
using ReactiveUI;

namespace AvaloniaApplication2.ViewModels;

public class BoolToHexColumnViewModel : ViewModelBase
{
    private List<ReactiveBool> _column;
    public List<ReactiveBool> Column
    {
        get => _column;
        set
        {
            this.RaiseAndSetIfChanged(ref _column, value);
        }
    }
    
    private string _columnAnswer;

    public string ColumnAnswer
    {
        get => _columnAnswer;
        set => this.RaiseAndSetIfChanged(ref _columnAnswer, value);
    }

    public BoolToHexColumnViewModel()
    {
        _column = new List<ReactiveBool>(Enumerable.Repeat(new ReactiveBool(false), 7).Select(x => new ReactiveBool(false)));
        _columnAnswer = string.Empty;
        
        _column.ForEach(x => x.Changed.Subscribe(y =>
        {
            ColumnAnswer = _column.AsEnumerable().Reverse().ConvertToBitArray().ConvertToHexadecimal();
        }));
    }
}

public static class BitArrayExt
{
    public static BitArray ConvertToBitArray(this IEnumerable<ReactiveBool> collection)
    {
        return new BitArray(collection.Select(x => x.Value).ToArray());
    }
    
    public static byte[] ConvertToByteArray(this BitArray bitArray)
    {
        byte[] bytes = new byte[(int)Math.Ceiling(bitArray.Count / 8.0)];
        bitArray.CopyTo(bytes, 0);
        return bytes;
    }
    
    public static int ConvertToInt32(this BitArray bitArray)
    {
        var bytes = bitArray.ConvertToByteArray();

        int result = 0;

        foreach (var item in bytes)
        {
            result += item;
        }

        return result;
    }
    
    public static string ConvertToHexadecimal(this BitArray bitArray)
    {
        return bitArray.ConvertToInt32().ToString("X");
    }
}