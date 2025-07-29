using UnityEngine;

namespace TestTask
{
    public class CheekTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var b = other.transform.parent.gameObject.GetComponent<BlushBrushItem>();
            if (b != null && b == BlushBrushItem.Brush)
                Player.PlayerChar.AddBlush(b.CurrentColor);
        }
    }
}