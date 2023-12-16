using CharacterHistoryRole.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterHistoryRole.Data.Models
{
    public partial class CharacterHistoryRoleContext : DbContext
    {        

        public CharacterHistoryRoleContext() { }

        public CharacterHistoryRoleContext(DbContextOptions<CharacterHistoryRoleContext> options) : base(options)
        {

        }

        public virtual DbSet<AtributesAbilities> AtributesAbilities { get; set; }
        public virtual DbSet<BackPack> BackPack { get; set; }
        public virtual DbSet<BackPackItem> BackPackItem { get; set; }
        public virtual DbSet<CharacterBio> CharacterBio { get; set; }
        public virtual DbSet<CharacterBioDetail> CharacterBioDetail { get; set; }
        public virtual DbSet<ClassRace> ClassRace { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<Permmission> Permmission { get; set; }
        public virtual DbSet<Profile> Profile { get; set; }
        public virtual DbSet<ProfilePermmission> ProfilePermmission { get; set; }
        public virtual DbSet<Race> Race { get; set; }
        public virtual DbSet<RacialBackground> RacialBackground { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserGroup> UserGroup { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(k => k.UserId);
                entity.Property(p => p.UserId).ValueGeneratedNever();

                entity.HasMany(m => m.ProfilePermmissions)
                    .WithOne(o => o.User)
                    .HasForeignKey(p => p.ProfileId)
                    .HasConstraintName("FK_User_ProfilePermmissions");
            });

            modelBuilder.Entity<ProfilePermmission>(entity =>
            {
                entity.HasKey(k => new { k.ProfileId })
                    .HasName("PK_ProfilePermmissions");

                entity.HasOne(o => o.Permmission)
                    .WithMany(m => m.ProfilePermmission)
                    .HasForeignKey(p => p.PermmissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProfilePermmisions_Permmissions");

                entity.HasOne(o => o.Profile)
                    .WithMany(m => m.ProfilePermmission)
                    .HasForeignKey(p => p.ProfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProfilePermmissions_Profile");
            });

            modelBuilder.Entity<UserGroup>(entity => {
                entity.HasKey(k => new { k.UserId })
                    .HasName("PK_UserGroup");

                entity.HasOne(o => o.User)
                    .WithMany(m => m.UserGroups)
                    .HasForeignKey(p => p.UserId)
                    .HasConstraintName("FK_UserGroups_Users");

                entity.HasOne(o => o.Group)
                    .WithMany(m => m.UserGroups)
                    .HasForeignKey(p => p.GroupId)
                    .HasConstraintName("FK_UserGroups_Group");

            });

            modelBuilder.Entity<Profile>(entity => {
                entity.HasKey(k => k.ProfileId);
                entity.Property(p => p.ProfileId).ValueGeneratedNever();

                entity.Property(p => p.ProfileName)
                    .IsRequired();
                    
            });

            modelBuilder.Entity<Permmission>(entity => {
                entity.HasKey(k => k.PermmissionId);
                entity.Property(p => p.PermmissionId).ValueGeneratedNever();

                entity.Property(p => p.PermmissionName)
                    .IsRequired();

            });

            modelBuilder.Entity<Group>(entity => {
                entity.HasKey(k => k.GroupId);
                entity.Property(p => p.GroupId).ValueGeneratedNever();

                entity.Property(p => p.GroupName)
                    .IsRequired();                
            });

            modelBuilder.Entity<CharacterBio>(entity => {
                entity.HasKey(k => new { k.CharacterBioId })
                    .HasName("PK_Bio_User_Group");

                entity.Property(p => p.CharacterBioId).ValueGeneratedNever();

                entity.HasMany(m => m.UserGroup)
                    .WithOne(o => o.CharacterBio)
                    .HasForeignKey(f => f.GroupId)
                    .HasConstraintName("FK_UserGroup_CharacterBio");

                entity.HasOne(o => o.User)
                    .WithMany(m => m.CharacterBio)
                    .HasForeignKey(f => f.UserId)
                    .HasConstraintName("FK_User_Character_Bio");
            });

            modelBuilder.Entity<CharacterBioDetail>(entity => {
                entity.HasKey(k => new { k.CharacterBioDetailId });

                entity.HasOne(cbd => cbd.Race)
                .WithOne(r => r.CharacterBioDetail)
                .HasForeignKey<Race>(r => r.RaceId);

                 entity.HasOne(cbd => cbd.ClassRace)
                    .WithOne(cr => cr.CharacterBioDetail)
                    .HasForeignKey<ClassRace>(cr => cr.ClassRaceId);

                entity.HasOne(cbd => cbd.CharacterBio)
                    .WithOne(cr => cr.CharacterBioDetail)
                    .HasForeignKey<CharacterBio>(cr => cr.CharacterBioId);
            });

            modelBuilder.Entity<ClassRace>(entity => {
                entity.HasKey(k => k.ClassRaceId);
                entity.Property(p => p.ClassRaceId).ValueGeneratedNever();

                entity.Property(p => p.ClassRaceName).IsRequired();
            });

            modelBuilder.Entity<Race>(entity => {
                entity.HasKey(k => k.RaceId);
                entity.Property(p => p.RaceId).ValueGeneratedNever();

                entity.Property(p => p.RaceName).IsRequired();
            });

            modelBuilder.Entity<BackPack>(entity => {
                entity.HasKey(k => new { k.BackPackId })
                    .HasName("PK_BackPack_CharacterBio");

                entity.Property(p => p.BackPackId).ValueGeneratedNever();
                entity.Property(p => p.Capacity).IsRequired();
                entity.Property(p => p.Description).IsRequired();

                entity.HasOne(cbd => cbd.CharacterBio)
                    .WithMany(m => m.BackPack)
                    .HasForeignKey(k => k.CharacterBioId);
            });

            modelBuilder.Entity<BackPackItem>(entity => {
                entity.HasKey(k => new { k.BackPackItemId });
                entity.Property(p => p.BackPackItemId).ValueGeneratedNever();
                entity.Property(p => p.Description).IsRequired();

                entity.HasOne(o => o.BackPack)
                    .WithMany(m => m.BackPackItem)
                    .HasForeignKey(f => f.BackPackId)
                    .HasConstraintName("FK_BackPackItem_BackPack");
            });

            modelBuilder.Entity<RacialBackground>(entity => {
                entity.HasKey(k => new { k.RacialBackgroundId });
                entity.Property(p => p.RacialBackgroundId).ValueGeneratedNever();
                entity.Property(p => p.Description).IsRequired();

                entity.HasOne(o => o.CharacterBioDetail)
                    .WithMany(m => m.RacialBackground)
                    .HasForeignKey(f => f.CharacterBioDetailId)
                    .HasConstraintName("FK_RacilBackGroud_CharacterBioDetail"); ;
            });

            modelBuilder.Entity<AtributesAbilities>(entity => {
                entity.HasKey(k => new { k.CharacterBioDetailId });
                entity.Property(p => p.AtributesAbilitiesId).ValueGeneratedNever();
                entity.Property(p => p.Description).IsRequired();

                entity.HasOne(o => o.CharacterBioDetail)
                    .WithMany(m => m.AtributesAbilities)
                    .HasForeignKey(f => f.CharacterBioDetailId)
                    .HasConstraintName("FK_Atributies_CharacterBioDetail");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
