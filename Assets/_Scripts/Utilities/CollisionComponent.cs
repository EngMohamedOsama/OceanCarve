using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionComponent : MonoBehaviour
{
    [Header("Collision Target")]
    public LayerMask target = 1 << 8;
    [SerializeField]
    public GameObject collideVFX;
    public AudioClip collideSFX;
    [SerializeField]
    private bool disableTrigger;
    [SerializeField]
    private bool collideOnTop;
    private void OnCollisionEnter(Collision collision)
    {
        if ((1 << collision.gameObject.layer & target.value) != 0)
        {
            if (collideOnTop && collision.transform.position.y + 1f < transform.position.y) return;
            DoSomethingOnEnter(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.enabled) return;
        if ((1 << collision.gameObject.layer & target.value) != 0)
        {
            if (collideOnTop && collision.transform.position.y + 1f < transform.position.y) return;
            DoSomethingOnEnter(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (disableTrigger) return;
        if ((1 << other.gameObject.layer & target.value) != 0)
        {
            DoSomethingOnEnter(other.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (disableTrigger) return;
        if ((1 << other.gameObject.layer & target.value) != 0)
        {
            DoSomethingOnEnter(other.gameObject);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if ((1 << collision.gameObject.layer & target.value) != 0)
        {
            if (collideOnTop && collision.transform.position.y + 1f < transform.position.y) return;
            DoSomethingOnStay(collision.gameObject);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!collision.enabled) return;
        if ((1 << collision.gameObject.layer & target.value) != 0)
        {
            if (collideOnTop && collision.transform.position.y + 1f < transform.position.y) return;
            DoSomethingOnStay(collision.gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (disableTrigger) return;
        if ((1 << other.gameObject.layer & target.value) != 0)
        {
            DoSomethingOnStay(other.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (disableTrigger) return;
        if ((1 << other.gameObject.layer & target.value) != 0)
        {
            DoSomethingOnStay(other.gameObject);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if ((1 << collision.gameObject.layer & target.value) != 0)
        {
            if (collideOnTop && collision.transform.position.y + 1f < transform.position.y) return;
            DoSomethingOnExit(collision.gameObject);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!collision.enabled) return;
        if ((1 << collision.gameObject.layer & target.value) != 0)
        {
            if (collideOnTop && collision.transform.position.y + 1f < transform.position.y) return;
            DoSomethingOnExit(collision.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (disableTrigger) return;
        if ((1 << other.gameObject.layer & target.value) != 0)
        {
            DoSomethingOnExit(other.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (disableTrigger) return;
        if ((1 << other.gameObject.layer & target.value) != 0)
        {
            DoSomethingOnExit(other.gameObject);
        }
    }
    internal virtual void DoSomethingOnEnter(GameObject target)
    {
        if (collideVFX) Instantiate(collideVFX, transform.position, Quaternion.identity);
        if (collideSFX) SoundManager.Instance.PlaySFX(collideSFX, true);
    }
    internal virtual void DoSomethingOnStay(GameObject target)
    {
    }
    internal virtual void DoSomethingOnExit(GameObject target)
    {
    }
}
