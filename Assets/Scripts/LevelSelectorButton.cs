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
    void Start()
    {
        //int levelReached = PlayerPrefs.GetInt("levelReached", 1);
		int levelReached = 7;
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