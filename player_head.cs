using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_head : MonoBehaviour
{
    public GameObject J, F, I;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void juya()
    {
        J.SetActive(true);
        I.SetActive(false);
        F.SetActive(false);
    }
    public void ic()
    {
        I.SetActive(true);
        J.SetActive(false);
        F.SetActive(false);
    }
    public void fei()
    {
        F.SetActive(true);
        I.SetActive(false);
        J.SetActive(false);
    }
}
