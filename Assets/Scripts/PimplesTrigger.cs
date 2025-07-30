using System;
using UnityEngine;

namespace TestTask
{
    public class PimplesTrigger : MonoBehaviour
    {
        private bool instrumentInside = false;
        public bool IsInstrumentInside => instrumentInside;

        private void OnTriggerEnter(Collider other)
        {
            //var b = other.transform.parent.gameObject.GetComponent<CreamBrushItem>();
            if (CreamBrushItem.CreamBrush != null && CreamBrushItem.CreamBrush.ItemCollider == other)
                instrumentInside = true;
                //Player.PlayerChar.ClearPimples();
        }

        private void OnTriggerExit(Collider other)
        {
            if (CreamBrushItem.CreamBrush != null && CreamBrushItem.CreamBrush.ItemCollider == other)
                instrumentInside = false;
        }

        public void UpdateState(bool value)
        {
            instrumentInside = value;
        }
    }
}
