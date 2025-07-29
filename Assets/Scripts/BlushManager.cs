using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TestTask
{
    public class BlushManager : MonoBehaviour
    {
        [SerializeField] private Image blushImage;
        [SerializeField] private List<Sprite> blushSprites;
        [SerializeField] private List<Color> blushMatchingColors;

        private int FindSpriteByColor(Color color)
        {
            for (int i = 0; i < blushMatchingColors.Count; i++)
            {
                if (blushMatchingColors[i] == color)
                    return i;
            }

            return -1;
        }

        public void AddBlushByColor(Color color)
        {
            int f = FindSpriteByColor(color);

            if (f < 0)
                return;

            blushImage.sprite = blushSprites[f];
        }
    }
}