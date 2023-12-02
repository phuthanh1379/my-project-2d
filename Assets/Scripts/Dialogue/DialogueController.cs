using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private Dialogue dialogue;
    [SerializeField] private CinemachineVirtualCamera vCam;

    public static DialogueController Instance;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        // Hide dialogue object
        dialogue.gameObject.SetActive(false);
    }

    public void ShowDialogue(string content)
    {
        // Show dialogue object and start showing content
        dialogue.gameObject.SetActive(true);
        dialogue.StartDialogue(content);

        // Zoom in camera
        DOTween.To(
            () => vCam.m_Lens.OrthographicSize,
            x => vCam.m_Lens.OrthographicSize = x,
            0.75f, 1f)
            .Play(); 
    }

    public void HideDialogue()
    {
        // Show dialogue object and start showing content
        dialogue.gameObject.SetActive(false);

        // Zoom out camera
        DOTween.To(
            () => vCam.m_Lens.OrthographicSize,
            x => vCam.m_Lens.OrthographicSize = x,
            2f, 1f)
            .Play();
    }
}
