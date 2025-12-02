using Xunit;
using FluentValidation.TestHelper;
using Application.Validators;
using Application.Dtos.Requests;

namespace Restaurant.Tests
{
    public class OrderSearchRequestValidatorTests
    {
        private readonly OrderSearchRequestValidator _validator;
        public OrderSearchRequestValidatorTests()
        {
            _validator = new OrderSearchRequestValidator();
        }
        [Fact]
        public void Should_HaveError_When_ToIsBeforeFrom()
        {
            var request = new OrderSearchRequest
            {
                From = DateTime.Today,
                To = DateTime.Today.AddDays(-1)
            };
            var result = _validator.TestValidate(request);
            result.ShouldHaveValidationErrorFor(x => x.To);

        }
        [Fact]
        public void Should_NotHaveError_When_ToIsAfterFrom()
        {
            var request = new OrderSearchRequest
            {
                From = DateTime.Today,
                To = DateTime.Today.AddDays(1) //To is greater than Today
            };
            var result = _validator.TestValidate(request);
            result.ShouldNotHaveValidationErrorFor(x => x.To);
        }
        [Fact]
        public void Sould_Not_Fail_When_Only_To_Is_Set()
        {
            var validator = new OrderSearchRequestValidator();
            var request = new OrderSearchRequest
            {
                To = DateTime.UtcNow
            };
            var result = validator.Validate(request);
            Assert.True(result.IsValid);
        }
    }
}