using UnityEngine;
using UnityEngine.SceneManagement;

public class restartScene : MonoBehaviour
{
   public void resetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
