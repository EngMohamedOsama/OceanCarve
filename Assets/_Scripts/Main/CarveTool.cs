using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarveTool : SkillTemplate
{
    [Header("General")]
    [SerializeField]
    private LayerMask targetMask;
    [SerializeField]
    private LayerMask stickerLayer;
    [SerializeField]
    private LayerMask carveAreaLayer;

    [Header("SFX")]
    public AudioClip stickerCarveSFX;
    public AudioClip areaCarveSFX;

    private readonly int AREA_LAYER = 6;
    private readonly int STICKER_LAYER = 7;

    public override void ProcessAbility()
    {
        base.ProcessAbility();

        var mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z + transform.position.z);
        var worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        worldPos.z = -2;
        transform.position = worldPos;

        if (!Input.GetMouseButton(0)) return;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, 100, targetMask))
        {
            if (hit.transform.gameObject.layer == STICKER_LAYER)
            {
                LevelManager.Instance.currentSticker.RemoveSticker(hit.transform.name);
                ScoreManager.Instance.AddScore(1);
                ScoreManager.Instance.AddProgress();
                SoundManager.Instance.PlaySFX(stickerCarveSFX);
            }

            if (hit.transform.gameObject.layer == AREA_LAYER)
            {
                LevelManager.Instance.carveArea.RemoveCube(hit.transform.name);
                ScoreManager.Instance.AddScore(-1);
                SoundManager.Instance.PlaySFX(areaCarveSFX,true);
                Vibrator.Vibrate(Random.Range(100, 250));
            }
            
        }
    }

    //Debug (Removeable)
    private void OnDrawGizmosSelected()
    {
        Debug.DrawRay(transform.position, Vector3.forward * 100, Color.red);
    }
}
