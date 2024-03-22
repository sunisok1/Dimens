using System;
using Core;
using UnityEngine;

public abstract class EntityMoveArgs : EventArgs
{
    public readonly AbstractEntity entity;
    public readonly Vector3Int origin;
    public readonly Vector3Int target;

    public EntityMoveArgs(AbstractEntity entity, Vector3Int origin, Vector3Int target)
    {
        this.origin = origin;
        this.target = target;
        this.entity = entity;
    }
}