using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaisonBois : MonoBehaviour
{
    private bool EPEE = false;
    private bool PIOCHE = false;
    private bool HACHE = true;
    [SerializeField]
    private float timeToDestroy = 5f;
    public bool destructed = false;
    private float timeBeforeDestroying;

    float neededTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (destructed == true)
        {
            timeBeforeDestroying += Time.deltaTime;
            if (timeBeforeDestroying > 5)
                Destroy(gameObject);
        }
    }

    void OnTriggerStay(Collider other) //Si on rencontre un mob
    {
        Debug.Log("entrere");
        if (other.gameObject.tag == "destroyer") //Si c'est le joueur qui détruit
        {
            if (destructed == false) //Si le cochon n'est pas détruit
            {
                neededTime += Time.deltaTime;
                Debug.Log(neededTime);
                if (neededTime > timeToDestroy)
                {
                    Debug.Log("tout est bon dans le cochon");
                    destructed = true;

                }
            }
        }


        if (other.gameObject.tag == "repareur") //Si c'est le joueur qui détruit
        {
            neededTime = 0;
            if (destructed == true) //Si le cochon est détruit
            {
                neededTime += Time.deltaTime;
                Debug.Log(neededTime);
                if (neededTime > timeToDestroy)
                {
                    Debug.Log("tout est bon dans le cochon");
                    destructed = false;

                }
            }
        }

    }

}
