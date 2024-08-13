using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Note : MonoBehaviour
{
    public NoteXPosition noteXPosition;
    public KeyCode hitKey;
    public bool hitActivate;
    public RectTransform rect;

    public virtual void Start()
    {
        rect = GetComponent<RectTransform>();

        switch (noteXPosition)
        {
            case NoteXPosition.Left:
                rect.anchoredPosition = new Vector2(-225, rect.anchoredPosition.y);
                break;
            case NoteXPosition.LeftCenter:
                rect.anchoredPosition = new Vector2(-75, rect.anchoredPosition.y);
                break;
            case NoteXPosition.RightCenter:
                rect.anchoredPosition = new Vector2(75, rect.anchoredPosition.y);
                break;
            case NoteXPosition.Right:
                rect.anchoredPosition = new Vector2(225, rect.anchoredPosition.y);
                break;
        }
    }

    public virtual void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * 100);

        if (hitActivate && Input.GetKeyDown(hitKey))
        {
            HitNote();
        }
    }

    public abstract void HitNote();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Activator"))
        {
            hitActivate = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Activator"))
        {
            hitActivate = false;
        }
    }
}

public enum NoteXPosition
{
    Left,
    LeftCenter,
    RightCenter,
    Right
}
