using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Key : MonoBehaviour
{
    [Header("Custom Event")]
    public UnityEvent myEvents;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (myEvents == null)
        {

        }
        else
        {
            myEvents.Invoke();
        }
    }


    //[SerializeField]
    //private string _colliderScript;
    
    //[SerializeField]
    //private UnityEvent _collisionEntered;

    //[SerializeField]
    //private UnityEvent _collisionExit;

    //private void OnCollisionEnter2D(Collision2D col)
    //{
    //    if (col.gameObject.GetComponent(_colliderScript))
    //    {
    //        _collisionEntered?.Invoke();
    //    }
    //}

    //private void OnCollisionExit2D(Collision2D col)
    //{
    //    if (col.gameObject.GetComponent(_colliderScript))
    //    {
    //        _collisionExit?.Invoke();
    //    }
    //}
}
