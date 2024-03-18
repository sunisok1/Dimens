using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Core.System.Input
{
    public interface ISelectable<out T> : IPointerClickHandler
    {
        public T Data { get; }
        public void OnSelected();
        public void OnUnselected();
    }

    public static class InputSystem
    {
        public static InputSystem<T, TData> Create<T, TData>() where T : ISelectable<TData>
        {
            return new InputSystem<T, TData>();
        }
    }

    public enum SelectionMode
    {
        Single,
        Multiple
    }

    public enum ExceedSelectionLimitBehavior
    {
        CancelEarliest, // 取消最先选中的单位
        CancelCurrentSelection // 取消当前的选择
    }

    public class InputSystem<T, TData> where T : ISelectable<TData>
    {
        private readonly LinkedList<T> selectedItems = new();

        private SelectionMode selectionMode = SelectionMode.Multiple;
        private int selectionLimit = int.MaxValue; // 默认无限制
        private ExceedSelectionLimitBehavior limitBehavior = ExceedSelectionLimitBehavior.CancelEarliest;

        public SelectionMode SelectionMode
        {
            get => selectionMode;
            set
            {
                ClearSelectedItems();
                selectionMode = value;
                switch (value)
                {
                    case SelectionMode.Single:
                        selectionLimit = 1;
                        break;
                    case SelectionMode.Multiple:
                        selectionLimit = int.MaxValue;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(value), value, null);
                }
            }
        }

        public int SelectionLimit
        {
            get => selectionLimit;
            set
            {
                if (selectionMode != SelectionMode.Multiple) return;
                while (selectedItems.Count > value)
                {
                    RemoveFirstItem();
                }

                selectionLimit = Mathf.Max(1, value);
            }
        }

        public ExceedSelectionLimitBehavior LimitBehavior
        {
            get => limitBehavior;
            set => limitBehavior = value;
        }

        public void Select(T item)
        {
            if (selectedItems.Count >= selectionLimit)
            {
                switch (limitBehavior)
                {
                    case ExceedSelectionLimitBehavior.CancelEarliest:
                        RemoveFirstItem();
                        break;
                    case ExceedSelectionLimitBehavior.CancelCurrentSelection:
                        return;
                }
            }

            selectedItems.AddLast(item);
            item.OnSelected();
        }

        private void RemoveFirstItem()
        {
            T earliestItem = selectedItems.First();
            selectedItems.RemoveFirst();
            earliestItem.OnUnselected();
        }

        public void Unselect(T item)
        {
            selectedItems.Remove(item);
            item.OnUnselected();
        }

        public IEnumerable<TData> GetAllSelectedItems()
        {
            return selectedItems.Select(item => item.Data);
        }

        public void ClearSelectedItems()
        {
            foreach (T item in selectedItems)
            {
                item.OnUnselected();
            }

            selectedItems.Clear();
        }

        public int ItemCount => selectedItems.Count;
    }
}