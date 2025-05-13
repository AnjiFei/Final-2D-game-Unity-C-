using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
    public CharacterDatabase characterDB;

    public SpriteRenderer artworkSprite;
    public GameObject artworkObject;
    private int selectedOption = 0;
    public Transform spawn;
    public int copy = 1;
    // Start is called before the first frame update
    void Start()
    {
        copy = 1;
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }

        else
        {
            Load();
        }
        UpdateCharacter(selectedOption);
    }
    private void Update()
    {
        SpawnP();
    }
    private void UpdateCharacter (int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.characterSprite;
        artworkObject = character.characterGameObject;
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
        
    }
    void SpawnP()
        {
        //for(int x = 0; x < copy; x++) 
        if(copy == 1)
        {
            
            GameObject newplauer = Instantiate(artworkObject, spawn.transform.position, transform.rotation) as GameObject;
            copy--;
            newplauer.transform.parent = GameObject.Find("Player").transform;
            
        }
        else
        {
            //copy--;
        }
    }

}
