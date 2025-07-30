using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace TestTask
{
    public class LipstickBrushItem : DraggableItem
    {
        [SerializeField] private Image assignedSprite;
        [Space]
        [SerializeField] private Transform positionToGrab;
        public Sprite CurrentSprite => assignedSprite.sprite;

        public static LipstickBrushItem Lipstick { get; private set; }

        protected override void Start()
        {
            base.Start();
            Lipstick = this;
            OnRelease += Player.PlayerChar.AddLipstick;
        }

        public void ChangeSprite(Sprite new_sprite)
        {
            StartCoroutine(MoveToWaitPos(new_sprite));
        }

        protected override IEnumerator ReturnCoroutine()
        {
            if (Player.PlayerChar.LipstickTrigger.IsInstrumentInside)
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
            Player.PlayerChar.LipstickTrigger.UpdateState(false);
        }

        private IEnumerator MoveToWaitPos(Sprite new_sprite)
        {
            Tween returnTween = transform.DOMove(originalPos, 0.5f, false);
            yield return returnTween.WaitForCompletion();
            assignedSprite.sprite = new_sprite;
            yield return new WaitForSeconds(0.3f);
            returnTween = transform.DOMove(positionToGrab.position, 0.5f, false);
            yield return returnTween.WaitForCompletion();
        }

        private void OnDestroy()
        {
            OnRelease -= Player.PlayerChar.AddLipstick;
        }
    }
}
