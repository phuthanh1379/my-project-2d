using System;
using UnityEngine;

public class SimpleRotate : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3 myVector3;
    [SerializeField] private Vector2 myVector2;
    [SerializeField] private string myString;
    [SerializeField] private Color myColor;
    [SerializeField] private MyEnum myEnum;
    [SerializeField] private MyClass myClass;

    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Update()
    {
        var x = 0;
        var y = 0;
        var z = speed;
        var rotate = new Vector3(x, y, z);

        transform.Rotate(rotate);

        if (myClass.sprite != null)
        {
            spriteRenderer.sprite = myClass.sprite;
        }
    }
}

[Serializable]
public class MyClass
{
    public int id;
    public string name;
    public Sprite sprite;
}

public enum MyEnum
{
    North = 0,
    South = 1,
    East = 2,
    West = 3,
    None = -1,
}
