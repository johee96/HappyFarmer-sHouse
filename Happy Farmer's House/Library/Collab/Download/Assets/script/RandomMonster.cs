using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMonster : MonoBehaviour {

    public GameObject rabbit;
    public static int rabbitCount = 0;

    public GameObject cobra;
    public static int cobraCount = 0;

    public GameObject tiger;
    public static int tigerCount = 0;
    // Use this for initialization
    void Start () {

        StartCoroutine(Rabbit());

        StartCoroutine(Cobra());

        StartCoroutine(Tiger());
    }
	
	// Update is called once per frame
	void Update () {
        if (rabbitCount <= 15) {
            StartCoroutine(Rabbit());
        }
        if (cobraCount <= 10)
            StartCoroutine(Cobra());
        if (tigerCount <= 5)
            StartCoroutine(Tiger());
     }

    IEnumerator Rabbit()
    {
        //토끼 15개 생성
        while (rabbitCount < 15)
        {
            Vector3 position = new Vector3(Random.Range(42.0f, 457.0f), 30.0f, Random.Range(50.0f, 447.0f));
            Instantiate(rabbit, position, Quaternion.identity);
            rabbitCount++;
            Debug.Log("rabbitCount : " + rabbitCount);
            yield return new WaitForSeconds(0.2f);

        }
    }

    IEnumerator Cobra()
    {
        //코브라 10개 생성
        while (cobraCount < 10)
        {
            Vector3 position = new Vector3(Random.Range(42.0f, 457.0f), 25.0f, Random.Range(50.0f, 447.0f));
            Instantiate(cobra, position, Quaternion.identity);
            cobraCount++;
            Debug.Log("cobraCount : " + cobraCount);
            yield return new WaitForSeconds(0.2f);

        }
    }

    IEnumerator Tiger()
    {
        //호랑이 5개 생성
        while (tigerCount < 5)
        {
            Vector3 position = new Vector3(Random.Range(42.0f, 457.0f), 25.0f, Random.Range(50.0f, 447.0f));
            Instantiate(tiger, position, Quaternion.identity);
            tigerCount++;
            Debug.Log("tigerCount : " + tigerCount);
            yield return new WaitForSeconds(0.2f);

        }
    }


     
}
