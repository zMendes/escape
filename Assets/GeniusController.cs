using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
public class GeniusController : MonoBehaviour
{

    public int ITER;
    public GameObject spotlight;
    public GameObject red_;
    public GameObject blue_;
    public GameObject green_;
    public GameObject yellow_;
    public GameObject playButton;
    public GameObject text_;

    TextMesh text;

    HoverButton red, blue, green, yellow, play;
    private List<Color> colors = new List<Color>();

    private List<Color> sequence = new List<Color>();

    private List<Color> buttonSequence = new List<Color>();

    
    private Light l;


    bool redClicked, blueClicked, greenClicked, yellowClicked;

    //public GameObject[]
    // Start is called before the first frame update
    void Start()
    {

        red = red_.GetComponent<HoverButton>();
        green = green_.GetComponent<HoverButton>();
        blue = blue_.GetComponent<HoverButton>();
        yellow = yellow_.GetComponent<HoverButton>();
        play = playButton.GetComponent<HoverButton>();
        text = text_.GetComponent<TextMesh>();


        colors.Add(Color.green);
        colors.Add(Color.red);
        colors.Add(Color.blue);
        colors.Add(Color.yellow);

        redClicked = false;
        blueClicked = false;
        greenClicked = false;
        yellowClicked = false;

        l = spotlight.GetComponent<Light>();
        l.color = Color.black;

        
    }


    IEnumerator StartGame(int n){
        text.text = "Starting Game";
        int count = 1;
        while (count <= n){
            text.text = "Level " + count + "/" + n;
            sequence.Add(colors[Random.Range(0, 4)]);
            l.color = sequence[sequence.Count - 1];
            foreach (Color color in sequence){
                l.color = color;
                yield return new WaitForSeconds(2.0f);
                l.color = Color.black;
                yield return new WaitForSeconds(.5f);
            }
            text.text = "Your turn";
            yield return new WaitForSeconds(count *2 + 5f);
            if (!CheckMatch(sequence, buttonSequence)){
                l.color = Color.black;
                text.text = "You lose";
                sequence.Clear();
                buttonSequence.Clear();
                count = 1;
                changeButtons(false);
                yield break;
                }
            if (count == n){
                text.text = "B: MMXXIX";
            }
            count++;
            buttonSequence.Clear();
        }
    changeButtons(false);
    
    }
    // Update is called once per frame
    void Update()
    {
        if (red.buttonDown)
            buttonSequence.Add(Color.red);
        if (blue.buttonDown)
            buttonSequence.Add(Color.blue);
        if (green.buttonDown)
            buttonSequence.Add(Color.green);
        if (yellow.buttonDown)
            buttonSequence.Add(Color.yellow);
        if (play.buttonDown){
            changeButtons(true);
            StartCoroutine(StartGame(ITER));
        }

    }

    //https://answers.unity.com/questions/1243846/how-do-i-compare-two-lists-in-c.html
    bool CheckMatch(List<Color> l1, List<Color> l2) {
        if (l1.Count != l2.Count)
            return false;
        for (int i = 0; i < l1.Count; i++) {
            print(l1[i] == l2[i]);
            if (l1[i] != l2[i])
                return false;
        }
        return true;
        }
    void changeButtons(bool state){
        red_.SetActive(state);
        green_.SetActive(state);
        blue_.SetActive(state);
        yellow_.SetActive(state);

    }
}
