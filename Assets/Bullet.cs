using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Enemy Target;
    public int speed = 15;

    public int power = 5;
    public Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Fly()
    {
        while (Vector2.Distance(rb.position, Target.transform.position) > 0.9f && Target != null)
        {
            Vector2 move = Vector2.MoveTowards(rb.position, Target.transform.position, speed * Time.fixedDeltaTime);
            //Debug.Log("Moving towards" + path[i]);
            rb.MovePosition(move);



            yield return null;
        }
        if (Target != null)
        {
            Target.HP -= power;
        }
    }
}
