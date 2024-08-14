using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public int hp;
    public float speed;
    public float addSpeed;
    public PositionType positionType;

    private void Awake()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.LookAt(player);
    }

    public virtual void Update()
    {
        transform.Translate(Vector3.forward * (speed + addSpeed) * Time.deltaTime);
    }

    public virtual void TakeDamage()
    {
        hp--;
        StartCoroutine(Stop());

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator Stop(float time = 0.5f)
    {
        float baseSpeed = speed;
        speed = 0;
        yield return new WaitForSeconds(time);
        speed = baseSpeed;

        yield break;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            NoteManager.Instance.TakeDamage(hp);
            Destroy(gameObject);
        }

        if (other.CompareTag("SpeedUp") && positionType == PositionType.Sky)
        {
            addSpeed = speed * 0.5f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SpeedUp") && positionType == PositionType.Sky)
        {
            addSpeed = 0;
        }
    }
}
