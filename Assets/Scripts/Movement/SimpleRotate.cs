using UnityEngine;

public class SimpleRotate : MonoBehaviour
{
    [SerializeField] private Vector3 rotation;

    private void Update()
    {
        transform.Rotate(rotation);
    }
}
