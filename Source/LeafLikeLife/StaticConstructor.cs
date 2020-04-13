using RimWorld;
using System.Collections.Generic;
using System.Linq;
using Verse;

namespace LeafLikeLife
{
  [StaticConstructorOnStartup]
  public static class LLLStartUp
  {
    static LLLStartUp()
    {
      // Loads right before main menu
      LLLUtility.UpdateConsciousnessPenalty();
    }
  }

  public class LLLUtility
  {
    public static void UpdateConsciousnessPenalty()
    {
      //DefDatabase<HediffDef>.GetNamed("SmokeleafHigh").stages[0].capMods[0].offset = LLLModSettings.amountPenaltyConsciousness;
      HediffDef.Named("SmokeleafHigh").
        stages.Where((HediffStage stage) => stage.capMods.Any((PawnCapacityModifier mod) => mod.capacity == PawnCapacityDefOf.Consciousness)).First().
        capMods.Where((PawnCapacityModifier mod) => mod.capacity == PawnCapacityDefOf.Consciousness).First().offset = LLLModSettings.amountPenaltyConsciousness;
    }
  }
}
