using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;
using System.Windows;

namespace EasyMVVM;

public class MainWindowVM : DependencyObject, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    private ObservableCollection<string> _BackingProperty;
    public ObservableCollection<string> BoundProperty
    { 
        get { return _BackingProperty; } 
        set { _BackingProperty = value; PropChanged("BoundProperty"); } 
    }
//Tell WPF Binding that this property value has changed
    public void PropChanged(String propertyName) 
    { 
        //Did WPF registerd to listen to this event
        if (PropertyChanged != null) 
        { 
            //Tell WPF that this property changed
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); 
        } 
    }
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    public MainWindowVM()
    {
        Model m = new Model(); 
        BoundProperty = m.GetData();

    }
}