using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
     
        public float speed = 8f;  //ź���� �̵��� �Ӥ��Ť�
        private Rigidbody bulletRigidbady; // �̵��� ����� ������ٵ� ������Ʈ

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
             Debug.Log("�浹����");
             if (other.tag == "Player")
             {
                     PlayerController playerConteroller = other.GetComponent<PlayerController>();
             
                     //�������κ��� PlayerController ������Ʈ�� �������� �� �����ߴٸ�
                     if(playerConteroller != null )
                     {
                //�������κ��� PlayerController ������Ʈ�� Die() �޼��� ����
                         playerConteroller.Die();
                     }

            }
        }


    }

