using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStore : MonoBehaviour
{
    public GameObject[] character;
    public GameObject[] selected;
    // Start is called before the first frame update
    void Start()
    {
        selected = new GameObject[character.Length];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
