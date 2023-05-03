
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
   public void ChangeScenes(int numberScenes)
    {
        SceneManager.LoadScene(numberScenes);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void LevelSelect()
    {
        SceneManager.LoadScene(11);
    }
    public void home()
    {
        SceneManager.LoadScene(0);
    }
}
