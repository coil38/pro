using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidBody;       // 플레이어 오브젝트에 있는 RigidBody 컴포넌트를 연결하기 위한 변수
    public float speed = 8f;        //이동 속도 수치 값을 저장하는 변수
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKey(KeyCode.UpArrow))
         {
             playerRigidBody.AddForce(0, 0, speed);
         }
         if (Input.GetKey(KeyCode.DownArrow))
         {
             playerRigidBody.AddForce(0, 0, -speed);
         }
         if (Input.GetKey(KeyCode.RightArrow))
         {
             playerRigidBody.AddForce( speed, 0, 0);
         }
         if (Input.GetKey(KeyCode.LeftArrow))
         {
             playerRigidBody.AddForce(-speed, 0, 0);
         }*/
        // 수평축과 수칙축의 입력값을 감지하여 저장
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // 실제 이동 속도를 입열값과 이동 속력을 사용해 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        // Vecter3 속도를 (xSpeed, 0,zspeed)로 생성
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed); 
        //리지드바디의 속도에 newVelocity할당
        playerRigidBody.velocity = newVelocity;
    }


    public void Die()       //플레이어 캐릭터가 사망시 호출되고 이부분 내용이 처리됨
    {
        //자신의 게임 오브젝트를 비활성화
        gameObject.SetActive(false);

        //씬에 존재하는 GameManager 타입의 오브젝트를 찾아서 가져오기
        GameManager gameManager = FindObjectOfType<GameManager>();
        //가져온 GameManager 오브젝트의 EndGame() 메서드 실행
        gameManager.EndGame();
    }
}
