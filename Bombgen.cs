using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombgen : MonoBehaviour
{

    public GameObject bombprefab;
    float buffer = 0.2f;
    float delta = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.buffer)
        {
            this.delta = 0;
            GameObject go = Instantiate(bombprefab) as GameObject;
            int px = Random.Range(-20, 20);
            int pz = Random.Range(-20, 20);
            go.transform.position = new Vector3(px, 20, pz);
        }
    }
}
