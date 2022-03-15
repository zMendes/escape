using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasswordController : MonoBehaviour
{ 

    public Text digits;

    public GameObject endgame;

    public List<GameObject> buttons = new List<GameObject>();

    List<int> password = new List<int>();
    List<int> truePassword; //= new List<int>();
    void Start(){
        truePassword = new List<int>( new int[] {9,0,7,2,3,1,3,6});

    }

    void Update(){

    }

    public void buttonPressed(int number){
        print("FUCK OFFFF");

        if (number == -1 )
            checkAnswer();

        else if (number == -2){
            password.Clear();
            digits.text = "";
        }
        else if (password.Count == truePassword.Count )
            return;
        else {
            password.Add(number);
            digits.text += "*";
        }

    }

    void checkAnswer(){
        print("Check answer");
        if (CheckMatch(password, truePassword)){
            print("IS EQUAL");
            endGame();
        }
        else {
            password.Clear();
            digits.text = "";
        }
    }

    void endGame(){
        print("ENDGAME");
        digits.color = Color.green;
        endgame.SetActive(true);

    }

    bool CheckMatch(List<int> l1, List<int> l2) {
        for (int i = 0; i < l1.Count; i++) {
            print(l1[i] == l2[i]);
            if (l1[i] != l2[i])
                return false;
        }
        return true;
        }
}