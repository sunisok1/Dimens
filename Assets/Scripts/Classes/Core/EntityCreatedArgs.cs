using System;
using Core;
using UnityEngine;

public class EntityCreatedArgs : EventArgs
{
    public readonly AbstractEntity entity;
    public readonly Vector3Int initialPosition;

    public EntityCreatedArgs(AbstractEntity entity, Vector3Int initialPosition)
    {
        this.entity = entity;
        this.initialPosition = initialPosition;
    }
}