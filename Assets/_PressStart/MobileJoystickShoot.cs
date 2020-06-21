using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MobileJoystickShoot : MonoBehaviour {
    public GameObject mainCamera; 
    public GameObject player; 
    public float playerSpeed = 15.0f; 
    public GameObject bulletPrefab;

    public Transform circle; //visual for joystick (inner circle)
    public Transform outerCircle; //container for joystick (outercircle)

    private Vector2 startingPoint;
    private int leftTouch = -1;

    void Start(){
        if (player == null){
            //error reporting
            player = gameObject;
        }
        if(mainCamera == null){
            mainCamera = Camera.main.gameObject;
        }
    }
    // Update is called once per frame
    void Update(){
        int i = 0;
        while (i < Input.touchCount){
            Touch t = Input.GetTouch(i);
            Vector2 touchPos = getTouchPosition(t.position);
            if (t.phase == TouchPhase.Began){
                if (t.position.x > Screen.width / 2){
                    shootBullet();
                }else{
                    leftTouch = t.fingerId;
                    startingPoint = touchPos;
                }
            }else if (t.phase == TouchPhase.Moved && leftTouch == t.fingerId){
                Vector2 offset = touchPos - startingPoint;
                Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);

                moveCharacter(direction);

                if(circle != null && outerCircle != null){
                    circle.transform.position = new Vector2(outerCircle.transform.position.x + direction.x, outerCircle.transform.position.y + direction.y);
                }

            }else if (t.phase == TouchPhase.Ended && leftTouch == t.fingerId){
                if (circle != null && outerCircle != null){
                    circle.transform.position = new Vector2(outerCircle.transform.position.x, outerCircle.transform.position.y);
                }
                leftTouch = -1;
            }
            ++i;
        }

    }
    Vector2 getTouchPosition(Vector2 touchPosition){
        return mainCamera.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, transform.position.z));
    }

    void moveCharacter(Vector2 direction){
        player.transform.Translate(direction * playerSpeed * Time.deltaTime);
    }
    void shootBullet(){
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = player.transform.position;
    }
}
