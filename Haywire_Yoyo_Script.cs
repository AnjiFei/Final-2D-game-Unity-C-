using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Haywire_Yoyo_Script : MonoBehaviour
{
    
    public float Chase_Range;
    Rigidbody2D rb;
    public GameObject player_target;
    public GameObject Yoyo_Sprite;
    Transform pplauer;


    // Start is called before the first frame update
    void Start()
    {
        
        //pplauer = player_target.transform;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player_target == null) {
        player_target = GameObject.FindWithTag("Player"); }
        float player_distance = Vector3.Distance(player_target.transform.position, transform.position);

        if (player_distance < Chase_Range)
        {

          
             
        

            if (transform.position.x > player_target.transform.position.x)
            {
                transform.eulerAngles = new Vector3(transform.rotation.x, 0, transform.rotation.z);
            }
            if (transform.position.x < player_target.transform.position.x)
            {
                transform.eulerAngles = new Vector3(transform.rotation.x, 180, transform.rotation.z);
            }

            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player_target.transform.position.x, transform.position.y, transform.position.z), 10 * Time.deltaTime);
            
            Yoyo_Sprite.transform.Rotate(0, 0, 720 * Time.deltaTime);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<Character_Movement>().iframes == 0)
        {


            collision.gameObject.GetComponent<Character_Movement>().Health -= 5;
            collision.gameObject.GetComponent<Character_Movement>().hurt = true;

            if (transform.position.x > collision.transform.position.x)
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
