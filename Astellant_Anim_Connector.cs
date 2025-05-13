using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astellant_Anim_Connector : MonoBehaviour
{
    // Start is called before the first frame update
    public Astellant_AI astellant_ai;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Shoot()
    {
        astellant_ai.Shoot();
    }
    public void HammerOn()
    {
        astellant_ai.Hammer_On();
    }

    public void HammerOff()
    {
        astellant_ai.Hammer_Off();
    }
}
