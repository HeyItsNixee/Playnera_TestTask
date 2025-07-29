using System;
using UnityEngine;
using UnityEngine.UI;

namespace TestTask
{
    public class UI_Bookmark : MonoBehaviour
    {
        public enum BookmarkType
        {
            Powder,
            Blush,
            Lipstick,
            Eyeshadow
        }

        [SerializeField] private BookmarkType bookmarkType;

        public Action<UI_Bookmark, BookmarkType> onClick;

        public void OnClick()
        {
            onClick?.Invoke(this, bookmarkType);
        }
    }
}