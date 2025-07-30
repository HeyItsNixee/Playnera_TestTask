using UnityEngine;
using UnityEngine.UI;

public class UI_FPSCounter : MonoBehaviour
{
    private void Start()
    {
        Application.targetFrameRate = 60;
    }
}
