using UnityEngine;
using UnityEngine.UI;

namespace TestTask
{
    public class PalleteButton : InstrumentButton
    {
        [SerializeField] private Image image;

        public Image Image => image;

        public override void OnClick()
        {
            base.OnClick();
        }
    }
}