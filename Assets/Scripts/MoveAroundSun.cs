using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAroundSun : MonoBehaviour
{
    static GameObject Sun;
    public float velocity;
    static float radius;
    private LineRenderer LineDrawer;
    static float DistanceToSun;
    public float widthLine = 0.01f;
    // Start is called before the first frame update

    // prueba de escalamiento
    float _currentScale;
    float TargetScale;
    float InitScale;
    const int FramesCount = 30;
    public float AnimationTimeSeconds;
    public float scaleLung;
    float _deltaTime;
    float _dx;
    bool _upScale = true;
    public bool breathing;
    public bool breathingInCycle;
    public bool startBreathing;

    void Start()
    {
        startBreathing = false;
        breathingInCycle = false;
        Sun = GameObject.Find("Sun");
        DistanceToSun = Vector3.Distance(Sun.transform.position, transform.position);
        radius = DistanceToSun;
        LineDrawer = GetComponent<LineRenderer>();
        DrawMoveOrbit();
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.up, velocity * Time.deltaTime);
        if (breathing)
        {
            LineDrawer.startColor = Color.green;
            LineDrawer.endColor = Color.green;

            if (breathing && !breathingInCycle && !startBreathing)
            {
                /*breathingInCycle = true;
                startBreathing = true;
                InitScale = transform.localScale.x;
                TargetScale = InitScale * scaleLung;
                _currentScale = InitScale;
                _deltaTime = AnimationTimeSeconds / FramesCount;
                _dx = (TargetScale - InitScale) / FramesCount;
                Debug.Log(_deltaTime);*/
                StartCoroutine(Breath());
            }
        }
        else
        {
            LineDrawer.startColor = Color.white;
            LineDrawer.endColor = Color.white;
        }

        //DrawMoveOrbit();
    }

    void DrawMoveOrbit()
    {
        var segments = 360;
        LineDrawer.startWidth = widthLine;
        LineDrawer.endWidth = widthLine;
        LineDrawer.positionCount = segments + 1;
        LineDrawer.startColor = Color.white;
        LineDrawer.endColor = Color.white;

        var pointCount = segments + 1;
        var points = new Vector3[pointCount];
        float inputXCyrclef = 0.0f;
        float inputYCyrclef = 0.0f;

        for (int i = 0; i < pointCount; i++)
        {
            var rad = Mathf.Deg2Rad * (i * 360f / segments);
            points[i] = new Vector3(Mathf.Sin(rad) * radius + inputXCyrclef, 0, Mathf.Cos(rad) * radius + inputYCyrclef);

            LineDrawer.SetPositions(points);
        }
    }

    private IEnumerator Breath()
    {

        breathingInCycle = true;
        startBreathing = true;
        InitScale = transform.localScale.x;
        TargetScale = InitScale * scaleLung;
        _currentScale = InitScale;
        _deltaTime = AnimationTimeSeconds / FramesCount;
        _dx = (TargetScale - InitScale) / FramesCount;
        while (breathingInCycle)
        {
            while (_upScale && breathingInCycle)
            {
                _currentScale += _dx;
                if (_currentScale > TargetScale)
                {
                    _upScale = false;
                    _currentScale = TargetScale;
                }
                transform.localScale = Vector3.one * _currentScale;
                yield return new WaitForSeconds(_deltaTime);
            }

            while (!_upScale && breathingInCycle)
            {
                _currentScale -= _dx;
                if (_currentScale < InitScale)
                {
                    _upScale = true;
                    _currentScale = InitScale;
                }
                transform.localScale = Vector3.one * _currentScale;

                yield return new WaitForSeconds(_deltaTime);
            }
            startBreathing = false;
            breathingInCycle = false;
        }


    }
}
