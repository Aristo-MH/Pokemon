using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementMonster : MonoBehaviour
{
    public float speed;

    public Rigidbody2D rb;

    private Vector2 movement;

    public bool kejar;

    public GameObject player;

    public MonsterData monsterData;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        kejar = false;
        player = GameObject.FindWithTag("Player");
        monsterData = GetComponent<MonsterData>();
    }

    // Update is called once per frame
    void Update()
    {
        if(kejar == false)
        {
            float horizontal = Random.Range(-1.5f, 1.5f);
            float vertical = Random.Range(-1.5f, 1.5f);
            movement = new Vector2(horizontal, vertical);
        }
        else
        {
            float step = speed * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step);
        }
    }

    void FixedUpdate()
    {
        if(kejar == false)
        {
            rb.velocity = movement * speed;
        }
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Bulbasaur");
            PlayerPrefs.SetInt("HP", monsterData.HP);
            PlayerPrefs.SetInt("attackPower", monsterData.attackPower);
            PlayerPrefs.SetString("name", monsterData.name);
            PlayerPrefs.Save();
            SceneLoader.Instance.LoadScene("BattleScene");
        }
    }
}