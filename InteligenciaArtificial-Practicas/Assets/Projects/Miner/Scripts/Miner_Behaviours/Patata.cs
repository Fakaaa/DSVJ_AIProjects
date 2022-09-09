using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Patata : MonoBehaviour
{
    private class MyInt
    {
        public int value;

        public MyInt(int initialVal)
        {
            value = initialVal;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        /*List<MyInt> patatas = new List<MyInt>();
        patatas.Add(new MyInt(0));
        patatas.Add(new MyInt(0));
        patatas.Add(new MyInt(0));
        patatas.Add(new MyInt(0));
        patatas.Add(new MyInt(0));
        patatas.Add(new MyInt(0));
        patatas.Add(new MyInt(0));
        patatas.Add(new MyInt(0));
        ParallelOptions parallelOptions = new ParallelOptions() { MaxDegreeOfParallelism = 8 };

        Parallel.ForEach(patatas, parallelOptions, (*//*int*//*patata) =>
        {
            patata.value++;
        });

        for (int i = 0; i < patatas.Count; i++)
        {
            Debug.Log(patatas[i].value);
        }*/

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
