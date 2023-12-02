using Sound.Value;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private const string MainSceneName = "Main";

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);    
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (string.Equals(scene.name, MainSceneName))
        {
            SoundController.Instance.PlayAudio(SoundName.UpAndRight);
        }
    }
}
