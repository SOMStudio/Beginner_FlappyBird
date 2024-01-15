using UnityEngine;
using UnityEngine.Events;

public class Bird : MonoBehaviour
{
    public float speed = 50f;
    public GameObject hitSprite;

    [Header("Events")] public UnityEvent deathEvent;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody;
    private bool isAlive = true;

    private bool screenClick = false;

    private Animator animator;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || screenClick == true) && isAlive)
        {
            rigidbody.velocity = Vector2.zero;
            rigidbody.AddForce(new Vector2(0.5f, 1) * speed);

            animator.SetTrigger("Flip");

            screenClick = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            isAlive = false;
            rigidbody.velocity = Vector2.down;

            animator.SetTrigger("Death");

            ShowHitSprite(collision.contacts[0].point);

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

    public void ClickScreenButton()
    {
        screenClick = true;
    }
}
