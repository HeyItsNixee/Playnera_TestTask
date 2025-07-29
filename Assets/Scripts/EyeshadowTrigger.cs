using UnityEngine;


namespace TestTask
{
    public class EyeshadowTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var b = other.transform.parent.gameObject.GetComponent<PowderBrushItem>();
            if (b != null && b == PowderBrushItem.Brush)
                Player.PlayerChar.AddEyeshadows(b.CurrentColor);
        }
    }
}
