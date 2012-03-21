using System;
using System.IO;
using System.Text;
using FluentValidation;

namespace demo.Creational
{
    class BclBuilder
        : IDemo
    {
        public void Demo(TextWriter writer)
        {
            var builder = new StringBuilder();
            builder
                .Append(DateTime.Now)
                .Append(Environment.NewLine)
                .AppendFormat("{0} + {1} = 3\n", 1, 2)
                .AppendLine("additional text");

            writer.WriteLine(builder.ToString());
        }
    }

    class FluentValidationBuilder
        : IDemo
    {
        public void Demo(TextWriter writer)
        {
            var model = new ViewModel
            {
                Text = "hello world",
                Number = -1
            };
            var results = new ViewModelValidator().Validate(model);
            
            writer.WriteLine("Is Valid: {0}", results.IsValid);
            foreach (var error in results.Errors)
            {
                writer.WriteLine("{0}: {1}", error.PropertyName, error.ErrorMessage);
            }
        }

        class ViewModelValidator 
            : FluentValidation.AbstractValidator<ViewModel>
        {
            public ViewModelValidator()
            {
                RuleFor(x => x.Text).NotNull().Length(5, 10);
                RuleFor(x => x.Number).GreaterThan(0);
            }
        }

        class ViewModel
        {
            public int Number { get; set; }
            public string Text { get; set; }
        }
    }
}
