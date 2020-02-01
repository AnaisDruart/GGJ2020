using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Movement : MonoBehaviour
{

    GameObject player1;
    Vector3 horizon;
    Vector3 vert;

    // Start is called before the first frame update
    void Start()
    {
        this.horizon = new Vector3(90, 0, 0);
        this.vert = new Vector3(0, 0, 90);
        this.player1 = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("z") || Input.GetKey("s") || Input.GetKey("a") || Input.GetKey("d"))
        {
            if (Input.GetKey("z"))
            {
                player1.transform.position += Vector3.forward * 0.05f;
            }
            if (Input.GetKey("s"))
            {
                player1.transform.position += Vector3.back * 0.05f;
            }
            if (Input.GetKey("a"))
            {
                player1.transform.position += Vector3.left * 0.05f;
            }
            if (Input.GetKey("d"))
            {
                player1.transform.position += Vector3.right * 0.05f;
            }

            float v = Input.GetAxis("Vertical");
            Vector3 vertical = vert * v;
            //vert = vert * v;
            float h = Input.GetAxis("Horizontal");
            Vector3 horizontal = horizon * h;
            //horizon = horizon * h;

            Vector3 rot = Vector3.Normalize(vertical + horizontal);
            player1.transform.forward = rot;
        }
    }
}
