using Common;
using Core.System.Input;

namespace Core.Entities
{
    public class EntityObject : BaseObject
    {
        private Entity entity;

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

        public Entity GetData() => entity;


        public virtual void OnSelected()
        {
            EventSystem.InvokeEvent(this, new SelectEventArgs<Entity>(entity, true));
            selected = true;
        }

        public virtual void OnUnselected()
        {
            EventSystem.InvokeEvent(this, new SelectEventArgs<Entity>(entity, false));
            selected = false;
        }

        public override void OnCreated(params object[] objs)
        {
            base.OnCreated(objs);
            entity = objs[0] as Entity;
        }
    }
}