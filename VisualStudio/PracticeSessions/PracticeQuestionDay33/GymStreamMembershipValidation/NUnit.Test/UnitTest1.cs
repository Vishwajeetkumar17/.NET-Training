using GymStreamMembershipValidationSystem;
using NUnit.Framework;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace GymStream.Tests
{
    [TestFixture]
    public class MembershipTests
    {
        private Membership _membership;

        [SetUp]
        public void Setup()
        {
            _membership = new Membership();
        }

        // --- VALIDATION TESTS ---

        [Test]
        public void ValidateEnrollment_ValidTiers_ReturnsTrue()
        {
            // Arrange
            _membership.Tier = "Premium";
            _membership.DurationInMonths = 6;

            // Act & Assert
            Assert.That(_membership.ValidateEnrollment(), Is.True);
        }

        [Test]
        public void ValidateEnrollment_InvalidTier_ThrowsInvalidTierException()
        {
            // Arrange
            _membership.Tier = "Gold"; // Invalid tier
            _membership.DurationInMonths = 12;

            // Act & Assert
            var ex = Assert.Throws<InvalidTierException>(() => _membership.ValidateEnrollment());
            Assert.That(ex.Message, Is.EqualTo("Tier not recognized. Please choose an available membership plan.")
);

        }

        [Test]
        public void ValidateEnrollment_ZeroDuration_ThrowsGeneralException()
        {
            // Arrange
            _membership.Tier = "Basic";
            _membership.DurationInMonths = 0; // Invalid duration

            // Act & Assert
            var ex = Assert.Throws<Exception>(() => _membership.ValidateEnrollment());
            Assert.That(ex.Message, Is.EqualTo("Duration must be at least one month."));
        }

        // --- CALCULATION TESTS ---

        [Test]
        [TestCase("Basic", 10, 100, 980)]    // 1000 - 2% = 980
        [TestCase("Premium", 10, 100, 930)]  // 1000 - 7% = 930
        [TestCase("Elite", 10, 100, 880)]    // 1000 - 12% = 880
        public void CalculateTotalBill_CorrectDiscountsApplied(string tier, int duration, double price, double expected)
        {
            // Arrange
            _membership.Tier = tier;
            _membership.DurationInMonths = duration;
            _membership.BasePricePerMonth = price;

            // Act
            double actual = _membership.CalculateTotalBill();

            // Assert
            Assert.That(actual, Is.EqualTo(expected)); ;
        }
    }
}
