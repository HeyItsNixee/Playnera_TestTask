using UnityEngine;
using UnityEngine.UI;

public class UI_FPSCounter : MonoBehaviour
{
    [SerializeField] private Text fpsText;

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        fpsText.text =  ((int)(1f / Time.unscaledDeltaTime)).ToString();
    }
}
