using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        this.gameObject.SetActive(false);
    }
    

    public Rigidbody2D rb;

    public virtual void shoot(Enemy target, int power, float speed)
    {

        Debug.Log("shot bullet");
        StartCoroutine(Fly(target, power,speed));
    }

    IEnumerator Fly(Enemy Target, int power, float speed)
    {
        while (Vector2.Distance(rb.position, Target.transform.position) > 0.9f && Target != null)
        {
            Vector2 move = Vector2.MoveTowards(rb.position, Target.transform.position, speed * Time.fixedDeltaTime);
            Debug.Log("Moving towards" + Target.transform.position);
            rb.MovePosition(move);



            yield return null;
        }
        if (Target != null)
        {
            Debug.Log("hit target");
            Target.TakeDamage(power);
        }
        else
        {
            Debug.Log("target already died");
        }
        this.gameObject.SetActive(false);
    }
}
