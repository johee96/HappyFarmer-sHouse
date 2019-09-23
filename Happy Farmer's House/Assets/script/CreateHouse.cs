using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateHouse : MonoBehaviour {
    public GameObject house1;
    public GameObject house2;
    public GameObject house3;
    public GameObject gameDataCtl;
    public GameDataCtrl data;
    // Use this for initialization
    void Start () {
        gameDataCtl = GameObject.Find("GameData");
        data = gameDataCtl.GetComponent<GameDataCtrl>();

        if (data.house_level == 0) {
            house1.SetActive(false);
            house2.SetActive(false);
            house3.SetActive(false);
        }
        else if (data.house_level == 1)
        {
            house1.SetActive(true);
            house2.SetActive(false);
            house3.SetActive(false);
        }
        else if (data.house_level == 2)
        {
            house1.SetActive(false);
            house2.SetActive(true);
            house3.SetActive(false);
        }
        else
        {
            house1.SetActive(false);
            house2.SetActive(false);
            house3.SetActive(true);

        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
