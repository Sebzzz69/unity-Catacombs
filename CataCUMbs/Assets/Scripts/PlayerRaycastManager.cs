using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycastManager : MonoBehaviour
{

    private float raycastDistance = .5f;

    [Header("GameObjects")]
    [SerializeField] GameObject targetDirection;
    [SerializeField] GameObject targetPosition;
    [Header("Scipts")]
    [SerializeField] KeyGrabberScript keyGrabberScript;
    Key keyScript;

    private void Update()
    {
        Ray2D ray = new Ray2D(targetPosition.transform.position, targetDirection.transform.up);

        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, raycastDistance);

        Debug.DrawRay(ray.origin, ray.direction * raycastDistance, Color.red);


        if (hit.collider != null)
        {
            Debug.Log("Object Hit: " + hit.collider.gameObject.name);

            // Snatch Key
            if (hit.collider.CompareTag("Key"))
            {
                keyGrabberScript.GrabKey(hit);
                keyScript = hit.collider.GetComponent<Key>();
            }

            // Use Key To Open Door
            if (hit.collider.CompareTag("Door") && keyScript != null)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    keyScript.OpenDoor();
                }
            }
        }


    }
}
