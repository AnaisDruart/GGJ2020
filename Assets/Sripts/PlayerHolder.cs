using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHolder : MonoBehaviour
{

    public GameObject destroyer;
    public GameObject repareur;

    // Start is called before the first frame update
    void Start()
    {
        destroyer.SetActive(true);
        repareur.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            destroyer.SetActive(false);
            repareur.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            destroyer.SetActive(true);
            repareur.SetActive(false);
        }
    }
}
