using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
     
        public float speed = 8f;  //탄알의 이도ㅇ 속ㄹㅕㄱ
        private Rigidbody bulletRigidbady; // 이동에 사용할 리지드바디 컴포넌트

        //Start is called before the first frame update
         void Start()
         {
             bulletRigidbady = GetComponent<Rigidbody>();
             bulletRigidbady.velocity = transform.forward * speed;
             Destroy(gameObject, 3f);
         }
    

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
             Debug.Log("충돌시작");
             if (other.tag == "Player")
             {
                     PlayerController playerConteroller = other.GetComponent<PlayerController>();
             
                     //상대방으로부터 PlayerController 컴포넌트를 가져오는 데 성공했다면
                     if(playerConteroller != null )
                     {
                //상대방으로부터 PlayerController 컴포넌트의 Die() 메서드 실행
                         playerConteroller.Die();
                     }

            }
        }


    }

