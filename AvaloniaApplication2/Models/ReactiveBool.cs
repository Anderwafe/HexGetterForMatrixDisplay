using ReactiveUI;

namespace AvaloniaApplication2.Models;

public class ReactiveBool : ReactiveObject
{
    private bool _value;

    public ReactiveBool(bool initValue)
    {
        _value = initValue;
    }
    
    public bool Value
    {
        get => _value;
        set => this.RaiseAndSetIfChanged(ref _value, value);
    }
}