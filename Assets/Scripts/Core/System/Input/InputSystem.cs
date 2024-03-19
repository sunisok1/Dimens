using System;
using System.Collections.Generic;
using Common;
using UnityEngine;

namespace Core.System.Input
{
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


    public class InputSystem<T> : IDisposable
    {
        private readonly LinkedList<T> selectedItems = new();

        private SelectionMode selectionMode = SelectionMode.Multiple;
        private int selectionLimit = int.MaxValue; // 默认无限制
        private ExceedSelectionLimitBehavior limitBehavior = ExceedSelectionLimitBehavior.CancelEarliest;

        public InputSystem()
        {
            EventSystem.Subscribe<SelectEventArgs<T>>(Select);
        }

        public void Dispose()
        {
            EventSystem.Unsubscribe<SelectEventArgs<T>>(Select);
        }

        public SelectionMode SelectionMode
        {
            get => selectionMode;
            set
            {
                selectedItems.Clear();
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
                    selectedItems.RemoveFirst();
                }

                selectionLimit = Mathf.Max(1, value);
            }
        }

        public ExceedSelectionLimitBehavior LimitBehavior
        {
            get => limitBehavior;
            set => limitBehavior = value;
        }

        private void Select(object sender, SelectEventArgs<T> args)
        {
            if (args.select)
            {
                if (selectedItems.Count >= selectionLimit && limitBehavior == ExceedSelectionLimitBehavior.CancelEarliest)
                {
                    selectedItems.RemoveFirst();
                }

                selectedItems.AddLast(args.item);
            }
            else
            {
                selectedItems.Remove(args.item);
            }
        }


        public IEnumerable<T> GetAllSelectedItems()
        {
            return selectedItems;
        }

        public int ItemCount => selectedItems.Count;
    }
}