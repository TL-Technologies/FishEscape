using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
	
	public GameObject effect;
	bool dead;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	void OnCollisionEnter2D( Collision2D col)
	{
	
		if(col.gameObject.layer == 11)
		{
			//col.gameObject.layer = 15;
			col.gameObject.tag = "Untagged";
			
			
			Instantiate(effect,gameObject.transform.position,Quaternion.identity);
			
		
			//	col.gameObject.GetComponent<SpriteRenderer>().color = new Color (0.5f,0.5f,0.5f,1);
			Destroy(col.gameObject);
			Destroy(this.gameObject);
		}
		if(col.gameObject.layer == 15)
		{//	Debug.Log("qqqqqqqqqqqq");
		}
	}
}
