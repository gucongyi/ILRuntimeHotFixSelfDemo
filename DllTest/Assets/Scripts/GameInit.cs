using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gcy
{
    public class GameInit : MonoBehaviour
    {
        private bool isFirstUpdate = false;

        public void Init()
        {
            GameObject firstGo = new GameObject("GoInit");
            firstGo.transform.localPosition = Vector3.zero;
            firstGo.transform.localEulerAngles = Vector3.zero;
            firstGo.transform.localScale = Vector3.zero;
            CreateCube createCube = firstGo.GetComponent<CreateCube>();
            if (createCube == null)
            {
                createCube = firstGo.AddComponent<CreateCube>();
            }
            CubeMove.CallBackX += MoveCallBack;
        }

        public void MoveCallBack(float x)
        {
            Debug.Log("GameInit++++++++++x:"+x);
        }

        void Awake()
        {
            Init();
            Debug.Log("======Awake");
        }

        // Use this for initialization
        void Start()
        {
            Debug.Log("======Start");
        }

        // Update is called once per frame
        void Update()
        {
            if (!isFirstUpdate)
            {
                Debug.Log("======Update");
                isFirstUpdate = true;
            }
        }
    }

    public class CreateCube : MonoBehaviour
    {
        private bool isFirstUpdate = false;

        void Awake()
        {
            Debug.Log("======CreateCube Awake");
            GameObject cube=GameObject.CreatePrimitive(PrimitiveType.Cube);
            CubeMove cubeMove = cube.GetComponent<CubeMove>();
            if (cubeMove==null)
            {
                cubeMove = cube.AddComponent<CubeMove>();
            }
        }

        // Use this for initialization
        void Start()
        {
            Debug.Log("======CreateCube Start");
        }

        // Update is called once per frame
        void Update()
        {
            if (!isFirstUpdate)
            {
                Debug.Log("======CreateCube Update");
                isFirstUpdate = true;
            }
        }
    }

    public class TestMonoBehaviour
    {
        public static void RunTest(GameObject go)
        {
            go.AddComponent<GameInit>();
        }

        public static void RunTest2(GameObject go)
        {
            GameInit init=go.GetComponent<GameInit>();
            if (init==null)
            {
                init= go.AddComponent<GameInit>();
            }
        }
    }

}

