using UnityEngine;
using UnityEngine.Events;

public class TriggerComponent : MonoBehaviour
{
    public UnityEvent onTriggerEnterEvent;
    public UnityEvent onTriggerStayEvent;
    public UnityEvent onTriggerExitEvent;

    private void OnTriggerEnter2D(Collider2D col)
    {
        onTriggerEnterEvent.Invoke();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        onTriggerStayEvent.Invoke();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        onTriggerExitEvent.Invoke();
    }
}
