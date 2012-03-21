using System;
using System.IO;
using FluentValidation;

namespace demo.Behavioral
{
    class NullObject
        : IDemo
    {
        public void Demo(TextWriter writer)
        {
            var validator = new ValidatorFactory().GetValidator<UserInput>();
            writer.WriteLine(validator);
            
            var results = validator.Validate(new UserInput());
            writer.WriteLine("Is Valid: {0}", results.IsValid);
            foreach (var error in results.Errors)
            {
                writer.WriteLine("{0}: {1}", error.PropertyName, error.ErrorMessage);
            }
        }
    }

    class NullValidator
            : AbstractValidator<object>
    {
    }

    class ValidatorFactory
        : ValidatorFactoryBase
    {
        public override IValidator CreateInstance(Type validatorType)
        {
            try
            {
                return (IValidator)Activator.CreateInstance(validatorType);
            }
            catch
            {
                return new NullValidator();
            }
        }
    }

    class UserInput
    {
        public string Text { get; set; }
    }
}