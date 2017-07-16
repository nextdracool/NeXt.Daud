using System;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace NeXt.Daud.Model
{
    [JsonObject(MemberSerialization.OptIn)]
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class Profile : IEquatable<Profile>, IIdentifiable
    {
        [JsonObject(MemberSerialization.OptIn)]
        public class SpeedrunSettings
        {
            [JsonProperty("engine")]
            public bool Engine { get; set; }

            [JsonProperty("keybinds")]
            public bool Keybinds { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class DaudSettings
        {
            [JsonProperty("knife_of_dunwall")]
            public bool KnifeOfDunwall { get; set; }

            [JsonProperty("brigmore_witches")]
            public bool BrigmoreWitches { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class MovieSettings
        {
            [JsonProperty("disable_intro")]
            public bool Intro { get; set; }

            [JsonProperty("disable_loadscreen")]
            public bool Loadscreen { get; set; }
        }

        public static Profile Default { get; } = new Profile
        {
            Name = "Default",
            Speedrun = new SpeedrunSettings(),
            Daud = new DaudSettings(),
            Movies = new MovieSettings(),
        };
        
        private Profile(Profile p)
        {
            Id = p.Id;
            Update(p);
        }

        public Profile()
        {
            Id = Guid.NewGuid();
            Name = string.Empty;
            Speedrun = new SpeedrunSettings();
        }
        
        [JsonProperty("id")]
        public Guid Id { get; private set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("speedrun")]
        public SpeedrunSettings Speedrun { get; set; }

        [JsonProperty("daud")]
        public DaudSettings Daud { get; set; }

        [JsonProperty("movies")]
        public MovieSettings Movies { get; set; }

        /// <summary>
        /// Returns a new profile with the same Id as this one
        /// </summary>
        /// <returns></returns>
        public Profile Clone()
        {
            return new Profile(this);
        }

        /// <summary>
        /// Creates a new Profile from this profile with a seperate Id and alters the name
        /// </summary>
        /// <returns></returns>
        public Profile Duplicate()
        {
            var p = Clone();
            p.Id = Guid.NewGuid();
            p.Name = (p.Name ?? string.Empty) + " (Copy)";
            return p;
        }

        /// <summary>
        /// Copies values from <paramref name="p"/> over to this profile
        /// <para>Note: <paramref name="p"/> and this profile must have the same Id</para>
        /// </summary>
        /// <param name="p">the profile to update from</param>
        public void Update(Profile p)
        {
            if (p.Id != Id) throw new InvalidOperationException("Cannot update profile from wrong Id");

            Name = p.Name;
            Speedrun = new SpeedrunSettings
            {
                Engine = p.Speedrun.Engine,
                Keybinds = p.Speedrun.Keybinds,
            };
            Daud = new DaudSettings
            {
                KnifeOfDunwall = p.Daud.KnifeOfDunwall,
                BrigmoreWitches = p.Daud.BrigmoreWitches,
            };

            Movies = new MovieSettings
            {
                Intro = p.Movies.Intro,
                Loadscreen = p.Movies.Loadscreen,
            };
        }

        [SuppressMessage("ReSharper", "NonReadonlyMemberInGetHashCode")] // Id is readonly in practice, never changes after creation or when an existing object is duplicated
        public override int GetHashCode() => Id.GetHashCode();
        public override bool Equals(object obj) => Equals(obj as Profile);
        public bool Equals(Profile other) => other?.Id == Id;
    }
}
