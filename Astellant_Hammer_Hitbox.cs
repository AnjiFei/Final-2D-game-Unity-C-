using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astellant_Hammer_Hitbox : MonoBehaviour
{

    public GameObject Astellant;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<Character_Movement>().iframes == 0 )
        {

            collision.gameObject.GetComponent<Character_Movement>().Health -= 15;
            collision.gameObject.GetComponent<Character_Movement>().hurt = true;

            if (Astellant.transform.position.x > collision.transform.position.x)
            {
                collision.gameObject.GetComponent<Character_Movement>().hurt_dir = -1;

            }
            else
            {
                collision.gameObject.GetComponent<Character_Movement>().hurt_dir = 1;

            }
        }
    }
}
