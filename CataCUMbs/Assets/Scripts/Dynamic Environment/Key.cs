using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] GameObject door;
    public void OpenDoor()
    {
        door.GetComponent<Door>().OpenDoor();
        Destroy(this.gameObject);
        Debug.Log("Door Opened & Key Destoyed");
    }
}
