using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core.System.Input
{
    public interface ISelectable<T>
    {
        public bool CanSelect(HashSet<T> selectedItems);
        public void OnSelected();
        public void OnUnselected();
    }

    public static class InputSystem<T> where T : ISelectable<T>
    {
        private static readonly HashSet<T> selectedItems = new();

        public static void Select(T item)
        {
            if (item.CanSelect(selectedItems))
            {
                if (selectedItems.Add(item))
                {
                    item.OnSelected();
                }
            }
        }

        public static void Unselect(T item)
        {
            if (selectedItems.Remove(item))
            {
                item.OnUnselected();
            }
        }

        public static IEnumerable<TResult> GetAllSelectedItems<TResult>(Func<T, TResult> selector)
        {
            return selectedItems.Select(selector);
        }

        public static void ClearSelectedItems()
        {
            selectedItems.Clear();
        }

        public static int ItemCount => selectedItems.Count;
    }
}