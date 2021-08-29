using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CarveArea : MonoBehaviour
{
    private List<Rigidbody> childsRigidBody = new List<Rigidbody>();

    void Start()
    {
        LevelManager.Instance.carveArea = this;
        childsRigidBody = GetComponentsInChildren<Rigidbody>().ToList();
    }

    public void RemoveCarveArea()
    {
        foreach (var childRB in childsRigidBody)
        {
            AddRandomForce(childRB);
            Destroy(childRB.gameObject, 2f);
        }
        Destroy(gameObject, 2f);
    }

    public void RemoveCube(string cubeName, bool addForce = true)
    {
        foreach (var childRB in childsRigidBody)
        {
            if (childRB.name.Equals(cubeName))
            {
                if(addForce) AddRandomForce(childRB);
                childsRigidBody.Remove(childRB);
                var destroyTime = (addForce) ? 2f : 0f;
                Destroy(childRB.gameObject, destroyTime);
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
}
