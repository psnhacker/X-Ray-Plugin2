using UnityEngine;
using XrCore.Parser;
using System.Collections.Generic;
using System.Text.RegularExpressions;


public class Alife_Converter : Base_Parser
{
    private List<string> str = new List<string>();
    public List<string> items = new List<string>();
    public List<string> stalker = new List<string>();
    public List<string> monster = new List<string>();
    public List<string> anomaly = new List<string>();
    public List<string> explosive = new List<string>();
    public List<string> physic_object = new List<string>();
    public List<string> lights_hanging_lamp = new List<string>();
    public List<string> physic_destroyable_object = new List<string>();

    /// <summary>
    /// Запустить анализ данных
    /// </summary>
    /// <param name="textAsset"></param>
    public void Parse(TextAsset textAsset)
    {
        string[] textFile = textAsset.text.Split('\n');
        foreach (string st in textFile)
        {
            if (st.Contains("[") && st.Contains("]")
                && Regex.IsMatch(st, @"\d")
                && !Regex.IsMatch(st, @"\p{L}"))
            {
                DataConverter(str);
                str.Clear();
                continue;
            }
            else
            {
                str.Add(st);
                continue;
            }
        }
    }
    private void DataConverter(List<string> data)
    {
        foreach (string str in data) if (str.Contains("section_name = m_crow")) C_Base_Quest_Monster(data, "m_crow");
        foreach (string str in data) if (str.Contains("section_name = m_flesh_e")) C_Base_Quest_Monster(data, "m_flesh_e");
        foreach (string str in data) if (str.Contains("section_name = stalker_zombied")) C_Base_Quest_Monster(data, "stalker_zombied");
        foreach (string str in data) if (str.Contains("section_name = m_car")) C_Base_Quest_Monster(data, "m_car");
        foreach (string str in data) if (str.Contains("section_name = m_controller_normal")) C_Base_Quest_Monster(data, "m_controller_normal");
        foreach (string str in data) if (str.Contains("section_name = m_controller_normal_fat")) C_Base_Quest_Monster(data, "m_controller_normal_fat");
        foreach (string str in data) if (str.Contains("section_name = m_controller_old_fat")) C_Base_Quest_Monster(data, "m_controller_old_fat");
        foreach (string str in data) if (str.Contains("section_name = m_dog_e")) C_Base_Quest_Monster(data, "m_dog_e");
        foreach (string str in data) if (str.Contains("section_name = m_poltergeist_normal_flame")) C_Base_Quest_Monster(data, "m_poltergeist_normal_flame");
        foreach (string str in data) if (str.Contains("section_name = m_poltergeist_normal_tele")) C_Base_Quest_Monster(data, "m_poltergeist_normal_tele");
        foreach (string str in data) if (str.Contains("section_name = m_poltergeist_strong_flame")) C_Base_Quest_Monster(data, "m_poltergeist_strong_flame");
        foreach (string str in data) if (str.Contains("section_name = m_poltergeist_tele_outdoor")) C_Base_Quest_Monster(data, "m_poltergeist_tele_outdoor");
        foreach (string str in data) if (str.Contains("section_name = m_pseudodog_e")) C_Base_Quest_Monster(data, "m_pseudodog_e");
        foreach (string str in data) if (str.Contains("section_name = m_tushkano_e")) C_Base_Quest_Monster(data, "m_tushkano_e");
        foreach (string str in data) if (str.Contains("section_name = m_bloodsucker_e")) C_Base_Quest_Monster(data, "m_bloodsucker_e");
        foreach (string str in data) if (str.Contains("section_name = stalker_sakharov")) C_Base_Quest_Npc(data, "stalker_sakharov");
        foreach (string str in data) if (str.Contains("section_name = stalker_trader")) C_Base_Quest_Npc(data, "stalker_trader");
        foreach (string str in data) if (str.Contains("section_name = m_osoznanie")) C_Base_Quest_Npc(data, "m_osoznanie");
        foreach (string str in data) if (str.Contains("section_name = m_barman")) C_Base_Quest_Npc(data, "m_barman");
        foreach (string str in data) if (str.Contains("section_name = m_trader")) C_Base_Quest_Npc(data, "m_trader");
        foreach (string str in data) if (str.Contains("section_name = physic_destroyable_object")) C_Base_Physics_Destroy(data, "physic_destroyable_object");
        foreach (string str in data) if (str.Contains("section_name = physic_object")) C_Base_Physics(data, "physic_object");
        foreach (string str in data) if (str.Contains("section_name = lights_hanging_lamp")) C_Base_Light(data, "lights_hanging_lamp");
        foreach (string str in data) if (str.Contains("section_name = stalker")) C_Base_Stalker(data, "stalker");
        foreach (string str in data) if (str.Contains("section_name = stalker_monolith")) C_Base_Stalker(data, "stalker_monolith");
        foreach (string str in data) if (str.Contains("section_name = dog_weak")) C_Base_Monster(data, "dog_weak");
        foreach (string str in data) if (str.Contains("section_name = boar_weak")) C_Base_Monster(data, "boar_weak");
        foreach (string str in data) if (str.Contains("section_name = flesh_weak")) C_Base_Monster(data, "flesh_weak");
        foreach (string str in data) if (str.Contains("section_name = dog_strong")) C_Base_Monster(data, "dog_strong");
        foreach (string str in data) if (str.Contains("section_name = dog_normal")) C_Base_Monster(data, "dog_normal");
        foreach (string str in data) if (str.Contains("section_name = pseudodog_weak")) C_Base_Monster(data, "pseudodog_weak");
        foreach (string str in data) if (str.Contains("section_name = boar_normal")) C_Base_Monster(data, "boar_normal");
        foreach (string str in data) if (str.Contains("section_name = bloodsucker_normal")) C_Base_Monster(data, "bloodsucker_normal");
        foreach (string str in data) if (str.Contains("section_name = bloodsucker_strong")) C_Base_Monster(data, "bloodsucker_strong");
        foreach (string str in data) if (str.Contains("section_name = boar_strong")) C_Base_Monster(data, "boar_strong");
        foreach (string str in data) if (str.Contains("section_name = flesh_normal")) C_Base_Monster(data, "flesh_normal");
        foreach (string str in data) if (str.Contains("section_name = gigant_normal")) C_Base_Monster(data, "gigant_normal");
        foreach (string str in data) if (str.Contains("section_name = gigant_strong")) C_Base_Monster(data, "gigant_strong");
        foreach (string str in data) if (str.Contains("section_name = snork_jumper")) C_Base_Monster(data, "snork_jumper");
        foreach (string str in data) if (str.Contains("section_name = snork_normal")) C_Base_Monster(data, "snork_normal");
        foreach (string str in data) if (str.Contains("section_name = snork_outdoor")) C_Base_Monster(data, "snork_outdoor");
        foreach (string str in data) if (str.Contains("section_name = snork_strong")) C_Base_Monster(data, "snork_strong");
        foreach (string str in data) if (str.Contains("section_name = snork_weak")) C_Base_Monster(data, "snork_weak");
        foreach (string str in data) if (str.Contains("section_name = psy_dog")) C_Base_Monster(data, "psy_dog");
        foreach (string str in data) if (str.Contains("section_name = psy_dog_radar")) C_Base_Monster(data, "psy_dog_radar");
        foreach (string str in data) if (str.Contains("section_name = tushkano_normal")) C_Base_Monster(data, "tushkano_normal");
        foreach (string str in data) if (str.Contains("section_name = pseudodog_normal")) C_Base_Monster(data, "pseudodog_normal");
        foreach (string str in data) if (str.Contains("section_name = pseudodog_strong")) C_Base_Monster(data, "pseudodog_strong");
        foreach (string str in data) if (str.Contains("section_name = gunslinger_flash")) C_Base_Monster(data, "gunslinger_flash");
        foreach (string str in data) if (str.Contains("section_name = controller_tubeman")) C_Base_Monster(data, "controller_tubeman");
        foreach (string str in data) if (str.Contains("section_name = bread")) C_Base_Item(data, "bread");
        foreach (string str in data) if (str.Contains("section_name = af_ameba_mica")) C_Base_Item(data, "af_ameba_mica");
        foreach (string str in data) if (str.Contains("section_name = af_ameba_slug")) C_Base_Item(data, "af_ameba_slug");
        foreach (string str in data) if (str.Contains("section_name = af_dummy_glassbeads")) C_Base_Item(data, "af_dummy_glassbeads");
        foreach (string str in data) if (str.Contains("section_name = af_dummy_pellicle")) C_Base_Item(data, "af_dummy_pellicle");
        foreach (string str in data) if (str.Contains("section_name = af_dummy_spring")) C_Base_Item(data, "af_dummy_spring");
        foreach (string str in data) if (str.Contains("section_name = af_electra_moonlight")) C_Base_Item(data, "af_electra_moonlight");
        foreach (string str in data) if (str.Contains("section_name = af_fireball")) C_Base_Item(data, "af_fireball");
        foreach (string str in data) if (str.Contains("section_name = af_fuzz_kolobok")) C_Base_Item(data, "af_fuzz_kolobok");
        foreach (string str in data) if (str.Contains("section_name = af_gold_fish")) C_Base_Item(data, "af_gold_fish");
        foreach (string str in data) if (str.Contains("section_name = af_night_star")) C_Base_Item(data, "af_night_star");
        foreach (string str in data) if (str.Contains("section_name = af_rusty_sea-urchin")) C_Base_Item(data, "af_rusty_sea-urchin");
        foreach (string str in data) if (str.Contains("section_name = ammo_11.43x23_hydro")) C_Base_Item(data, "ammo_11.43x23_hydro");
        foreach (string str in data) if (str.Contains("section_name = ammo_12x76_dart")) C_Base_Item(data, "ammo_12x76_dart");
        foreach (string str in data) if (str.Contains("section_name = ammo_12x76_zhekan")) C_Base_Item(data, "ammo_12x76_zhekan");
        foreach (string str in data) if (str.Contains("section_name = ammo_5.45x39_ap")) C_Base_Item(data, "ammo_5.45x39_ap");
        foreach (string str in data) if (str.Contains("section_name = ammo_5.56x45_ap")) C_Base_Item(data, "ammo_5.56x45_ap");
        foreach (string str in data) if (str.Contains("section_name = ammo_5.56x45_ss190")) C_Base_Item(data, "ammo_5.56x45_ss190");
        foreach (string str in data) if (str.Contains("section_name = ammo_9x19_pbp")) C_Base_Item(data, "ammo_9x19_pbp");
        foreach (string str in data) if (str.Contains("section_name = ammo_9x39_pab9")) C_Base_Item(data, "ammo_9x39_pab9");
        foreach (string str in data) if (str.Contains("section_name = ammo_og-7b")) C_Base_Item(data, "ammo_og-7b");
        foreach (string str in data) if (str.Contains("section_name = ammo_vog-25")) C_Base_Item(data, "ammo_vog-25");
        foreach (string str in data) if (str.Contains("section_name = bread_a")) C_Base_Item(data, "bread_a");
        foreach (string str in data) if (str.Contains("section_name = dolg_outfit")) C_Base_Item(data, "dolg_outfit");
        foreach (string str in data) if (str.Contains("section_name = exo_outfit")) C_Base_Item(data, "exo_outfit");
        foreach (string str in data) if (str.Contains("section_name = decoder")) C_Base_Item(data, "decoder");
        foreach (string str in data) if (str.Contains("section_name = military_outfit")) C_Base_Item(data, "military_outfit");
        foreach (string str in data) if (str.Contains("section_name = monolit_outfit")) C_Base_Item(data, "monolit_outfit");
        foreach (string str in data) if (str.Contains("section_name = medkit_scientic")) C_Base_Item(data, "medkit_scientic");
        foreach (string str in data) if (str.Contains("section_name = wpn_abakan")) C_Base_Item(data, "wpn_abakan");
        foreach (string str in data) if (str.Contains("section_name = wpn_ak74")) C_Base_Item(data, "wpn_ak74");
        foreach (string str in data) if (str.Contains("section_name = wpn_ak74_m1")) C_Base_Item(data, "wpn_ak74_m1");
        foreach (string str in data) if (str.Contains("section_name = wpn_binoc")) C_Base_Item(data, "wpn_binoc");
        foreach (string str in data) if (str.Contains("section_name = wpn_groza")) C_Base_Item(data, "wpn_groza");
        foreach (string str in data) if (str.Contains("section_name = wpn_lr300")) C_Base_Item(data, "wpn_lr300");
        foreach (string str in data) if (str.Contains("section_name = wpn_lr300_m1")) C_Base_Item(data, "wpn_lr300_m1");
        foreach (string str in data) if (str.Contains("section_name = wpn_mp5")) C_Base_Item(data, "wpn_mp5");
        foreach (string str in data) if (str.Contains("section_name = wpn_rg-6")) C_Base_Item(data, "wpn_rg-6");
        foreach (string str in data) if (str.Contains("section_name = wpn_rpg7")) C_Base_Item(data, "wpn_rpg7");
        foreach (string str in data) if (str.Contains("section_name = wpn_vintorez")) C_Base_Item(data, "wpn_vintorez");
        foreach (string str in data) if (str.Contains("section_name = guitar_a")) C_Base_Item(data, "guitar_a");
        foreach (string str in data) if (str.Contains("section_name = pri_decoder_documents")) C_Base_Item(data, "pri_decoder_documents");
        foreach (string str in data) if (str.Contains("section_name = svoboda_heavy_outfit")) C_Base_Item(data, "svoboda_heavy_outfit");
        foreach (string str in data) if (str.Contains("section_name = svoboda_light_outfit")) C_Base_Item(data, "svoboda_light_outfit");
        foreach (string str in data) if (str.Contains("section_name = hunters_toz")) C_Base_Item(data, "hunters_toz");
        foreach (string str in data) if (str.Contains("section_name = specops_outfit")) C_Base_Item(data, "specops_outfit");
        foreach (string str in data) if (str.Contains("section_name = stalker_outfit")) C_Base_Item(data, "stalker_outfit");
        foreach (string str in data) if (str.Contains("section_name = grenade_rgd5")) C_Base_Item(data, "grenade_rgd5");
        foreach (string str in data) if (str.Contains("section_name = killer_outfit")) C_Base_Item(data, "killer_outfit");
        foreach (string str in data) if (str.Contains("section_name = hand_radio")) C_Base_Item(data, "hand_radio");
        foreach (string str in data) if (str.Contains("section_name = quest_case_02")) C_Base_Item(data, "quest_case_02");
        foreach (string str in data) if (str.Contains("section_name = dar_document4")) C_Base_Item(data, "dar_document4");
        foreach (string str in data) if (str.Contains("section_name = ammo_9x19_fmj")) C_Base_Item(data, "ammo_9x19_fmj");
        foreach (string str in data) if (str.Contains("section_name = bandit_outfit")) C_Base_Item(data, "bandit_outfit");
        foreach (string str in data) if (str.Contains("section_name = wpn_walther")) C_Base_Item(data, "wpn_walther");
        foreach (string str in data) if (str.Contains("section_name = medkit_army")) C_Base_Item(data, "medkit_army");
        foreach (string str in data) if (str.Contains("section_name = quest_case_01")) C_Base_Item(data, "quest_case_01");
        foreach (string str in data) if (str.Contains("section_name = conserva")) C_Base_Item(data, "conserva");
        foreach (string str in data) if (str.Contains("section_name = vodka")) C_Base_Item(data, "vodka");
        foreach (string str in data) if (str.Contains("section_name = energy_drink")) C_Base_Item(data, "energy_drink");
        foreach (string str in data) if (str.Contains("section_name = kolbasa")) C_Base_Item(data, "kolbasa");
        foreach (string str in data) if (str.Contains("section_name = wpn_ak74u")) C_Base_Item(data, "wpn_ak74u");
        foreach (string str in data) if (str.Contains("section_name = ammo_9x18_fmj")) C_Base_Item(data, "ammo_9x18_fmj");
        foreach (string str in data) if (str.Contains("section_name = wpn_pm")) C_Base_Item(data, "wpn_pm");
        foreach (string str in data) if (str.Contains("section_name = ammo_9x18_pmm")) C_Base_Item(data, "ammo_9x18_pmm");
        foreach (string str in data) if (str.Contains("section_name = bandage")) C_Base_Item(data, "bandage");
        foreach (string str in data) if (str.Contains("section_name = af_blood")) C_Base_Item(data, "af_blood");
        foreach (string str in data) if (str.Contains("section_name = wpn_bm16")) C_Base_Item(data, "wpn_bm16");
        foreach (string str in data) if (str.Contains("section_name = ammo_12x70_buck")) C_Base_Item(data, "ammo_12x70_buck");
        foreach (string str in data) if (str.Contains("section_name = af_medusa")) C_Base_Item(data, "af_medusa");
        foreach (string str in data) if (str.Contains("section_name = outfit_bandit_m1")) C_Base_Item(data, "outfit_bandit_m1");
        foreach (string str in data) if (str.Contains("section_name = af_electra_flash")) C_Base_Item(data, "af_electra_flash");
        foreach (string str in data) if (str.Contains("section_name = af_cristall_flower")) C_Base_Item(data, "af_cristall_flower");
        foreach (string str in data) if (str.Contains("section_name = af_electra_sparkler")) C_Base_Item(data, "af_electra_sparkler");
        foreach (string str in data) if (str.Contains("section_name = af_dummy_battery")) C_Base_Item(data, "af_dummy_battery");
        foreach (string str in data) if (str.Contains("section_name = af_dummy_dummy")) C_Base_Item(data, "af_dummy_dummy");
        foreach (string str in data) if (str.Contains("section_name = af_gravi")) C_Base_Item(data, "af_gravi");
        foreach (string str in data) if (str.Contains("section_name = af_mincer_meat")) C_Base_Item(data, "af_mincer_meat");
        foreach (string str in data) if (str.Contains("section_name = af_vyvert")) C_Base_Item(data, "af_vyvert");
        foreach (string str in data) if (str.Contains("section_name = ammo_11.43x23_fmj")) C_Base_Item(data, "ammo_11.43x23_fmj");
        foreach (string str in data) if (str.Contains("section_name = ammo_5.45x39_fmj")) C_Base_Item(data, "ammo_5.45x39_fmj");
        foreach (string str in data) if (str.Contains("section_name = antirad")) C_Base_Item(data, "antirad");
        foreach (string str in data) if (str.Contains("section_name = grenade_f1")) C_Base_Item(data, "grenade_f1");
        foreach (string str in data) if (str.Contains("section_name = explosive_barrel")) C_Base_Explosive(data, "explosive_barrel");
        foreach (string str in data) if (str.Contains("section_name = explosive_mobiltank")) C_Base_Explosive(data, "explosive_mobiltank");
        foreach (string str in data) if (str.Contains("section_name = explosive_barrel_low")) C_Base_Explosive(data, "explosive_barrel_low");
        foreach (string str in data) if (str.Contains("section_name = explosive_dinamit")) C_Base_Explosive(data, "explosive_dinamit");
        foreach (string str in data) if (str.Contains("section_name = explosive_fuelcan")) C_Base_Explosive(data, "explosive_fuelcan");
        foreach (string str in data) if (str.Contains("section_name = explosive_tank")) C_Base_Explosive(data, "explosive_tank");
        foreach (string str in data) if (str.Contains("section_name = zone_mosquito_bald_weak")) C_Base_Anomaly_Zone(data, "zone_mosquito_bald_weak");
        foreach (string str in data) if (str.Contains("section_name = zone_radioactive_killing")) C_Base_Anomaly_Zone(data, "zone_radioactive_killing");
        foreach (string str in data) if (str.Contains("section_name = zone_mincer_weak_noart")) C_Base_Anomaly_Zone(data, "zone_mincer_weak_noart");
        foreach (string str in data) if (str.Contains("section_name = zone_mosquito_bald_weak_noart")) C_Base_Anomaly_Zone(data, "zone_mosquito_bald_weak_noart");
        foreach (string str in data) if (str.Contains("section_name = zone_flame_small")) C_Base_Anomaly_Zone(data, "zone_flame_small");
        foreach (string str in data) if (str.Contains("section_name = zone_radioactive_average")) C_Base_Anomaly_Zone(data, "zone_radioactive_average");
        foreach (string str in data) if (str.Contains("section_name = zone_gravi_Zone_average")) C_Base_Anomaly_Zone(data, "zone_gravi_Zone_average");
        foreach (string str in data) if (str.Contains("section_name = zone_gravi_Zone_weak")) C_Base_Anomaly_Zone(data, "zone_gravi_Zone_weak");
        foreach (string str in data) if (str.Contains("section_name = zone_mincer_average")) C_Base_Anomaly_Zone(data, "zone_mincer_average");
        foreach (string str in data) if (str.Contains("section_name = zone_mincer_strong")) C_Base_Anomaly_Zone(data, "zone_mincer_strong");
        foreach (string str in data) if (str.Contains("section_name = zone_mincer_weak")) C_Base_Anomaly_Zone(data, "zone_mincer_weak");
        foreach (string str in data) if (str.Contains("section_name = zone_mosquito_bald_average")) C_Base_Anomaly_Zone(data, "zone_mosquito_bald_average");
        foreach (string str in data) if (str.Contains("section_name = zone_radioactive_strong")) C_Base_Anomaly_Zone(data, "zone_radioactive_strong");
        foreach (string str in data) if (str.Contains("section_name = zone_radioactive_weak")) C_Base_Anomaly_Zone(data, "zone_radioactive_weak");
        foreach (string str in data) if (str.Contains("section_name = zone_mine_field")) C_Base_Anomaly_Zone(data, "zone_mine_field");
        foreach (string str in data) if (str.Contains("section_name = zone_witches_galantine")) C_Base_Anomaly_Zone(data, "zone_witches_galantine");
        foreach (string str in data) if (str.Contains("section_name = zone_burning_fuzz_strong")) C_Base_Anomaly_Zone(data, "zone_burning_fuzz_strong");
        foreach (string str in data) if (str.Contains("section_name = zone_burning_fuzz1")) C_Base_Anomaly_Zone(data, "zone_burning_fuzz1");
        foreach (string str in data) if (str.Contains("section_name = zone_buzz")) C_Base_Anomaly_Zone(data, "zone_buzz");
        foreach (string str in data) if (str.Contains("section_name = zone_buzz_average")) C_Base_Anomaly_Zone(data, "zone_buzz_average");
        foreach (string str in data) if (str.Contains("section_name = zone_campfire_grill")) C_Base_Anomaly_Zone(data, "zone_campfire_grill");
        foreach (string str in data) if (str.Contains("section_name = zone_emi")) C_Base_Anomaly_Zone(data, "zone_emi");
        foreach (string str in data) if (str.Contains("section_name = zone_flame")) C_Base_Anomaly_Zone(data, "zone_flame");
        foreach (string str in data) if (str.Contains("section_name = zone_gravi_zone")) C_Base_Anomaly_Zone(data, "zone_gravi_zone");
        foreach (string str in data) if (str.Contains("section_name = zone_gravi_Zone_strong")) C_Base_Anomaly_Zone(data, "zone_gravi_Zone_strong");
        foreach (string str in data) if (str.Contains("section_name = zone_mincer")) C_Base_Anomaly_Zone(data, "zone_mincer");
        foreach (string str in data) if (str.Contains("section_name = zone_monolith")) C_Base_Anomaly_Zone(data, "zone_monolith");
        foreach (string str in data) if (str.Contains("section_name = zone_mosquito_bald")) C_Base_Anomaly_Zone(data, "zone_mosquito_bald");
        foreach (string str in data) if (str.Contains("section_name = zone_mosquito_bald_strong")) C_Base_Anomaly_Zone(data, "zone_mosquito_bald_strong");
        foreach (string str in data) if (str.Contains("section_name = zone_mosquito_bald_strong_noart")) C_Base_Anomaly_Zone(data, "zone_mosquito_bald_strong_noart");
        foreach (string str in data) if (str.Contains("section_name = zone_no_gravity")) C_Base_Anomaly_Zone(data, "zone_no_gravity");
        foreach (string str in data) if (str.Contains("section_name = zone_radioactive")) C_Base_Anomaly_Zone(data, "zone_radioactive");
        foreach (string str in data) if (str.Contains("section_name = zone_teleport")) C_Base_Anomaly_Zone(data, "zone_teleport");
        foreach (string str in data) if (str.Contains("section_name = zone_witches_galantine_average")) C_Base_Anomaly_Zone(data, "zone_witches_galantine_average");
        foreach (string str in data) if (str.Contains("section_name = zone_witches_galantine_strong")) C_Base_Anomaly_Zone(data, "zone_witches_galantine_strong");
        foreach (string str in data) if (str.Contains("section_name = zone_zhar")) C_Base_Anomaly_Zone(data, "zone_zhar");
        foreach (string str in data) if (str.Contains("section_name = zone_zharka_static_average")) C_Base_Anomaly_Zone(data, "zone_zharka_static_average");
        foreach (string str in data) if (str.Contains("section_name = zone_zharka_static_strong")) C_Base_Anomaly_Zone(data, "zone_zharka_static_strong");
        foreach (string str in data) if (str.Contains("section_name = zone_zharka_static_weak")) C_Base_Anomaly_Zone(data, "zone_zharka_static_weak");
        foreach (string str in data) if (str.Contains("section_name = fireball_zone")) C_Base_Anomaly_Zone(data, "fireball_zone");
        foreach (string str in data) if (str.Contains("section_name = medkit") && !str.Contains("section_name = medkit_army") && !str.Contains("section_name = medkit_scientic")) C_Base_Item(data, "medkit");
    }

