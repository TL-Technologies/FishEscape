using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
	public GameObject water_obj;
	public GameObject water_lava_contact;
	public float no;
	// Start is called before the first frame update
	void Start()
	{
		
		no = GameManager.instance.water;
		for(int i =0; i< no;i++)
		{
			GameObject temp_obj = 	Instantiate(water_obj,gameObject.transform.position,Quaternion.identity);
			
			temp_obj.AddComponent<Death>().effect = water_lava_contact;
		}
	}

	// Update is called once per frame
	void Update()
	{
        
	}
}
