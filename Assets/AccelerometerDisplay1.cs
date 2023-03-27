using UnityEngine;
using UnityEngine.UI;

public class AccelerometerDisplay1 : MonoBehaviour
{
    private Text accelerometerText;

    void Start()
    {
        accelerometerText = GetComponent<Text>();
    }

    void Update()
    {
        Vector3 accelerometerData = Input.acceleration;
        string dataString = string.Format("Accelerometer Data:\nX: {0:F2}\nY: {1:F2}\nZ: {2:F2}", accelerometerData.x, accelerometerData.y, accelerometerData.z);
        accelerometerText.text = dataString;
    }
}
