using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    int ObstacleSize = 50;
    int ObstacleIndex;

    public Transform Target;
    public GameObject[] obstaclenum;
    public int FirstObstacleIndex;
    public int aheadObstacle;
    public List<GameObject> ObstacleList = new List<GameObject>();
    //private var rand = new Random();

    void Start()
    {
        ObstacleIndex = FirstObstacleIndex - 1;
        ObstacleManager(aheadObstacle);
    }

    void Update()
    {
        int targetPosIndex = (int) (Target.position.z / ObstacleSize);

        if (targetPosIndex + aheadObstacle > ObstacleIndex)
        {
            ObstacleManager(targetPosIndex + aheadObstacle);
        }
    }

    void ObstacleManager(int maps)
    {
        if (maps <= ObstacleIndex)
        {
            return;
        }

        for (int i = ObstacleIndex + 1; i <= maps; i++) //指定したステージまで作成する
        {
            GameObject Obstacle = MakeObstacle(i);
            ObstacleList.Add(Obstacle);
        }

        while (ObstacleList.Count > aheadObstacle + 1) //古いステージを削除する
        {
            DestroyObstacle();
        }

        ObstacleIndex = maps;
    }

    GameObject MakeObstacle(int index) //ステージを生成する
    {
        int nextObstacle = Random.Range(0, obstaclenum.Length);

        //double value = rand.NextDouble(minValue: -3, maxValue : 3);

        GameObject ObstacleObject = (GameObject) Instantiate(obstaclenum[nextObstacle], new Vector3(3, 0, index * ObstacleSize), Quaternion.identity);

        return ObstacleObject;
    }

    void DestroyObstacle()
    {
        GameObject oldObstacle = ObstacleList[0];
        ObstacleList.RemoveAt(0);
        Destroy(oldObstacle);
    }
}