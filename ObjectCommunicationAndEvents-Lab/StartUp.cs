using System;
using Heroes;

public class StartUp    
{
    public static void Main(string[] args)
    {
        Logger combatLog = new CombatLogger();
        Logger eventLog = new EventLogger();

        combatLog.SetSuccessor(eventLog);

        IAttackGroup group = new Group();
        group.AddMember(new Warrior("gosho", 10, combatLog));
        group.AddMember(new Warrior("Rolo", 13, combatLog));
        
        var dragon = new Dragon("Peter", 200, 25);

        IExecutor executor = new CommandExecutor();
        ICommand groupTarget = new GroupTargetCommand(group, dragon);
        ICommand groupattack = new GroupAttackCommand(group);
    }
}
