using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{

    [SerializeField] GameObject layoutPanel;

    [SerializeField] Animator textAnimator;
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

  
    public IEnumerator StartRoutine(int count)
    {
        cameraAnimator.enabled = true;
        playerAnimator.SetTrigger("Start");
    
        // �ڷ�ƾ�� �ð��� ������ �ֱ� ������
        // ���� Time.Scale�� 0�̹Ƿ�, WaitForSecondsRealtime�� ����
        
        while(count > 0)
        {
            textAnimator.GetComponent<TextMeshProUGUI>().text = count.ToString();
            textAnimator.Play("Count Down");
            yield return new WaitForSecondsRealtime(1f);
            count--;
        }
    
        layoutPanel.SetActive(false);
        textAnimator.gameObject.SetActive(false);

        playerAnimator.SetLayerWeight(1, 0);
        Time.timeScale = 1.0f;
    }


}
