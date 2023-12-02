using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerProfileData : ScriptableObject
{
    [SerializeField] private int health;
    [SerializeField] private Vector3 position;
    [SerializeField] private string scene;

    public int Health => health;
    public Vector3 Position => position;
    public string Scene => scene;
}
