using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollector : MonoBehaviour
{
    public int keys;
	
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Key"))
		{
			Destroy(collision.gameObject);
			keys++;
			Debug.Log("Keys: " + keys);
		}
	}
}
