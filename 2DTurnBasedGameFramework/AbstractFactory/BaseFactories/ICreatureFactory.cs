using _2DTurnBasedGameFramework.Models.BaseModels;
using CustomRange = _2DTurnBasedGameFramework.Helpers.CustomRange;

namespace _2DTurnBasedGameFramework.AbstractFactory.BaseFactories
{
    /// <summary>
    /// A factory you make new creatures with.
    /// </summary>
    public interface ICreatureFactory
    {
        /// <summary>
        /// Creates a new creature.
        /// </summary>
        /// <param name="name">Name of the creature. (e.g. Medusa, Dragon, Wolf Rider etc.)</param>
        /// <param name="atk">Attack bonus. Increases damage dealt.</param>
        /// <param name="def">Defense bonus. Decreases damage taken.</param>
        /// <param name="hp">Hitpoints. Determines how much damage to take before dying.</param>
        /// <param name="dmgRange">The base damage range for the creature.</param>
        /// <param name="isCaster">Determines if the creature is a caster or not. If it is, it gains additional damage from SpellPower</param>
        /// <returns>A creature that inherits from BaseCreature</returns>
        BaseCreature CreateCreature(string name, int atk, int def, int hp, CustomRange dmgRange, bool isCaster);

        /// <summary>
        /// Creates a new non-caster creature.
        /// </summary>
        /// <param name="name">Name of the creature. (e.g. Medusa, Dragon, Wolf Rider etc.)</param>
        /// <param name="atk">Attack bonus. Increases damage dealt.</param>
        /// <param name="def">Defense bonus. Decreases damage taken.</param>
        /// <param name="hp">Hitpoints. Determines how much damage to take before dying.</param>
        /// <param name="dmgRange">The base damage range for the creature.</param>
        /// <returns>A creature that inherits from BaseCreature</returns>
        BaseCreature CreateCreature(string name, int atk, int def, int hp, CustomRange dmgRange);

        /// <summary>
        /// Creates a new T creature. (T could be a custom creature implementation that, in some way, inherits from BaseCreature)
        /// </summary>
        /// <param name="name">Name of the creature. (e.g. Medusa, Dragon, Wolf Rider etc.)</param>
        /// <param name="atk">Attack bonus. Increases damage dealt.</param>
        /// <param name="def">Defense bonus. Decreases damage taken.</param>
        /// <param name="hp">Hitpoints. Determines how much damage to take before dying.</param>
        /// <param name="dmgRange">The base damage range for the creature.</param>
        /// <returns>A creature that inherits from BaseCreature</returns>
        BaseCreature CreateCreature<T>(string name, int atk, int def, int hp, CustomRange dmgRange)
            where T : BaseCreature, new();
    }
}
