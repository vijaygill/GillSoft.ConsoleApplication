using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GillSoft.ConsoleApplicationFramework
{
    /// <summary>
    /// Base class for parsing commandline arguments,
    /// </summary>
    public abstract class CommandlineArgumentsBase : ICommandlineArguments
    {
        /// <summary>
        /// Show help.
        /// </summary>
        public virtual bool Help { get { return IsTrue(ParameterNames.Help); } }

        /// <summary>
        /// Show diagnostic messages.
        /// </summary>
        public virtual bool Verbose { get { return IsTrue(ParameterNames.Verbose); } }

        /// <summary>
        /// Show even more diagnostic messages
        /// </summary>
        public virtual bool Verbose2 { get { return IsTrue(ParameterNames.Verbose2); } }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        public CommandlineArgumentsBase(ILogger logger)
        {
            this.logger = logger;
        }


        internal static class ParameterNames
        {
            public static readonly string Help = @"h";
            public static readonly string Verbose = @"v";
            public static readonly string Verbose2 = @"vv";
        }

        /// <summary>
        /// Get the value of a given commandline parameter.
        /// If commandline parameter is not provided, default value is returned.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        protected string Get(string name, string defaultValue)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns if a given commandline parameter is set.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        protected bool IsTrue(string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the type of class that has list of parametrer names.
        /// Each field should have description attribute to show help.
        /// </summary>
        /// <returns></returns>
        protected abstract Type GetHelpClassType();

        /// <summary>
        /// Shows help on all commandline parameters,
        /// </summary>
        public void ShowHelp()
        {
            this.GetType().GetFields().Select(f => new { Index = 0, Name = f.Name, Field = f })
                .Concat(GetHelpClassType().GetFields().Select(f => new { Index = 0, Name = f.Name, Field = f }))
                .GroupBy(f => f.Name).Select(g => g.OrderBy(gi => gi.Index).Last()).Select(f => f.Field)
                .Select(f => new
                {
                    Name = "" + f.GetValue(null),
                    Help = f.GetCustomAttributes(typeof(DescriptionAttribute), true).Cast<DescriptionAttribute>().Select(a => a.Description).FirstOrDefault(),
                })
                .AsTableFormatter()
                .Column("Name", 20, a => a.Name)
                .Column("Help", 50, a => a.Help)
                .Print();
            ;
        }

        /// <summary>
        /// Shows errors raised from validation of commandline parameters,
        /// </summary>
        public void ShowErrors()
        {

        }

        private List<string> errors = new List<string>();
        private readonly ILogger logger;

        /// <summary>
        /// Check validity of commandline parameters.
        /// </summary>
        /// <param name="check">Lambda-expression that returns true of validation is successful.</param>
        /// <param name="errorMessage">Error message if validation fails.</param>
        protected void Validate(Func<bool> check, string errorMessage)
        {
            try
            {
                if (!check())
                {
                    this.errors.Add(errorMessage);
                }
            }
            catch (Exception ex)
            {
                errors.Add("Exception: " + ex.Message + ": raised for while checking for: " + errors);
            }
        }

    }
}
