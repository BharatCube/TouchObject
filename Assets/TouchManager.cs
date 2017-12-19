using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class TouchManager : MonoBehaviour {

    public static bool guiTouch = false;
    private int tapCount;
    private float doubleTapTimer;
    public static int levelNo { get; set; }

    private float LastTap;
    private  float tapTime = 0.5f;
    private void Start()
    {

        //if (levelNo == 0)
        //{
        //    StartCoroutine(InitialhandMRemove());

        //    GameObject.Find("InstructionMHand").GetComponent<Animator>().enabled = false;
        //    GameObject.Find("InstructionMBText").GetComponent<Image>().enabled = false;
        //    GameObject.Find("InstructionMHand").GetComponent<Image>().enabled = false;
        //    GameObject.Find("InstructionMText").GetComponent<Text>().enabled = false;

        //}
    }
    
    
    public void TouchInput(Collider2D collider, int levelno)
    {
        if (Input.touchCount > 0)
        {           
            if ( collider == Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
            
            {
                
                switch (Input.GetTouch(0).phase)
                {
                    case TouchPhase.Began:
                        SendMessage("OnFirstTouchBegan", SendMessageOptions.DontRequireReceiver);
                        SendMessage("OnFirstTouch", SendMessageOptions.DontRequireReceiver);
                        if (levelno == 0)
                        {                           
                          // StartCoroutine("handMRemove");
                        }

                        if (!guiTouch)
                        {
                            guiTouch = true;
                            SingleTap();
                        }
                        if ((Time.time - LastTap) < tapTime)
                        {
                            if (collider.CompareTag("SemiRotate"))
                            {
                                transform.Rotate(new Vector3(0, 0, -180)); // Double click for 180'                              
                                guiTouch = false;
                            }
                            else
                            {
                                transform.Rotate(new Vector3(0, 0, -90)); // Double click for 90'                                
                                guiTouch = false;
                            }
                            
                        }
                        LastTap = Time.time;
                        break;
                    case TouchPhase.Stationary:
                        SendMessage("OnFirstTouchStationary", SendMessageOptions.DontRequireReceiver);
                        SendMessage("OnFirstTouch", SendMessageOptions.DontRequireReceiver);
                        guiTouch = true;
                      
                        break;
                    case TouchPhase.Moved:

                        SendMessage("OnFirstTouchMoved", SendMessageOptions.DontRequireReceiver);
                        SendMessage("OnFirstTouch", SendMessageOptions.DontRequireReceiver);
                        guiTouch = true;
                       
                        break;
                    case TouchPhase.Ended:
                        SendMessage("OnFirstTouchEnded", SendMessageOptions.DontRequireReceiver);
                        SendMessage("OnFirstTouch", SendMessageOptions.DontRequireReceiver);
                        guiTouch = false;
                       

                        break;

                }
            }
        }

        if (Input.touchCount > 1)
        {
            
            if (collider == Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.GetTouch(1).position)))
            {
                switch (Input.GetTouch(1).phase)
                {
                    case TouchPhase.Began:
                        SendMessage("OnFirstTouchBegan", SendMessageOptions.DontRequireReceiver);
                        SendMessage("OnFirstTouch", SendMessageOptions.DontRequireReceiver);
                        break;
                    case TouchPhase.Stationary:
                        SendMessage("OnFirstTouchStationary", SendMessageOptions.DontRequireReceiver);
                        SendMessage("OnFirstTouch", SendMessageOptions.DontRequireReceiver);

                        break;
                    case TouchPhase.Moved:
                        SendMessage("OnFirstTouchMoved", SendMessageOptions.DontRequireReceiver);
                        SendMessage("OnFirstTouch", SendMessageOptions.DontRequireReceiver);

                        break;
                    case TouchPhase.Ended:
                        SendMessage("OnFirstTouchEnded", SendMessageOptions.DontRequireReceiver);
                        SendMessage("OnFirstTouch", SendMessageOptions.DontRequireReceiver);
                        break;

                }
            }
        }

    }

    IEnumerator handMRemove()
    {
        GameObject.Find("InstructionMHand").GetComponent<Animator>().enabled = true;
        GameObject.Find("InstructionMBText").GetComponent<Image>().enabled = true;
        GameObject.Find("InstructionMHand").GetComponent<Image>().enabled = true;
        GameObject.Find("InstructionMText").GetComponent<Text>().enabled = true;
        yield return new WaitForSeconds(3.0f);
        GameObject.Find("InstructionMHand").GetComponent<Animator>().enabled = false;
        GameObject.Find("InstructionMHand").GetComponent<Image>().enabled = false;
        GameObject.Find("InstructionMText").GetComponent<Text>().enabled = false;
        GameObject.Find("InstructionMBText").GetComponent<Image>().enabled = false;
    }

    IEnumerator InitialhandMRemove()
    {
        GameObject.Find("InstructionBText").GetComponent<Image>().enabled = true;
        GameObject.Find("InstructionHand").GetComponent<RawImage>().enabled = true;
        GameObject.Find("InstructionHand").GetComponent<Animator>().enabled = true;
        GameObject.Find("InstructionText").GetComponent<Text>().enabled = true;
        yield return new WaitForSeconds(5.0f);
        GameObject.Find("InstructionBText").GetComponent<Image>().enabled = false;
        GameObject.Find("InstructionHand").GetComponent<RawImage>().enabled = false;
        GameObject.Find("InstructionHand").GetComponent<Animator>().enabled = false;
        GameObject.Find("InstructionText").GetComponent<Text>().enabled = false;

    }
    IEnumerator SingleTap()
    {
        yield return new  WaitForSeconds(tapTime);
        if (guiTouch)
        {
           // Debug.Log("SingleTap");
            guiTouch = false;
        }
    }
}

