//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity gameSettingsEntity { get { return GetGroup(GameMatcher.GameSettings).GetSingleEntity(); } }
    public GameSettingsComponent gameSettings { get { return gameSettingsEntity.gameSettings; } }
    public bool hasGameSettings { get { return gameSettingsEntity != null; } }

    public GameEntity SetGameSettings(Game.Settings.GameSettings newValue) {
        if (hasGameSettings) {
            throw new Entitas.EntitasException("Could not set GameSettings!\n" + this + " already has an entity with GameSettingsComponent!",
                "You should check if the context already has a gameSettingsEntity before setting it or use context.ReplaceGameSettings().");
        }
        var entity = CreateEntity();
        entity.AddGameSettings(newValue);
        return entity;
    }

    public void ReplaceGameSettings(Game.Settings.GameSettings newValue) {
        var entity = gameSettingsEntity;
        if (entity == null) {
            entity = SetGameSettings(newValue);
        } else {
            entity.ReplaceGameSettings(newValue);
        }
    }

    public void RemoveGameSettings() {
        gameSettingsEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public GameSettingsComponent gameSettings { get { return (GameSettingsComponent)GetComponent(GameComponentsLookup.GameSettings); } }
    public bool hasGameSettings { get { return HasComponent(GameComponentsLookup.GameSettings); } }

    public void AddGameSettings(Game.Settings.GameSettings newValue) {
        var index = GameComponentsLookup.GameSettings;
        var component = CreateComponent<GameSettingsComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceGameSettings(Game.Settings.GameSettings newValue) {
        var index = GameComponentsLookup.GameSettings;
        var component = CreateComponent<GameSettingsComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveGameSettings() {
        RemoveComponent(GameComponentsLookup.GameSettings);
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

    static Entitas.IMatcher<GameEntity> _matcherGameSettings;

    public static Entitas.IMatcher<GameEntity> GameSettings {
        get {
            if (_matcherGameSettings == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameSettings);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameSettings = matcher;
            }

            return _matcherGameSettings;
        }
    }
}
