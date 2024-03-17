using System.Collections.Generic;
using System.Linq;

namespace Core.System.Input
{
    public interface ISelectable
    {
        public void Select();
        public void Unselect();
    }

    public static class InputSystem<T>
    {
        private static readonly HashSet<T> selectedItems = new();

        public static bool Select(T item)
        {
            return selectedItems.Add(item);
        }

        public static bool Unselect(T item)
        {
            return selectedItems.Remove(item);
        }

        public static IEnumerable<T> GetAllSelectedItems()
        {
            return selectedItems.ToArray();
        }

        public static void ClearSelectedItems()
        {
            selectedItems.Clear();
        }

        public static int ItemCount => selectedItems.Count;
    }
}