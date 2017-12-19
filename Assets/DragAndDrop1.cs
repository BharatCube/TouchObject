using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DragAndDrop1 : TouchManager {

    //Public Variable
    public bool movingObj = true;
   // public Animator _myanimator;
    public float objectPositionaPit;
    public float objectPositionaPitStone;
    //Private variable
    public Rigidbody2D movingbody;
    private int levelIndexNo;
    private Vector2 objectposition;
    private void Awake()
    {
       // TouchManager.levelNo = int.Parse(SceneManager.GetActiveScene().name);
    }
    private void Start()
    {
        
        movingbody.mass = 0.0001f;
         levelIndexNo = int.Parse(SceneManager.GetActiveScene().name);       
        objectposition = transform.position;
        movingbody = GetComponent<Rigidbody2D>();

        //if (levelIndexNo == 0)
        //{
        //    GameObject.Find("InstructionPlayHand").GetComponent<RawImage>().enabled = false;
        //    GameObject.Find("InstructionPlayHand").GetComponent<Animator>().enabled = false;
        //    GameObject.Find("InstructionPlayText").GetComponent<Text>().enabled = false;
        //}
  

        if (levelIndexNo == 3 || levelIndexNo == 4)
        {
            //GameObject.Find("InstructionHandL3").GetComponent<Image>().enabled = false;
           // GameObject.Find("InstructionHandL3").GetComponent<Animator>().enabled = false;
            GameObject.Find("InstructionTextL3").GetComponent<Text>().enabled = false;
            GameObject.Find("InstructionBTextL3").GetComponent<Image>().enabled = false;
        }
    }

    void Update()
    {
        if (movingObj)
        {
            TouchInput(GetComponent<Collider2D>(),levelIndexNo);
        }

        if (movingbody.position.x > 8.32 || movingbody.position.x < -8.32f || movingbody.position.y < -5.32f || movingbody.position.y > 5.0f)
        {
            transform.position = objectposition;
        }

        if (transform.localEulerAngles.z == 90 || transform.localEulerAngles.z == 270)
        {
            if (movingbody.position.y < objectPositionaPitStone)
            {
                movingbody.mass = 10.0f;
            }
            else
            {
                movingbody.mass = 0.0001f;
            }

        }
        else
        {
            if (movingbody.position.y < objectPositionaPit)
            {
                movingbody.mass = 50.0f;
            }
            else
            {
                movingbody.mass = 0.0001f;
            }

        }
    }
    public void OnFirstTouch()
    {
        Vector3 pos;
        // pos = Camera.main.ScreenToWorldPoint( new Vector3(Input.GetTouch(0).position.x,Input.GetTouch(0).position.y,100));
        pos = new Vector3(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).x,
         Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).y, transform.position.z);
        transform.position = pos;

    }

    //checks whether it's collided with object.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.relativeVelocity.y > 0.5f)
        {
            if (collision.gameObject.name == "BottomGround")
            {
                return;
            }
            else if (!(collision.gameObject.name == "Stone"))
            {
                if (levelIndexNo == 3 || levelIndexNo == 4)
                {
                    StartCoroutine("handletoneMovement");
                }
                StartCoroutine("detectStoneCollision");                                              
            }
        }


        //if (collision.gameObject.name == "Player" && (GameManager.Instance.Paused == false) )
        //{        
        //    _myanimator.SetBool("dizzy", true);
        //    StartCoroutine(dizzywait());
        //    transform.position = objectposition;
        //}
        //else if (!GameManager.Instance.Paused)
        //{
        //    _myanimator.SetBool("dizzy", false);
        //}

    }
    IEnumerator dizzywait()
    {
        yield return new WaitForSeconds(0.2f);
        //_myanimator.SetBool("dizzy", false);
    }

    IEnumerator detectStoneCollision()
    {
        if (transform.localEulerAngles.z == 90 || transform.localEulerAngles.z == 270)
        {
            if (movingbody.position.y < objectPositionaPitStone)
            {
                if (levelIndexNo == 3)
                {
                    Handheld.Vibrate();
                    transform.position = objectposition;
                    yield return new WaitForSeconds(0.3f);         
                    movingbody.mass = 0.0001f;
                }
                else
                {
                  
                    Handheld.Vibrate();                   
                    transform.position = objectposition;
                    yield return new WaitForSeconds(0.3f);
                   // Player.Instance.health.CurrentVal -= 50;
                    movingbody.mass = 0.0001f;
                }
            }
            //else
            // {
                //transform.position = objectposition;
            //    print(movingbody.position.y + "outside 90");
            //}
        }
        else
        {
            if (movingbody.position.y < objectPositionaPit)
            {
                
                if (levelIndexNo == 3)
                {
                    Handheld.Vibrate();
                    transform.position = objectposition;
                    yield return new WaitForSeconds(0.3f);                   
                    movingbody.mass = 0.0001f;
                }
                else
                {
                    Handheld.Vibrate();
                    transform.position = objectposition;
                    yield return new WaitForSeconds(0.3f);
                    //Player.Instance.health.CurrentVal -= 50;
                    movingbody.mass = 0.0001f;
                }
            }
           // else
            //{
            //   //transform.position = objectposition;
            //  print(movingbody.position.y + "remainijng outside 90");
            //}
        }        
        
    }
    IEnumerator handletoneMovement()
    {
        //GameObject.Find("InstructionHandL3").GetComponent<Image>().enabled = true;
      //  GameObject.Find("InstructionHandL3").GetComponent<Animator>().enabled = true;
        GameObject.Find("InstructionTextL3").GetComponent<Text>().enabled = true;
        GameObject.Find("InstructionBTextL3").GetComponent<Image>().enabled = true;
        yield return new WaitForSeconds(3.0f);
         //   GameObject.Find("InstructionHandL3").GetComponent<Image>().enabled = false;
           // GameObject.Find("InstructionHandL3").GetComponent<Animator>().enabled = false;
            GameObject.Find("InstructionTextL3").GetComponent<Text>().enabled = false;
            GameObject.Find("InstructionBTextL3").GetComponent<Image>().enabled = false;
           
    }

}
