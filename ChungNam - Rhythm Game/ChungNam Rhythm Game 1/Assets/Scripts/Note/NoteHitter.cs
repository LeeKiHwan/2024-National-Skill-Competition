using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteHitter : MonoBehaviour
{
    public List<NormalNote> notes = new();

    private void Update()
    {
        if (notes.Count > 0)
        {
            if (notes[0].noteXPosition == NoteXPosition.Left)
            {
                if (notes[0].notePositionType == PositionType.Ground && Input.GetKeyDown(NoteManager.Instance.leftSky)) MissNote();
                else if (notes[0].notePositionType == PositionType.Sky && Input.GetKeyDown(NoteManager.Instance.leftGround)) MissNote();
            }
        }
    }

    public void MissNote()
    {
        int hitAccuracy = 0;

        if (NoteManager.Instance.missDefense > 0)
        {
            hitAccuracy = 50;
            NoteManager.Instance.combo++;
            NoteManager.Instance.missDefense--;
        }
        else
        {
            NoteManager.Instance.combo = 0;
        }

        NoteManager.Instance.noteCount++;
        NoteManager.Instance.noteSuccess += hitAccuracy;

        UIManager.Instance.UpdateNoteUI(hitAccuracy);

        Destroy(notes[0].gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            if (collision.GetComponent<NormalNote>() != null)
            {
                notes.Add(collision.GetComponent<NormalNote>());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            if (collision.GetComponent<NormalNote>() != null)
            {
                notes.Remove(collision.GetComponent<NormalNote>());
            }
        }
    }
}
