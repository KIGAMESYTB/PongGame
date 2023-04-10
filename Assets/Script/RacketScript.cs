using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RacketScript : MonoBehaviour
{
    public Text Text;
    public float MoveY;

    BallMoveScript ballMoveScript;


    // Start is called before the first frame update
    void Start()
    {
        ballMoveScript = GameObject.FindGameObjectWithTag("ball").GetComponent<BallMoveScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.tag == "raquetRight")
        {
            PositionTouchRaquetChanged(KeyCode.UpArrow, KeyCode.DownArrow);
        }
        else if (gameObject.tag == "raquetLeft")
        {
            PositionTouchRaquetChanged(KeyCode.A, KeyCode.W);
        }
    }

    private void PositionTouchRaquetChanged(KeyCode keyCodeUp, KeyCode keyCodeDown)
    {
        if (Input.GetKeyDown(keyCodeUp))
            transform.position = new Vector3(transform.position.x, transform.position.y + MoveY, 0);

        if (Input.GetKeyDown(keyCodeDown))
            transform.position = new Vector3(transform.position.x, transform.position.y - MoveY, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ballMoveScript.AugmenteVitesse();
        ballMoveScript.ChangeValueX();
    }
}
