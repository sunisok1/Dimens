using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.System.Input
{
    public class InputSystem<T>
    {
        public enum InputSelectionMode
        {
            Single,
            Multiple
        }

        public enum ExceedSelectionLimitBehavior
        {
            CancelEarliest, // 取消最先选中的单位
            CancelCurrentSelection // 取消当前的选择
        }

        private readonly LinkedList<T> selectedItems = new();

        private InputSelectionMode selectionMode = InputSelectionMode.Multiple;
        private int selectionLimit = int.MaxValue; // 默认无限制
        private ExceedSelectionLimitBehavior limitBehavior = ExceedSelectionLimitBehavior.CancelEarliest;

        public InputSelectionMode SelectionMode
        {
            get => selectionMode;
            set
            {
                selectedItems.Clear();
                selectionMode = value;
                switch (value)
                {
                    case InputSelectionMode.Single:
                        selectionLimit = 1;
                        break;
                    case InputSelectionMode.Multiple:
                        selectionLimit = int.MaxValue;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(value), value, null);
                }
            }
        }

        public ExceedSelectionLimitBehavior LimitBehavior
        {
            get => limitBehavior;
            set => limitBehavior = value;
        }

        public int SelectionLimit
        {
            get => selectionLimit;
            set
            {
                if (selectionMode != InputSelectionMode.Multiple) return;
                while (selectedItems.Count > value)
                {
                    selectedItems.RemoveFirst();
                }

                selectionLimit = Mathf.Max(1, value);
            }
        }


        public void ToggleSelection(object sender, SelectEventArgs<T> args)
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