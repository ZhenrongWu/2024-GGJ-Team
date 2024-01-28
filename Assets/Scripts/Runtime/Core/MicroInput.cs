using UnityEngine;
using UnityEngine.SceneManagement;

public class MicroInput : MonoBehaviour
{
    public float m_CurrentVolume;

    private AudioClip _microRecord;
    private string    _deviceName;
    private int       _volumeDataLength;

    private void Start()
    {
        // 取得麥克風預設裝置
        _deviceName = Microphone.devices[0];
        // 開始錄製聲音
        _microRecord = Microphone.Start(_deviceName, true, 999, 44100);
    }

    private void Update()
    {
        m_CurrentVolume = GetMaxVolume();

        if (m_CurrentVolume > .2f)
        {
            SceneManager.LoadScene("Menu");
        }
    }

    private float GetMaxVolume()
    {
        float maxVolume = 0;

        _volumeDataLength = 128;
        float[] volumeData = new float[_volumeDataLength];
        int     offset     = Microphone.GetPosition(_deviceName) - _volumeDataLength;
        if (offset <= 0)
        {
            return 0;
        }

        _microRecord.GetData(volumeData, offset);

        for (int i = 0; i < _volumeDataLength; i++)
        {
            float tempVolume = volumeData[i];
            if (maxVolume < tempVolume)
            {
                maxVolume = tempVolume;
            }
        }

        return maxVolume;
    }
}