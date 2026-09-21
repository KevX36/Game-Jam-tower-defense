using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public int speed = 15;

    public Rigidbody2D rb;

    public void shoot(Enemy target, int power)
    {

        Debug.Log("shot bullet");
        Fly(target,power);
    }

    IEnumerator Fly(Enemy Target, int power)
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
            Target.HP -= power;
        }
        this.gameObject.SetActive(false);
    }
}
