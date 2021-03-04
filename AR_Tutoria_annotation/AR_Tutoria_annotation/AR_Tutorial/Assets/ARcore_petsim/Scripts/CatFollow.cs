using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFollow : MonoBehaviour
{
    public string gameObjectTag;
    private GameObject objectToFollow;
    public float Speed = 2f;
    public float StoppingDistance = 1.0f;
    private Animator CatAnimator;
    // Start is called before the first frame update
    void Start()
    {
        objectToFollow = GameObject.FindGameObjectWithTag(gameObjectTag);
        CatAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if(objectToFollow!=null)
        {
            var tempPos = objectToFollow.transform.position;
            tempPos.y = transform.position.y;

            if (Vector3.Distance(transform.position, tempPos) > StoppingDistance)
            {
                CatAnimator.SetBool("isRunning", true);
                tempPos.y = -0.8f;
                transform.position = Vector3.MoveTowards(transform.position, tempPos, Speed * Time.deltaTime);

                var lookPos = objectToFollow.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10f);
            }
            else
            {
                CatAnimator.SetBool("isRunning", false);

            }
        }
    }
}
