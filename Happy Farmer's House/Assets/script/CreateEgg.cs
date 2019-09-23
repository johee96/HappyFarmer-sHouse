using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEgg : MonoBehaviour
{

    public GameObject egg;
    public static int eggCount = 0;
    private static float eggTime = 10.0f;   //120초

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (eggTime > 0.0f)
        {
            eggTime -= Time.deltaTime;

        }
        else
        {   //달걀생성
           
            
            if (eggCount == 0 ) {
                Debug.Log(eggCount);
                eggTime = 10.0f;         
             }
           
        }
        if (eggCount == 0 && eggTime < 0.0f) {
            StartCoroutine(Egg());
        }


    }

    IEnumerator Egg()
    {
        while (eggCount < 2)
        {
            Vector3 position = new Vector3(Random.Range(13.975f, 13.975f), 1.0f, Random.Range(2.857f, 4.265f));
            Instantiate(egg, position, Quaternion.identity);
            eggCount++;
            yield return new WaitForSeconds(0.2f);

        }
    }
}
