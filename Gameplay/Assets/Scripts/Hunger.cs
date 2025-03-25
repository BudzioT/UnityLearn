using UnityEngine;
using UnityEngine.UI;

public class Hunger : MonoBehaviour
{
    public GameObject hungerBar;
    public GameObject hungerBarPrefab;
    public GameObject canvas;
    private Slider _hungerSlider;
    public int timesToFeed = 2;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        hungerBar = Instantiate(hungerBarPrefab, canvas.transform);
        _hungerSlider = hungerBar.GetComponent<Slider>();

        if (_hungerSlider != null)
        {
            _hungerSlider.maxValue = timesToFeed;
            _hungerSlider.value = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        hungerBar.transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
    }

    public void Feed()
    {
        if (_hungerSlider != null)
        {
            timesToFeed -= 1;
            _hungerSlider.value = _hungerSlider.maxValue - timesToFeed;
        }

        if (timesToFeed <= 0)
        {
            gameObject.tag = "Fed";
        }
    }

    private void OnDestroy()
    {
        Destroy(hungerBar);
    }
}
