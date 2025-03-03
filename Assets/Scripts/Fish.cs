using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
	
	public int no;
	
		public Vector3 fish_pos;
    // Start is called before the first frame update
    void Start()
	{
		
		no = GameManager.instance.fishUnlock;
		GameObject.FindGameObjectWithTag("FISH").gameObject.transform.GetChild(0).gameObject.SetActive(false);
		GameObject.FindGameObjectWithTag("FISH").gameObject.transform.GetChild(no).gameObject.SetActive(true);
		fish_anim = GameObject.FindGameObjectWithTag("FISH").gameObject.transform.GetChild(no).GetComponent<Animator>();
	    
	    
		gameObject.transform.SetParent(fish_anim.transform);
		fish_anim.GetComponent<Rigidbody2D>().constraints  = RigidbodyConstraints2D.None;
		
		
		fish_anim.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
		
	
		fish_anim.GetComponent<Rigidbody2D>().mass =3f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public  int death_counter,counter;
	public bool live,dead;
	public Animator fish_anim;   
	void OnTriggerEnter2D(Collider2D col)
	{
		
		
		if(col.gameObject.layer == 9)
		{
			//height = (float)(counter /300);
			counter = counter +1;
		}
		if(col.gameObject.layer == 11)
		{
			death_counter = death_counter +1;
			
		}
		if((death_counter- counter)  >GameManager.instance.No_LavaReq  )
		{
			Invoke("Death",1f);
		}
		else if(counter > GameManager.instance.No_WaterReq )
		{
			live = true;
			fish_anim.SetBool("Sad",false);
			fish_anim.SetBool("Happy",true);
			//fish_anim.gameObject.transform.position = fish_pos;
			Invoke("Win",2f);
		}
	
		
	}
	
	void Death()
	{
		
		
		fish_anim.SetBool("Happy",false);
		fish_anim.SetBool("Sad",true);
		Invoke("Loose",2f);
		//if(!dead && !GameController.instance.win)
		//{
		//	fish_anim.SetBool("Idle",false);
		//	fish_anim.SetBool("Lose",true);
		//	if(live_bucket)
		//	{
		//		GameController.instance.loose = true;
		//		GameController.instance.live_bucket ++;
		//	}
		//	else
		//	{
		//		GameController.instance.Check();
		//		GameController.instance.dead_bucket -- ;
		//	}
		//	dead = true;
		//}
	}
	
	public void Win()
	{
		    GameObject.FindGameObjectWithTag("LEVEL")?.SetActive(false);
			GameObject.FindGameObjectWithTag("canvas")?.transform.GetChild(5).gameObject.SetActive(true);
	}
	
	public void Loose()
	{
			GameObject.FindGameObjectWithTag("LEVEL")?.SetActive(false);
			GameObject.FindGameObjectWithTag("canvas")?.transform.GetChild(4).gameObject.SetActive(true);

	}
}
