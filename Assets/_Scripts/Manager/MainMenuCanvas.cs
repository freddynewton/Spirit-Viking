using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[ExecuteInEditMode]
public class MainMenuCanvas : MonoBehaviour
{
    public Slider worldSizeSlider;
    public Dropdown dungeonTypeDropdown;

    public int size;
    public DungeonType DungeonType;


    public void Dropdown_IndexChanged(int index)
    {
        DungeonType name = (DungeonType)index;
    }


    // Start is called before the first frame update
    void Start()
    {
        dungeonTypeDropdown.options.Clear();
        PopulateList();
    }

    // Update is called once per frame
    void Update()
    { 
        size = (int)worldSizeSlider.value;
        DungeonType = (DungeonType)dungeonTypeDropdown.value;
    }


    void PopulateList()
    {
        string[] enumNames = Enum.GetNames(typeof(DungeonType));
        List<string> names = new List<string>(enumNames);
        dungeonTypeDropdown.AddOptions(names);
    }
}
