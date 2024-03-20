using System;
using Core.Cards;
using Core.Entities;
using UnityEngine;

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

public class EntityCreatedArgs : EventArgs
{
    public readonly Entity entity;
    public readonly Vector3Int initialPosition;

    public EntityCreatedArgs(Entity entity, Vector3Int initialPosition)
    {
        this.entity = entity;
        this.initialPosition = initialPosition;
    }
}

public class EntityMoveArgs : EventArgs
{
    public readonly Entity entity;
    public readonly Vector3Int origin;
    public readonly Vector3Int target;

    public EntityMoveArgs(Entity entity, Vector3Int origin, Vector3Int target)
    {
        this.origin = origin;
        this.target = target;
        this.entity = entity;
    }
}

public class DamageGiveArgs : EventArgs
{
    public float damage;
    public DamageInfo.DamageType type;
    public AbstractCard card;
}

public class DamageAllEnemiesArgs : EventArgs
{
    public int[] damage;
}

public class HealArgs : EventArgs
{
    public int healAmount;
}

public class AttackedArgs : EventArgs
{
    public DamageInfo info;
    public int damageAmount;
    private ITarget target;
}

public class CardDrawArgs : EventArgs
{
    public AbstractCard card;
}

public class DiscardArgs : EventArgs
{
    public AbstractCard card;
}

public class PlayCardArgs : EventArgs
{
    public AbstractCard card;
    public ITarget target;
}