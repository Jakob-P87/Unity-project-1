using UnityEngine;
using System.Collections;

public class CharacterSelect : MonoBehaviour
{

    public BasicStats[] AllClassStats;
    public bool ClassSelectWindow;
    public GameObject User;

    // Use this for initialization
    void Start()
    {

    }

    void OnGUI()
    {

        if (ClassSelectWindow)
        {

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 150, 200, 40), "Barbarian"))
            {

                AssignBaseStats(0);
                ClassSelectWindow = false;
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 40), "Sorcerer"))
            {

                AssignBaseStats(1);
                ClassSelectWindow = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void AssignBaseStats(int classChosen)
    {

        var Comp = User.GetComponent<UserStats>();

        Comp.userClass = AllClassStats[classChosen].userClass;
        Comp.baseAttackPower = AllClassStats[classChosen].baseAttackPower;
        Comp.baseAttackSpeed = AllClassStats[classChosen].baseAttackSpeed;
    }
}
