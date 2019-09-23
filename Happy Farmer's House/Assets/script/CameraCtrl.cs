using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour {

    public Transform targetTR;
    public float dist = 10.0f;
    public float height = 30.0f;
    public float dampTrace = 10.0f;
    private Transform tr;
    // Use this for initialization
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        tr.position = Vector3.Lerp(tr.position, targetTR.position - (targetTR.forward * dist) + (Vector3.up * height), Time.deltaTime * dampTrace);
        tr.LookAt(targetTR.position);
    }
}
