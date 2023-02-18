using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

  public Vector2 inputVec;
  public float speed;

  Rigidbody2D rigid;
  SpriteRenderer spriter;

  // 초기화용 함수(1회 실행)
  void Awake()
  {
    rigid = GetComponent<Rigidbody2D>();
    spriter = GetComponent<SpriteRenderer>();
  }

  // Update is called once per frame
  // void Update()
  // {
  //   inputVec.x = Input.GetAxis("Horizontal");   
  //   inputVec.y = Input.GetAxis("Vertical");   


  //   GetAxisRaw: Returns the value of the virtual axis identified by axisName with no smoothing filtering applied.
  //   inputVec.x = Input.GetAxisRaw("Horizontal");
  //   inputVec.y = Input.GetAxisRaw("Vertical");
  // }

  // 물리 연산 프레임마다 호출
  void FixedUpdate()
  {
    // 1. 힘을 통한 구현
    // rigid.AddForce(inputVec);

    // 2. 속도를 통한 구현
    // rigid.velocity = inputVec;

    // 3. 위치를 통한 구현
    // rigid.MovePosition(rigid.position + inputVec);

    // normalized: Returns this vector with a magnitude of 1 (Read Only). removed: already set up in input system package setup
    // fixedDeltaTime: The interval in seconds at which physics and other fixed frame rate updates (like MonoBehaviour's MonoBehaviour.FixedUpdate) are performed.
    Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
    rigid.MovePosition(rigid.position + nextVec);
  }

  // input system with 'input systen' package installed from package manager
  void OnMove(InputValue value)
  {
    inputVec = value.Get<Vector2>();
    rigid.MovePosition(rigid.position + inputVec);

  }

  // LateUpdate is called once per frame, after Update has finished. Any calculations that are performed in Update will have completed when LateUpdate begins.
  void LateUpdate()
  {
    if (inputVec.x != 0 && spriter != null)
    {
      spriter.flipX = inputVec.x < 0;
    }
  }
}
