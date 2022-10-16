using UnityEngine.SceneManagement;
using UnityEngine;

public class CollisonHandler : MonoBehaviour
{

    Movement movementComponent;
    [SerializeField] float deleySeconds = 1f;

    void Start()
    {
        movementComponent = GetComponent<Movement>();
    }

    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This thing is friendly");
                break;
            case "Finish":
                StartLoadNextLevel();
                break;
            case "Fuel":
                Debug.Log("Add Fuel");
                break;
            default:
                StartCrashSequence();
                break;


        }
    }

    void StartCrashSequence()
    {
        movementComponent.enabled = false;
        Invoke("ReloadLevel", deleySeconds);
    }

    void StartLoadNextLevel()
    {
        movementComponent.enabled = false;
        Invoke("LoadNextLevel",deleySeconds);
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
