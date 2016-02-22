using UnityEngine;
using System.Collections;
using System.IO;
using System;

public static class txtReader
{
    //Constants for parsing
    private const string PARENT_KEY = "parent";
    private const string KEY_KEY = "key";
    private const string POSITION_KEY = "position";
    private const string ROTATION_KEY = "rotation";
    private const string SCALE_KEY = "scale";
    //Flags for parsing sub components
    enum Flags { Parent, Key, Host }

    public static void ConstructProteinHierarchy() {
        FileInfo theSourceFile = new FileInfo(Application.dataPath + "'Resources/proteinList.txt");
        StreamReader reader = theSourceFile.OpenText();

        string text;
        do {
            text = reader.ReadLine().Trim();
            switch (text) {
                case PARENT_KEY:
                    break;
                case KEY_KEY:
                    break;
                case POSITION_KEY:
                    break;
                case ROTATION_KEY:
                    break;
                case SCALE_KEY:
                    break;
            }
        } while (text != null);
    }
}
