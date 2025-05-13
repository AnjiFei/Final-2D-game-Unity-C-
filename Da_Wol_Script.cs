using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Da_Wol_Script : MonoBehaviour
{
    
    public float patrol;
    public bool Attacking;
    public float speed;
    GameObject Player;
    public Animator wol_anim;
    public float smash_cd;
    public GameObject hitbox;
    // Start is called before the first frame update
    void Start()
    {
      
        InvokeRepeating("PatrolAndCD", Random.Range(0, 1f), 1f);

        Player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if (patrol <= 2 && !Attacking)
        {
            wol_anim.SetBool("IsIdle", true);
            wol_anim.SetBool("IsMoving", false);

        }
        else if (patrol <= 4 && !Attacking)
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
            transform.rotation = Quaternion.Euler(0, 0, 0);
            wol_anim.SetBool("IsMoving", true);
            wol_anim.SetBool("IsIdle", false);


        }
        else if( patrol <= 6 && !Attacking)
        {
            wol_anim.SetBool("IsIdle", true);
            wol_anim.SetBool("IsMoving", false);

        }
        else if (patrol <= 8 && !Attacking)
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
            transform.rotation = Quaternion.Euler(0, 180, 0);
            wol_anim.SetBool("IsMoving", true);
            wol_anim.SetBool("IsIdle", false);


        }
        if (patrol == 9 && !Attacking)
        {
            patrol = 1;
        }



        if (Vector3.Distance(transform.position, Player.transform.position) <= 6 && smash_cd == 0)
        {
            smash_cd = 3;
            Attacking = true;
            wol_anim.SetTrigger("Smash");
        }

        if (wol_anim.GetCurrentAnimatorStateInfo(0).IsName("Da_Wol_SmashUp") || wol_anim.GetCurrentAnimatorStateInfo(0).IsName("Da_Wol_SmashDown"))
        {
            Debug.Log("not atak");
            Attacking = true;
        }
        else
        {
            Attacking = false;
        }

        if (wol_anim.GetCurrentAnimatorStateInfo(0).IsName("Da_Wol_SmashDown"))
        {
            if (Vector3.Distance(transform.position, Player.transform.position) <=6 && Player.gameObject.GetComponent<Character_Movement>().iframes ==0)
            {
                Player.gameObject.GetComponent<Character_Movement>().Health -= 15;
                Player.gameObject.GetComponent<Character_Movement>().hurt = true;

                if (transform.position.x > Player.transform.position.x)
                {
                    Player.gameObject.GetComponent<Character_Movement>().hurt_dir = -1;

                }
                else
                {
                    Player.gameObject.GetComponent<Character_Movement>().hurt_dir = 1;

                }


            }
        }

    }




    void PatrolAndCD()
    {

        if (!Attacking)
        {
            patrol += 1;
        }
        if (smash_cd > 0)
        {
            smash_cd -= 1;
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
    }
}
