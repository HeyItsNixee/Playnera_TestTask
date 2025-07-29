using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TestTask
{
    public class EyeshadowsManager : MonoBehaviour
    {
        [SerializeField] private Image eyeshadowsImage;
        [SerializeField] private List<Sprite> eyeshadowsSprites;
        [SerializeField] private List<Color> eyeshadowsMatchingColors;

        private int FindSpriteByColor(Color color)
        {
            for (int i = 0; i < eyeshadowsMatchingColors.Count; i++)
            {
                if (eyeshadowsMatchingColors[i] == color)
                    return i;
            }

            return -1;
        }

        public void AddEyeshadowsByColor(Color color)
        {
            int f = FindSpriteByColor(color);

            if (f < 0)
                return;

            eyeshadowsImage.sprite = eyeshadowsSprites[f];
        }
    }
}
