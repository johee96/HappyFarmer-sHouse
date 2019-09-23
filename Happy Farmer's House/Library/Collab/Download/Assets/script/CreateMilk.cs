using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMilk : MonoBehaviour {

    public GameObject milk;
    public static int milkCount = 0;
    private static float milkTime = 10.0f;      //240초


    // Use this for initialization
    void Start () {
   
    }
	
	// Update is called once per frame
	void Update () {
        if (milkTime > 0.0f)
        {
            milkTime -= Time.deltaTime;

        }
        else
        {   //우유생성
            StartCoroutine(Milk());
            Debug.Log("Time is Over");
            milkTime = 10.0f;

        }
    }


    IEnumerator Milk()
    {
        while (milkCount < 1)
        {
            Vector3 position = new Vector3(Random.Range(12.68f, 12.68f), 0.17f, Random.Range(8.56f, 9.76f));
            Instantiate(milk, position, Quaternion.identity);
            milkCount++;
            yield return new WaitForSeconds(0.2f);

        }
    }
}
