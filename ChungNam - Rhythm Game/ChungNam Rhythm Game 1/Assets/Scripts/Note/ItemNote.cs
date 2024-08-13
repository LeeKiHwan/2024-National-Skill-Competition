using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemNote : Note
{
    public KeyCode otherKey;
    public ItemType itemType;

    public override void Start()
    {
        base.Start();

        if (noteXPosition == NoteXPosition.Left)
        {
            hitKey = NoteManager.Instance.leftGround;
            otherKey = NoteManager.Instance.leftSky;
        }
        if (noteXPosition == NoteXPosition.LeftCenter)
        {
            hitKey = NoteManager.Instance.leftCenterGround;
            otherKey = NoteManager.Instance.leftCenterSky;
        }
        if (noteXPosition == NoteXPosition.RightCenter)
        {
            hitKey = NoteManager.Instance.rightCenterGround;
            otherKey = NoteManager.Instance.rightCenterSky;
        }
        if (noteXPosition == NoteXPosition.Right)
        {
            hitKey = NoteManager.Instance.rightGround;
            otherKey = NoteManager.Instance.rightSky;
        }
    }

    public override void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * 100);

        if (hitActivate && Input.GetKeyDown(hitKey) || Input.GetKeyDown(otherKey))
        {
            HitNote();
        }
    }

    public override void HitNote()
    {
        switch (itemType)
        {
            case ItemType.Health:
                NoteManager.Instance.TakeHeal(50);
                break;
            case ItemType.Stop:
                break;
            case ItemType.Energy:
                break;
            case ItemType.Miss:
                NoteManager.Instance.missDefense += 2;
                break;
            case ItemType.Timer:
                break;
            case ItemType.Perfect:
                break;
        }
        Destroy(gameObject);
    }
}

public enum ItemType
{
    Health,
    Stop,
    Energy,
    Miss,
    Timer,
    Perfect
}
