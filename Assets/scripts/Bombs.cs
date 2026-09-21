using UnityEngine;
using System.Collections;

public class Bombs : Bullet
{
    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        blastRange = this.GetComponent<Collider2D>();
        this.gameObject.SetActive(false);
    }
    public int Power;
    public Collider2D blastRange;
    public override void shoot(Enemy target, int power, float speed)
    {
        Power = power;
        Debug.Log("shot bullet");
        StartCoroutine(Fly(target.transform, speed));
    }

    IEnumerator Fly(Transform Target, float speed)
    {
        while (Vector2.Distance(rb.position, Target.position) > 0.9f && Target != null)
        {
            Vector2 move = Vector2.MoveTowards(rb.position, Target.transform.position, speed * Time.fixedDeltaTime);
            Debug.Log("Moving towards" + Target.position);
            rb.MovePosition(move);



            yield return null;
        }
        if (Target != null)
        {
            Debug.Log("hit target");
            
        }
        yield return new WaitForSecondsRealtime(1);
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(Power);
            
        }
    }
}
