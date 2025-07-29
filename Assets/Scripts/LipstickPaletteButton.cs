using UnityEngine;

namespace TestTask
{
    public class LipstickPaletteButton : InstrumentButton
    {
        [SerializeField] private Sprite assignedSprite;

        public override void OnClick()
        {
            base.OnClick();
            LipstickBrushItem.Lipstick.ChangeSprite(assignedSprite);
        }
    }
}
