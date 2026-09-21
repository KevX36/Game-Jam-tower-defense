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
            if (Target == null)
            {
                Debug.Log("target died before it was reached");
                this.gameObject.SetActive(false);
            }


            yield return null;
        }
        
        Debug.Log("hit target");
        Target.TakeDamage(power);
        this.gameObject.SetActive(false);
    }
}
