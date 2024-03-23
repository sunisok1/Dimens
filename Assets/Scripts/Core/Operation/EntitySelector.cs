using System.Collections.Generic;
using Core.Entities;
using UnityEngine;

namespace Core.Operation
{
    public class EntitySelector : MonoBehaviour
    {
        private readonly HashSet<ISelectable> selectedCollection = new();

        private void Update()
        {
            if (Input.GetMouseButtonDown(0)) 
            {
                Vector2 raycastPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(raycastPos, Vector2.zero);

                if (hit.collider == null) return;
                var selectable = hit.collider.gameObject.GetComponent<ISelectable>();
                if (selectable == null) return;
                if (selectedCollection.Contains(selectable))
                {
                    if (selectable.Deselect())
                    {
                        selectedCollection.Remove(selectable);
                    }
                }
                else
                {
                    if (selectable.Select())
                    {
                        selectedCollection.Add(selectable);
                    }
                }
            }
        }
    }
}