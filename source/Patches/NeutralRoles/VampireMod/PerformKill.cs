
/*using AmongUs.GameOptions;
using HarmonyLib;
using Hazel;
using InnerNet;
using System;
using System.Collections.Generic;
using System.Linq;
using TownOfRoles.CrewmateRoles.ImitatorMod;
using TownOfRoles.CrewmateRoles.TrapperMod;
using TownOfRoles.Roles;
using TownOfRoles.Roles.Modifiers;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TownOfRoles.NeutralRoles.JackalMod
{
  [HarmonyPatch(typeof (KillButton), "DoClick")]
  public class Bite
  {
    public static bool Prefix(KillButton __instance)
    {
      if (UnityEngine.Object.op_Inequality((UnityEngine.Object) __instance, (Object) DestroyableSingleton<HudManager>.Instance.KillButton) || !PlayerControl.LocalPlayer.Is(RoleEnum.Jackal))
        return true;
      Jackal role1 = Role.GetRole<Jackal>(PlayerControl.LocalPlayer);
      if (!PlayerControl.LocalPlayer.CanMove || Object.op_Equality((Object) role1.ClosestPlayer, (Object) null) || (double) role1.BiteTimer() != 0.0 || !((Behaviour) __instance).enabled)
        return false;
      float killDistance = GameOptionsData.KillDistances[GameOptionsManager.Instance.currentNormalGameOptions.KillDistance];
      if ((double) Vector2.Distance(role1.ClosestPlayer.GetTruePosition(), PlayerControl.LocalPlayer.GetTruePosition()) > (double) killDistance || Object.op_Equality((Object) role1.ClosestPlayer, (Object) null))
        return false;
      List<PlayerControl> list1 = PlayerControl.AllPlayerControls.ToArray().Where<PlayerControl>((Func<PlayerControl, bool>) (x => x.Is(RoleEnum.Jackal))).ToList<PlayerControl>();
      foreach (Phantom role2 in Role.GetRoles(RoleEnum.Phantom))
      {
        if (role2.formerRole == RoleEnum.Jackal)
          list1.Add(role2.Player);
      }
      List<PlayerControl> list2 = PlayerControl.AllPlayerControls.ToArray().Where<PlayerControl>((Func<PlayerControl, bool>) (x => x.Is(RoleEnum.Jackal) && !x.Data.IsDead && !x.Data.Disconnected)).ToList<PlayerControl>();
      if (role1.ClosestPlayer.Is(RoleEnum.JackalHunter))
      {
        role1.LastBit = DateTime.UtcNow;
        Utils.RpcMurderPlayer(role1.ClosestPlayer, PlayerControl.LocalPlayer);
        return false;
      }
      if ((role1.ClosestPlayer.Is(Faction.Crewmates) || role1.ClosestPlayer.Is(Faction.Neutral) && !role1.ClosestPlayer.Is(ModifierEnum.Lover) && list2.Count == 1 && list1.Count < CustomGameOptions.MaxJackalsPerGame))
      {
        List<bool> boolList = Utils.Interact(PlayerControl.LocalPlayer, role1.ClosestPlayer);
        if (boolList[4])
        {
          Bite.Convert(role1.ClosestPlayer);
          MessageWriter messageWriter = ((InnerNetClient) AmongUsClient.Instance).StartRpcImmediately(((InnerNetObject) PlayerControl.LocalPlayer).NetId, (byte) 175, (SendOption) 1, -1);
          messageWriter.Write(role1.ClosestPlayer.PlayerId);
          ((InnerNetClient) AmongUsClient.Instance).FinishRpcImmediately(messageWriter);
        }
        if (boolList[0])
        {
          role1.LastBit = DateTime.UtcNow;
          return false;
        }
        if (boolList[1])
        {
          role1.LastBit = DateTime.UtcNow;
          role1.LastBit = role1.LastBit.AddSeconds((double) CustomGameOptions.ProtectKCReset - (double) CustomGameOptions.BiteCd);
          return false;
        }
        return boolList[3] && false;
      }
      List<bool> boolList1 = Utils.Interact(PlayerControl.LocalPlayer, role1.ClosestPlayer, true);
      if (boolList1[4])
        return false;
      if (boolList1[0])
      {
        role1.LastBit = DateTime.UtcNow;
        return false;
      }
      if (boolList1[1])
      {
        role1.LastBit = DateTime.UtcNow;
        role1.LastBit = role1.LastBit.AddSeconds((double) CustomGameOptions.ProtectKCReset - (double) CustomGameOptions.BiteCd);
        return false;
      }
      if (boolList1[2])
      {
        role1.LastBit = DateTime.UtcNow;
        role1.LastBit = role1.LastBit.AddSeconds((double) CustomGameOptions.VestKCReset - (double) CustomGameOptions.BiteCd);
        return false;
      }
      return boolList1[3] && false;
    }

    public static void Convert(PlayerControl newVamp)
    {
      foreach (Guardian role in Role.GetRoles(RoleEnum.Guardian))
      {
        if (Object.op_Equality((Object) role.target, (Object) newVamp))
          role.TargetIsVamp = true;
      }
      Role role1 = Role.GetRole(newVamp);
      (int, int, int, int) valueTuple = (role1.CorrectKills, role1.IncorrectKills, role1.CorrectAssassinKills, role1.IncorrectAssassinKills);
      if (newVamp.Is(RoleEnum.Informant))
      {
        Informant role2 = Role.GetRole<Informant>(newVamp);
        ((IEnumerable<Component>) role2.InformantArrows.Values).DestroyAll();
        role2.InformantArrows.Clear();
        ((IEnumerable<Component>) role2.ImpArrows).DestroyAll();
        role2.ImpArrows.Clear();
      }
      if (Object.op_Equality((Object) newVamp, (Object) StartImitate.ImitatingPlayer))
        StartImitate.ImitatingPlayer = (PlayerControl) null;
      if (newVamp.Is(RoleEnum.Guardian))
        Role.GetRole<Guardian>(newVamp).UnProtect();
      if (Object.op_Equality((Object) PlayerControl.LocalPlayer, (Object) newVamp))
      {
        if (PlayerControl.LocalPlayer.Is(RoleEnum.Engineer))
          Object.Destroy((Object) Role.GetRole<Engineer>(PlayerControl.LocalPlayer).UsesText);
        if (PlayerControl.LocalPlayer.Is(RoleEnum.Tracker))
        {
          Tracker role3 = Role.GetRole<Tracker>(PlayerControl.LocalPlayer);
          ((IEnumerable<Component>) role3.TrackerArrows.Values).DestroyAll();
          role3.TrackerArrows.Clear();
          Object.Destroy((Object) role3.UsesText);
        }
        if (PlayerControl.LocalPlayer.Is(RoleEnum.Mystic))
        {
          Mystic role4 = Role.GetRole<Mystic>(PlayerControl.LocalPlayer);
          ((IEnumerable<Component>) role4.BodyArrows.Values).DestroyAll();
          role4.BodyArrows.Clear();
        }
        if (PlayerControl.LocalPlayer.Is(RoleEnum.Transporter))
        {
          Transporter role5 = Role.GetRole<Transporter>(PlayerControl.LocalPlayer);
          Object.Destroy((Object) role5.UsesText);
          if (Object.op_Inequality((Object) role5.TransportList, (Object) null))
          {
            role5.TransportList.Toggle();
            role5.TransportList.SetVisible(false);
            role5.TransportList = (ChatController) null;
            role5.PressedButton = false;
            role5.TransportPlayer1 = (PlayerControl) null;
          }
        }
        if (PlayerControl.LocalPlayer.Is(RoleEnum.Veteran))
          Object.Destroy((Object) Role.GetRole<Veteran>(PlayerControl.LocalPlayer).UsesText);
        if (PlayerControl.LocalPlayer.Is(RoleEnum.Medium))
        {
          Medium role6 = Role.GetRole<Medium>(PlayerControl.LocalPlayer);
          ((IEnumerable<Component>) role6.MediatedPlayers.Values).DestroyAll();
          role6.MediatedPlayers.Clear();
        }
        if (PlayerControl.LocalPlayer.Is(RoleEnum.Trapper))
        {
          Trapper role7 = Role.GetRole<Trapper>(PlayerControl.LocalPlayer);
          Object.Destroy((Object) role7.UsesText);
          role7.traps.ClearTraps();
        }
        if (PlayerControl.LocalPlayer.Is(RoleEnum.Mystic))
          ((Component) Role.GetRole<Mystic>(PlayerControl.LocalPlayer).ExamineButton).gameObject.SetActive(false);
        if (PlayerControl.LocalPlayer.Is(RoleEnum.Guardian))
          Object.Destroy((Object) Role.GetRole<Guardian>(PlayerControl.LocalPlayer).UsesText);
      }
      Role.RoleDictionary.Remove(newVamp.PlayerId);
      if (Object.op_Equality((Object) PlayerControl.LocalPlayer, (Object) newVamp))
      {
        Jackal vampire = new Jackal(PlayerControl.LocalPlayer);
        vampire.CorrectKills = valueTuple.Item1;
        vampire.IncorrectKills = valueTuple.Item2;
        vampire.CorrectAssassinKills = valueTuple.Item3;
        vampire.IncorrectAssassinKills = valueTuple.Item4;
        vampire.RegenTask();
      }
      else
      {
        Jackal vampire = new Jackal(newVamp);
        vampire.CorrectKills = valueTuple.Item1;
        vampire.IncorrectKills = valueTuple.Item2;
        vampire.CorrectAssassinKills = valueTuple.Item3;
        vampire.IncorrectAssassinKills = valueTuple.Item4;
      }
      if (!CustomGameOptions.NewVampCanAssassin)
        return;
      Assassin assassin = new Assassin(newVamp);
    }
  }
}
*/