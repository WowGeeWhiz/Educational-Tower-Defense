using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
public class DragObject : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    DragManager dragManager = null;

    Vector2 centerLocation;
    Vector2 worldCenterLocation => transform.TransformPoint(centerLocation);

    private void Awake()
    {
        centerLocation = (transform as RectTransform).rect.center;
        dragManager = FindFirstObjectByType<DragManager>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        dragManager.RegisterDraggedObject(this);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (dragManager.IsWithinBounds(worldCenterLocation + eventData.delta))
        {
            transform.Translate(eventData.delta);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        dragManager.UnregisterDraggedObject(this);
    }
}