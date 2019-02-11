//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Game.Components.ShotViewComponent shotView { get { return (Game.Components.ShotViewComponent)GetComponent(GameComponentsLookup.ShotView); } }
    public bool hasShotView { get { return HasComponent(GameComponentsLookup.ShotView); } }

    public void AddShotView(Game.Views.ShotView newValue) {
        var index = GameComponentsLookup.ShotView;
        var component = CreateComponent<Game.Components.ShotViewComponent>(index);
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceShotView(Game.Views.ShotView newValue) {
        var index = GameComponentsLookup.ShotView;
        var component = CreateComponent<Game.Components.ShotViewComponent>(index);
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveShotView() {
        RemoveComponent(GameComponentsLookup.ShotView);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherShotView;

    public static Entitas.IMatcher<GameEntity> ShotView {
        get {
            if (_matcherShotView == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ShotView);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherShotView = matcher;
            }

            return _matcherShotView;
        }
    }
}