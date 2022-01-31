namespace Crossvertise.Calendar.Service.Tests.Data
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;

    using Crossvertise.Calendar.Service.Data.Abstract;
    using Crossvertise.Calendar.Service.Data.Concrete;
    using Crossvertise.Calender.Data.Abstract;
    using Crossvertise.Calender.Data;
    using Crossvertise.Calender.Data.Entities;

    /// <summary>
    /// Test for <see cref="AppointmentDataService"/>
    /// </summary>
    [TestFixture]
    public class AppointmentDataServiceTests
    {
        private IApplicationContext _applicationContext;

        private IAppointmentDataService _appointmentDataService;

        [OneTimeSetUp]
        public void Init()
        {
            _applicationContext = ApplicationContext();

            _appointmentDataService = new AppointmentDataService(_applicationContext);
        }

        private ApplicationContext ApplicationContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            var applicationContext = new ApplicationContext(options);      

            applicationContext.Database.EnsureCreated();

            applicationContext.Users.Add(new User()
            {
                Id = 1,
                UserName = $"Test User1",
                CreatedAt = DateTime.UtcNow,
            });

            applicationContext.Users.Add(new User()
            {
                Id = 2,
                UserName = $"Test User2",
                CreatedAt = DateTime.UtcNow,
            });

            applicationContext.Users.Add(new User()
            {
                Id = 3,
                UserName = $"Test User3",
                CreatedAt = DateTime.UtcNow,
            });

            applicationContext.Appointments.Add(new Appointment()
            {
                Id = 1,
                OrganizerId = 1,
                Description = $"Test Description1",
                Date = new DateTime(2022, 1, 31, 17, 0, 0)
            });

            applicationContext.Appointments.Add(new Appointment()
            {
                Id = 2,
                OrganizerId = 2,
                Description = $"Test Description2",
                Date = new DateTime(2022, 2, 1, 16, 0, 0)
            });

            applicationContext.UserAppointments.Add(new UserAppointment()
            {
                Id = 1,
                AppointmentId = 1,
                UserId = 1,
                CreatedAt = DateTime.UtcNow

            });

            applicationContext.UserAppointments.Add(new UserAppointment()
            {
                Id = 2,
                AppointmentId = 2,
                UserId = 2,
                CreatedAt = DateTime.UtcNow
            });

            applicationContext.SaveChangesAsync();

            return applicationContext;
        }



        [TestCase(1)]
        [TestCase(2)]
        public void GetAppointment_Test(long id)
        {
            //Act
            var appointment = _appointmentDataService.GetAppointment(id);

            //Assert
            appointment.Should().NotBeNull();
            appointment.Id.Should().Be(id);
        }

        [Test]
        public void GetAppointments_Test()
        {
            //Arrange 
            var expectedAppointmentCount = 3;

            // Act
            var result = _appointmentDataService.GetAllAppointments();

            result.Should().NotBeNull();
            result.Count.Should().Be(expectedAppointmentCount);
        }
        private static IEnumerable<TestCaseData> DateTestCaseSelection
        {
            get
            {
                yield return new TestCaseData(new DateTime(2022, 1, 31), new DateTime(2022, 2, 1), 1);
                yield return new TestCaseData(new DateTime(2022, 2, 1), new DateTime(2022, 2, 2), 1);
            }
        }

        [TestCaseSource("DateTestCaseSelection")]
        public void GetAppointmentsByDate_Test(DateTime startTime, DateTime endTime, int expectedCount)
        {
            // Act
            var result = _appointmentDataService.GetAppointmentsByDate(startTime, endTime);

            result.Should().NotBeNull();
            result.Count.Should().Be(expectedCount);
        }
    }
}
