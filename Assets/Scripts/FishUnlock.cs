using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishUnlock : MonoBehaviour
{
	
	public int fishno;
	public bool fishSelector;
	public GameObject Selected_fish;
    // Start is called before the first frame update
    void Start()
    {
	    //fishno =  GameManager.instance.fishUnlock;
	    SelectedFish();
	    
    }

	public void SelectedFish()
	{
		if(!fishSelector)
		{
			fishno =  GameManager.instance.total_fish_unlock +1;
			for(int i =0; i<Selected_fish.transform.childCount;i++)
			{
				Selected_fish.transform.GetChild(i).gameObject.SetActive(false);
			}
			Selected_fish.transform.GetChild(fishno).gameObject.SetActive(true);
		}
		else
		{
			fishno =  GameManager.instance.fishUnlock ;
			for(int i =0; i<Selected_fish.transform.childCount;i++)
			{
				Selected_fish.transform.GetChild(i).gameObject.SetActive(false);
			}
			Selected_fish.transform.GetChild(fishno).gameObject.SetActive(true);
		}
	}
    // Update is called once per frame
    void Update()
    {
        
    }
    
	public void Unlock()
	{
		GameManager.instance.total_fish_unlock = GameManager.instance.total_fish_unlock+1;
		if(GameManager.instance.total_fish_unlock >9)
		{
			GameManager.instance.total_fish_unlock = 9;
		}
		PlayerPrefs.SetInt("TOTALFISH",	GameManager.instance.total_fish_unlock);
		//	PlayerPrefs.GetInt("TOTALFISH",GameManager.instance.total_fish_unlock);
		//	GameManager.instance.total_fish_unlock = PlayerPrefs.SetInt("TOTALFISH",9);
	}
}
