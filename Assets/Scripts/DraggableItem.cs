using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using System;
using System.Collections;

namespace TestTask
{
    public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] protected Collider itemCollider;
        [Space]
        [SerializeField] protected Transform[] applyTransforms;
        public Collider ItemCollider => itemCollider;
        public Action OnRelease;
        public Action OnReturn;

        protected Vector3 originalPos;

        protected virtual void Start()
        {
            originalPos = transform.position;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            //Debug.Log("Begin dragging");
            itemCollider.enabled = true;
        }

        public void OnDrag(PointerEventData eventData)
        {
            //Debug.Log("Dragging");
            transform.position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            //Debug.Log("End dragging");
            //transform.position = originalPos;
            OnRelease?.Invoke();
            StartCoroutine(ReturnCoroutine());
        }

        protected virtual IEnumerator ReturnCoroutine()
        {
            //===Return Instrument===
            itemCollider.enabled = false;
            Tween returnTween = transform.DOMove(originalPos, 1f, false);
            yield return returnTween.WaitForCompletion();
            OnReturn?.Invoke();
        }
    }
}
