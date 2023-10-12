using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IObserver
{
    private Rigidbody rb;
    [SerializeField]
    private float speed;

    public int health;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.velocity = new Vector3(0, rb.velocity.y, speed);
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void Start()
    {
        //GameObject.Find("GameManager").GetComponent<GameManager>().Attach(this);
        GameManager.Instance.OnProgressionChanged += Execute;
    }

    /*public void Execute(ISubject subject)
    {
        if(subject is GameManager)
        {
            speed = ((GameManager)subject).Progression;
        }
    }
    */
    private void Execute(int value)
    {
        speed = value;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnProgressionChanged -= Execute;
    }
}
