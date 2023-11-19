using DG.Tweening;
using UnityEngine;

public class JumpTween : MonoBehaviour
{
    [SerializeField] private Vector3 basePosition;
    [SerializeField] private Vector3 endPosition;
    [SerializeField] private float jumpPower;
    [SerializeField] private int numJumps;
    [SerializeField] private float duration;
    [SerializeField] private int loops;

    private Sequence _sequence;

    private void Awake()
    {
        _sequence = DOTween.Sequence();
        var jumpTween = transform.DOLocalJump(endPosition, jumpPower, numJumps, duration);
        var backTween = transform.DOMove(basePosition, duration);

        _sequence
            .Append(jumpTween)
            .Append(backTween)
            .SetLoops(loops);
    }

    private void Start()
    {
        _sequence.Play();
    }
}
