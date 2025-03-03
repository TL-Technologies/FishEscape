using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
	
	bool dead;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.layer == 11)
		{
			if(!dead)
				Instantiate(GameManager.instance.AcidSmoke,gameObject.transform.position,Quaternion.identity);
			
			
			dead = true;
			gameObject.transform.GetChild(1).gameObject.SetActive(true);
			gameObject.transform.GetChild(0).gameObject.SetActive(false);
			Destroy(this.gameObject,2f);
		}
	}
}
