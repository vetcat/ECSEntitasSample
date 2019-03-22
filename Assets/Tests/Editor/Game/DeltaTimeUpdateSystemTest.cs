using NUnit.Framework;
using Game.Systems;

public class DeltaTimeUpdateSystemTest
{
    private Contexts _context;
    private Entitas.Systems _systems;
    private DeltaTimeUpdateSystem _deltaTimeUpdateSystem;

    [SetUp]
    public void SetUp()
    {
        _context = new Contexts();
        _context.game.SetDeltaTime(0f);

        _deltaTimeUpdateSystem = new DeltaTimeUpdateSystem(_context.game);
        _systems = new Feature("Game").Add(_deltaTimeUpdateSystem);
    }

    [Test]
    public void DeltaTime_StartValue()
    {
        Assert.AreEqual(_context.game.deltaTime.Value, 0f);
    }

    [Test]
    public void DeltaTime_Value_Set_Get()
    {
        float dt = 1f;
        _context.game.deltaTime.Value = dt;
        Assert.AreEqual(_context.game.deltaTime.Value, dt);
    }

    [Test]
    public void DeltaTimeUpdateSystem_Update()
    {
        float dt = 1.5f;
        _deltaTimeUpdateSystem.Execute(dt);
        Assert.AreEqual(_context.game.deltaTime.Value, dt);
    }
}