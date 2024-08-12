using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public KeyCode leftGround;
    public KeyCode leftCenterGround;
    public KeyCode rightCenterGround;
    public KeyCode rightGround;

    public KeyCode leftSky;
    public KeyCode leftCenterSky;
    public KeyCode rightCenterSky;
    public KeyCode rightSky;

    public int combo;

    private void Update()
    {
        HitNote();
    }

    public void HitNote()
    {
        float x = 0;
        NotePositionType notePositionType = NotePositionType.Ground;

        if (Input.GetKeyDown(leftGround))
        {
            x = -3;
            notePositionType = NotePositionType.Ground;
        }
        if (Input.GetKeyDown(leftCenterGround))
        {
            x = -1;
            notePositionType = NotePositionType.Ground;
        }
        if (Input.GetKeyDown(rightCenterGround))
        {
            x = 1;
            notePositionType = NotePositionType.Ground;
        }
        if (Input.GetKeyDown(rightGround))
        {
            x = 3;
            notePositionType = NotePositionType.Ground;
        }

        if (Input.GetKeyDown(leftSky))
        {
            x = -3;
            notePositionType = NotePositionType.Sky;
        }
        if (Input.GetKeyDown(leftCenterSky))
        {
            x = -1;
            notePositionType = NotePositionType.Sky;
        }
        if (Input.GetKeyDown(rightCenterSky))
        {
            x = 1;
            notePositionType = NotePositionType.Sky;
        }
        if (Input.GetKeyDown(rightSky))
        {
            x = 3;
            notePositionType = NotePositionType.Sky;
        }

        if (x != 0)
        {
            RaycastHit hit;
            Physics.Raycast(new Vector3(x, 0, -0.8f), Vector3.forward, out hit, 1.6f, LayerMask.GetMask("Note"));

            if (hit.collider != null)
            {
                hit.collider.GetComponent<Note>().HitNote(notePositionType);
            }
            else
            {

            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        for (int i = -3; i<=3; i+=2)
        {
            Gizmos.DrawRay(new Vector3(i, 0, -0.8f), Vector3.forward * 1.6f);
        }
    }
}
