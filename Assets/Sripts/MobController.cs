using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobController : MonoBehaviour
{
    public GameObject cochonPrefab;
    public GameObject maisonPrefab;
    public GameObject murPrefab;

    [SerializeField]
    private float waveTime;

    public GameObject posiPossible0;
    public GameObject posiPossible1;
    public GameObject posiPossible2;
    public GameObject posiPossible3;
   /* public GameObject posiPossible4;
    public GameObject posiPossible5;
    public GameObject posiPossible6;
    public GameObject posiPossible7;
    public GameObject posiPossible8;
    public GameObject posiPossible9;
    public GameObject posiPossible10;
    public GameObject posiPossible11;
    public GameObject posiPossible12;*/

    [SerializeField]
    List<GameObject> listMob = new List<GameObject>(); //Pour choisir quel type de mob va pop 
    [SerializeField]
    List<GameObject> listPosi = new List<GameObject>(); // Pour choisir à quel emplacement
    [SerializeField]
    List<bool> listOccupe = new List<bool>(); //Pour vérifier que la position n'est pas déjà occupée
    [SerializeField]
    List<GameObject> listMobActuels = new List<GameObject>(); // 

    [SerializeField]
    int[,] mobPosi = new int[3,2];


    [SerializeField]
    private int enemyCount;

    private int stock;

    // Start is called before the first frame update
    void Start()
    {
        listMob.Add(cochonPrefab);
        listMob.Add(maisonPrefab);
        listMob.Add(murPrefab);
        enemyCount = 0;

        listPosi.Add(posiPossible0);
        listPosi.Add(posiPossible1);
        listPosi.Add(posiPossible2);
        listPosi.Add(posiPossible3);

        for(int i = 0; i < 4; i++)
        {
            listOccupe.Add(false);
        }

        OnCommence();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i =0; i < listMobActuels.Count;i++)
        {
            if (listMobActuels[i] == null)
            {
                stock = i;
                listOccupe[mobPosi[i, 1]] = false;
                listMobActuels.RemoveAt(i);
            }
        }
        enemyCount = listMobActuels.Count;

        genererMobs();
    }

    void OnCommence()
    {
        int quellePosi = -1;
        

        for(int i =0; i <3; i++)
        {
            GameObject clone;
            quellePosi = -1;
            do {
                quellePosi = Random.Range(0, 4);
            } while (listOccupe[quellePosi] == true);
            Debug.Log(quellePosi);
            clone = Instantiate(listMob[i], listPosi[quellePosi].transform.position, Quaternion.identity);
            listMobActuels.Add(clone);
            listOccupe[quellePosi] = true;
            mobPosi[i, 0] = i;
            mobPosi[i, 1] = quellePosi;
            
        }
    }

    void genererMobs() //Utile dès que des mobs sont détruits def
    {
        if (enemyCount < 3)
        {
            GameObject clone;
            int quellePosi = -1;

            do
            {
                quellePosi = Random.Range(0, 4);
            } while (listOccupe[quellePosi] == true);

            int quelMob = Random.Range(0, 3);

            clone = Instantiate(listMob[quelMob], listPosi[quellePosi].transform.position, Quaternion.identity);

            Debug.Log(listPosi[quellePosi]);
            listMobActuels.Add(clone);
            listOccupe[quellePosi] = true;
            mobPosi[stock, 0] = quelMob;
            mobPosi[stock, 1] = quellePosi;

        }
    }
}
