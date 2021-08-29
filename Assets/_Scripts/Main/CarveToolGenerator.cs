using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CarveToolGenerator : MonoBehaviour, IPointerDownHandler
{
    [Header("General")]
    public GameObject toolPrefab;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (LevelManager.Instance.currentCarveTool) return;

        LevelManager.Instance.currentCarveTool =  
            Instantiate(toolPrefab, transform.position, Quaternion.identity)
            .GetComponent<CarveTool>();

        UIManager.Instance.carveBar.SetTrigger("Hide");
        UIManager.Instance.scoreBar.SetTrigger("Show");
    }
}
