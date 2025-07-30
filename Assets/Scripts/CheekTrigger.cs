using UnityEngine;

namespace TestTask
{
    public class CheekTrigger : MonoBehaviour
    {
        private bool instrumentInside = false;
        public bool IsInstrumentInside => instrumentInside;

        private void OnTriggerEnter(Collider other)
        {
            if (BlushBrushItem.Brush != null && BlushBrushItem.Brush.ItemCollider == other)
                instrumentInside = true;
        }

        private void OnTriggerExit(Collider other)
        {
            if (BlushBrushItem.Brush != null && BlushBrushItem.Brush.ItemCollider == other)
                instrumentInside = false;
        }

        public void UpdateState(bool value)
        {
            instrumentInside = value;
        }
    }
}