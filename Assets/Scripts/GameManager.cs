using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
	public static GameManager instance = null;
	
	public float water,lava,No_WaterReq,No_LavaReq;
	public int level_no;
	public GameObject[] level;
	public Animator loading;
	public bool test;
	public int fishUnlock,total_fish_unlock;
	public GameObject AcidSmoke;
	public Text lv;
	//public GoogleMobileAdsDemoScript ads;
    // Start is called before the first frame update
	void Awake()
	{
		fishUnlock = PlayerPrefs.GetInt("CURRENTFISH",0);
		total_fish_unlock = PlayerPrefs.GetInt("TOTALFISH",0);
		//loading.SetTrigger("in");
	    instance = this;
		level_no = PlayerPrefs.GetInt("LEVEL",level_no);
		lv.text = "LEVEL :"+level_no;
		if(!test)
		level[level_no]?.SetActive(true);
		Invoke("LOadingOut",1f);
	}
    
	public void LOadingOut()
	{
		//loading.SetTrigger("out");
	}

    // Update is called once per frame
    void Update()
    {
	    if(Input.GetKeyDown(KeyCode.A))
	    {
	    	NextLevel();
	    }
    }
    
	public void NextLevel()
	{
		//	ads.ShowInterstitial();
		loading.SetTrigger("out");
		Destroy(level[level_no-1].gameObject);
		
		//	level[level_no].SetActive(true);
		level_no++;
		if(level_no >level.Length)
		{
			level_no = 1;
		}
		PlayerPrefs.SetInt("LEVEL",level_no);
		Application.LoadLevel(0);


	}

	public void Restart()
	{
		loading.SetTrigger("out");
		Application.LoadLevel(0);

	
	}


	public void rewardSkipLevel()
    {
		loading.SetTrigger("out");
		Destroy(level[level_no - 1].gameObject);

		//	level[level_no].SetActive(true);
		level_no++;
		if (level_no > level.Length)
		{
			level_no = 1;
		}
		PlayerPrefs.SetInt("LEVEL", level_no);
		Application.LoadLevel(0);
	}


	[ContextMenu("FDJH")]
	public void sas()
	{
		PlayerPrefs.DeleteAll();
	}
	
}
