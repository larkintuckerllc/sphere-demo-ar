using System;
using UnityEngine;
using UniRx;

public static class Provider
{
    public enum Actions
    {
        __INIT,
        SET_SPHERE_COLOR,
        THUNK,
    }

    private static bool initialized = false;
    private static State state;

    public static State GetState()
    {
        return state;
    }

    public static State Reducer(State state, Action action)
    {
        bool hasChanged = false;
        int nextStateSphereColor = SphereColor.Reducer(state.SphereColor, action);
        if (nextStateSphereColor != state.SphereColor)
        {
            hasChanged = true;
        }
        return hasChanged ? new State(nextStateSphereColor) : state;
    }

    public static Action Logger(Action action)
    {
        Debug.Log(action.Type);
        return action;
    }

    public static Boolean FilterThunk(Action action)
    {
        return action.Type != Actions.THUNK;
    }

    public static State ExtractState(State state)
    {
        Provider.state = state;
        return state;
    }

    static ISubject<Action> StoreDispatch;

    public static void Dispatch(Action action)
    {
        StoreDispatch.OnNext(action);
    }

    public static BehaviorSubject<State> Store { get; private set; }

    public static void Initialize()
    {
        if (initialized) return;
        initialized = true;
        StoreDispatch = new Subject<Action>();
        State initialState = new State(
            SphereColor.InitialState
        );
        Store = new BehaviorSubject<State>(initialState);
        StoreDispatch
            .Where<Action>(FilterThunk)
            .Select(Logger)
            .Scan(initialState, Reducer)
            .Select(ExtractState)
            .Subscribe(Store);
        Dispatch(new Action(Actions.__INIT));
    }
}