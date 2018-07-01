using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hont
{
    public class StackListTest : MonoBehaviour
    {
        [ContextMenu("Foo")]
        void Foo()
        {
            //---------------------------------------------------
            var list = new StackList<Vector3>();
            list.Add(new Vector3(1, 0, 0));
            list.Add(new Vector3(2, 0, 0));
            list.Add(new Vector3(3, 0, 0));
            list.Add(new Vector3(4, 0, 0));

            for (int i = 0; i < list.Count; i++)
            {
                Debug.Log("add list[i]: " + list[i]);
            }
            //---------------------------------------------------add.

            //---------------------------------------------------
            var isRemoved = list.Remove(new Vector3(2, 0, 0));
            Debug.Log("isRemoved: " + isRemoved);

            for (int i = 0; i < list.Count; i++)
            {
                Debug.Log("removed list[i]: " + list[i]);
            }
            Debug.Log("removed list count: " + list.Count);
            //---------------------------------------------------remove.

            //---------------------------------------------------
            list.RemoveAt(0);

            for (int i = 0; i < list.Count; i++)
            {
                Debug.Log("removed(RemoveAt) list[i]: " + list[i]);
            }
            Debug.Log("removed(RemoveAt) list count: " + list.Count);
            //---------------------------------------------------remove at.

            //---------------------------------------------------
            for (int i = 0; i < 100; i++)
            {
                list.Add(new Vector3(1, 1, 1));
            }

            for (int i = 0; i < list.Count; i++)
            {
                Debug.Log("overflow list[i]: " + list[i]);
            }
            Debug.Log("overflow list count: " + list.Count);
            //---------------------------------------------------overflow.
        }

        void Update()
        {
            UnityEngine.Profiling.Profiler.BeginSample("--- SatackListGCTest ---");
            GCTest();
            UnityEngine.Profiling.Profiler.EndSample(); ;
        }

        void GCTest()
        {
            var list = new StackList<Vector3>();
            list.Add(new Vector3(1, 0, 0));
            list.Add(new Vector3(2, 0, 0));
            list.Add(new Vector3(3, 0, 0));
            list.Add(new Vector3(4, 0, 0));
        }
    }
}
