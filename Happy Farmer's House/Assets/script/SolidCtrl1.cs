using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidCtrl1 : MonoBehaviour {
    public GameObject ssak;
    public GameObject tomato;
    public GameObject eggplant;
    public GameObject carrot;
    public GameObject pumpkin;
    public Transform pos;
    public GameObject gameDataCtl;
    public GameDataCtrl data;

    private GameObject ins_ssak;

    private static float carrotTime; //
    private static float eggplantTime; //
    private static float tomatoTime; //  
    private static float pumpkinTime; //
    private static int store_plant;
    private static int is_ssak = 0;
    private static bool isKeyDown;
    // Use this for initialization
    void Start()
    {
        gameDataCtl = GameObject.Find("GameData");
        data = gameDataCtl.GetComponent<GameDataCtrl>();
        pos = gameObject.GetComponent<Transform>();
        ssak.SetActive(false);

        carrotTime = data.carrotTime;
        eggplantTime = data.eggplantTime;
        tomatoTime = data.tomatoTime;
        pumpkinTime = data.pumpkinTime;

    }

    // Update is called once per frame
    void Update()
    {
        isKeyDown = Input.GetKey(KeyCode.S);
        if (isKeyDown && is_ssak == 0)
        {
            //ins_ssak=Instantiate(ssak, pos.position, pos.rotation);
            ssak.SetActive(true);
            Debug.Log("생성: 싹");
            store_plant = data.hand_plant;
            is_ssak = 1;                         /////////////////////////////////////////////////////d여긴 플레이어에서 적용 
        }
        if (is_ssak == 1)
        {
            if (store_plant == 1)
            {//당근
                if (carrotTime > 0.0f)
                {
                    Debug.Log("당근: 시간측정");
                    carrotTime -= Time.deltaTime;
                }
                else
                {
                    ssak.SetActive(false);
                    //DestroyImmediate(ins_ssak, true);
                    is_ssak = 0;
                    Instantiate(carrot, pos.position, pos.rotation);
                    Debug.Log("당근: 타임오버");
                    carrotTime = data.carrotTime;

                }
            }
            else if (store_plant == 2)
            {
                //가지
                if (eggplantTime > 0.0f)
                {
                    eggplantTime -= Time.deltaTime;

                }
                else
                {
                    ssak.SetActive(false);
                    //DestroyImmediate(ins_ssak, true);
                    is_ssak = 0;
                    Instantiate(eggplant, pos.position, pos.rotation);
                    Debug.Log("가지: 타임오버");
                    eggplantTime = data.eggplantTime;

                }
            }
            else if (store_plant == 3)
            {//토마토 
                if (tomatoTime > 0.0f)
                {
                    tomatoTime -= Time.deltaTime;

                }
                else
                {
                    ssak.SetActive(false);
                    //DestroyImmediate(ins_ssak, true);
                    is_ssak = 0;
                    Instantiate(tomato, pos.position, pos.rotation);
                    Debug.Log("토마토: 타임오버");
                    tomatoTime = data.tomatoTime;

                }

            }
            else if (store_plant == 4)
            {//호박
                if (pumpkinTime > 0.0f)
                {
                    pumpkinTime -= Time.deltaTime;

                }
                else
                {
                    ssak.SetActive(false);
                    //DestroyImmediate(ins_ssak, true);
                    is_ssak = 0;
                    Instantiate(pumpkin, pos.position, pos.rotation);
                    Debug.Log("호박: 타임오버");
                    pumpkinTime = data.pumpkinTime;

                }

            }
        }
    }

}
