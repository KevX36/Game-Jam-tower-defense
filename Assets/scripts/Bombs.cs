using UnityEngine;
using System.Collections;

public class Bombs : Bullet
{
    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        blastRange = this.GetComponent<Collider2D>();
        blastRange.enabled = false;
        this.gameObject.SetActive(false);
    }
    public GameObject target;
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
        target.transform.position = Target.transform.position;
        while (Vector2.Distance(rb.position, target.transform.position) > 0.9f && Target != null)
        {
            Vector2 move = Vector2.MoveTowards(rb.position, target.transform.position, speed * Time.fixedDeltaTime);
            Debug.Log("Moving towards" + Target.position);
            rb.MovePosition(move);



            yield return null;
        }
        Debug.Log("bomb go boom");
        blastRange.enabled = true;
        yield return new WaitForSecondsRealtime(0.5f);
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
