using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NormalNote : Note
{
    public NoteType noteType;
    public PositionType notePositionType;
    
    public override void Start()
    {
        base.Start();

        if (noteXPosition == NoteXPosition.Left)
        {
            if (notePositionType == PositionType.Ground) hitKey = NoteManager.Instance.leftGround;
            else hitKey = NoteManager.Instance.leftSky;
        }
        if (noteXPosition == NoteXPosition.LeftCenter)
        {
            if (notePositionType == PositionType.Ground) hitKey = NoteManager.Instance.leftCenterGround;
            else hitKey = NoteManager.Instance.leftCenterSky;
        } 
        if (noteXPosition == NoteXPosition.RightCenter)
        {
            if (notePositionType == PositionType.Ground) hitKey = NoteManager.Instance.rightCenterGround;
            else hitKey = NoteManager.Instance.rightCenterSky;
        }
        if (noteXPosition == NoteXPosition.Right)
        {
            if (notePositionType == PositionType.Ground) hitKey = NoteManager.Instance.rightGround;
            else hitKey = NoteManager.Instance.rightSky;
        }

        if (noteType == NoteType.Stealth) StartCoroutine(Stealth());
        if (noteType == NoteType.Size) StartCoroutine(Size());

        if (notePositionType == PositionType.Ground) GetComponent<Image>().color = Color.yellow;
        else GetComponent<Image>().color = Color.cyan;
    }

    public override void HitNote()
    {
        int hitAccuracy = 100 - (int)Mathf.Abs(rect.anchoredPosition.y);
        int energy = 0;

        if (NoteManager.Instance.perfect) hitAccuracy = 100;

        if (hitAccuracy >= 75)
        {
            NoteManager.Instance.combo++;
            energy = 2;
        }
        else if (hitAccuracy >= 20)
        {
            NoteManager.Instance.combo++;
            energy = 1;
        }
        else if (NoteManager.Instance.missDefense > 0)
        {
            hitAccuracy = 20;
            NoteManager.Instance.combo++;
            energy = 1;
            NoteManager.Instance.missDefense--;
        }
        else
        {
            NoteManager.Instance.combo = 0;
        }

        if (noteType == NoteType.Stealth) energy *= 2;
        else if (noteType == NoteType.Size) energy *= 4;

        if (notePositionType == PositionType.Ground)
        {
            NoteManager.Instance.AddGroundEnergy(energy);
            if (NoteManager.Instance.combo % 2 == 0)
            {
                NoteManager.Instance.AddSkyEnergy(1);
            }
        }
        else
        {
            NoteManager.Instance.AddSkyEnergy(energy);
            if (NoteManager.Instance.combo % 2 == 0)
            {
                NoteManager.Instance.AddGroundEnergy(1);
            }
        }

        NoteManager.Instance.noteCount++;
        NoteManager.Instance.noteSuccess += hitAccuracy;

        UIManager.Instance.UpdateNoteUI(hitAccuracy);
        Destroy(gameObject);
    }

    public IEnumerator Stealth()
    {
        Image image = GetComponent<Image>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);

        while (true)
        {
            if (rect.anchoredPosition.y < 150 && !NoteManager.Instance.ghostSkill)
            {
                image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + Time.deltaTime);
            }
            yield return null;
        }
    }

    public IEnumerator Size()
    {
        while (rect.anchoredPosition.y > 200)
        {
            float rand = Random.Range(0.1f, 1f);
            while (transform.localScale != new Vector3(rand, rand, rand))
            {
                transform.localScale = Vector3.MoveTowards(transform.localScale, new Vector3(rand, rand, rand), Time.deltaTime);
                yield return null;
            }
        }

        while (transform.localScale != Vector3.one)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, Vector3.one, Time.deltaTime);
            yield return null;
        }

        yield break;
    }
}

public enum NoteType
{
    Normal,
    Stealth,
    Size
}

public enum PositionType
{
    Ground,
    Sky
}
