using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{

    public GameObject bullet;
    public Transform firepos;

    private void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }
    void Fire()
    {
        CreateBullet();
    }
 
    void CreateBullet()
    {
        Instantiate(bullet, firepos.position, firepos.rotation);
    }
}
