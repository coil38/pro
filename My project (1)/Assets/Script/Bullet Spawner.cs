using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    public GameObject bulletPrefeb;     //������ ź���� ���� ������
    public float spawnRateMin = 0.5f;       //�ּ� ���� �ֱ�
    public float spawnRateMax = 3f;         //���� �����ֱ�

    private Transform target;               //�߻��� ���
    private float spawnRate;               //���� �ֱ�
    private float timeAfterSpawn;          // �ֱ� ���� �������� ���� �ð�

    public AudioSource audioPlayer;

    // Start is called before the first frame update
    void Start()
    {
        //�ֱ� ���� ������ ���� �ð��� 0���� �ʱ�ȭ
        timeAfterSpawn = 0f;
        //ź�� ���� ������ spawnRateMin�� spawnRateMax ���̿��� ���� ����
        spawnRate = Random.Range(spawnRateMin, spawnRateMax); 
        //PlayerController ������Ʈ�� ���� ���� ������Ʈ�� ã�� ���� ������� ����
        target = FindObjectOfType<PlayerController>().transform;
        audioPlayer = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //Ÿ�ӿ� ���ͽ��p �ð� ���� (Update ������ �귯�� �ð��� ���� �ջ�
        timeAfterSpawn += Time.deltaTime;
        //TimeAfterSpawn = timeAfterSpawn + Time.deltaTime;
        //(���� ������ ������) źȯ �����ֱ� ���� ������ ���� ���� �帥 �ð��� Ŀ���� �Ʒ� if ����
        if (timeAfterSpawn > spawnRate)
        {
            //������ źȯ �߻� ���� �ð��� 0���� ������
            timeAfterSpawn = 0;

            //źȯ�� ������ �ϰ�, ĳ���� (target)�� �ٶ󺸵��� ���� ��ȯ
            GameObject Bullet = Instantiate(bulletPrefeb, transform.position, transform.rotation);
            Bullet.transform.LookAt(target);

            //���� źȯ ���� �ֱ� �� (spawnRate�� �ּ� (0.5��) �ִ�(3.0��) �������� ���� �������� �����۾� ����
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
            audioPlayer.Play();
        }
    }
}
