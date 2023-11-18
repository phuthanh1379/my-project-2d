using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float multiplier;
    [SerializeField] private Vector3 baseScale;
    [SerializeField] private Transform playerModel;

    private float _horizontal;
    private float _vertical;

    private void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");

        Flip(_horizontal);
    }

    private void FixedUpdate()
    {
        var x = transform.position.x;
        var y = transform.position.y;

        transform.position = new Vector2(x + _horizontal * multiplier, 
            y + _vertical * multiplier);
    }

    private void Flip(float horizontal)
    {
        // Move right -> left
        if (horizontal < 0)
        {
            playerModel.localScale = new Vector3(baseScale.x * -1f, baseScale.y, baseScale.z);
        }

        // Move left -> right
        if (horizontal > 0)
        {
            playerModel.localScale = baseScale;
        }
    }
}
