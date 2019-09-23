using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour {

    public int damage = 20;
    public float speed = 100.0f;

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.up * speed);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
