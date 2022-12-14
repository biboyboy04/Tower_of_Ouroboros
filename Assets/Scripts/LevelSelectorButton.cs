using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectorButton : MonoBehaviour
{
    // Start is called before the first frame update
    
	public Button[] levelButtons;
	public GameObject loadingScreen;
    public Slider slider;
    public GameManagerScript gameManagerScript;

    private int floorNumber;

    void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 0);
		Debug.Log(levelReached);
		for (int i = 0; i < levelButtons.Length; i++)
		{
			if (i + 1 > levelReached)
			{
				levelButtons[i].interactable = false;
				levelButtons[i].GetComponent<Image>().color = new Color32(55, 55, 55, 0);
			}

		}
        

        
    }

	public void Select (string levelName)
	{

        if(SceneManager.GetActiveScene().name == "Prologue")
        {
            PlayerPrefs.SetInt("levelReached", 1);
        }

        floorNumber = System.Int32.Parse(levelName.Substring(levelName.Length - 1));
        
        

        // If player go to mainmenu and start the level again, restart the soul count same as the 
        // started soul count when the level start

        Debug.Log("floorNumber" + floorNumber);
        Debug.Log("PlayerPrefs.GetInt" + PlayerPrefs.GetInt("levelReached"));

        if(floorNumber == PlayerPrefs.GetInt("levelReached"))
        {
            PlayerPrefs.SetFloat("soulCount", PlayerPrefs.GetFloat("soulCountStart"));
            Debug.Log("Set playercountsoul");
        }
        
		StartCoroutine(LoadAsynchronously(levelName));
    }
 
	IEnumerator LoadAsynchronously (string sceneToLoad)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneToLoad);
        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }

}
