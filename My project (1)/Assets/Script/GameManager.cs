using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;        //UI 관련 라이브러리
using UnityEngine.SceneManagement;      // 씬 관리 라이브러리

public class GameManager : MonoBehaviour  
{
    public GameObject gameoverText;     //게임오버 시 활성화할 텍스트 게임 오브젝트
    public Text timeText;               //생존 시간을 표시할 텍스트 컴포넌트
    public Text recordText;             //최고기록을 표시할 텍스트 컴포넌트

    private float survivetime;      //생존시간
    private bool isGameover;        //게임오버

    AudioSource audiogameover;

    // Start is called before the first frame update
    void Start()
    {
        // 생존 시간과 게임오버 상태 초기화
        survivetime = 0;
        isGameover = false;

        audiogameover = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameover)
        {
            //생존 시간 갱신
            survivetime += Time.deltaTime;
            //갱신한 생존 시간을 TimeText 텍스트 컴초넌트를 이용해 표시
            timeText.text = "Time: " + (int)survivetime;
        }
        else
        {
            //게임오버인 상태에서 R 키를 누른 경우
            if (Input.GetKeyDown(KeyCode.R))
            {
                //SampleScene 씬을 로드
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
    //현재 게임을 게임오버 상태로 변경하는 메서드
    public void EndGame()
    {
        //현재 상태를 게임오버 상태로 전환
        isGameover = true;
        //게임오버 텍스트 게임 오브젝트를 활성화
        gameoverText.SetActive(true);

        //BestTime 키로 기록보다 현재 생존 시간이 더 크다면
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        //이번까지의 최고 기록보다 현재 생존 시간이 더 크다면
        if (survivetime > bestTime)
        {
            //최고 기록 값을 현재 생존 시간 값으로 변경
            bestTime = survivetime;
            //변경된 최고 기록을 BestTime 키로 저장
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        //최고 기록을 recordText 텍스트 컴포넌트를 이용해 표시
        recordText.text = "Best Time: " + (int)bestTime;
        audiogameover.Play();
    }
}
