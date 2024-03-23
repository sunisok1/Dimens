using Classes;
using Common;

namespace Core.Entities.GameObjects.Players
{
    public abstract class EntityObject : BaseObject
    {
        private AbstractEntity entity;

        private bool selected;

        public void OnPointerClick()
        {
            if (!selected)
            {
                OnSelected();
            }
            else
            {
                OnUnselected();
            }
        }

        public AbstractEntity GetData() => entity;


        public virtual void OnSelected()
        {
            EventSystem.InvokeEvent(this, new SelectEventArgs<AbstractEntity>(entity, true));
            selected = true;
        }

        public virtual void OnUnselected()
        {
            EventSystem.InvokeEvent(this, new SelectEventArgs<AbstractEntity>(entity, false));
            selected = false;
        }

        public override void OnCreated(params object[] objs)
        {
            base.OnCreated(objs);
            entity = objs[0] as AbstractEntity;
        }
    }
}