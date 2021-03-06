﻿using UnityEngine;

public class ObstacleController : MovementController
{
    public AudioSource die_sound;


    private SpriteRenderer sprite_renderer;
    private ObstacleData data;
    private Rigidbody2D rigid_body;

	private bool collider_set = false;

    protected new void Awake()
    {
        base.Awake();
        this.transform.parent = GameController.ObstacleMama.transform;

        this.data = new ObstacleData();
        Vector3 position = this.MainCamera.ViewportToWorldPoint(this.data.start_viewport);
        position.z = 0;
        this.name = ObstacleData.name;

        this.transform.position = position;
        this.sprite_renderer = GetComponent<SpriteRenderer>();
        this.sprite_renderer.sprite = Resources.Load<Sprite>("Sprites/Obstacle");

        this.transform.localEulerAngles = this.data.rotation;

        this.rigid_body = this.GetComponent<Rigidbody2D>();
        Vector2 force = this.transform.right * this.data.speed;
        this.rigid_body.AddForce(force);

        this.die_sound = GetComponent<AudioSource>();

    }

    // Use this for initialization
    protected new void Start()
    {
        base.Start();

    }

    // Update is called once per frame
    protected new void Update()
    {
        base.Update();
        this.data.last_move_time += Time.deltaTime;
		if (!this.collider_set) {
			//cirle inside box
			var collider = GetComponent<CircleCollider2D> ();
			collider.radius = this.sprite_renderer.sprite.bounds.size.x / 2.0f;
			this.collider_set = true;
		}
    }

    public void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        this.takeDamage();
    }

    void takeDamage(int amount = 1)
    {
        this.data.health -= amount;
        if (this.data.health <= 0)
        {
            if (this.die_sound != null) this.die_sound.Play();
            this.destroy();
        }
    }

	public override void onResolutionChanged()
	{
        this.collider_set = false;
	}

}