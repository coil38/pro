using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    public GameObject bulletPrefeb;     //생성할 탄얄의 원본 프리팹
    public float spawnRateMin = 0.5f;       //최소 생성 주기
    public float spawnRateMax = 3f;         //최재 생성주기

    private Transform target;               //발사할 대상
    private float spawnRate;               //생성 주기
    private float timeAfterSpawn;          // 최근 생성 시점에서 지난 시간

    public AudioSource audioPlayer;

    // Start is called before the first frame update
    void Start()
    {
        //최근 생성 이후의 누적 시간을 0으로 초기화
        timeAfterSpawn = 0f;
        //탄알 생성 간격을 spawnRateMin과 spawnRateMax 사이에서 램덤 지정
        spawnRate = Random.Range(spawnRateMin, spawnRateMax); 
        //PlayerController 컴포넌트를 가진 게임 오브젝트를 찾아 조준 대상으로 설정
        target = FindObjectOfType<PlayerController>().transform;
        audioPlayer = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //타임에 프터스퐌 시간 갱신 (Update 때마다 흘러간 시간을 누적 합산
        timeAfterSpawn += Time.deltaTime;
        //TimeAfterSpawn = timeAfterSpawn + Time.deltaTime;
        //(램덤 값으로 결정된) 탄환 생성주기 보다 마지막 생성 이후 흐른 시간이 커지면 아래 if 실행
        if (timeAfterSpawn > spawnRate)
        {
            //마지막 탄환 발사 이후 시간을 0으로 돌리고
            timeAfterSpawn = 0;

            //탄환을 생성함 하고, 캐릭터 (target)을 바라보도록 방향 전환
            GameObject Bullet = Instantiate(bulletPrefeb, transform.position, transform.rotation);
            Bullet.transform.LookAt(target);

            //다음 탄환 생성 주기 값 (spawnRate를 최소 (0.5초) 최대(3.0초) 범위에서 랜덤 갖ㅅ으로 결정작업 진행
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
            audioPlayer.Play();
        }
    }
}
