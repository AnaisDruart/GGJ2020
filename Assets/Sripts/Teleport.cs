using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject player;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject == player)
        {
            player.transform.position = teleportTarget.transform.position;
        }
    }
}
