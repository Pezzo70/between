using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public RoomMessagesManager roomMessagesManager;
    public EnviromentManager enviromentManager;
    private SpriteRenderer _spriteRenderer;

    public GameObject interactedItem;

    private void Awake()
    {
        _spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        roomMessagesManager.SetMessage(0, 3);
    }

    public void OnInteraction()
    {
        if (roomMessagesManager.coroutine != null)
            roomMessagesManager.ShowNextMessage();


        if (interactedItem != null)
            enviromentManager.OnInteract(interactedItem);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        interactedItem = collision.gameObject;
        if (collision.gameObject.tag == "Man")
        {
            if (this.transform.position.y > collision.gameObject.transform.position.y)
                _spriteRenderer.sortingOrder = 6;
            else if (this.transform.position.y < collision.gameObject.transform.position.y)
                _spriteRenderer.sortingOrder = 7;
        }

    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Man")
        {
            if (this.transform.position.y > other.gameObject.transform.position.y)
                _spriteRenderer.sortingOrder = 6;
            else if (this.transform.position.y < other.gameObject.transform.position.y)
                _spriteRenderer.sortingOrder = 7;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        interactedItem = null;
        if (collision.gameObject.tag == "Man")
            _spriteRenderer.sortingOrder = 6;
    }
}
