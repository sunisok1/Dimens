using System;

public class SelectEventArgs<T> : EventArgs
{
    public readonly T item;
    public readonly bool select;

    public SelectEventArgs(T item, bool select)
    {
        this.item = item;
        this.select = select;
    }
}