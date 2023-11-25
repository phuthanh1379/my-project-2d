using System;
using UnityEngine;

public class ParticleTrigger : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private Sprite sprite;

    public static event Action<Sprite> PickUpItem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var particleSystem = Instantiate(particles, transform.position, Quaternion.identity);
            particleSystem.Play();
            PickUpItem?.Invoke(sprite);
            Destroy(gameObject);
        }
    }
}
