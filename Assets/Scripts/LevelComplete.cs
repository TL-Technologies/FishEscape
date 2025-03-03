using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelComplete : MonoBehaviour
{
	
	public  Image progress;
	public  float percentage;
	public Text val;
	public GameObject unlock;
    // Start is called before the first frame update
    void Start()
    {
	    percentage = PlayerPrefs.GetFloat("PROGRESS",0);
	    percentage = percentage +0.2f;
	    PlayerPrefs.SetFloat("PROGRESS",percentage);
	    val.text = (percentage*100)+"%";
	    if(percentage >= 1)
	    {
		    PlayerPrefs.SetFloat("PROGRESS",0);
		    Invoke("EnbleFishPopUp",0.7f);
		    
	    }
	    progress.fillAmount = percentage;
    }


	public void EnbleFishPopUp()
	{
		unlock.SetActive(true);
	}
    // Update is called once per frame
    void Update()
    {
        
    }
}
