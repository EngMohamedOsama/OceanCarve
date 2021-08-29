using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Sticker : SkillTemplate
{
    [Header("General")]
    [SerializeField]
    private LayerMask carveMask;

    [Header("SFX")]
    public AudioClip placeStickerSFX;

    [Header("Deabug")]
    [ReadOnly]
    public bool canMove;
    [ReadOnly]
    public bool stickerPlaced;
    [SerializeField]
    private bool drawGizmoz;
    
    private List<Rigidbody> childsRigidBody = new List<Rigidbody>();
    private Dictionary<Rigidbody, RaycastHit> cubeMap = 
        new Dictionary<Rigidbody, RaycastHit>();


    private void Start()
    {
        childsRigidBody = GetComponentsInChildren<Rigidbody>().ToList();
    }

    public override void ProcessAbility()
    {
        base.ProcessAbility();
        if (canMove)
        {
            var mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z + transform.position.z);
            var worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            worldPos.z = -4f;
            transform.position = worldPos;
        }
    }

    public bool IsStickerCollide()
    {
        foreach(var child in childsRigidBody)
        {
            RaycastHit hit;
            if (!Physics.Raycast(child.transform.position, Vector3.forward, out hit, 100, carveMask))
            {
                cubeMap.Clear();
                return false;
            }
            cubeMap.Add(child, hit);
        }
        return true;
    }

    public void PlaceSticker()
    {
        foreach (KeyValuePair<Rigidbody, RaycastHit> cube in cubeMap)
        {
            var stickerCube = cube.Key;
            var carveCube = cube.Value;
            stickerCube.isKinematic = false;
            stickerCube.transform.position = carveCube.transform.position;
            LevelManager.Instance.carveArea.RemoveCube(carveCube.transform.name, false);
        }
        SoundManager.Instance.PlaySFX(placeStickerSFX);
        ScoreManager.Instance.totalScore = childsRigidBody.Count;
        ScoreManager.Instance.ResetScore();
        stickerPlaced = true;
    }

    public void RemoveSticker()
    {
        foreach (var childRB in childsRigidBody)
        {
            AddRandomForce(childRB);
            Destroy(childRB.gameObject, 2f);
        }
        Destroy(gameObject, 2f);
    }

    public void RemoveSticker(string cubeName)
    {
        foreach (var childRB in childsRigidBody)
        {
            if (childRB.name.Equals(cubeName))
            {
                AddRandomForce(childRB);
                childsRigidBody.Remove(childRB);
                Destroy(childRB.gameObject, 2f);
                return;
            }

        }
    }

    private void AddRandomForce(Rigidbody cubeRB)
    {
        cubeRB.isKinematic = false;
        cubeRB.useGravity = true;

       var force = new Vector3(Random.Range(-1f, 1f), .5f, Random.Range(-1f, 1f));

        float speed = 25;
        cubeRB.AddForce(force * speed, ForceMode.Impulse);
        cubeRB.detectCollisions = false;
    }

    // Debug (Removeable)
    private void OnDrawGizmos()
    {
        if (!drawGizmoz) return;
        foreach (var child in childsRigidBody)
        {
            Debug.DrawRay(child.transform.position, Vector3.forward * 100, Color.red);
        }
    }
}
