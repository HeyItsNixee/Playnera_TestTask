using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace TestTask
{
    public class CreamButton : MonoBehaviour
    {
        [SerializeField] private Image creamButtonImg;
        [SerializeField] private Button creamButton;
        [SerializeField] private Text creamButtonText;
        [SerializeField] private CreamBrushItem creamBrushItem;
        [Space]
        [SerializeField] private Transform leftFaceSide;

        private void Start()
        {
            ResetState();
            creamBrushItem.OnReturn += ResetState;
        }

        public void OnClick()
        {
            creamButtonText.enabled = false;
            creamButtonImg.enabled = false;
            creamButton.enabled = false;
            creamBrushItem.transform.DOMove((transform.position + leftFaceSide.position) / 2f, 1f, false);
            creamBrushItem.gameObject.SetActive(true);
        }

        public void ResetState()
        {
            creamBrushItem.gameObject.SetActive(false);
            creamButtonImg.enabled = true;
            creamButtonText.enabled = true;
            creamButton.enabled = true;
        }

        private void OnDestroy()
        {
            creamBrushItem.OnReturn -= ResetState;
        }
    }
}
