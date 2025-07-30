using UnityEngine;

namespace TestTask
{
    public class LipstickTrigger : MonoBehaviour
    {
        private bool instrumentInside = false;
        public bool IsInstrumentInside => instrumentInside;

        private void OnTriggerEnter(Collider other)
        {
            if (LipstickBrushItem.Lipstick != null && LipstickBrushItem.Lipstick.ItemCollider == other)
                instrumentInside = true;
        }

        private void OnTriggerExit(Collider other)
        {
            if (LipstickBrushItem.Lipstick != null && LipstickBrushItem.Lipstick.ItemCollider == other)
                instrumentInside = false;
        }

        public void UpdateState(bool value)
        {
            instrumentInside = value;
        }
    }
}