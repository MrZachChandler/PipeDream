using UnityEngine;
using System.Collections;

public class EnemyBackandForth : MonoBehaviour {

    public Transform[] keyPoints;
    public float speed;
    public float min_Distance;
    public float RotationSpeed;
    private int currentKeyPoint;

    private Quaternion _lookRotation;
    private Vector3 _direction;


    // Use this for initialization
    void Start()
    {
        transform.position = keyPoints[0].position;
        currentKeyPoint = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(transform.position, keyPoints[currentKeyPoint].position) <= min_Distance)
        {
            currentKeyPoint++;
        }

        if (currentKeyPoint >= keyPoints.Length)
        {
            currentKeyPoint = 0;
        }

        transform.position = Vector3.MoveTowards(transform.position, keyPoints[currentKeyPoint].position, speed * Time.deltaTime);

        _direction = (keyPoints[currentKeyPoint].position - transform.position).normalized;
        _lookRotation = Quaternion.LookRotation(_direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);

    }
}
