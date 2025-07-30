using DG.Tweening;
using System.Collections;
using UnityEngine;

namespace TestTask
{
    public class CreamBrushItem : DraggableItem
    {
        public static CreamBrushItem CreamBrush { get; private set; }

        protected override void Start()
        {
            base.Start();
            CreamBrush = this;
            OnRelease += Player.PlayerChar.ClearPimples;
        }

        protected override IEnumerator ReturnCoroutine()
        {
            if (Player.PlayerChar.PimplesTrigger.IsInstrumentInside)
            {
                //=======APPLY==========
                itemCollider.enabled = false;
                foreach (var t in applyTransforms)
                {
                    Tween tween = transform.DOMove(t.position, 0.5f, false);
                    yield return tween.WaitForCompletion();
                }
            }

            //===Return Instrument===
            itemCollider.enabled = false;
            Tween returnTween = transform.DOMove(originalPos, 1f, false);
            yield return returnTween.WaitForCompletion();
            OnReturn?.Invoke();
            Player.PlayerChar.PimplesTrigger.UpdateState(false);
        }

        private void OnDestroy()
        {
            OnRelease -= Player.PlayerChar.ClearPimples;
        }
    }
}
