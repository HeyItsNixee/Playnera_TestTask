using UnityEngine;
using UnityEngine.UI;

namespace TestTask
{
    public class LipstickBrushItem : DraggableItem
    {
        [SerializeField] private Image assignedSprite;

        public Sprite CurrentSprite => assignedSprite.sprite;

        public static LipstickBrushItem Lipstick { get; private set; }

        protected override void Start()
        {
            base.Start();
            Lipstick = this;
        }

        public void ChangeSprite(Sprite new_sprite)
        {
            assignedSprite.sprite = new_sprite;
        }
    }
}
