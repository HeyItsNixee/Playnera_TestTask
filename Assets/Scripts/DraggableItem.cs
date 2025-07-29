using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace TestTask
{
    public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private Vector3 originalPos;
        protected virtual void Start()
        {
            originalPos = transform.position;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            //Debug.Log("Begin dragging");
        }

        public void OnDrag(PointerEventData eventData)
        {
            //Debug.Log("Dragging");
            transform.position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            //Debug.Log("End dragging");
            transform.position = originalPos;
        }
    }
}
