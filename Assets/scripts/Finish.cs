using UnityEngine;
using UnityEngine.SceneManagement;
public class Finish : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Character")
        {
            UnlockLevel();
            SceneManager.LoadScene(11); 
        }

    }

    private void UnlockLevel()
    {
         int currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (currentLevel>=PlayerPrefs.GetInt("levels"))
        {
            PlayerPrefs.SetInt("levels", currentLevel  + 1 );
            Debug.Log(currentLevel);
        }

        
    }
}
