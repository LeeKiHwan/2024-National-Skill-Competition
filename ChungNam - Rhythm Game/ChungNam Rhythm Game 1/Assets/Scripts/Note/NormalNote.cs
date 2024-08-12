using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalNote : Note
{
    public NoteType noteType;
    public NotePositionType notePositionType;

    public override void Update()
    {
        base.Update();

        switch (noteType)
        {
            case NoteType.Stealth:
                break;
            case NoteType.Size:
                break;
        }
    }

    public override void HitNote(NotePositionType notePositionType)
    {
        if (this.notePositionType == notePositionType)
        {
            switch (noteType)
            {
                case NoteType.Normal:
                    Destroy(gameObject);
                    break;
                case NoteType.Stealth:

                    break;
                case NoteType.Size:
                    break;
            }
        }
        else
        {
            Debug.Log("Fail");
        }
    }

    public IEnumerator Stealth()
    {


        yield break;
    }
}

public enum NoteType
{
    Normal,
    Stealth,
    Size
}

public enum NotePositionType
{
    Ground,
    Sky
}
