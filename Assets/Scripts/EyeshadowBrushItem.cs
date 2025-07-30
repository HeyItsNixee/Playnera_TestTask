using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


namespace TestTask
{
    public class EyeshadowBrushItem : DraggableItem
    {
        [SerializeField] private Image colorMask;
        [Space]
        [SerializeField] private Transform positionToGrab;
        private Color bufferedColor;
        public static EyeshadowBrushItem Brush { get; private set; }
        public Color CurrentColor => bufferedColor;

        protected override void Start()
        {
            base.Start();
            Brush = this;
            ClearColorMask();
            OnRelease += Player.PlayerChar.AddEyeshadows;
        }

        private void OnEnable()
        {
            ClearColorMask();
        }

        public void ClearColorMask()
        {
            colorMask.gameObject.SetActive(false);
        }
        
        public void SavePalettePosition(Vector3 palettePos, Color color)
        {
            StartCoroutine(TakeShadows(palettePos, color));
        }

        protected override IEnumerator ReturnCoroutine()
        {
            if (Player.PlayerChar.EyeshadowTrigger.IsInstrumentInside)
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
            Player.PlayerChar.EyeshadowTrigger.UpdateState(false);
        }

        private IEnumerator TakeShadows(Vector3 palettePos, Color color)
        {
            Tween returnTween = transform.DOMove(palettePos, 0.5f, false);
            yield return returnTween.WaitForCompletion();

            returnTween = transform.DORotate(Vector3.forward * 30f, 0.3f, RotateMode.Fast);
            yield return returnTween.WaitForCompletion();

            colorMask.color = new Color(color.r, color.g, color.b, 0f);
            colorMask.gameObject.SetActive(true);
            returnTween = colorMask.DOFade(0.43f, 0.2f);
            colorMask.color = new Color(color.r, color.g, color.b, 0.11f);
            yield return returnTween.WaitForCompletion();

            bufferedColor = color;
            returnTween = transform.DORotate(Vector3.zero, 0.5f, RotateMode.FastBeyond360);
            yield return returnTween.WaitForCompletion();

            returnTween = transform.DOMove(positionToGrab.position, 0.5f, false);
            yield return returnTween.WaitForCompletion();
        }

        private void OnDestroy()
        {
            OnRelease -= Player.PlayerChar.AddEyeshadows;
        }
    }
}
