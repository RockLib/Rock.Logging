﻿using Microsoft.Extensions.Logging;

namespace RockLib.Logging.Extensions
{
    /// <summary>
    /// Helpers for .NET Core
    /// </summary>
    public static class ConfigureExtensions
    {
        /// <summary>
        /// Enable RockLib as logging provider in .NET Core.
        /// </summary>
        /// <param name="factory">The factory being extended</param>
        /// <param name="rockLibLoggerName">The Logger name</param>
        /// <returns>ILoggerFactory for chaining</returns>
        public static ILoggerFactory AddRockLib(this ILoggerFactory factory, string rockLibLoggerName = null)
        {
            factory.AddProvider(new RockLibLoggerProvider(rockLibLoggerName));
            return factory;
        }

        /// <summary>
        /// Enable RockLib as logging provider in .NET Core.
        /// </summary>
        /// <param name="factory">The factory being extended</param>
        /// <param name="rockLibLoggerName">The Logger name</param>
        /// <returns>ILoggerFactory for chaining</returns>
        public static ILoggingBuilder AddRockLib(this ILoggingBuilder factory, string rockLibLoggerName = null)
        {
            factory.AddProvider(new RockLibLoggerProvider(rockLibLoggerName));
            return factory;
        }
    }
}
