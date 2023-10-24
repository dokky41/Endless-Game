using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] Animator playerAnimator;
    [SerializeField] Animator cameraAnimator;
    
    void Start()
    {
        GameOver();
    }

    public void GameOver()
    {
        Time.timeScale = 0.0f;
    }

    public IEnumerator StartRoutine()
    {
        cameraAnimator.enabled = true;
        playerAnimator.SetTrigger("Start");

        // �ڷ�ƾ�� �ð��� ������ �ֱ� ������
        // ���� Time.Scale�� 0�̹Ƿ�, WaitForSecondsRealtime�� ����
        yield return new WaitForSecondsRealtime(3f);

        playerAnimator.SetLayerWeight(1, 0);
        Time.timeScale = 1.0f;
    }


}
