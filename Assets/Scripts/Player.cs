using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

namespace TestTask {
    public class Player : MonoBehaviour
    {
        [SerializeField] private Image pimplesObj;
        [SerializeField] private Image blushesObj;
        [SerializeField] private Image lipstickObj;
        [SerializeField] private Image eyeshadowsObj;
        [Space]
        [SerializeField] private BlushManager blushManager;
        [SerializeField] private EyeshadowsManager eyeshadowsManager;
        [SerializeField] private LipstickManager lipstickManager;
        [Space]
        [SerializeField] private PimplesTrigger pimplesTrigger;
        [SerializeField] private LipstickTrigger lipstickTrigger;
        [SerializeField] private EyeshadowTrigger eyeshadowTrigger;
        [SerializeField] private CheekTrigger blushTrigger;

        public static Player PlayerChar { get; private set; }
        public PimplesTrigger PimplesTrigger => pimplesTrigger;
        public LipstickTrigger LipstickTrigger => lipstickTrigger;
        public EyeshadowTrigger EyeshadowTrigger => eyeshadowTrigger;
        public CheekTrigger BlushTrigger => blushTrigger;

        private bool pimplesCleared = false;
        private Color nullColor = new Color(0, 0, 0, 0);

        private void Awake()
        {
            PlayerChar = this;
        }

        private void Start()
        {
            pimplesCleared = false;
            ClearAll();
        }

        public void ClearPimples()
        {
            if (!pimplesTrigger.IsInstrumentInside)
                return;

            StartCoroutine(PimplesFadeCoroutine(3f));
        }

        public void AddBlush()
        {
            if (!blushTrigger.IsInstrumentInside)
                return;

            if (BlushBrushItem.Brush.CurrentColor == nullColor)
                return;

            StartCoroutine(BlushFadeCoroutine(1.7f));
        }

        public void AddEyeshadows()
        {
            if (!eyeshadowTrigger.IsInstrumentInside)
                return;

            if (EyeshadowBrushItem.Brush.CurrentColor == nullColor)
                return;

            StartCoroutine(EyeshadowsFadeCoroutine(1.7f));
        }

        public void AddLipstick()
        {
            if (!lipstickTrigger.IsInstrumentInside)
                return;

            if (LipstickBrushItem.Lipstick.CurrentSprite == null)
                return;

            lipstickManager.AddLipstickBySprite(LipstickBrushItem.Lipstick.CurrentSprite);
            lipstickObj.enabled = true;
        }

        public void ClearAll()
        {
            pimplesObj.enabled = !pimplesCleared;
            blushesObj.enabled = false;
            lipstickObj.enabled = false;
            eyeshadowsObj.enabled = false;
        }

        private IEnumerator PimplesFadeCoroutine(float duration)
        {
            pimplesObj.DOFade(0f, duration);
            yield return new WaitForSeconds(duration);

            pimplesObj.gameObject.SetActive(false);
            pimplesCleared = true;
        }

        private IEnumerator EyeshadowsFadeCoroutine(float duration)
        {
            eyeshadowsManager.AddEyeshadowsByColor(EyeshadowBrushItem.Brush.CurrentColor);
            eyeshadowsObj.DOFade(0f, 0.1f);
            eyeshadowsObj.enabled = true;
            yield return new WaitForSeconds(duration);
            Tween returnTween = eyeshadowsObj.DOFade(1f, duration / 2f);
            yield return returnTween.WaitForCompletion();
        }

        private IEnumerator BlushFadeCoroutine(float duration)
        {
            blushManager.AddBlushByColor(BlushBrushItem.Brush.CurrentColor);
            blushesObj.DOFade(0f, 0.1f);
            blushesObj.enabled = true;
            yield return new WaitForSeconds(duration);
            Tween returnTween = blushesObj.DOFade(1f, duration / 2f);
            yield return returnTween.WaitForCompletion();
        }
    } 
}
