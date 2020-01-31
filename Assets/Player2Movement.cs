using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    GameObject player2;
    Vector3 horizon;
    Vector3 vert;

    // Start is called before the first frame update
    void Start()
    {
        this.horizon = new Vector3(90, 0, 0);
        this.vert = new Vector3(0, 0, 90);
        this.player2 = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up") || Input.GetKey("down") || Input.GetKey("left") || Input.GetKey("right"))
        {
            if (Input.GetKey("up"))
            {
                player2.transform.position += Vector3.forward * 0.05f;
            }
            if (Input.GetKey("down"))
            {
                player2.transform.position += Vector3.back * 0.05f;
            }
            if (Input.GetKey("left"))
            {
                player2.transform.position += Vector3.left * 0.05f;
            }
            if (Input.GetKey("right"))
            {
                player2.transform.position += Vector3.right * 0.05f;
            }

            float v = Input.GetAxis("Vertical");
            Vector3 vertical = vert * v;
            //vert = vert * v;
            float h = Input.GetAxis("Horizontal");
            Vector3 horizontal = horizon * h;
            //horizon = horizon * h;

            Vector3 rot = Vector3.Normalize(vertical + horizontal);
            player2.transform.forward = rot;
        }
    }
}
