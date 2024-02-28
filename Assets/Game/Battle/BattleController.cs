using System;
using UnityEngine;
using Utils;
using Random = UnityEngine.Random;

public class BattleController : MonoBehaviour
{
    private PriorityQueue<string, int> _unitsOrder;

    private void Awake()
    {
        _unitsOrder = new PriorityQueue<string, int>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            print(_unitsOrder.Dequeue());
        if (Input.GetKeyDown(KeyCode.A))
        {
            int rand =Random.Range(0, 10);
            print(rand);
            _unitsOrder.Enqueue($"{rand}+sss",rand);
        }
    }
}