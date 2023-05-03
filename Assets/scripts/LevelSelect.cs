using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public Button[] buttons;
    private int levelUnlock;
   
    void Start()
    {
        levelUnlock = PlayerPrefs.GetInt("levels", 1);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
        for (int i = 0; i < levelUnlock; i++)
        {
            buttons[i].interactable = true;
        }
        
        Debug.Log(levelUnlock);
    }

    public void LoadLevel(int indexLevel)
    {
        SceneManager.LoadScene(indexLevel);

    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Reset");
    }

}
