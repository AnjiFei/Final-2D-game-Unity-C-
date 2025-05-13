using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu]
public class CharacterDatabase : ScriptableObject
{
	//public CharacterStore charr;
	
	public Character[] charcter;

	public int CharacterCount
	{
		
		get
		{
			return charcter.Length;
		}
	}

	public Character GetCharacter (int index)
	{
		return charcter[index];
       // Instantiate(charr.character[index], new Vector3(0, 0, 0), Quaternion.identity);
	}
}
