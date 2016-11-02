﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipController : MovementController
{
    public SpriteRenderer sprite_renderer;
    private GameObject parent;
    public ShipData data;

    protected new void Awake()
    {
        base.Awake();
        this.data = new ShipData();
        this.name = ShipData.name;
        //this.sprite_renderer.sprite = Resources.Load<Sprite>("Sprites/Ship");
    }

    // Use this for initialization
    public new void Start () {
        base.Start();
        parent = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    protected new void Update()
    {
        base.Update();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == ObstacleData.name)
        {
            this.takeDamage();
        }
    }

    void takeDamage(int amount = 1)
    {
        this.data.health -= amount;
        if(this.data.health <= 0)
        {
            this.destroy();
           
        }
    }

    void OnDestroy()
    {
        if (this.parent.name == PlayerData.name)
        {
            this.parent.GetComponent<PlayerController>().shipDestroyed();
        }
    }

    public void shoot()
    {
        GameObject prefab = (GameObject)Resources.Load("Prefabs/Shot", typeof(GameObject));
        GameObject shot = Instantiate(prefab);
        ShotController controller = shot.GetComponent<ShotController>();
        Vector2 location = new Vector2(this.transform.position.x, this.transform.position.y + 1);
        controller.shoot(location);        
    }



}
