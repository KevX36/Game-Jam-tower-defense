using UnityEngine;
using System.Collections;

public class Bombs : Bullet
{
    private void Start()
    {
        Blast.Stop();
        rb = this.GetComponent<Rigidbody2D>();
        blastRange = this.GetComponent<CircleCollider2D>();
        blastRange.enabled = false;
        this.gameObject.SetActive(false);
    }
    public void Update()
    {
        
    }
    public GameObject target;
    public int Power;
    public CircleCollider2D blastRange;
    public override void shoot(Enemy target, int power, float speed,float BlastZone)
    {
        blastRange.radius = BlastZone;
        Blast.Stop();
        Blast.startSpeed = BlastZone - 1;
        Power = power;
        //Debug.Log("shot bullet");
        StartCoroutine(Fly(target.transform, speed));
    }

    IEnumerator Fly(Transform Target, float speed)
    {
        
        target.transform.position = Target.transform.position;
        while (Vector2.Distance(rb.position, target.transform.position) > 0.1f && Target != null)
        {
            transform.up = Target.transform.position - transform.position;
            Vector2 move = Vector2.MoveTowards(rb.position, target.transform.position, speed * Time.fixedDeltaTime);
            //Debug.Log("Moving towards" + Target.position);
            rb.MovePosition(move);



            yield return null;
        }
        //Debug.Log("bomb go boom");
        blastRange.enabled = true;
        Blast.Play();
        yield return new WaitForSecondsRealtime(0.7f);
        this.gameObject.SetActive(false);
    }
    public ParticleSystem Blast;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("touched enemy");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(Power);
            
        }
    }
    
}
