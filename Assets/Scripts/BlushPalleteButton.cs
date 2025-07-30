using UnityEngine;

namespace TestTask
{
    public class BlushPalleteButton : InstrumentButton
    {
        [SerializeField] private Color assignedColor;

        public override void OnClick()
        {
            base.OnClick();
            BlushBrushItem.Brush.SavePalettePosition(transform.position, assignedColor);
        }
    }
}
