using UnityEngine;


namespace TestTask
{
    public class EyeshadowTrigger : MonoBehaviour
    {
        private bool instrumentInside = false;
        public bool IsInstrumentInside => instrumentInside;

        private void OnTriggerEnter(Collider other)
        {
            if (EyeshadowBrushItem.Brush != null && EyeshadowBrushItem.Brush.ItemCollider == other)
                instrumentInside = true;
        }

        private void OnTriggerExit(Collider other)
        {
            if (EyeshadowBrushItem.Brush != null && EyeshadowBrushItem.Brush.ItemCollider == other)
                instrumentInside = false;
        }

        public void UpdateState(bool value)
        {
            instrumentInside = value;
        }
    }
}
