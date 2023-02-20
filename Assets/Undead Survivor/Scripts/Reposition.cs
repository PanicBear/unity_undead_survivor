using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
  void OnTriggerExit2D(Collider2D other)
  {
    if (!other.CompareTag("Area")) return;

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
    }
  }
}