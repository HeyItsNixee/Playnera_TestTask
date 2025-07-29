using UnityEngine;
using UnityEngine.UI;

namespace TestTask
{
    public class BlushBrushItem : DraggableItem
    {
        [SerializeField] private Image colorMask;
        private Color bufferedColor;
        public static BlushBrushItem Brush { get; private set; }
        public Color CurrentColor => bufferedColor;

        protected override void Start()
        {
            base.Start();
            Brush = this;
            ClearColorMask();
        }

        private void OnEnable()
        {
            ClearColorMask();
        }

        public void ChangeMaskColor(Color new_color)
        {
            colorMask.color = new_color;
            bufferedColor = new_color;
            colorMask.gameObject.SetActive(true);
        }

        public void ClearColorMask()
        {
            colorMask.gameObject.SetActive(false);
        }
    }
}
