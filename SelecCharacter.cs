using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelecCharacter : MonoBehaviour
{
    public GameObject[] charct;
    public int[] options;
    public int opt = 3;
    public int opt2 = 0;
    // Start is called before the first frame update
    void Start()
    {
        options = new int[charct.Length];
    }

    // Update is called once per frame
    void Update()
    {
         if (opt == 1)
        {
            charct[0].SetActive(true);
            charct[1].SetActive(false);
            charct[2].SetActive(false);
        }
        if (opt == 2)
        {
            charct[1].SetActive(true);
            charct[0].SetActive(false);
            charct[2].SetActive(false);
        }
        if (opt == 3)
        {
            charct[2].SetActive(true);
            charct[1].SetActive(false);
            charct[0].SetActive(false);
        }
    }
    public void Previous()
    {
        
       opt--;
        if (opt == 1)
        {
            opt = 1;
        }
        if (opt == 2)
        {
            opt = 2;
        }
        if (opt == 3)
        {
            opt = 3;

        }
        if (opt == 0)
        {
            opt = 3;
        }
    }
    public void Next()
    {

        opt2++;
        if (opt2 == 1)
        {
            opt = 1;
        }
        if (opt2 == 2)
        {
            opt = 2;
        }
        if (opt2 == 3)
        {
            opt = 3;

        }
        if (opt2 < 3)
        {
            opt2 = 0;

        }
    }
}
