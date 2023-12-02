using DG.Tweening;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private string dialogue;
    [SerializeField] private float typingSpeed;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clip;

    private string _typingDialogue = string.Empty;
    private Sequence _typingSequence;

    private void Awake()
    {
        _typingSequence = DOTween.Sequence();

        var duration = dialogue.Length / typingSpeed;
        var typing = DOTween
                .To(() => _typingDialogue, x => _typingDialogue = x, dialogue, duration)
                .OnUpdate(() =>
                {
                    dialogueText.SetText(_typingDialogue);
                    audioSource.Play();
                })
            ;
        
        _typingSequence
            .Append(typing)
            ;
    }

    private void Start()
    {
        _typingSequence.Play();
    }
}
