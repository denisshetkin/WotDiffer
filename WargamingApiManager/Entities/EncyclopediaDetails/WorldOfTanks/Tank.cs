﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using WargamingApiManager.Entities.EncyclopediaDetails.WorldOfTanks.Modules;

namespace WargamingApiManager.Entities.EncyclopediaDetails.WorldOfTanks
{
    public class Tank : Vehicle
    {
        /// <summary>
        /// Tank id
        /// </summary>
        [JsonProperty("tank_id")]
        public long Id { get; set; }

        /// <summary>
        /// Standard suspension traverse speed
        /// </summary>
        [JsonProperty("chassis_rotation_speed")]
        public long SuspensionRotationSpeed { get; set; }

        /// <summary>
        /// Standard turret view range
        /// </summary>
        [JsonProperty("circular_vision_radius")]
        public long CircularVisionRadius { get; set; }

        /// <summary>
        /// URL to outline image of vehicle
        /// </summary>
        [JsonProperty("contour_image")]
        public string ContourImage { get; set; }

        /// <summary>
        /// Standard engine power
        /// </summary>
        [JsonProperty("engine_power")]
        public long EnginePower { get; set; }

        /// <summary>
        /// Maximum damage of standard gun
        /// </summary>
        [JsonProperty("gun_damage_max")]
        public long GunDamageMax { get; set; }

        /// <summary>
        /// Minimum damage of standard gun
        /// </summary>
        [JsonProperty("gun_damage_min")]
        public long GunDamageMin { get; set; }

        /// <summary>
        /// Ammunition of standard gun
        /// </summary>
        [JsonProperty("gun_max_ammo")]
        public long GunMaxAmmo { get; set; }

        /// <summary>
        /// Standard gun name
        /// </summary>
        [JsonProperty("gun_name")]
        public string GunName { get; set; }

        /// <summary>
        /// Maximum penetration of standard gun
        /// </summary>
        [JsonProperty("gun_piercing_power_max")]
        public long GunPiercingPowerMax { get; set; }

        /// <summary>
        /// Minimum penetration of standard gun
        /// </summary>
        [JsonProperty("gun_piercing_power_min")]
        public long GunPiercingPowerMin { get; set; }

        /// <summary>
        /// Rate of fire of standard gun
        /// </summary>
        [JsonProperty("gun_rate")]
        public decimal GunRateOfFire { get; set; }

        /// <summary>
        /// URL to 160 x 100 px image of vehicle
        /// </summary>
        [JsonProperty("image")]
        public string Image { get; set; }

        /// <summary>
        /// URL to 124 x 31 px image of vehicle
        /// </summary>
        [JsonProperty("image_small")]
        public string ImageSmall { get; set; }

        /// <summary>
        /// Gift vehicle
        /// </summary>
        [JsonProperty("is_gift")]
        public bool IsGift { get; set; }

        /// <summary>
        /// Load limit
        /// </summary>
        [JsonProperty("limit_weight")]
        public decimal LoadLimit { get; set; }

        /// <summary>
        /// Localized name
        /// </summary>
        [JsonProperty("localized_name")]
        [Obsolete("Warning. The field will be disabled.")]
        public string LocalizedNameObs { get; set; }

        /// <summary>
        /// Hit Points
        /// </summary>
        [JsonProperty("max_health")]
        public long HitPoints { get; set; }

        /// <summary>
        /// Purchase cost in credits
        /// </summary>
        [JsonProperty("price_credit")]
        public long PriceCredit { get; set; }

        /// <summary>
        /// Purchase cost in gold
        /// </summary>
        [JsonProperty("price_gold")]
        public long PriceGold { get; set; }

        /// <summary>
        /// Signal range of standard radio
        /// </summary>
        [JsonProperty("radio_distance")]
        public long RadioDistance { get; set; }

        /// <summary>
        /// Speed Limit
        /// </summary>
        [JsonProperty("speed_limit")]
        public decimal SpeedLimit { get; set; }

        /// <summary>
        /// Standard turret armor: front
        /// </summary>
        [JsonProperty("turret_armor_forehead")]
        public long TurretArmorFront { get; set; }

        /// <summary>
        /// Standard turret armor: rear
        /// </summary>
        [JsonProperty("turret_armor_fedd")]
        public long TurretArmorRear { get; set; }

        /// <summary>
        /// Standard turret armor: sides
        /// </summary>
        [JsonProperty("turret_armor_board")]
        public long TurretArmorSides2 { get; set; }

        /// <summary>
        /// Standard turret traverse speed
        /// </summary>
        [JsonProperty("turret_rotation_speed")]
        public long TurretRotationSpeed { get; set; }

        /// <summary>
        /// Hull armor: sides
        /// </summary>
        [JsonProperty("vehicle_armor_board")]
        public long ArmorSides { get; set; }

        /// <summary>
        /// Hull armor: rear
        /// </summary>
        [JsonProperty("vehicle_armor_fedd")]
        public long ArmorRear { get; set; }

        /// <summary>
        /// Hull armor: front
        /// </summary>
        [JsonProperty("vehicle_armor_forehead")]
        public long ArmorFront { get; set; }

        /// <summary>
        /// Parent vehicles in Tech Tree
        /// </summary>
        [JsonProperty("parent_tanks")]
        [Obsolete("Warning. The field will be disabled.")]
        public List<long> ParentTanks { get; set; }

        /// <summary>
        /// Cost of research in experience
        /// </summary>
        [JsonProperty("price_xp")]
        [Obsolete("Warning. The field will be disabled.")]
        public long? PriceXp { get; set; }

        /// <summary>
        /// Weight
        /// </summary>
        [JsonProperty("weight")]
        public decimal Weight { get; set; }

        [JsonProperty("chassis")]
        public List<Chassis> Suspensions { get; set; }

        [JsonProperty("engines")]
        public List<Engine> Engines { get; set; }

        [JsonProperty("guns")]
        public List<Gun> Guns { get; set; }

        [JsonProperty("radios")]
        public List<Radio> Radios { get; set; }

        [JsonProperty("turrets")]
        public List<Turret> Turrets { get; set; }
    }
}
