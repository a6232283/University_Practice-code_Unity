using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMoveTo : MonoBehaviour
{
    public Transform startMaker;
    public Vector3 endMaker;
    private float speed = 0.1f;
    private float startTime;
    private float journeyLength;
    private Animator catAnim;
    // Start is called before the first frame update
    void Start()
    {
        journeyLength = 0;
        catAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (journeyLength > 0)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startMaker.position, endMaker, fracJourney);

            if (fracJourney < 0.1)
            {
                var lookPos = endMaker - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10f);
            }
        }

        if(Vector3.Distance(startMaker.position, endMaker)<0.1)
        {
            catAnim.SetBool("isRunning", false);

        }
    }


    public void StartMove(Vector3 endPos)
    {
        catAnim.SetBool("isRunning",true);
        startMaker = this.transform;
        endMaker = endPos;
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMaker.position, endMaker);
        Debug.Log("journeyLength is" + journeyLength);

    }
}
