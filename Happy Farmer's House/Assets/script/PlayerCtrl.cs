using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerCtrl : MonoBehaviour {

    private float h = 0.0f;
    private float v = 0.0f;
    private Transform tr;
    public float moveSpeed = 10.0f;
    public float rotSpeed = 10.0f;
  //  private int potionCount = 0;
   // private int sillingCount = 0;
   // public int playerHp=0;
  //  bool isShield = false;          //방패 장착하면 true로 바꾸기 

    public GameObject resultUI;

  

    //전역으로 사용 할 것 
    public GameObject gameDataCtl;
    public GameDataCtrl data;

    [System.Serializable]
    public class Anim
    {
        public AnimationClip IdleA;
        public AnimationClip Move;
        public AnimationClip runBackward;
        public AnimationClip Move_R;
        public AnimationClip Move_L;

        public Animation _animation;
    }

    public Anim anim;
    public Animation _animation;

    public static Animator animator;

    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;

    
    // Use this for initialization
    void Start()
    {
        tr = GetComponent<Transform>();
        _animation = GetComponentInChildren<Animation>();
        _animation.clip = anim.IdleA;
        _animation.Play();
        animator = this.gameObject.GetComponent<Animator>();
        resultUI.SetActive(false);

        gameDataCtl = GameObject.Find("GameData");
        data = gameDataCtl.GetComponent<GameDataCtrl>();

    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.gameObject.tag == "Untagged")
        {
            return;
        }

        if (hit.collider.gameObject.tag == "POTION")
        {
            hit.collider.gameObject.tag = "Finish";
            ++data.potion;
            Debug.Log("포션"+ data.potion);
            Destroy(hit.collider.gameObject, 0.2f);
            
        }

        if (hit.collider.gameObject.tag == "SILLING")
        {
            hit.collider.gameObject.tag = "Finish";
            data.silling += Random.Range(1,6);
            Debug.Log("실링"+data.silling);
            Destroy(hit.collider.gameObject, 0.2f);
        }
        

        if (hit.collider.gameObject.CompareTag("COBRA"))
        {
            if(data.playerHp > 0)
            {
                data.playerHp -= 15;
                animator.SetInteger("animation", 5);
            }
                
            Debug.Log("코브라: "+ data.playerHp);
        }

        if (hit.collider.gameObject.tag == "TIGER")
        {
            if (data.playerHp > 0) {
                data.playerHp -= 30;
                animator.SetInteger("animation", 5);
            }
            Debug.Log("타이거: " + data.playerHp);
        }

        if (hit.collider.gameObject.tag == "RABBIT")
        {
            if (data.playerHp > 0)
            {
                data.playerHp -= 10;
                animator.SetInteger("animation", 5);
            }
            Debug.Log("토끼: " + data.playerHp);
        }

        if (hit.collider.gameObject.tag == "EGG")
        {

            hit.collider.gameObject.tag = "Finish";   
            data.chicken_egg++;
            Debug.Log("에그에그에그에그" + data.chicken_egg);
            Destroy(hit.collider.gameObject, 0.2f);
            CreateEgg.eggCount--;
            return;
        }

  
        if (hit.collider.gameObject.tag == "MILK")
        {

            hit.collider.gameObject.tag = "Finish";
            data.goat_milk++;
            Debug.Log("우유우유" + data.chicken_egg);
            Destroy(hit.collider.gameObject, 0.2f);
            CreateMilk.milkCount--;
            return;
        }

        if (hit.collider.gameObject.tag == "SHEEPPER")
        {
            hit.collider.gameObject.tag = "Finish";
            data.sheep_pur++;
            Debug.Log("털털털" + data.sheep_pur);
            Destroy(hit.collider.gameObject, 0.2f);
            CreateSheeppur.sheeppurCount--;
            return;
        }
        if (hit.collider.gameObject.tag == "TOMATO")
        {
           
            Destroy(hit.collider.gameObject, 0.1f);
            data.tomato += 1;
            Debug.Log("TOMATO:" + data.tomato);
            return;
        }
        if (hit.collider.gameObject.tag == "CARROT")
        {
           
            Destroy(hit.collider.gameObject, 0.1f);
            data.carrot += 1;
            Debug.Log("CARROT:" + data.carrot);
            return;
        }
        if (hit.collider.gameObject.tag == "EGGPLANT")
        {
            
            Destroy(hit.collider.gameObject, 0.1f);
            data.eggplant += 1;
            Debug.Log("EGGPLANT:" + data.eggplant);
            return;
        }
        if (hit.collider.gameObject.tag == "PUMPKIN")
        {
            
            Destroy(hit.collider.gameObject, 0.1f);
            data.pumpkin += 1;
            Debug.Log("PUMPKIN:" + data.pumpkin);
            return;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(data.playerHp == 0)
            resultUI.SetActive(true);

        CharacterController controller = GetComponent<CharacterController>(); // 캐릭터 콘트롤러 참조
            if (controller.isGrounded)
            { // 땅에 있으면
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); // 전후좌우 조정
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;  // 움직임의 속도를 제어...
                if (Input.GetButton("Jump")) // 점프 버튼 누르면

                moveDirection.y = jumpSpeed;  // 해당 y값에 대입... 점프 한다.

            }
            moveDirection.y -= gravity * Time.deltaTime;  // y값에 조절 중력 가속도라고 보면 된다.
            controller.Move(moveDirection * Time.deltaTime);  // 콘트롤러는 이 모든 데이터를 참조하여 움직인다.. 시간 개념으로..
 
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
        tr.Translate(moveDir * moveSpeed * Time.deltaTime, Space.Self);
        tr.Rotate(Vector3.up * Time.deltaTime * rotSpeed * Input.GetAxis("Mouse X"));

        

        if(data.playerHp <= 0)
        {
            animator.SetInteger("animation", 6);
            data.playerHp = 0;
        }
        else
        {
            if (v >= 0.1f)
                animator.SetInteger("animation", 18);
            else if (v <= -0.1f)
                animator.SetInteger("animation", 18);
            else if (h >= 0.1f)
                animator.SetInteger("animation", 16);
            else if (h <= -0.1f)
                animator.SetInteger("animation", 17);
            else
                animator.SetInteger("animation", 20);
        }
            
    }

    
}
