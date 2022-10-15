using UnityEngine.SceneManagement;
using UnityEngine;

public class CollisonHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This thing is friendly");
                break;
            case "Finish":
                Debug.Log("Congrats you finish");
                break;
            case "Fuel":
                Debug.Log("Add Fuel");
                break;
            default:
                ReloadLevel();
                break;


        }
    }

    private static void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
