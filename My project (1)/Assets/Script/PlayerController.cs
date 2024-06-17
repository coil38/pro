using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidBody;       // �÷��̾� ������Ʈ�� �ִ� RigidBody ������Ʈ�� �����ϱ� ���� ����
    public float speed = 8f;        //�̵� �ӵ� ��ġ ���� �����ϴ� ����
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
        // ������� ��Ģ���� �Է°��� �����Ͽ� ����
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // ���� �̵� �ӵ��� �Կ����� �̵� �ӷ��� ����� ����
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        // Vecter3 �ӵ��� (xSpeed, 0,zspeed)�� ����
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed); 
        //������ٵ��� �ӵ��� newVelocity�Ҵ�
        playerRigidBody.velocity = newVelocity;
    }


    public void Die()       //�÷��̾� ĳ���Ͱ� ����� ȣ��ǰ� �̺κ� ������ ó����
    {
        //�ڽ��� ���� ������Ʈ�� ��Ȱ��ȭ
        gameObject.SetActive(false);

        //���� �����ϴ� GameManager Ÿ���� ������Ʈ�� ã�Ƽ� ��������
        GameManager gameManager = FindObjectOfType<GameManager>();
        //������ GameManager ������Ʈ�� EndGame() �޼��� ����
        gameManager.EndGame();
    }
}
