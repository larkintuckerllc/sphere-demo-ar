using UnityEngine;

public class SphereColor : Singleton<SphereColor>
{
    public static int InitialState = -1;

    public static int Reducer(int state, Action action)
    {
        switch (action.Type)
        {
            case Provider.Actions.SET_SPHERE_COLOR:
                return action.PayloadInt;
            default:
                return state;
        }
    }

    public static int GetSphereColor(State state)
    {
        return state.SphereColor;
    }

    protected SphereColor() { }

    public Action SetSphereColor(int color)
    {
        return new Action(Provider.Actions.SET_SPHERE_COLOR, color);
    }

    public void Intialize()
    {
    }
}