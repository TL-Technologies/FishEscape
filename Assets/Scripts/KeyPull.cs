using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPull : MonoBehaviour
{
	private bool dragging = false;
	public GameObject target,parent_obj;
	
	private float distance;
	public AudioSource keyRelease;
	bool onMouseDown;
   
	void OnMouseEnter()
	{
		
	}
 
	void OnMouseExit()
	{
		
	}
 
	void OnMouseDown()
	{
		//keyRelease.Play();
		onMouseDown= true;
		Destroy(parent_obj,1f);
	}
 
	void OnMouseUp()
	{
	
	}
 
	void Update()
	{
		
		if(onMouseDown)
		{
			parent_obj.transform.position = Vector3.MoveTowards(gameObject.transform.position,target.transform.position,50*Time.deltaTime);
		}
	}
}
