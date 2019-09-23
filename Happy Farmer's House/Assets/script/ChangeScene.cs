using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeScene : MonoBehaviour {
    public GameObject gameDataCtl;
    public GameDataCtrl data;
    // Use this for initialization
    void Start () {

        gameDataCtl = GameObject.Find("GameData");
        data = gameDataCtl.GetComponent<GameDataCtrl>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void ChangeShootingScene()
    {
        if(data.hand_gun)
        SceneManager.LoadScene("Scene");
        
    }

    public void ChangeFarmScene()
    {
        SceneManager.LoadScene("farm");
    }

    public void ChangeStoreScene()
    {
        SceneManager.LoadScene("store");
    }

}
