using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishNo : MonoBehaviour
{
	public int fish_no,currentFish_no;
	public FishUnlock fishUnlock;
    // Start is called before the first frame update
    void Start()
	{  
		currentFish_no=GameManager.instance.total_fish_unlock;
		if(currentFish_no < fish_no)
		{
			gameObject.transform.GetChild(1).gameObject.SetActive(false);
		}
	    
	}
    
	public void Select()
	{
		if(currentFish_no < fish_no)
		{
			return;
		}
		PlayerPrefs.SetInt("CURRENTFISH",fish_no);
		GameManager.instance.fishUnlock = PlayerPrefs.GetInt("CURRENTFISH",0);
		fishUnlock.SelectedFish();
	
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
