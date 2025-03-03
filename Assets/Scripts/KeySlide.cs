using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySlide : MonoBehaviour
{
	// Start is called before the first frame update
	public GameObject ParentObj;
    
	public bool dragging = false;
	private float distance;
	public GameObject point_1,point_2;
   
	public bool pos_X,pos_Y,rot_X,rot_Y;
	float x,y;
	public float	temp_rot_z,rot;
	
	public bool anticlockwise;
	void OnMouseEnter()
	{
		
	}
 
	void OnMouseExit()
	{
		
	}
 
	void OnMouseDown()
	{
		distance = Vector3.Distance(ParentObj.transform.position, Camera.main.transform.position);
		dragging = true;
		
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Vector3 rayPoint = ray.GetPoint(distance);
		x = rayPoint.x;
		y =rayPoint.y;
		temp_rot_z = gameObject.transform.localEulerAngles.z;//e
	}
 
	void OnMouseUp()
	{
		dragging = false;
	}
 
	void Update()
	{
		if (dragging)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector3 rayPoint = ray.GetPoint(distance);
			
			if(pos_X)
			{
				rayPoint.x = Mathf.Clamp(rayPoint.x,point_1.transform.position.x,point_2.transform.position.x);
				
				ParentObj.transform.position =  Vector3.Lerp(ParentObj.transform.position,new Vector3 (rayPoint.x,transform.position.y,transform.position.z),10*Time.deltaTime);
			}
			
			
			if(pos_Y)
			{
				rayPoint.y = Mathf.Clamp(rayPoint.y,point_1.transform.position.y,point_2.transform.position.y);
				rayPoint.x= gameObject.transform.position.x;
				ParentObj.transform.position =  Vector3.Lerp(ParentObj.transform.position,new Vector3 (transform.position.x, rayPoint.y,transform.position.z),10*Time.deltaTime);
			}
			
			if(rot_X)
			{
				float temprot =  x  - rayPoint.x;
				if(anticlockwise)
				{
					 temprot =rayPoint.x -  x ;
				}
				
				//	rayPoint = -rayPoint;
				
				
				temp_rot_z= 	temp_rot_z -temprot;
				temp_rot_z = Mathf.Clamp(temp_rot_z,point_1.transform.localEulerAngles.z,point_2.transform.localEulerAngles.z);
				
				ParentObj.transform.localEulerAngles=new Vector3(gameObject.transform.localEulerAngles.x,gameObject.transform.localEulerAngles.y, temp_rot_z);
				
				temp_rot_z = gameObject.transform.localEulerAngles.z;
				x  = rayPoint.x;
			}
			
			if(rot_Y)
			{
				float temprot = y -rayPoint.y;
				
				temp_rot_z= 	temp_rot_z -temprot;
				temp_rot_z = Mathf.Clamp(temp_rot_z,point_1.transform.localEulerAngles.z,point_2.transform.localEulerAngles.z);
				
				ParentObj.transform.localEulerAngles=new Vector3(gameObject.transform.localEulerAngles.x,gameObject.transform.localEulerAngles.y, temp_rot_z);
				
				temp_rot_z = gameObject.transform.localEulerAngles.z;
				y = rayPoint.y;
			}
			
		}
		
	
	}
}
