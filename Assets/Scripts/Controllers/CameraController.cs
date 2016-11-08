﻿using UnityEngine;

public class CameraController : Controller
{
	public static float pixels_to_units = 1f;
	public static float scale = 1;

	public Vector2 native_resolution = new Vector2(240,160);
	public Camera main_camera;
	public CameraData data;

	public CameraResolution resolution;

	protected new void Awake()
	{
		base.Awake();
		this.data = new CameraData();
		this.name = CameraData.name;
		this.main_camera = this.GetComponent<Camera>();
		this.init();
        if (this.main_camera.orthographic)
        {
            scale = Screen.height / native_resolution.y;
            pixels_to_units *= scale;
            this.main_camera.orthographicSize = (Screen.height / 2.0f) / pixels_to_units;
        }
    }

	// Use this for initialization
	protected new void Start() {
		base.Start();
	}

	// Update is called once per frame
	protected new void Update()
	{
		base.Update();
		this.update_camera_size();

	}

	private void init()
	{
		this.tag = "MainCamera";
		this.transform.position = new Vector3(0, 0, -10);
		this.main_camera.orthographic = true;
		this.main_camera.depth = -1;
		//this.main_camera.orthographicSize = 5;
		//this.update_camera_size();
	}

	public void update_camera_size()
	{
      
        //Debug.Log(this.main_camera.orthographicSize.ToString());
        //Debug.Log(scale.ToString());
        //Debug.Log(pixels_to_units.ToString());
        //this.resolution = new CameraResolution(this.main_camera);
	}
}
