using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] public int maxHealth;
    public int currentHealth;

    public Bar HealthBar;

    public UnityEvent OnDeath;

    public float safeTime = 1f;
    public float _safeTimeCooldown = 0f;
    public float _hitTimeCooldown = 0f;

    //animation
    public Animator animator;

    private void OnEnable()
    {
        OnDeath.AddListener(Death);
    }

    private void OnDisable()
    {
        OnDeath.RemoveListener(Death);
    }

    private void Start()
    {
        //sound
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        currentHealth = maxHealth;

        if (HealthBar != null)
            HealthBar.UpdateBar(currentHealth, maxHealth);

        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        _safeTimeCooldown -= Time.deltaTime;
        _hitTimeCooldown -= Time.deltaTime;

        if (_hitTimeCooldown < 0)
            animator.SetBool("isHit", false);
    }

    //sound
    public AudioClip hitSound;
    public AudioSource audioSource;

    //damaged
    public GameObject damaged;
    public void TakeDamage(int damage)
    {
        if (_safeTimeCooldown > 0) return;

        //animation - hit
        animator.SetBool("isHit", true);
        _hitTimeCooldown = safeTime;

        //sound
        audioSource.PlayOneShot(hitSound);

        _safeTimeCooldown = safeTime;
        currentHealth -= damage;

        //damaged
        damaged.GetComponent<TextMesh>().text = damage.ToString();
        Instantiate(damaged, gameObject.transform.position, Quaternion.identity);

        if (currentHealth <= 0)
        {
            currentHealth = 0;

            //animation - die
            //animator.SetBool("isDie", true);

            Invoke("InvodeDeath", 0f);


        }

        if (HealthBar == null) return;
        HealthBar.UpdateBar(currentHealth, maxHealth);
    }

    public void InvodeDeath()
    {
        OnDeath.Invoke();
    }

    public void RecoverHP(int hp)
    {
        currentHealth += hp;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        HealthBar.UpdateBar(currentHealth, maxHealth);
    }


    //UI
    //public Monster monsterUI;
    public Canvas endGame;

    public void Death()
    {
        //if (monsterUI != null && GameOver != null)
        //{
        //    if (monsterUI.valueText.text.Equals("20"))
        //        GameOver.ToggleGameOver();
        //    monsterUI.UpdateMonster(20);
        //}
        Destroy(gameObject);
        //if (GetComponent<Player>())
        //{
        //    if (endGame != null)
        //    {
        //        Instantiate(endGame, FindObjectOfType<Player>().transform.position, Quaternion.identity);
        //        Time.timeScale = 0;
        //    }
        //}


    }

}
