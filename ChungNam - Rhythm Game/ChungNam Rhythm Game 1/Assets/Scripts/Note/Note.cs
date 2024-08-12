using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Note : MonoBehaviour
{
    public float noteZ;
    public NoteXPosition noteXPosition;

    private float speed = 1;

    public virtual void Awake()
    {
        switch (noteXPosition)
        {
            case NoteXPosition.Left:
                transform.position = new Vector3(-3, 0, noteZ);
                break; 
            case NoteXPosition.CenterLeft:
                transform.position = new Vector3(-1, 0, noteZ);
                break;
            case NoteXPosition.CenterRight:
                transform.position = new Vector3(1, 0, noteZ);
                break;
            case NoteXPosition.Right:
                transform.position = new Vector3(3, 0, noteZ);
                break;
        }
    }

    public virtual void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }

    public abstract void HitNote(NotePositionType notePositionType);
}

public enum NoteXPosition
{
    Left,
    CenterLeft,
    CenterRight,
    Right
}
