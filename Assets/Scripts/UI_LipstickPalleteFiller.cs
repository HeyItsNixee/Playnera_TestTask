using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

namespace TestTask
{
    public class UI_LipstickPaleteFiller : MonoBehaviour
    {
        [SerializeField] private List<Sprite> palleteColors;
        [Space]
        [SerializeField] private PalleteButton palletePrefab;

        private List<PalleteButton> spawnedPalletes = new List<PalleteButton>();

        private void Start()
        {
            if (palleteColors.Count <= 0)
                return;

            spawnedPalletes.Clear();

            for (int i = 0; i < palleteColors.Count; i++)
            {
                PalleteButton p = Instantiate(palletePrefab, transform);
                p.Image.sprite = palleteColors[i];
                spawnedPalletes.Add(p);
            }
        }
    }
}

