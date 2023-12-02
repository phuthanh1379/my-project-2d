using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Sound.Value;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button myButton;

    private const int MainLevelSceneIndex = 1;
    private const string MainLevelSceneName = "MainLevel";

    private void OnEnable()
    {
        myButton.onClick.AddListener(() =>
        {
            OnClickMyButton(MainLevelSceneIndex);
        });
    }

    private void OnDisable()
    {
        myButton.onClick.RemoveListener(() =>
        {
            OnClickMyButton(MainLevelSceneIndex);
        });
    }

    private void OnClickMyButton()
    {
        //SceneManager.LoadScene(MainLevelSceneIndex);
        SceneManager.LoadScene(MainLevelSceneName);
    }

    private void OnClickMyButton(int sceneIndex)
    {
        SoundController.Instance.PlayAudio(SoundName.Type2);
        SceneManager.LoadScene(sceneIndex);
        Debug.Log($"Loading scene index={sceneIndex}");
    }

    public void OnClickLoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
