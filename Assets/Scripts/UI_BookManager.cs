using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TestTask
{
    public class UI_BookManager : MonoBehaviour
    {
        [SerializeField] private List<UI_Bookmark> bookmarks;
        [Space]
        [SerializeField] private GameObject activePowderBookmark;
        [SerializeField] private GameObject activeBlushBookmark;
        [SerializeField] private GameObject activeLipstickBookmark;
        [SerializeField] private GameObject activeEyeshadowBookmark;

        //[Space]

        private UI_Bookmark bufferedBookmark = null;

        private void Start()
        {
            if (bookmarks.Count <= 0)
                return;

            for (int i = 0; i < bookmarks.Count; i++)
                bookmarks[i].onClick += BookmarkClickHandler;

            activePowderBookmark.SetActive(false);
            activeBlushBookmark.SetActive(false);
            activeLipstickBookmark.SetActive(false);
            activeEyeshadowBookmark.SetActive(false);

            bookmarks[0].OnClick();
        }

        private void BookmarkClickHandler(UI_Bookmark bookmark, UI_Bookmark.BookmarkType type)
        {
            if (bufferedBookmark != null)
                bufferedBookmark.gameObject.SetActive(true);

            bufferedBookmark = bookmark;
            bookmark.gameObject.SetActive(false);

            switch (type)
            {
                case UI_Bookmark.BookmarkType.Powder:
                    activePowderBookmark.SetActive(true);
                    activeBlushBookmark.SetActive(false);
                    activeLipstickBookmark.SetActive(false);
                    activeEyeshadowBookmark.SetActive(false);
                    break;
                case UI_Bookmark.BookmarkType.Blush:
                    activePowderBookmark.SetActive(false);
                    activeBlushBookmark.SetActive(true);
                    activeLipstickBookmark.SetActive(false);
                    activeEyeshadowBookmark.SetActive(false);
                    break;
                case UI_Bookmark.BookmarkType.Lipstick:
                    activePowderBookmark.SetActive(false);
                    activeBlushBookmark.SetActive(false);
                    activeLipstickBookmark.SetActive(true);
                    activeEyeshadowBookmark.SetActive(false);
                    break;
                case UI_Bookmark.BookmarkType.Eyeshadow:
                    activePowderBookmark.SetActive(false);
                    activeBlushBookmark.SetActive(false);
                    activeLipstickBookmark.SetActive(false);
                    activeEyeshadowBookmark.SetActive(true);
                    break;
            }
        }

        private void OnDestroy()
        {
            for (int i = 0; i < bookmarks.Count; i++)
                bookmarks[i].onClick -= BookmarkClickHandler;
        }

    }
}
