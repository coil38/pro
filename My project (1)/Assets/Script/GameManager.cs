using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;        //UI ���� ���̺귯��
using UnityEngine.SceneManagement;      // �� ���� ���̺귯��

public class GameManager : MonoBehaviour  
{
    public GameObject gameoverText;     //���ӿ��� �� Ȱ��ȭ�� �ؽ�Ʈ ���� ������Ʈ
    public Text timeText;               //���� �ð��� ǥ���� �ؽ�Ʈ ������Ʈ
    public Text recordText;             //�ְ����� ǥ���� �ؽ�Ʈ ������Ʈ

    private float survivetime;      //�����ð�
    private bool isGameover;        //���ӿ���

    AudioSource audiogameover;

    // Start is called before the first frame update
    void Start()
    {
        // ���� �ð��� ���ӿ��� ���� �ʱ�ȭ
        survivetime = 0;
        isGameover = false;

        audiogameover = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameover)
        {
            //���� �ð� ����
            survivetime += Time.deltaTime;
            //������ ���� �ð��� TimeText �ؽ�Ʈ ���ʳ�Ʈ�� �̿��� ǥ��
            timeText.text = "Time: " + (int)survivetime;
        }
        else
        {
            //���ӿ����� ���¿��� R Ű�� ���� ���
            if (Input.GetKeyDown(KeyCode.R))
            {
                //SampleScene ���� �ε�
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
    //���� ������ ���ӿ��� ���·� �����ϴ� �޼���
    public void EndGame()
    {
        //���� ���¸� ���ӿ��� ���·� ��ȯ
        isGameover = true;
        //���ӿ��� �ؽ�Ʈ ���� ������Ʈ�� Ȱ��ȭ
        gameoverText.SetActive(true);

        //BestTime Ű�� ��Ϻ��� ���� ���� �ð��� �� ũ�ٸ�
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        //�̹������� �ְ� ��Ϻ��� ���� ���� �ð��� �� ũ�ٸ�
        if (survivetime > bestTime)
        {
            //�ְ� ��� ���� ���� ���� �ð� ������ ����
            bestTime = survivetime;
            //����� �ְ� ����� BestTime Ű�� ����
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        //�ְ� ����� recordText �ؽ�Ʈ ������Ʈ�� �̿��� ǥ��
        recordText.text = "Best Time: " + (int)bestTime;
        audiogameover.Play();
    }
}
