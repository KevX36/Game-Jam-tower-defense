using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        this.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (targetEnemy == null)
        {
            //Debug.Log("target died before it was reached");
            this.gameObject.SetActive(false);
        }
    }

    public Rigidbody2D rb;
    public Enemy targetEnemy;
    public virtual void shoot(Enemy target, int power, float speed,float Blast)
    {
        targetEnemy = target;
        //Debug.Log("shot bullet");
        StartCoroutine(Fly(target,power, speed));
    }

    IEnumerator Fly(Enemy Target, int power, float speed)
    {
        targetEnemy = Target;
        while (Vector2.Distance(rb.position, targetEnemy.transform.position) > 0.5f && targetEnemy != null)
        {
            transform.up = Target.transform.position - transform.position;
            Vector2 move = Vector2.MoveTowards(rb.position, targetEnemy.transform.position, speed * Time.fixedDeltaTime);

            //Debug.Log("Moving towards" + Target.transform.position);
            rb.MovePosition(move);
            


            yield return null;
        }

        //Debug.Log("hit target");
        targetEnemy.TakeDamage(power);
        this.gameObject.SetActive(false);
    }
}