    private void C_Base_Physics(List<string> objects, string object_name)            { physic_object.Add(B_Base_Physics(objects, object_name)); }
    private void C_Base_Light(List<string> objects, string lamp_name)                { lights_hanging_lamp.Add(B_Base_Light(objects, lamp_name)); }
    private void C_Base_Stalker(List<string> objects, string stalker_name)           { stalker.Add(B_Base_Stalker(objects, stalker_name)); }
    private void C_Base_Monster(List<string> objects, string mutant_name)            { monster.Add(B_Base_Monster(objects, mutant_name)); }
    private void C_Base_Item(List<string> objects, string item_name)                 { items.Add(B_Base_Item(objects, item_name)); }
    private void C_Base_Anomaly_Zone(List<string> objects, string anomaly_name)      { anomaly.Add(B_Base_Anomaly_Zone(objects, anomaly_name)); }
    private void C_Base_Explosive(List<string> objects, string object_name)          { explosive.Add(B_Base_Explosive(objects, object_name)); }
    private void C_Base_Physics_Destroy(List<string> objects, string object_name)    { physic_destroyable_object.Add(B_Base_Physics_Destroy(objects, object_name)); }
    //static void C_Base_Quest_Npc(List<string> objects, string npc_name)             { stalker.Add(B_Base_Quest_Npc(objects, npc_name)); }
    //static void C_Base_Quest_Monster(List<string> objects, string monster_name)     { monster.Add(B_Base_Quest_Monster(objects, monster_name)); }
    private void C_Base_Quest_Npc(List<string> objects, string npc_name)             { stalker.Add(B_Base_Stalker(objects, npc_name)); }
    private void C_Base_Quest_Monster(List<string> objects, string monster_name)     { monster.Add(B_Base_Monster(objects, monster_name)); }
}
