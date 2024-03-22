using System;
using Core;

public abstract class AttackedArgs : EventArgs
{
    public DamageInfo info;
    public int damageAmount;
    private ITarget target;
}