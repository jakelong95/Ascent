package ascent.game;




public abstract class Attack
{
	//This could benefit from a better naming standard. 
	public final static float COOLDOWN_STANDARD = 1.0f;
	public final static float COOLDOWN_FASTEST = 0.2f * COOLDOWN_STANDARD;
	public final static float COOLDOWN_FASTER = 0.3f * COOLDOWN_STANDARD;
	public final static float COOLDOWN_FAST = 0.5f * COOLDOWN_STANDARD;
	public final static float COOLDOWN_MEDIUM = 3.0f * COOLDOWN_STANDARD;
	public final static float COOLDOWN_SLOW = 5.0f * COOLDOWN_STANDARD;
	public final static float COOLDOWN_SLOWEST = 10.0f * COOLDOWN_STANDARD;
	public final static float COOLDOWN_SUPER_SLOW = 100.0f * COOLDOWN_STANDARD;
	
	
	public final static float DAMAGE_STANDARD = 1.0f;
	public final static float DAMAGE_BASICALLY_NOTHING = .03f * DAMAGE_STANDARD;
	public final static float DAMAGE_LOW = .5f * DAMAGE_STANDARD;
	public final static float HIGH = 2.0f * DAMAGE_STANDARD;
	public final static float VERY_HIGH = 3.0f * DAMAGE_STANDARD;
	public final static float MASSIVE = 5.0f * DAMAGE_STANDARD;
}
