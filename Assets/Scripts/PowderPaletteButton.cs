using UnityEngine;

namespace TestTask
{
    public class PowderPaletteButton : InstrumentButton
    {
        [SerializeField] private Color assignedColor;
        public override void OnClick()
        {
            base.OnClick();
            EyeshadowBrushItem.Brush.SavePalettePosition(transform.position, assignedColor);
        }
    }
}
