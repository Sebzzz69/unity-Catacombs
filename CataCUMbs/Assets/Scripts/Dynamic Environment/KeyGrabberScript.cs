using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyGrabberScript : MonoBehaviour
{

    public float raycastDistance = 2f;

    [SerializeField] GameObject targetDirection;

    public void GrabKey(RaycastHit2D hit)
    {
        hit.collider.gameObject.transform.parent = this.transform;

        hit.collider.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        hit.collider.gameObject.GetComponent<SpriteRenderer>().enabled = false;

        Debug.Log("Key Snatched");
    }

}
