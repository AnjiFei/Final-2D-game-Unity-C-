using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
	private Animator _animator;
	
	void Start()
	{
		_animator = GetComponent<Animator>();
	}

	private void OnTriggerEnter2D (Collider2D collision)
	{
		_animator.Play("NextLevel");
	}

	//void Update ()
	//{
	//	if (keys == 1)
	//	{
	//		_animator.Play("DoorOpen");
	//	}
	//}

	//private void Awake()
	//{
	//	_animator = GetComponent<Animator>();
	//}

	//[ContextMenu(itemName:"Open")]
	//public void Open()
	//{
	//	_animator.SetTrigger(name:"Open");
	//}
   
}
