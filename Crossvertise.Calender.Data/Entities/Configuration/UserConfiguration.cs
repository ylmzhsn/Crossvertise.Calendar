namespace Crossvertise.Calender.Data.Entities.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// User Entity Configuration Class
    /// </summary>
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.Property(x => x.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.HasMany(t => t.AttendeeAppointments)
                  .WithMany(t => t.Attendees)
                  .UsingEntity<UserAppointment>(
                  x => x.HasOne(t => t.Appointment)
                      .WithMany(t => t.UserAppointment)
                      .HasForeignKey(t => t.AppointmentId),
                  x => x.HasOne(t => t.User)
                      .WithMany(p => p.UserAppointment)
                      .HasForeignKey(t => t.UserId));

            builder.HasMany(t => t.OrganizedAppointments)
                      .WithOne(t => t.Organizer)
                      .HasForeignKey(t => t.OrganizerId); 

            builder.HasData
            (
                new User
                {
                    Id = 1,
                    UserName = "Max Mustermann"
                },
                new User
                {
                    Id = 2,
                    UserName = "John Smith"
                },
                new User
                {
                    Id = 3,
                    UserName = "Robert Turner"
                },
                new User
                {
                    Id = 4,
                    UserName = "Erika Gobler"
                }
            );
        }
    }
}
