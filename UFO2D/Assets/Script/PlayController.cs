using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayController : MonoBehaviour
{
    [Header("水平方向")]
    public float moveX;

    [Header("垂直方向")]
    public float moveY;

    public float push;

    Rigidbody2D rb2D;

    [Header("分數文字UI")]
    public Text CountText;

    [Header("過關文字UI")]
    public Text winText;

    int score;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        winText.text = "";
        setScoreText();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveX = Input.GetAxis("Horizontal");

        moveY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveX, moveY);

        rb2D.AddForce(push * movement);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(name + "觸發了" + other.name);
        if (other.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            score = score + 1;
            setScoreText();
        }
    }

    void setScoreText()
    {
        CountText.text = "目標分數:" + score.ToString();

        if (score >= 12)
        {
            winText.text = "你贏了";
        }
    }
}
