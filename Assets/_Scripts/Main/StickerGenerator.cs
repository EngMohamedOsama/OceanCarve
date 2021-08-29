using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StickerGenerator : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [Header("General")]
    public GameObject stickerPrefab;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!LevelManager.Instance.gameStarted) return;
        if(LevelManager.Instance.currentSticker)
            if (LevelManager.Instance.currentSticker.stickerPlaced) return;

        LevelManager.Instance.currentSticker = 
            Instantiate(stickerPrefab,transform.position,Quaternion.identity)
            .GetComponent<Sticker>();

        LevelManager.Instance.currentSticker.canMove = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!LevelManager.Instance.gameStarted) return;
        if (!LevelManager.Instance.currentSticker) return;
        if (LevelManager.Instance.currentSticker.stickerPlaced) return;

        LevelManager.Instance.currentSticker.canMove = false;

        if (!LevelManager.Instance.currentSticker.IsStickerCollide())
            LevelManager.Instance.currentSticker.RemoveSticker();
        else
        {
            LevelManager.Instance.currentSticker.PlaceSticker();
            UIManager.Instance.stickerBar.SetTrigger("Hide");
            UIManager.Instance.carveBar.SetTrigger("Show");
        }
    }
}
