using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public static bool lose = false;
    GameObject player;

    void Start()
    {
        this.player = GameObject.Find("Player");
    }

    void Update()
    {
        transform.Translate(0, -0.2f, 0);
        if (transform.position.y < -0f)
        {
            Destroy(gameObject);
        }

        Vector3 bomb_position = transform.position;
        Vector3 player_position = this.player.transform.position;
        Vector3 dir = bomb_position - player_position;

        float distance = dir.magnitude;
        float bomb_radius = 0.5f;
        float player_radius = 0.5f;

        if (distance < bomb_radius + player_radius)
        {
            Destroy(gameObject);
            lose = true;
        }
    }
}
