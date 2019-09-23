using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalRandom : MonoBehaviour {
    public GameObject chicken;

    public GameObject goat;

    public GameObject sheep;

    public GameObject gameDataCtl;
    public GameDataCtrl data;

    // Use this for initialization
    void Start () {
        gameDataCtl = GameObject.Find("GameData");
        data = gameDataCtl.GetComponent<GameDataCtrl>();

        StartCoroutine(Chicken());

        StartCoroutine(Goat());

        StartCoroutine(Sheep());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Chicken()
    {
        Debug.Log("닭닭닭"+ data.chicken);
        for (int i = 0; i < data.chicken; i++) {
            Vector3 position = new Vector3(Random.Range(13.59f, 14.81f), -0.175163f, Random.Range(2.05f, 4.32f));
            Instantiate(chicken, position, Quaternion.identity);
            Debug.Log("닭닭닭");
            yield return new WaitForSeconds(0.2f);
        }

    }

    IEnumerator Sheep()
    {
        Debug.Log("양양양"+ data.sheep);
        for (int i = 0; i < data.sheep; i++) {
            Vector3 position = new Vector3(Random.Range(13.5f, 17.58f), -0.175163f, Random.Range(7.59f, 17.78f));
            Instantiate(sheep, position, Quaternion.identity);
            Debug.Log("양양양");
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator Goat()
    {
        for (int i = 0; i < data.goat; i++){
            Vector3 position = new Vector3(Random.Range(13.5f, 17.58f), -0.175163f, Random.Range(7.59f, 17.78f));
            Instantiate(goat, position, Quaternion.identity);
            Debug.Log("염소염소염소");
            yield return new WaitForSeconds(0.2f);

        }
    }

}
