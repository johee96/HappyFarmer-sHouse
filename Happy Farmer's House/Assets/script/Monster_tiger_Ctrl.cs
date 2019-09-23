using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_tiger_Ctrl : MonoBehaviour {

    private Transform MonsterTr;
    private Transform PlayerTr;
    private UnityEngine.AI.NavMeshAgent nvAgent;
    public GameObject bloodEffect;
    public GameObject bloodDecal;

    public enum MonsterState { idle, trace, hit, die };
    public MonsterState monsterState = MonsterState.idle;

    public float traceDist = 13.0f;
    public float attackDist = 2.0f;
    private bool isDie = false;

    private int hitCount;


   private Animator animator;


    public GameObject sparkEffect;

    public GameObject potion;
    public GameObject silling;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BULLET")
        {
            GameObject spark = (GameObject)Instantiate(sparkEffect, collision.transform.position, Quaternion.identity);
            hitCount++;
            Destroy(spark, spark.GetComponent<ParticleSystem>().duration + 0.2f);
            Destroy(collision.gameObject, 0.2f);
        }
      
    }
    // Use this for initialization
    void Start()
    {
        hitCount = 0;
        MonsterTr = this.gameObject.GetComponent<Transform>();
        PlayerTr = GameObject.FindWithTag("PLAYER").GetComponent<Transform>();
        nvAgent = this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = this.gameObject.GetComponent<Animator>();
        nvAgent.destination = PlayerTr.position;	



        StartCoroutine(this.CheckMonsterState());
        StartCoroutine(this.MonsterAction());
    }

    // Update is called once per frame
    void Update()
    {

        if (hitCount==8)
        {
            hitCount = 0;
            Instantiate(potion, gameObject.transform.position, gameObject.transform.rotation);    //생성하는 것 프리팹을 화면에 보이게 함 
            Instantiate(silling, gameObject.transform.position, gameObject.transform.rotation);    //생성하는 것 프리팹을 화면에 보이게 함 

            Destroy(gameObject, 0.2f);
            RandomMonster.tigerCount--;
        }

    }


    IEnumerator CheckMonsterState()
    {
        while (!isDie)
        {
            yield return new WaitForSeconds(0.2f);
            float dist = Vector3.Distance(PlayerTr.position, MonsterTr.position);
            if (dist <= attackDist)
                monsterState = MonsterState.hit;
            else if (dist <= traceDist)
                monsterState = MonsterState.trace;
            else
                monsterState = MonsterState.idle;
        }

    }

    IEnumerator MonsterAction()
    {
        while (!isDie)
        {
            switch (monsterState)
            {
                case MonsterState.idle:
                    nvAgent.Stop();
                    animator.SetBool("isIdle", true);
                    animator.SetBool("isRun", false);
                    break;
                case MonsterState.trace:
                    nvAgent.destination = PlayerTr.position;
                    nvAgent.Resume();
                    animator.SetBool("isHit", false);
                    animator.SetBool("isRun", true);
                    break;
                case MonsterState.hit:
                    nvAgent.destination = PlayerTr.position;
                    nvAgent.Resume();
                     animator.SetBool("isHit", true);
                     animator.SetBool("isRun", true);
                    break;


            }

            yield return null;
        }
    }
}
