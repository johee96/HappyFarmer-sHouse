using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSheeppur : MonoBehaviour {

    public GameObject sheeppur;
    public static int sheeppurCount = 0;
    private static float sheeppurTime = 10.0f;   //180초

                                            // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (sheeppurTime > 0.0f)
        {
            sheeppurTime -= Time.deltaTime;

        }
        else
        {   //양털생성
            Debug.Log("Time is Over");
            sheeppurTime = 10.0f;

        }


        if (sheeppurCount == 0 && sheeppurTime < 0.0f)
        {

            StartCoroutine(Sheeppur());
        }


    }

    IEnumerator Sheeppur()
    {
        while (sheeppurCount < 1)
        {
            Vector3 position = new Vector3(Random.Range(12.735f, 12.735f), 0.056f, Random.Range(10.784f, 11.943f));
            Instantiate(sheeppur, position, Quaternion.identity);
            sheeppurCount++;
            yield return new WaitForSeconds(0.2f);

        }
    }
}
