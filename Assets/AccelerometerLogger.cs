using UnityEngine;
using System.IO;

public class AccelerometerLogger : MonoBehaviour
{
    public float loggingDuration = 10f; // Duration of logging in seconds
    private string filePath;
    private StreamWriter writer;
    private bool isLogging = false;

    void Start()
    {
        filePath = @"C:\Users\Holge\CSV_FILES\accelerometer_data_" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv";
        writer = new StreamWriter(filePath);
        writer.WriteLine("Time,X,Y,Z");
    }

    void Update()
    {
        if (isLogging)
        {
            Vector3 accelerometerData = Input.acceleration;
            string dataString = string.Format("{0},{1},{2},{3}", Time.time, accelerometerData.x, accelerometerData.y, accelerometerData.z);
            writer.WriteLine(dataString);
            Debug.Log(dataString);
        }
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(50, 50, 500, 250), "Start Logging"))
        {
            isLogging = true;
            Invoke("StopLogging", loggingDuration);
        }
    }

    void StopLogging()
    {
        isLogging = false;
        writer.Close();
    }
}
