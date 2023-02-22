using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public float speed;
  public Rigidbody2D target;

  bool isAlive = true;

  Rigidbody2D rigid;
  SpriteRenderer sprinter;

  private void Awake()
  {
    rigid = GetComponent<Rigidbody2D>();
    sprinter = GetComponent<SpriteRenderer>();
  }

  private void FixedUpdate()
  {
    if (!isAlive) return;

    Vector2 dirVec = target.position - rigid.position;
    Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;

    rigid.MovePosition(rigid.position + nextVec);
    // prevent accelerate on collision
    rigid.velocity = Vector2.zero;
  }

  private void LateUpdate()
  {
    if (!isAlive) return;

    sprinter.flipX = target.position.x - rigid.position.x < 0;
  }
}
