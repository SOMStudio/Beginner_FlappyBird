using UnityEngine;
using UnityEngine.Events;

public class Bird : MonoBehaviour {

    public Sprite deathSprite;

    [Header("Events")]
    public UnityEvent deathEvent;
    
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody;
    private bool isAlive = true;

    private void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && isAlive)
        {
            rigidbody.velocity = Vector2.zero;
            rigidbody.AddForce(new Vector2(0.5f, 1) * 50f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            isAlive = false;
            spriteRenderer.sprite = deathSprite;
            rigidbody.velocity = Vector2.down;
            
            deathEvent?.Invoke();
        }
    }
}
