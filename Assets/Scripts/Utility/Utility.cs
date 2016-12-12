using UnityEngine;

public static class Utility
{
    private static readonly string numberModelFileName = "number";

    public static NumberModel LoadNumberModel()
    {
        TextAsset textAsset = Resources.Load<TextAsset>(numberModelFileName);
        string json = textAsset.text;
        NumberModel numberModel = new NumberModel();
        JsonUtility.FromJsonOverwrite(json, numberModel);
        return numberModel;
    }
}