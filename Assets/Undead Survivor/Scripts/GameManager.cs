using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

  // static varible do not show up in inspector window
  public static GameManager instance;
  public Player player;

  void Awake()
  {
    instance = this;
  }

}
