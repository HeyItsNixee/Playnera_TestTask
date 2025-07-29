using UnityEngine;

namespace TestTask
{
    public class LipstickTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var l = other.transform.parent.gameObject.GetComponent<LipstickBrushItem>();
            if (l != null && l == LipstickBrushItem.Lipstick)
                Player.PlayerChar.AddLipstick(l.CurrentSprite);
        }
    }
}