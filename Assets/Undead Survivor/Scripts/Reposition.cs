using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
  Collider2D coll;

  void Awake()
  {
    coll = GetComponent<Collider2D>();
  }

  // Sent when another object leaves a trigger collider attached to this object (2D physics only).
  void OnTriggerExit2D(Collider2D other)
  {
    if (!other.CompareTag("Area")) return;

    Vector3 playerDir = GameManager.instance.player.inputVec;

    Vector3 playerPos = GameManager.instance.player.transform.position;
    Vector3 myPos = transform.position;

    float dirX = playerPos.x - myPos.x;
    float dirY = playerPos.y - myPos.y;

    float diffX = Mathf.Abs(dirX);
    float diffY = Mathf.Abs(dirY);

    dirX = dirX > 0 ? 1 : -1;
    dirY = dirY > 0 ? 1 : -1;

    switch (transform.tag)
    {
      case "Ground":
        if (diffX > diffY)
        {
          transform.Translate(Vector3.right * dirX * 40);
        }
        else if (diffX < diffY)
        {
          transform.Translate(Vector3.up * dirY * 40);
        }
        else
        {
          transform.Translate(dirX * 40, dirY * 40, 0);
        }
        break;
      case "Enemy":
        if (coll.enabled)
        {
          transform.Translate(playerDir * 20 + new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0));
        }
        break;
    }
  }
}