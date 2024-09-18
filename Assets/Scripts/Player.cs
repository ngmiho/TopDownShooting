using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int hp;
    public float str;
    public float agi;
    public float spd;

    //move
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    public Vector3 moveInput;

    //animation
    public Animator animator;

    //animation - role
    public float rollBoost = 2f;
    private float rollTime;
    public float RollTime;
    bool toggleRoll = false;

    //Rotation - Character
    public SpriteRenderer characterSR;

    //Coin
    public Coin coin;

    //R-Mouse skill
    public Circle Circle;
    public Circle2 Circle2;
    private GameObject circle;
    private GameObject circle2;
    private bool isCircleCreated = false;

    public void SetStatuses()
    {
        //status
        hp = int.Parse(FindObjectOfType<StatusManager>(true).texts[0].GetComponent<TextMeshProUGUI>().text);
        str = float.Parse(FindObjectOfType<StatusManager>(true).texts[1].GetComponent<TextMeshProUGUI>().text);
        agi = float.Parse(FindObjectOfType<StatusManager>(true).texts[2].GetComponent<TextMeshProUGUI>().text);
        spd = float.Parse(FindObjectOfType<StatusManager>(true).texts[3].GetComponent<TextMeshProUGUI>().text);

        GetComponent<Health>().maxHealth = hp;
        GetComponent<Health>().currentHealth = hp;
        moveSpeed = spd;
    }

    private void Start()
    {
        //status
        //hp = int.Parse(FindObjectOfType<StatusManager>(true).texts[0].GetComponent<TextMeshProUGUI>().text);
        //str = float.Parse(FindObjectOfType<StatusManager>(true).texts[1].GetComponent<TextMeshProUGUI>().text);
        //agi = float.Parse(FindObjectOfType<StatusManager>(true).texts[2].GetComponent<TextMeshProUGUI>().text);
        //spd = float.Parse(FindObjectOfType<StatusManager>(true).texts[3].GetComponent<TextMeshProUGUI>().text);

        //GetComponent<Health>().maxHealth = hp;
        //moveSpeed = spd;


        animator = GetComponentInChildren<Animator>();
    }

    public float circleTime = 0f;

    private void Update()
    {
        this.Move();
        this.AnimatorIdle();
        this.AnimatorRoll();

        //if (Input.GetMouseButton(1) && isCircleCreated == false)
        //{
        //    isCircleCreated = true;
        //    circle = Instantiate(Circle.gameObject, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        //}
        //if (Input.GetMouseButton(2) && isCircleCreated == true)
        //{
        //    isCircleCreated = false;
        //    Destroy(circle);

        //    //create circle
        //    Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    mouse.z = 0;
        //    Instantiate(Circle2.gameObject, mouse, Quaternion.identity);
        //}
        if (circleTime >= 0)
        {
            circleTime -= Time.deltaTime;
            FindObjectOfType<RCooldown>().GetComponent<Image>().fillAmount = circleTime * (100f / 15 / 100f);
        }
        if (Input.GetMouseButton(1) && circleTime <= 0)
        {
            circleTime = 15f;
            Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouse.z = 0;
            Instantiate(Circle2.gameObject, mouse, Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && isCircleCreated == true)
        {
            isCircleCreated = false;
            Destroy(circle);
        }

    }

    public void AnimatorRoll()
    {
        if (Input.GetKeyDown(KeyCode.Space) && rollTime <= 0)
        {
            animator.SetBool("isRoll", true);
            moveSpeed += rollBoost;
            rollTime = RollTime;
            toggleRoll = true;
            //safe time
            GetComponent<Health>()._safeTimeCooldown = 2f;
        }

        if (rollTime <= 0 && toggleRoll == true)
        {
            animator.SetBool("isRoll", false);
            moveSpeed -= rollBoost;
            toggleRoll = false;
        }
        else
            rollTime -= Time.deltaTime;
    }

    public void AnimatorIdle()
    {
        animator.SetFloat("Walk", moveInput.sqrMagnitude);
        //animator.SetBool("isRoll", Input.GetAxis(KeyCode.Space.ToString());
    }

    public void Move()
    {
        moveInput.x = Input.GetAxis("Horizontal"); // || Input.GetKeyDown(KeyCode.D) 
        moveInput.y = Input.GetAxis("Vertical");
        transform.position += moveInput * moveSpeed * Time.deltaTime;

        if (moveInput.x != 0)
            if (moveInput.x > 0)
                characterSR.transform.localScale = new Vector3(1, 1, 0);
            else
                characterSR.transform.localScale = new Vector3(-1, 1, 0);
    }

}
