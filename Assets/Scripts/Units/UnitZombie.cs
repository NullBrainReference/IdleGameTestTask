public class UnitZombie : UnitBase
{
	public UnitZombie() : base()
	{
		this.maxHealth = 10;
		this.health = this.maxHealth;
        this.damageBase = 2;
        this.damage = this.damageBase;
        this.movementSpeed = 0.5f;
		this.attackSpeed = 1;
		this.team = UnitTeam.Enemy;
		this.unitType = UnitType.Zombie;
	}
}
