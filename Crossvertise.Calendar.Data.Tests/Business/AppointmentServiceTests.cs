namespace Crossvertise.Calendar.Service.Tests.Business
{
    using System.Linq;
    using System;

    using Moq;
    using NUnit.Framework;
    using System.Collections.Generic;
    using FluentAssertions;

    using Crossvertise.Calendar.Service.Business.Abstract;
    using Crossvertise.Calendar.Service.Business.Concrete;
    using Crossvertise.Calendar.Service.Data.Abstract;
    using Crossvertise.Calender.Data.Entities;

    /// <summary>
    /// Test for <see cref="AppointmentService"/>
    /// </summary>
    [TestFixture]
    public class AppointmentServiceTests
    {
        private Mock<IAppointmentDataService> _appointmentDataService;

        private IAppointmentService _appointmentService;

        [SetUp]
        public void Init()
        {
            _appointmentDataService = new Mock<IAppointmentDataService>();

            _appointmentService = new AppointmentService(_appointmentDataService.Object);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void GetAppointmentDetail_Should_Success(long id)
        {
            // Arrange
            var appointment = new Appointment
            {
                Id = id,
                Organizer = new User { UserName = "test1" }
            };

            _appointmentDataService.Setup(x => x.GetAppointment(It.IsAny<long>())).Returns(appointment);

            // Act
            var result = _appointmentService.GetAppointmentDetail(id);

            // Assert
            result.Id.Should().Be(id);

            _appointmentDataService.Verify(x => x.GetAppointment(It.IsAny<long>()), Times.Once);
        }

        [TestCase(default)]
        public void GetAppointmentDetail_Should_Failed_When_Search_Id_Default(long id)
        {
            // Act
            var result = _appointmentService.GetAppointmentDetail(id);

            // Assert
            result.Should().BeNull();
        }

        [Test]
        public void GetAppointmentsByDate_Should_Success()
        {
            // Arrange
            var appointments = new List<Appointment>()
            {
                new Appointment()
                {
                    Id = 1,
                    Organizer = new User { UserName = "test1" }
                },
                new Appointment
                {
                    Id = 2,
                    Organizer = new User { UserName = "test2" }
                }

            };

            _appointmentDataService.Setup(x => x.GetAppointmentsByDate(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(appointments);

            // Act
            var result = _appointmentService.GetAppointmentsByDate(It.IsAny<DateTime>(), It.IsAny<DateTime>());

            // Assert
            result.Any().Should().BeTrue();

            result.Count.Should().Be(appointments.Count);

            _appointmentDataService.Verify(x => x.GetAppointmentsByDate(It.IsAny<DateTime>(), It.IsAny<DateTime>()), Times.Once);

        }

        [Test]
        public void GetAppointments_Should_Success()
        {
            // Arrange
            var appointments = new List<Appointment>()
            {
                new Appointment()
                {
                    Id = 1,
                    Organizer = new User { UserName = "test1" }

                },
                new Appointment
                {
                    Id = 2,
                    Organizer = new User { UserName = "test2" }
                }
            };

            _appointmentDataService.Setup(x => x.GetAllAppointments()).Returns(appointments);

            // Act
            var result = _appointmentService.GetAllAppointments();

            // Assert
            result.Any().Should().BeTrue();

            result.Count.Should().Be(appointments.Count);

            _appointmentDataService.Verify(x => x.GetAllAppointments(), Times.Once);

        }
    }
}
