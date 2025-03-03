using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
	public GameObject lava_obj;
	List<GameObject> lava = new List<GameObject>();
	public float no;
    // Start is called before the first frame update
    void Start()
	{
    	
		no = GameManager.instance.lava;
	    for(int i =0; i< no;i++)
	    {
	    	
	    	GameObject temp =Instantiate(lava_obj,gameObject.transform.position,Quaternion.identity);
		    lava.Add(temp);
		    
		    
	    }
	    
	    Invoke("obj",1f);
	   
    }
	public void obj()
	{
		for(int i =0; i< no;i++)
		{
			lava[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
		}
	}
    // Update is called once per frame
    void Update()
    {
        
    }
}
