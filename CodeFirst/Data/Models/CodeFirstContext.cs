using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CodeFirst.Data.Models;

namespace CodeFirst.Data.Models
{
    public partial class CodeFirstContext : DbContext
    {
        public CodeFirstContext()
        {
        }

        public CodeFirstContext(DbContextOptions<CodeFirstContext> options) : base (options)
        {
        }
        public virtual DbSet<Bets> Bets { get; set; }
        public virtual DbSet<Colors> Colors { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Games> Games { get; set; }
        public virtual DbSet<Players> Players { get; set; }
        public virtual DbSet<PlayerStatistics> PlayerStatistics { get; set; }
        public virtual DbSet<Positions> Positions { get; set; }
        public virtual DbSet<Teams> Teams { get; set; }
        public virtual DbSet<Towns> Towns { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=CodeFirst;Integrated Security=True;");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bets>(entity =>
            {
                entity.HasKey(e => e.BetId);
                entity.Property(e => e.BetId).HasColumnName("BetId");
                entity.Property(e => e.Amount).HasColumnName("Amount");
                entity.Property(e => e.GameId).HasColumnName("GameId");
                entity.Property(e => e.Prediction).HasColumnName("Prediction");
                entity.Property(e => e.DateTime).HasColumnType("smalldatetime");
                entity.Property(e => e.UserId).HasColumnName("UserId");
                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Bets)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_Bets_Games");
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bets)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_Bets_Users");
            });

            modelBuilder.Entity<Colors>(entity =>
            {
                entity.HasKey(e => e.ColorId);
                entity.Property(e => e.ColorId).HasColumnName("ColorId");
                entity.Property(e => e.Name)
                .HasColumnName("Name")
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(64);
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.HasKey(e => e.CountryId);
                entity.Property(e => e.CountryId).HasColumnName("CountryId");
                entity.Property(e => e.Name)
                .HasColumnName("Name")
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(64);
            });

            modelBuilder.Entity<Games>(entity =>
            {
                entity.HasKey(e => e.GameId);
                entity.Property(e => e.GameId).HasColumnName("GameId");
                entity.Property(e => e.AwayTeamBetRate).HasColumnName("AwayTeamBetRate");
                entity.Property(e => e.AwayTeamGoals).HasColumnName("AwayTeamGoals");
                entity.Property(e => e.AwayTeamId).HasColumnName("AwayTeamId");
                entity.Property(e => e.DrowBetRate).HasColumnName("DrowBetRate");
                entity.Property(e => e.HomeTeamBetRate).HasColumnName("HomeTeamBetRate");
                entity.Property(e => e.HomeTeamGoals).HasColumnName("HomeTeamGoals");
                entity.Property(e => e.HomeTeamId).HasColumnName("HomeTeamId");
                entity.Property(e => e.Result).HasColumnName("Result");
                entity.Property(e => e.DateTime).HasColumnType("smalldatetime");
                entity.HasOne(d => d.TeamAway)
                    .WithMany(p => p.AwayTeam)
                    .HasForeignKey(d => d.AwayTeamId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_Games_TeamAways");
                entity.HasOne(d => d.TeamHome)
                    .WithMany(p => p.HomeTeam)
                    .HasForeignKey(d => d.HomeTeamId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_Games_HomeTeams");
            });

            modelBuilder.Entity<Players>(entity =>
            {
                entity.HasKey(e => e.PlayerId);
                entity.Property(e => e.PlayerId).HasColumnName("PlayerId");
                entity.Property(e => e.PositionId).HasColumnName("PositionId");
                entity.Property(e => e.SquadNumber).HasColumnName("SquadNumber");
                entity.Property(e => e.TeamId).HasColumnName("TeamId");
                entity.Property(e => e.IsInjured)
                .HasColumnName("IsInjured")
                .IsUnicode();
                entity.Property(e => e.Name)
                .HasColumnName("Name")
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(64);
                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_Players_Positions");
                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_Players_Teams");
            });

            modelBuilder.Entity<PlayerStatistics>(entity =>
            {
                entity.HasKey(e => new { e.PlayerId, e.GameId });
                entity.Property(e => e.PlayerId).HasColumnName("PlayerId");
                entity.Property(e => e.GameId).HasColumnName("GameId");
                entity.Property(e => e.Assists).HasColumnName("Assists");
                entity.Property(e => e.MinutesPlayed).HasColumnName("MinutesPlayed");
                entity.Property(e => e.ScoredGoals).HasColumnName("ScoredGoals");   
                entity.HasOne(d => d.Player)
                    .WithMany(p => p.PlayerStatistics)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_PlayerStatistics_Players");
                entity.HasOne(d => d.Game)
                    .WithMany(p => p.PlayerStatistics)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_PlayerStatistics_Games");
            });

            modelBuilder.Entity<Positions>(entity =>
            {
                entity.HasKey(e => e.PositionId);
                entity.Property(e => e.PositionId).HasColumnName("PositionId");
                entity.Property(e => e.Name)
                .HasColumnName("Name")
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(32);
            });

            modelBuilder.Entity<Teams>(entity =>
            {
                entity.HasKey(e => e.TeamId);
                entity.Property(e => e.TeamId).HasColumnName("TeamId");
                entity.Property(e => e.Budget).HasColumnName("Budget");
                entity.Property(e => e.Initials).HasColumnName("Initials");
                entity.Property(e => e.PrimaryKitColorId).HasColumnName("PrimaryKitColorId");
                entity.Property(e => e.SecondaryKitColorId).HasColumnName("SecondaryKitColorId");
                entity.Property(e => e.TownId).HasColumnName("TownId");
                entity.Property(e => e.LogoUrl)
                .HasColumnName("LogoUrl")
                .IsRequired()
                .IsUnicode();
                entity.Property(e => e.Name)
                .HasColumnName("Name")
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(128);
                entity.HasOne(d => d.PrimaryKitColor)
                    .WithMany(p => p.Color1)
                    .HasForeignKey(d => d.PrimaryKitColorId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_Teams_PrimaryKitColors");
                entity.HasOne(d => d.SecondaryKitColor)
                    .WithMany(p => p.Color2)
                    .HasForeignKey(d => d.SecondaryKitColorId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_Teams_SecondaryKitColors");
                entity.HasOne(d => d.Town)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.TownId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_Teams_Towns");
            });

            modelBuilder.Entity<Towns>(entity =>
            {
                entity.HasKey(e => e.TownId);
                entity.Property(e => e.TownId).HasColumnName("TownId");
                entity.Property(e => e.CountryId).HasColumnName("CountryId");
                entity.Property(e => e.Name)
                 .HasColumnName("Name")
                 .IsRequired()
                 .IsUnicode()
                 .HasMaxLength(64);
                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Towns)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_Towns_Countries");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.UserId).HasColumnName("UserId");
                entity.Property(e => e.Balance).HasColumnName("Balance");
                entity.Property(e => e.Email)
                .HasColumnName("Email")
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(64);
                entity.Property(e => e.Name)
                .HasColumnName("Name")
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(128);
                entity.Property(e => e.Password)
                .HasColumnName("Password")
                .IsRequired()
                .IsUnicode();
                entity.Property(e => e.Username)
                .HasColumnName("Username")
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(128);
            });
        }
    }
}
