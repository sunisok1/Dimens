using Core.Entities.View;
using UnityEngine;

namespace Core.Entities
{
    public abstract class EntityController
    {
        private readonly AbstractEntityModel entityModel;
        private readonly EntityView view;
        

        protected EntityController(AbstractEntityModel entityModel, EntityView view)
        {
            this.entityModel = entityModel;
            this.view = view;
        }

        public virtual void ChangePosition(Vector3Int position)
        {
            entityModel.Position = position;
            view.UpdatePosition(position);
        }
    }
}