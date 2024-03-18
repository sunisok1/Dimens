﻿using UnityEngine;

namespace Core.Entities
{
    public class EntityManager : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

                if (hit.collider != null && hit.collider.TryGetComponent(out EntityObject entityObject))
                {
                    entityObject.OnPointerClick();
                }
            }
        }
    }
}