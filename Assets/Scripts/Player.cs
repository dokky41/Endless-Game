using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public enum RoadLine
{
    LEFT = -1,
    MIDDLE = 0,
    RIGHT = 1
}

public class Player : MonoBehaviour
{
    [SerializeField] CharacterController characterController;
    [SerializeField] Vector3 direction;

    [SerializeField] Animator animator;
    [SerializeField] RoadLine roadLine;
    [SerializeField] float jumpPower = 500f;
    [SerializeField] float positionX = 3.5f;

    [SerializeField] UnityEvent playerEvent;
    [SerializeField] ObjectSound objectSound = new ObjectSound();



    void Start()
    {
        direction = transform.position;

        roadLine = RoadLine.MIDDLE;

    }

   
    void Update()
    {
        // ĳ���� �̵� �Լ�
        Move();

        // ĳ���� ���� �Լ�
        Jump();

        // ĳ���� �̵� ����
        Status();

    }

    public void Move()
    {
       
        // ���� ����Ű�� ������ ��
        if(Input.GetKeyDown (KeyCode.LeftArrow))
        {
            AudioManager.instance.Sound(objectSound.audioClip[0]);


            if(roadLine == RoadLine.LEFT)
            {
                roadLine = RoadLine.LEFT;
            }
            else
            {
                roadLine--;
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)) // ������
        {
            AudioManager.instance.Sound(objectSound.audioClip[0]);

            if (roadLine == RoadLine.RIGHT)
            {
                roadLine = RoadLine.RIGHT;
            }
            else
            {
                roadLine++;
            }
        }


        


    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if(transform.position.y <= 0.01f)
            {
                direction.y = 100;
                transform.position = new Vector3(transform.position.x,direction.y,0);
            }

            direction.y -= 50f * Time.deltaTime;

            transform.position = direction;
           
        }
    }

    public void Status()
    {
        switch(roadLine)
        {
            case RoadLine.LEFT:
                transform.position = new Vector3(-positionX, transform.position.y, 0);
                break;

            case RoadLine.MIDDLE:
                transform.position = new Vector3(0, transform.position.y, 0);
                break;

            case RoadLine.RIGHT:
                transform.position = new Vector3(positionX, transform.position.y, 0);
                break;
        }
    }

    public void OnDie()
    {
        playerEvent.Invoke();

        animator.Play("Die");

    }

    public void OnGameOverUI()
    {
        GameManager.instance.GameOverPanel();
    }


    private void OnTriggerEnter(Collider other)
    {
        IItem item = other.GetComponent<IItem>();

        if(item != null)
        {
            item.Use();
            other.GetComponent<MeshRenderer>().enabled = false;
            //other.gameObject.SetActive(false);
        }    
        
        if(other.CompareTag("Obstacle"))
        {
            OnDie();

        }

    }




}
