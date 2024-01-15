using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Bird : MonoBehaviour
{
    public float speed = 50f;
    public GameObject hitSprite;
    public AudioClip[] audioClips;

    [Header("Events")] public UnityEvent deathEvent;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbodyMy;
    private bool isAlive = true;

    private bool screenClick = false;

    private Animator animator;
    public AudioSource[] audioSource;

    private void Start()
    {
        rigidbodyMy = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        audioSource = GetComponents<AudioSource>();
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || screenClick == true) && isAlive)
        {
            rigidbodyMy.velocity = Vector2.zero;
            rigidbodyMy.AddForce(new Vector2(0.5f, 1) * speed);

            animator.SetTrigger("Flip");

            PlaySound(0);

            screenClick = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            isAlive = false;
            rigidbodyMy.velocity = Vector2.down;

            animator.SetTrigger("Death");

            ShowHitSprite(collision.contacts[0].point);
            
            PlaySound(1);
            PlaySound(2, 1);

            deathEvent?.Invoke();
        }
    }

    private void ShowHitSprite(Vector2 position)
    {
        hitSprite.SetActive(true);
        hitSprite.transform.position = position;

        Invoke(nameof(HideHitSprite), 0.2f);
    }

    private void HideHitSprite()
    {
        hitSprite.SetActive(false);
    }

    private void PlaySound(int numberClip, int numberAudioSource = 0)
    {
        audioSource[numberAudioSource].clip = audioClips[numberClip];
        audioSource[numberAudioSource].Play();
    }

    public void ClickScreenButton()
    {
        screenClick = true;
    }
}
