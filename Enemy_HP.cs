using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_HP : MonoBehaviour
{
    public AudioSource source;
    public int Health;
    public Animator animator;
    public Astellant_AI astl_ai;
    public Da_Wol_Script wol_ai;
    public Haywire_Yoyo_Script yoyo_ai;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            if (astl_ai!= null)
            {
                astl_ai.enabled = false;
                animator.SetTrigger("Die");
                source.Play();
                Destroy(gameObject, 2f);
            }
            if (wol_ai != null)
            {
                wol_ai.enabled = false;
                source.Play();
                Destroy(gameObject);


            }
            if (yoyo_ai != null)
            {
                yoyo_ai.enabled = false;
                source.Play();
                Destroy(gameObject);

            }

        }
    }
}
