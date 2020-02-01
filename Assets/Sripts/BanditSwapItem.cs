using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditSwapItem : MonoBehaviour
{

    public GameObject bandit;

    void Update()
    {
        if (Input.GetKey("r"))
        {
            //gameObject[] bandits = bandit.GetComponent()

            switch (bandit.name)
            {
                case "Bandit":
                    break;
                case "Bandit_Epée":
                    break;
                case "Bandit_Hache":
                    break;
                case "Bandit_Pioche":
                    break;
                default:
                    break;
            }
        }
    }
}
