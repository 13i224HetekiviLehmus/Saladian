﻿using System.Collections;
using UnityEngine;

public class ObstacleData {
    public Vector2 start_position;
    public int direction;
    public int speed;
    public const float SPEED_MIN = 50;
    public const float SPEED_MAX = 10000;
    public const float DISTANCE = 0.1f;
    public float last_move_time = 0;
    public const float OUTSIDE_BUFFER = 0.2f;
    public Vector3 rotation;
    public int health = 1;
    public const string name = "Obstacle";
    public Vector3 start_viewport;

    public ObstacleData()
    {
        this.init();
    }

    private void init()
    {
        int axis = Random.Range(0, 2);
        int side = Random.Range(0, 2);
        float place = Random.Range(0f, 1f);
        int direction_min = 0;
        int direction_max = 361;
        if (axis == 0)
        {
            direction_min = 0;
            direction_max = 181;
        }
        else
        {
            direction_min = 90;
            direction_max = 271;
        }
        if (side + axis == 1)
        {
            direction_min += 180;
            direction_max += 180;
        }
        this.direction = Random.Range(direction_min, direction_max);
        this.rotation = new Vector3(0, 0, this.direction);

        float x = (axis == 1) ? (float)side : place;
        float y = (axis == 0) ? (float)side : place;
        this.start_viewport = new Vector3(x, y, 0f);

        this.speed = (int)Random.Range(ObstacleData.SPEED_MIN, ObstacleData.SPEED_MAX);
    }
}
