using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementJoueur : MonoBehaviour
{
    [SerializeField]
    private GameObject cochonous;
    [SerializeField]
    private GameObject murous;
    [SerializeField]
    private GameObject maisonous;
    [SerializeField]
    float moveSpeed = 4f;
    [SerializeField]
    string armePortee = "";
    [SerializeField]
    bool inAction; //True quand casse ou répare



    Vector3 forward, right;
    // Use this for initialization

    void Start()
    {
        inAction = false;
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;

        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.anyKey)
        {
            Move();
        }
    }
    void Move() //Fonction déplacements des joueurs
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;
    }

    void OnTriggerStay(Collider other) //Si on rencontre un mob
    {
        if (other.gameObject.tag != "indestructible") //Qu'il est destructible
        {
                if (other.gameObject.name == "Cochon" || other.gameObject.name == "MurPierre" || other.gameObject.name == "MaisonBois")
                {
                    if (this.tag == "destroyer") //Si on est le destructeur
                {
                    if (other.gameObject.name == "Cochon")
                    {
                        cochonous = other.gameObject;
                        Cochon targetScript = cochonous.GetComponent<Cochon>();
                        if (targetScript.destructed == false)
                        {
                            inAction = true;
                        }
                    }
                    if (other.gameObject.name == "MurPierre")
                    {
                        murous = other.gameObject;
                        MurPierre targetScript = murous.GetComponent<MurPierre>();
                        if (targetScript.destructed == false)
                        {
                            inAction = true;
                        }
                    }
                    if (other.gameObject.name == "MaisonBois")
                    {
                        maisonous = other.gameObject;
                        MaisonBois targetScript = maisonous.GetComponent<MaisonBois>();
                        if (targetScript.destructed == false)
                        {
                            inAction = true;
                        }
                    }

                }
                    else //Si on est le répareur
                {
                    if (other.gameObject.name == "Cochon")
                    {
                        cochonous = other.gameObject;
                        Cochon targetScript = cochonous.GetComponent<Cochon>();
                        if (targetScript.destructed == true)
                        {
                            inAction = true;
                        }
                    }
                    if (other.gameObject.name == "MurPierre")
                    {
                        murous = other.gameObject;
                        MurPierre targetScript = murous.GetComponent<MurPierre>();
                        if (targetScript.destructed == true)
                        {
                            inAction = true;
                        }
                    }
                    if (other.gameObject.name == "MaisonBois")
                    {
                        maisonous = other.gameObject;
                        MaisonBois targetScript = maisonous.GetComponent<MaisonBois>();
                        if (targetScript.destructed == true)
                        {
                            inAction = true;
                        }
                    }
                }
                //if (Cochon.destructed == false;)

                //mobCochon = other.gameObject;
                //StartCoroutine(MobDestruction(2f), mobCochon);
                inAction = true;
                }
                // other.gameObject.destructed = true;
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        inAction = false;
    }

    IEnumerator MobDestruction(float timeToDestroy, GameObject mob)
    {
        yield return new WaitForSeconds(timeToDestroy);

    }


}

