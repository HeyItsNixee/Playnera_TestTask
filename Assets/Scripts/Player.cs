using UnityEngine;
using UnityEngine.UI;

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

        public static Player PlayerChar { get; private set; }

        private bool pimplesCleared = false;

        private void Start()
        {
            PlayerChar = this;
            pimplesCleared = false;
            ClearAll();

        }

        public void ClearPimples()
        {
            pimplesObj.gameObject.SetActive(false);
            pimplesCleared = true;
        }

        public void AddBlush(Color color)
        {
            blushManager.AddBlushByColor(color);
            blushesObj.enabled = true;
        }

        public void AddEyeshadows(Color color)
        {
            eyeshadowsManager.AddEyeshadowsByColor(color);
            eyeshadowsObj.enabled = true;
        }

        public void AddLipstick(Sprite sprite)
        {
            lipstickManager.AddLipstickBySprite(sprite);
            lipstickObj.enabled = true;
        }

        public void ClearAll()
        {
            pimplesObj.enabled = !pimplesCleared;
            blushesObj.enabled = false;
            lipstickObj.enabled = false;
            eyeshadowsObj.enabled = false;
        }
    } 
}
