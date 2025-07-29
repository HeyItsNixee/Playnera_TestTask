using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TestTask
{
    public class LipstickManager : MonoBehaviour
    {
        [SerializeField] private Image lipstickImage;
        [SerializeField] private List<Sprite> lipstickSprites;
        [SerializeField] private List<Sprite> lipstickMatchingSprites;

        private int FindSpriteByLipstickColor(Sprite sprite)
        {
            for (int i = 0; i < lipstickMatchingSprites.Count; i++)
            {
                if (lipstickMatchingSprites[i] == sprite)
                    return i;
            }

            return -1;
        }

        public void AddLipstickBySprite(Sprite sprite)
        {
            int f = FindSpriteByLipstickColor(sprite);

            if (f < 0)
                return;

            lipstickImage.sprite = lipstickSprites[f];
        }
    }
}
