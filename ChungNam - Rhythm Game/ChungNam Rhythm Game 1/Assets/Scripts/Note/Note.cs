using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        transform.Translate(Vector3.down * Time.deltaTime * 100 *  (NoteManager.Instance.timer ? 0.5f : 1)) ;

        if (hitActivate && Input.GetKeyDown(hitKey))
        {
            HitNote();
        }
        if (NoteManager.Instance.ghostSkill && rect.anchoredPosition.y < 150)
        {
            HideNote();
        }
    }

    public abstract void HitNote();

    public void HideNote()
    {
        Image image = GetComponent<Image>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - Time.deltaTime * 5);
    }

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
