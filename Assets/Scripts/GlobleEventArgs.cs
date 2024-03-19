using System;
using Core.Maps;
using UnityEngine;

public class PlayerMoveEventArgs : EventArgs
{
    public Vector3Int origin;
    public Vector3Int target;
}

public class InitializeMapArgs : EventArgs
{
    public Map map;
}

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