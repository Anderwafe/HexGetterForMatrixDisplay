using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AvaloniaApplication2.Models;
using ReactiveUI;

namespace AvaloniaApplication2.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private List<BoolToHexColumnViewModel> _columns;

    public List<BoolToHexColumnViewModel> Columns
    {
        get => _columns;
        set => this.RaiseAndSetIfChanged(ref _columns, value);
    }
    
    public MainWindowViewModel()
    {
        _columns = new List<BoolToHexColumnViewModel>([
            new BoolToHexColumnViewModel(), new BoolToHexColumnViewModel(), new BoolToHexColumnViewModel(),
            new BoolToHexColumnViewModel(), new BoolToHexColumnViewModel()
        ]);
    }
}