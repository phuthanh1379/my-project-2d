using UnityEngine;

public class SurpriseTrap : MonoBehaviour
{
    [SerializeField] private GameObject trap;
    [SerializeField] private Transform basePosition;

    private bool _createdTrap = default;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (_createdTrap)
            {
                return;
            }

            Instantiate(trap, basePosition.position, Quaternion.identity);
            _createdTrap = true;
        }
    }
}
