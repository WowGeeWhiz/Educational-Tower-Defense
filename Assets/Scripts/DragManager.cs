using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragManager : MonoBehaviour
{
    [SerializeField]
    Rect UIContainer;
    public RectTransform defaultLayer = null;
    public RectTransform dragLayer = null;

    DragObject currentDragObject = null;
    public DragObject CurrentDraggedObject => currentDragObject;

    private void Awake()
    {
        SetBoundingBoxRect(dragLayer);
    }

    public void RegisterDraggedObject(DragObject drag)
    {
        currentDragObject = drag;
        drag.transform.SetParent(dragLayer);
    }

    public void UnregisterDraggedObject(DragObject drag)
    {
        drag.transform.SetParent(defaultLayer);
        currentDragObject = null;
    }

    public bool IsWithinBounds(Vector2 position)
    {
        return UIContainer.Contains(position);
    }

    private void SetBoundingBoxRect(RectTransform rectTransform)
    {
        var corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);
        var position = corners[0];

        Vector2 size = new Vector2(
            rectTransform.lossyScale.x * rectTransform.rect.size.x,
            rectTransform.lossyScale.y * rectTransform.rect.size.y);

        UIContainer = new Rect(position, size);
    }
}