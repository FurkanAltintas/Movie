using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MvcMovieTicketSales.Models.EntityFramework
{
    public partial class MovieMvc : DbContext
    {
        public MovieMvc()
            : base("name=MovieMvc")
        {
        }

        public virtual DbSet<Authority> Authority { get; set; }
        public virtual DbSet<CardInformation> CardInformation { get; set; }
        public virtual DbSet<Celebrite> Celebrite { get; set; }
        public virtual DbSet<CelebriteDetail> CelebriteDetail { get; set; }
        public virtual DbSet<CelebriteFollow> CelebriteFollow { get; set; }
        public virtual DbSet<CelebriteTask> CelebriteTask { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Director> Director { get; set; }
        public virtual DbSet<DirectorDetail> DirectorDetail { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeFollow> EmployeeFollow { get; set; }
        public virtual DbSet<EmployeeSkill> EmployeeSkill { get; set; }
        public virtual DbSet<Hall> Hall { get; set; }
        public virtual DbSet<HallDetail> HallDetail { get; set; }
        public virtual DbSet<Member> Member { get; set; }
        public virtual DbSet<Month> Month { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<MovieCalendar> MovieCalendar { get; set; }
        public virtual DbSet<MovieCategory> MovieCategory { get; set; }
        public virtual DbSet<MovieDate> MovieDate { get; set; }
        public virtual DbSet<MovieFormat> MovieFormat { get; set; }
        public virtual DbSet<MovieFormatDetail> MovieFormatDetail { get; set; }
        public virtual DbSet<MovieHours> MovieHours { get; set; }
        public virtual DbSet<MovieType> MovieType { get; set; }
        public virtual DbSet<Seat> Seat { get; set; }
        public virtual DbSet<SeatDetail> SeatDetail { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }
        public virtual DbSet<SocialMedia> SocialMedia { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TicketSale> TicketSale { get; set; }
        public virtual DbSet<Update> Update { get; set; }
        public virtual DbSet<WatchList> WatchList { get; set; }
        public virtual DbSet<WriterDetail> WriterDetail { get; set; }
        public virtual DbSet<Year> Year { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Month>()
                .HasMany(e => e.CardInformation)
                .WithOptional(e => e.Month)
                .HasForeignKey(e => e.ExpiryDateMonth);

            modelBuilder.Entity<Seat>()
                .Property(e => e.Row)
                .IsFixedLength();

            modelBuilder.Entity<Seat>()
                .Property(e => e.Code)
                .IsFixedLength();

            modelBuilder.Entity<Year>()
                .HasMany(e => e.CardInformation)
                .WithOptional(e => e.Year)
                .HasForeignKey(e => e.ExpiryDateYear);
        }
    }
}
