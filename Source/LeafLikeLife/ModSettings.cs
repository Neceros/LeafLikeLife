using System;
using UnityEngine;
using Verse;

namespace LeafLikeLife
{
  public class LLLModSettings : ModSettings
  {
    public static float amountPenaltyConsciousness = -0.15f;


    public override void ExposeData()
    {
      base.ExposeData();
      Scribe_Values.Look(ref amountPenaltyConsciousness, "LLLamountPenaltyConsciousness");
    }
  }

  public class LLLMod : Mod
  {
    LLLModSettings settings;
    public LLLMod(ModContentPack con) : base(con)
    {
      this.settings = GetSettings<LLLModSettings>();
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
      Listing_Standard listing = new Listing_Standard();
      listing.Begin(inRect);
      listing.Label("LLLConsciousnessLabel".Translate() + ": " + (LLLModSettings.amountPenaltyConsciousness * 100) + "%", tooltip: "LLLConsciousnessTooltip".Translate());
      LLLModSettings.amountPenaltyConsciousness = listing.Slider(RoundToNearestTenth(LLLModSettings.amountPenaltyConsciousness), -0f, -1f);
      listing.End();
      base.DoSettingsWindowContents(inRect);
    }

    public override void WriteSettings()
    {
      LLLUtility.UpdateConsciousnessPenalty();

      base.WriteSettings();
    }

    public override string SettingsCategory()
    {
      return "LLLTitle".Translate();
    }

    private float RoundToNearestHalf(float val)
    { 
      return (float)Math.Round(val * 2, MidpointRounding.AwayFromZero) / 2;
    }

    private float RoundToNearestTenth(float val)
    {
      return (float)Math.Round(val * 100, MidpointRounding.AwayFromZero) / 100;
    }
  }
}
