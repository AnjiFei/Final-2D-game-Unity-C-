using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRE : MonoBehaviour
{
    public GameObject[] wol;
    public GameObject[] yo;
    public Transform[] spa;
    public int wlenght, ylenght,s,t;
    public GameObject w, y;
    // Start is called before the first frame update
    void Start()
    {
        wlenght = wol.Length;
        ylenght = yo.Length;
        t = wlenght + ylenght;
    }

    // Update is called once per frame
    void Update()
    {
        gone();
        wol = new GameObject[wol.Length];
        yo = new GameObject[yo.Length];

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FallRespawn"))
        {
           
        }

    }
    void gone()
    {
        for (int i = 0; i < wol.Length; i++)
        {
            if (wol[i] == null) {
                
            }
            else
            {
                GameObject newplauer = Instantiate(w, spa[i].transform.position, transform.rotation) as GameObject;
                newplauer.transform.parent = GameObject.Find("EnemyS").transform;

            }
        }
        for (int i = 0; i < wol.Length; i++)
        {
            if (yo[i] == null)
            {
                
            }
            else
            {
            GameObject newy = Instantiate(y, spa[i].transform.position, transform.rotation) as GameObject;
                newy.transform.parent = GameObject.Find("EnemyS").transform;
            }
        }
    }
    void spaww()
    {

        if (s != (wlenght + ylenght))
        {

        }
        for (int i = 0; i < wol.Length; i++)
        {
            w = wol[i];
            GameObject newplauer = Instantiate(w, spa[i].transform.position, transform.rotation) as GameObject;
            newplauer.transform.parent = GameObject.Find("EnemyS").transform;
        }

        for (int j = 0; j < yo.Length; j++)
        {
            y = yo[j];
            GameObject newy = Instantiate(y, spa[j].transform.position, transform.rotation) as GameObject;
            newy.transform.parent = GameObject.Find("EnemyS").transform;
        }
    }
}
