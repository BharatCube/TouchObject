using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DragAndDrop : TouchManager
{
    
//private variables
private Vector2 objectposition;
private Rigidbody2D movingbody;
//public variables
public bool movingObj = true;
//float bcolliderlen;
private int levelIndexNo;
private void Start()
{
    TouchManager.levelNo = int.Parse(SceneManager.GetActiveScene().name);
    levelIndexNo = int.Parse(SceneManager.GetActiveScene().name);
    objectposition = transform.position;
    movingbody = GetComponent<Rigidbody2D>();
    //if (levelIndexNo == 0)
    //{
    //    GameObject.Find("InstructionPlayHand").GetComponent<RawImage>().enabled = false;
    //    GameObject.Find("InstructionPlayHand").GetComponent<Animator>().enabled = false;
    //    GameObject.Find("InstructionPlayText").GetComponent<Text>().enabled = false;
    //    GameObject.Find("InstructionBPlayText").GetComponent<Image>().enabled = false;
    //}
}


void Update()
{
    if (movingObj)
    {
        TouchInput(GetComponent<Collider2D>(), levelIndexNo);
    }

    //if (movingbody.position.x > 8.32 || movingbody.position.x < -8.32f || movingbody.position.y < -5.32f || movingbody.position.y > 5.0f)
    //{
    //    transform.position = objectposition;
    //    Debug.Log("Object Moving out of the screen");
    //}


}

public void OnFirstTouch()
{
    Vector3 pos;
    //pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 100));
    pos = new Vector3(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).x,
     Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).y, transform.position.z);
    transform.position = pos;
}

//checks whether it's collided with object.
private void OnCollisionEnter2D(Collision2D collision)
{
   

    //if (collision.gameObject.name == "Player" && (GameManager.Instance.Paused == false))
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
   // _myanimator.SetBool("dizzy", false);
}

    //Vector2 dist;
    //float posX;
    //float posY;
    //Vector2 original;
    //private Rigidbody2D movingbody;
    //public bool movingObj = true;
    //private void Start()
    //{
    //    original = transform.position;
    //}
    //void Update()
    //{
    //    print(movingbody.position.x);
    //    print(movingbody.position.y);
    //    if (movingbody.position.x < -1.14 || movingbody.position.x > 1.14)
    //    {
    //        if (movingbody.position.y < 0.5)
    //        {
    //            transform.position = original;
    //        }
    //    }
    //    else
    //    {
    //        if (transform.position.y < -4)
    //        {
    //            transform.position = original;
    //        }
    //    }

    //}
    //private void OnMouseDown()
    //{               
    //        dist = Camera.main.WorldToScreenPoint(transform.position);
    //        posX = Input.mousePosition.x - dist.x;
    //        posY = Input.mousePosition.y - dist.y;       
    //}

    //private void OnMouseDrag()
    //{


    //        Vector2 curPos = new Vector2(Input.mousePosition.x - posX, Input.mousePosition.y - posY);
    //        Vector2 worldPos = Camera.main.ScreenToWorldPoint(curPos);
    //        transform.position = worldPos;

}









