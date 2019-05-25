using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bomb"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
