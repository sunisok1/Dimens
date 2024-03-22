using System;
using Core;

public abstract class DamageGiveArgs : EventArgs
{
    public float damage;
    public DamageInfo.DamageType type;
    public AbstractCard card;
}