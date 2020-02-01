using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    public GameObject player;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject == player)
        {
            repair();
        }
    }

    private void repair()//Réparer l'objet en main?
    {

    }


}