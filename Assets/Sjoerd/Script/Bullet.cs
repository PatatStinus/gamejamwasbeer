using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    public Transform Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;

    }
    void Update()
    {
        transform.LookAt(Player);
    }
}
