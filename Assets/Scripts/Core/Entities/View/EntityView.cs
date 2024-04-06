﻿using Common;
using UnityEngine;

namespace Core.Entities.View
{
    public abstract class EntityView : BaseObject
    {
        public abstract void UpdatePosition(Vector3Int position);
    }
}