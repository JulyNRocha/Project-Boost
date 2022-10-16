using UnityEngine.SceneManagement;
using UnityEngine;

public class CollisonHandler : MonoBehaviour
{
    [SerializeField] float deleySeconds = 2f;
    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip successSound;
   
    AudioSource audioSource;
    Movement movementComponent;

    bool isTransitioning = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        movementComponent = GetComponent<Movement>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if(isTransitioning) { return; }

        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This thing is friendly");
                break;
            case "Finish":
                StartSuccessSequence();
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
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(crashSound);
        movementComponent.enabled = false;
        Invoke("ReloadLevel", deleySeconds);
    }

    void StartSuccessSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(successSound);
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
