﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using Moq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(RockLib.Logging.Moq.MockLoggerExtensions.GeneratedAssemblyName)]

namespace RockLib.Logging.Moq
{
    /// <summary>
    /// Provides extension methods for setting up and verifying instances of <see cref="Mock{T}"/> of type
    /// <see cref="ILogger"/>.
    /// </summary>
    public static class MockLoggerExtensions
    {
        internal const string GeneratedAssemblyName = "RockLib.Logging.Moq.MockLoggerExtensions";

        /// <summary>
        /// Specifies setups on the mock logger for the <see cref="ILogger.Level"/> and <see cref="ILogger.Name"/>
        /// properties.
        /// </summary>
        /// <param name="mockLogger">The mock logger to perform setups on.</param>
        /// <param name="level">The level of the mock logger.</param>
        /// <param name="name">The name of the mock logger.</param>
        /// <returns>The same mock logger.</returns>
        public static Mock<ILogger> SetupLogger(this Mock<ILogger> mockLogger, LogLevel level = LogLevel.Debug, string name = Logger.DefaultName)
        {
            mockLogger.Setup(m => m.Level).Returns(level);
            mockLogger.Setup(m => m.Name).Returns(name ?? Logger.DefaultName);

            return mockLogger;
        }

        /// <summary>
        /// Verifies that the mock logger logged at <see cref="LogLevel.Debug"/> the number of times specified
        /// by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyDebug(this Mock<ILogger> mockLogger, Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(null, null, null, LogLevel.Debug, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged at <see cref="LogLevel.Info"/> the number of times specified
        /// by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyInfo(this Mock<ILogger> mockLogger, Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(null, null, null, LogLevel.Info, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged at <see cref="LogLevel.Warn"/> the number of times specified
        /// by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyWarn(this Mock<ILogger> mockLogger, Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(null, null, null, LogLevel.Warn, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged at <see cref="LogLevel.Error"/> the number of times specified
        /// by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyError(this Mock<ILogger> mockLogger, Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(null, null, null, LogLevel.Error, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged at <see cref="LogLevel.Fatal"/> the number of times specified
        /// by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyFatal(this Mock<ILogger> mockLogger, Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(null, null, null, LogLevel.Fatal, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged at <see cref="LogLevel.Audit"/> the number of times specified
        /// by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyAudit(this Mock<ILogger> mockLogger, Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(null, null, null, LogLevel.Audit, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged at any <see cref="LogLevel"/> the number of times specified
        /// by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyLog(this Mock<ILogger> mockLogger, Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(null, null, null, null, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the message specified by <paramref name="messagePattern"/>
        /// at <see cref="LogLevel.Debug"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="messagePattern">
        /// A regular expression pattern that the message of a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyDebug(this Mock<ILogger> mockLogger, string messagePattern,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(messagePattern, null, null, LogLevel.Debug, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the message specified by <paramref name="messagePattern"/>
        /// at <see cref="LogLevel.Info"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="messagePattern">
        /// A regular expression pattern that the message of a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyInfo(this Mock<ILogger> mockLogger, string messagePattern,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(messagePattern, null, null, LogLevel.Info, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the message specified by <paramref name="messagePattern"/>
        /// at <see cref="LogLevel.Warn"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="messagePattern">
        /// A regular expression pattern that the message of a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyWarn(this Mock<ILogger> mockLogger, string messagePattern,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(messagePattern, null, null, LogLevel.Warn, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the message specified by <paramref name="messagePattern"/>
        /// at <see cref="LogLevel.Error"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="messagePattern">
        /// A regular expression pattern that the message of a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyError(this Mock<ILogger> mockLogger, string messagePattern,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(messagePattern, null, null, LogLevel.Error, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the message specified by <paramref name="messagePattern"/>
        /// at <see cref="LogLevel.Fatal"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="messagePattern">
        /// A regular expression pattern that the message of a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyFatal(this Mock<ILogger> mockLogger, string messagePattern,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(messagePattern, null, null, LogLevel.Fatal, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the message specified by <paramref name="messagePattern"/>
        /// at <see cref="LogLevel.Audit"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="messagePattern">
        /// A regular expression pattern that the message of a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyAudit(this Mock<ILogger> mockLogger, string messagePattern,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(messagePattern, null, null, LogLevel.Audit, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the message specified by <paramref name="messagePattern"/>
        /// at any <see cref="LogLevel"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="messagePattern">
        /// A regular expression pattern that the message of a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyLog(this Mock<ILogger> mockLogger, string messagePattern,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(messagePattern, null, null, null, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the extended properties specified by
        /// <paramref name="extendedProperties"/> at <see cref="LogLevel.Debug"/> the number of times
        /// specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="extendedProperties">
        /// An object representing the extended properties that a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyDebug(this Mock<ILogger> mockLogger, object extendedProperties,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(null, null, extendedProperties, LogLevel.Debug, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the extended properties specified by
        /// <paramref name="extendedProperties"/> at <see cref="LogLevel.Info"/> the number of times
        /// specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="extendedProperties">
        /// An object representing the extended properties that a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyInfo(this Mock<ILogger> mockLogger, object extendedProperties,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(null, null, extendedProperties, LogLevel.Info, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the extended properties specified by
        /// <paramref name="extendedProperties"/> at <see cref="LogLevel.Warn"/> the number of times
        /// specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="extendedProperties">
        /// An object representing the extended properties that a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyWarn(this Mock<ILogger> mockLogger, object extendedProperties,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(null, null, extendedProperties, LogLevel.Warn, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the extended properties specified by
        /// <paramref name="extendedProperties"/> at <see cref="LogLevel.Error"/> the number of times
        /// specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="extendedProperties">
        /// An object representing the extended properties that a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyError(this Mock<ILogger> mockLogger, object extendedProperties,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(null, null, extendedProperties, LogLevel.Error, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the extended properties specified by
        /// <paramref name="extendedProperties"/> at <see cref="LogLevel.Fatal"/> the number of times
        /// specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="extendedProperties">
        /// An object representing the extended properties that a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyFatal(this Mock<ILogger> mockLogger, object extendedProperties,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(null, null, extendedProperties, LogLevel.Fatal, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the extended properties specified by
        /// <paramref name="extendedProperties"/> at <see cref="LogLevel.Audit"/> the number of times
        /// specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="extendedProperties">
        /// An object representing the extended properties that a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyAudit(this Mock<ILogger> mockLogger, object extendedProperties,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(null, null, extendedProperties, LogLevel.Audit, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the extended properties specified by
        /// <paramref name="extendedProperties"/> at any <see cref="LogLevel"/> the number of times
        /// specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="extendedProperties">
        /// An object representing the extended properties that a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyLog(this Mock<ILogger> mockLogger, object extendedProperties,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(null, null, extendedProperties, null, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the message specified by <paramref name="messagePattern"/>
        /// and the extended properties specified by <paramref name="extendedProperties"/> at
        /// <see cref="LogLevel.Debug"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="messagePattern">
        /// A regular expression pattern that the message of a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="extendedProperties">
        /// An object representing the extended properties that a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyDebug(this Mock<ILogger> mockLogger, string messagePattern, object extendedProperties,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(messagePattern, null, extendedProperties, LogLevel.Debug, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the message specified by <paramref name="messagePattern"/>
        /// and the extended properties specified by <paramref name="extendedProperties"/> at
        /// <see cref="LogLevel.Info"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="messagePattern">
        /// A regular expression pattern that the message of a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="extendedProperties">
        /// An object representing the extended properties that a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyInfo(this Mock<ILogger> mockLogger, string messagePattern, object extendedProperties,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(messagePattern, null, extendedProperties, LogLevel.Info, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the message specified by <paramref name="messagePattern"/>
        /// and the extended properties specified by <paramref name="extendedProperties"/> at
        /// <see cref="LogLevel.Warn"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="messagePattern">
        /// A regular expression pattern that the message of a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="extendedProperties">
        /// An object representing the extended properties that a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyWarn(this Mock<ILogger> mockLogger, string messagePattern, object extendedProperties,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(messagePattern, null, extendedProperties, LogLevel.Warn, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the message specified by <paramref name="messagePattern"/>
        /// and the extended properties specified by <paramref name="extendedProperties"/> at
        /// <see cref="LogLevel.Error"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="messagePattern">
        /// A regular expression pattern that the message of a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="extendedProperties">
        /// An object representing the extended properties that a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyError(this Mock<ILogger> mockLogger, string messagePattern, object extendedProperties,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(messagePattern, null, extendedProperties, LogLevel.Error, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the message specified by <paramref name="messagePattern"/>
        /// and the extended properties specified by <paramref name="extendedProperties"/> at
        /// <see cref="LogLevel.Fatal"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="messagePattern">
        /// A regular expression pattern that the message of a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="extendedProperties">
        /// An object representing the extended properties that a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyFatal(this Mock<ILogger> mockLogger, string messagePattern, object extendedProperties,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(messagePattern, null, extendedProperties, LogLevel.Fatal, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the message specified by <paramref name="messagePattern"/>
        /// and the extended properties specified by <paramref name="extendedProperties"/> at
        /// <see cref="LogLevel.Audit"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="messagePattern">
        /// A regular expression pattern that the message of a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="extendedProperties">
        /// An object representing the extended properties that a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyAudit(this Mock<ILogger> mockLogger, string messagePattern, object extendedProperties,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(messagePattern, null, extendedProperties, LogLevel.Audit, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the message specified by <paramref name="messagePattern"/>
        /// and the extended properties specified by <paramref name="extendedProperties"/> at any
        /// <see cref="LogLevel"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="messagePattern">
        /// A regular expression pattern that the message of a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="extendedProperties">
        /// An object representing the extended properties that a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyLog(this Mock<ILogger> mockLogger, string messagePattern, object extendedProperties,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(messagePattern, null, extendedProperties, null, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the exception specified by <paramref name="exception"/>
        /// at <see cref="LogLevel.Debug"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="exception">
        /// The exception instance that a log entry's <see cref="LogEntry.Exception"/> must be a
        /// reference to in order for successful verification to occur. Pass <see langword="null"/>
        /// if <see cref="LogEntry.Exception"/> is expected to be <see langword="null"/>.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyDebug(this Mock<ILogger> mockLogger, Exception exception, Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(null, ex => ReferenceEquals(ex, exception), null, LogLevel.Debug, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the exception specified by <paramref name="exception"/>
        /// at <see cref="LogLevel.Info"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="exception">
        /// The exception instance that a log entry's <see cref="LogEntry.Exception"/> must be a
        /// reference to in order for successful verification to occur. Pass <see langword="null"/>
        /// if <see cref="LogEntry.Exception"/> is expected to be <see langword="null"/>.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyInfo(this Mock<ILogger> mockLogger, Exception exception, Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(null, ex => ReferenceEquals(ex, exception), null, LogLevel.Info, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the exception specified by <paramref name="exception"/>
        /// at <see cref="LogLevel.Warn"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="exception">
        /// The exception instance that a log entry's <see cref="LogEntry.Exception"/> must be a
        /// reference to in order for successful verification to occur. Pass <see langword="null"/>
        /// if <see cref="LogEntry.Exception"/> is expected to be <see langword="null"/>.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyWarn(this Mock<ILogger> mockLogger, Exception exception, Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(null, ex => ReferenceEquals(ex, exception), null, LogLevel.Warn, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the exception specified by <paramref name="exception"/>
        /// at <see cref="LogLevel.Error"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="exception">
        /// The exception instance that a log entry's <see cref="LogEntry.Exception"/> must be a
        /// reference to in order for successful verification to occur. Pass <see langword="null"/>
        /// if <see cref="LogEntry.Exception"/> is expected to be <see langword="null"/>.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyError(this Mock<ILogger> mockLogger, Exception exception, Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(null, ex => ReferenceEquals(ex, exception), null, LogLevel.Error, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the exception specified by <paramref name="exception"/>
        /// at <see cref="LogLevel.Fatal"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="exception">
        /// The exception instance that a log entry's <see cref="LogEntry.Exception"/> must be a
        /// reference to in order for successful verification to occur. Pass <see langword="null"/>
        /// if <see cref="LogEntry.Exception"/> is expected to be <see langword="null"/>.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyFatal(this Mock<ILogger> mockLogger, Exception exception, Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(null, ex => ReferenceEquals(ex, exception), null, LogLevel.Fatal, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the exception specified by <paramref name="exception"/>
        /// at <see cref="LogLevel.Audit"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="exception">
        /// The exception instance that a log entry's <see cref="LogEntry.Exception"/> must be a
        /// reference to in order for successful verification to occur. Pass <see langword="null"/>
        /// if <see cref="LogEntry.Exception"/> is expected to be <see langword="null"/>.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyAudit(this Mock<ILogger> mockLogger, Exception exception, Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(null, ex => ReferenceEquals(ex, exception), null, LogLevel.Audit, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the exception specified by <paramref name="exception"/>
        /// at any <see cref="LogLevel"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="exception">
        /// The exception instance that a log entry's <see cref="LogEntry.Exception"/> must be a
        /// reference to in order for successful verification to occur. Pass <see langword="null"/>
        /// if <see cref="LogEntry.Exception"/> is expected to be <see langword="null"/>.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyLog(this Mock<ILogger> mockLogger, Exception exception, Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(null, ex => ReferenceEquals(ex, exception), null, null, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the message specified by <paramref name="messagePattern"/>
        /// and the exception specified by <paramref name="exception"/> at <see cref="LogLevel.Debug"/> the
        /// number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="messagePattern">
        /// A regular expression pattern that the message of a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="exception">
        /// The exception instance that a log entry's <see cref="LogEntry.Exception"/> must be a
        /// reference to in order for successful verification to occur. Pass <see langword="null"/>
        /// if <see cref="LogEntry.Exception"/> is expected to be <see langword="null"/>.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyDebug(this Mock<ILogger> mockLogger, string messagePattern, Exception exception,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(messagePattern, ex => ReferenceEquals(ex, exception), null, LogLevel.Debug, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the message specified by <paramref name="messagePattern"/>
        /// and the exception specified by <paramref name="exception"/> at <see cref="LogLevel.Info"/> the
        /// number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="exception">
        /// The exception instance that a log entry's <see cref="LogEntry.Exception"/> must be a
        /// reference to in order for successful verification to occur. Pass <see langword="null"/>
        /// if <see cref="LogEntry.Exception"/> is expected to be <see langword="null"/>.
        /// </param>
        /// <param name="messagePattern">
        /// A regular expression pattern that the message of a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyInfo(this Mock<ILogger> mockLogger, string messagePattern, Exception exception,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(messagePattern, ex => ReferenceEquals(ex, exception), null, LogLevel.Info, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the message specified by <paramref name="messagePattern"/>
        /// and the exception specified by <paramref name="exception"/> at <see cref="LogLevel.Warn"/> the
        /// number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="exception">
        /// The exception instance that a log entry's <see cref="LogEntry.Exception"/> must be a
        /// reference to in order for successful verification to occur. Pass <see langword="null"/>
        /// if <see cref="LogEntry.Exception"/> is expected to be <see langword="null"/>.
        /// </param>
        /// <param name="messagePattern">
        /// A regular expression pattern that the message of a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyWarn(this Mock<ILogger> mockLogger, string messagePattern, Exception exception,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(messagePattern, ex => ReferenceEquals(ex, exception), null, LogLevel.Warn, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the message specified by <paramref name="messagePattern"/>
        /// and the exception specified by <paramref name="exception"/> at <see cref="LogLevel.Error"/> the
        /// number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="exception">
        /// The exception instance that a log entry's <see cref="LogEntry.Exception"/> must be a
        /// reference to in order for successful verification to occur. Pass <see langword="null"/>
        /// if <see cref="LogEntry.Exception"/> is expected to be <see langword="null"/>.
        /// </param>
        /// <param name="messagePattern">
        /// A regular expression pattern that the message of a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyError(this Mock<ILogger> mockLogger, string messagePattern, Exception exception,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(messagePattern, ex => ReferenceEquals(ex, exception), null, LogLevel.Error, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the message specified by <paramref name="messagePattern"/>
        /// and the exception specified by <paramref name="exception"/> at <see cref="LogLevel.Fatal"/> the
        /// number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="exception">
        /// The exception instance that a log entry's <see cref="LogEntry.Exception"/> must be a
        /// reference to in order for successful verification to occur. Pass <see langword="null"/>
        /// if <see cref="LogEntry.Exception"/> is expected to be <see langword="null"/>.
        /// </param>
        /// <param name="messagePattern">
        /// A regular expression pattern that the message of a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyFatal(this Mock<ILogger> mockLogger, string messagePattern, Exception exception,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(messagePattern, ex => ReferenceEquals(ex, exception), null, LogLevel.Fatal, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the message specified by <paramref name="messagePattern"/>
        /// and the exception specified by <paramref name="exception"/> at <see cref="LogLevel.Audit"/> the
        /// number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="exception">
        /// The exception instance that a log entry's <see cref="LogEntry.Exception"/> must be a
        /// reference to in order for successful verification to occur. Pass <see langword="null"/>
        /// if <see cref="LogEntry.Exception"/> is expected to be <see langword="null"/>.
        /// </param>
        /// <param name="messagePattern">
        /// A regular expression pattern that the message of a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyAudit(this Mock<ILogger> mockLogger, string messagePattern, Exception exception,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(messagePattern, ex => ReferenceEquals(ex, exception), null, LogLevel.Audit, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the message specified by <paramref name="messagePattern"/>
        /// and the exception specified by <paramref name="exception"/> at any <see cref="LogLevel"/> the
        /// number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="exception">
        /// The exception instance that a log entry's <see cref="LogEntry.Exception"/> must be a
        /// reference to in order for successful verification to occur. Pass <see langword="null"/>
        /// if <see cref="LogEntry.Exception"/> is expected to be <see langword="null"/>.
        /// </param>
        /// <param name="messagePattern">
        /// A regular expression pattern that the message of a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyLog(this Mock<ILogger> mockLogger, string messagePattern, Exception exception,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(messagePattern, ex => ReferenceEquals(ex, exception), null, null, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the exception specified by <paramref name="exception"/> and
        /// the extended properties specified by <paramref name="extendedProperties"/> at
        /// <see cref="LogLevel.Debug"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="exception">
        /// The exception instance that a log entry's <see cref="LogEntry.Exception"/> must be a
        /// reference to in order for successful verification to occur. Pass <see langword="null"/>
        /// if <see cref="LogEntry.Exception"/> is expected to be <see langword="null"/>.
        /// </param>
        /// <param name="extendedProperties">
        /// An object representing the extended properties that a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyDebug(this Mock<ILogger> mockLogger, Exception exception, object extendedProperties,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(null, ex => ReferenceEquals(ex, exception), extendedProperties, LogLevel.Debug, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the exception specified by <paramref name="exception"/> and
        /// the extended properties specified by <paramref name="extendedProperties"/> at
        /// <see cref="LogLevel.Info"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="exception">
        /// The exception instance that a log entry's <see cref="LogEntry.Exception"/> must be a
        /// reference to in order for successful verification to occur. Pass <see langword="null"/>
        /// if <see cref="LogEntry.Exception"/> is expected to be <see langword="null"/>.
        /// </param>
        /// <param name="extendedProperties">
        /// An object representing the extended properties that a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyInfo(this Mock<ILogger> mockLogger, Exception exception, object extendedProperties,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(null, ex => ReferenceEquals(ex, exception), extendedProperties, LogLevel.Info, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the exception specified by <paramref name="exception"/> and
        /// the extended properties specified by <paramref name="extendedProperties"/> at
        /// <see cref="LogLevel.Warn"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="exception">
        /// The exception instance that a log entry's <see cref="LogEntry.Exception"/> must be a
        /// reference to in order for successful verification to occur. Pass <see langword="null"/>
        /// if <see cref="LogEntry.Exception"/> is expected to be <see langword="null"/>.
        /// </param>
        /// <param name="extendedProperties">
        /// An object representing the extended properties that a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyWarn(this Mock<ILogger> mockLogger, Exception exception, object extendedProperties,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(null, ex => ReferenceEquals(ex, exception), extendedProperties, LogLevel.Warn, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the exception specified by <paramref name="exception"/> and
        /// the extended properties specified by <paramref name="extendedProperties"/> at
        /// <see cref="LogLevel.Error"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="exception">
        /// The exception instance that a log entry's <see cref="LogEntry.Exception"/> must be a
        /// reference to in order for successful verification to occur. Pass <see langword="null"/>
        /// if <see cref="LogEntry.Exception"/> is expected to be <see langword="null"/>.
        /// </param>
        /// <param name="extendedProperties">
        /// An object representing the extended properties that a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyError(this Mock<ILogger> mockLogger, Exception exception, object extendedProperties,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(null, ex => ReferenceEquals(ex, exception), extendedProperties, LogLevel.Error, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the exception specified by <paramref name="exception"/> and
        /// the extended properties specified by <paramref name="extendedProperties"/> at
        /// <see cref="LogLevel.Fatal"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="exception">
        /// The exception instance that a log entry's <see cref="LogEntry.Exception"/> must be a
        /// reference to in order for successful verification to occur. Pass <see langword="null"/>
        /// if <see cref="LogEntry.Exception"/> is expected to be <see langword="null"/>.
        /// </param>
        /// <param name="extendedProperties">
        /// An object representing the extended properties that a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyFatal(this Mock<ILogger> mockLogger, Exception exception, object extendedProperties,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(null, ex => ReferenceEquals(ex, exception), extendedProperties, LogLevel.Fatal, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the exception specified by <paramref name="exception"/> and
        /// the extended properties specified by <paramref name="extendedProperties"/> at
        /// <see cref="LogLevel.Audit"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="exception">
        /// The exception instance that a log entry's <see cref="LogEntry.Exception"/> must be a
        /// reference to in order for successful verification to occur. Pass <see langword="null"/>
        /// if <see cref="LogEntry.Exception"/> is expected to be <see langword="null"/>.
        /// </param>
        /// <param name="extendedProperties">
        /// An object representing the extended properties that a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyAudit(this Mock<ILogger> mockLogger, Exception exception, object extendedProperties,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(null, ex => ReferenceEquals(ex, exception), extendedProperties, LogLevel.Audit, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the exception specified by <paramref name="exception"/> and
        /// the extended properties specified by <paramref name="extendedProperties"/> at any
        /// <see cref="LogLevel"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="exception">
        /// The exception instance that a log entry's <see cref="LogEntry.Exception"/> must be a
        /// reference to in order for successful verification to occur. Pass <see langword="null"/>
        /// if <see cref="LogEntry.Exception"/> is expected to be <see langword="null"/>.
        /// </param>
        /// <param name="extendedProperties">
        /// An object representing the extended properties that a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyLog(this Mock<ILogger> mockLogger, Exception exception, object extendedProperties,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(null, ex => ReferenceEquals(ex, exception), extendedProperties, null, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the message specified by <paramref name="messagePattern"/>,
        /// the exception specified by <paramref name="exception"/>,
        /// and the extended properties specified by <paramref name="extendedProperties"/> at
        /// <see cref="LogLevel.Debug"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="messagePattern">
        /// A regular expression pattern that the message of a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="exception">
        /// The exception instance that a log entry's <see cref="LogEntry.Exception"/> must be a
        /// reference to in order for successful verification to occur. Pass <see langword="null"/>
        /// if <see cref="LogEntry.Exception"/> is expected to be <see langword="null"/>.
        /// </param>
        /// <param name="extendedProperties">
        /// An object representing the extended properties that a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyDebug(this Mock<ILogger> mockLogger, string messagePattern, Exception exception, object extendedProperties,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(messagePattern, ex => ReferenceEquals(ex, exception), extendedProperties, LogLevel.Debug, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the message specified by <paramref name="messagePattern"/>,
        /// the exception specified by <paramref name="exception"/>,
        /// and the extended properties specified by <paramref name="extendedProperties"/> at
        /// <see cref="LogLevel.Info"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="messagePattern">
        /// A regular expression pattern that the message of a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="exception">
        /// The exception instance that a log entry's <see cref="LogEntry.Exception"/> must be a
        /// reference to in order for successful verification to occur. Pass <see langword="null"/>
        /// if <see cref="LogEntry.Exception"/> is expected to be <see langword="null"/>.
        /// </param>
        /// <param name="extendedProperties">
        /// An object representing the extended properties that a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyInfo(this Mock<ILogger> mockLogger, string messagePattern, Exception exception, object extendedProperties,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(messagePattern, ex => ReferenceEquals(ex, exception), extendedProperties, LogLevel.Info, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the message specified by <paramref name="messagePattern"/>,
        /// the exception specified by <paramref name="exception"/>,
        /// and the extended properties specified by <paramref name="extendedProperties"/> at
        /// <see cref="LogLevel.Warn"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="messagePattern">
        /// A regular expression pattern that the message of a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="exception">
        /// The exception instance that a log entry's <see cref="LogEntry.Exception"/> must be a
        /// reference to in order for successful verification to occur. Pass <see langword="null"/>
        /// if <see cref="LogEntry.Exception"/> is expected to be <see langword="null"/>.
        /// </param>
        /// <param name="extendedProperties">
        /// An object representing the extended properties that a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyWarn(this Mock<ILogger> mockLogger, string messagePattern, Exception exception, object extendedProperties,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(messagePattern, ex => ReferenceEquals(ex, exception), extendedProperties, LogLevel.Warn, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the message specified by <paramref name="messagePattern"/>,
        /// the exception specified by <paramref name="exception"/>,
        /// and the extended properties specified by <paramref name="extendedProperties"/> at
        /// <see cref="LogLevel.Error"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="messagePattern">
        /// A regular expression pattern that the message of a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="exception">
        /// The exception instance that a log entry's <see cref="LogEntry.Exception"/> must be a
        /// reference to in order for successful verification to occur. Pass <see langword="null"/>
        /// if <see cref="LogEntry.Exception"/> is expected to be <see langword="null"/>.
        /// </param>
        /// <param name="extendedProperties">
        /// An object representing the extended properties that a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyError(this Mock<ILogger> mockLogger, string messagePattern, Exception exception, object extendedProperties,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(messagePattern, ex => ReferenceEquals(ex, exception), extendedProperties, LogLevel.Error, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the message specified by <paramref name="messagePattern"/>,
        /// the exception specified by <paramref name="exception"/>,
        /// and the extended properties specified by <paramref name="extendedProperties"/> at
        /// <see cref="LogLevel.Fatal"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="messagePattern">
        /// A regular expression pattern that the message of a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="exception">
        /// The exception instance that a log entry's <see cref="LogEntry.Exception"/> must be a
        /// reference to in order for successful verification to occur. Pass <see langword="null"/>
        /// if <see cref="LogEntry.Exception"/> is expected to be <see langword="null"/>.
        /// </param>
        /// <param name="extendedProperties">
        /// An object representing the extended properties that a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyFatal(this Mock<ILogger> mockLogger, string messagePattern, Exception exception, object extendedProperties,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(messagePattern, ex => ReferenceEquals(ex, exception), extendedProperties, LogLevel.Fatal, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the message specified by <paramref name="messagePattern"/>,
        /// the exception specified by <paramref name="exception"/>,
        /// and the extended properties specified by <paramref name="extendedProperties"/> at
        /// <see cref="LogLevel.Audit"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="messagePattern">
        /// A regular expression pattern that the message of a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="exception">
        /// The exception instance that a log entry's <see cref="LogEntry.Exception"/> must be a
        /// reference to in order for successful verification to occur. Pass <see langword="null"/>
        /// if <see cref="LogEntry.Exception"/> is expected to be <see langword="null"/>.
        /// </param>
        /// <param name="extendedProperties">
        /// An object representing the extended properties that a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyAudit(this Mock<ILogger> mockLogger, string messagePattern, Exception exception, object extendedProperties,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(messagePattern, ex => ReferenceEquals(ex, exception), extendedProperties, LogLevel.Audit, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the message specified by <paramref name="messagePattern"/>,
        /// the exception specified by <paramref name="exception"/>,
        /// and the extended properties specified by <paramref name="extendedProperties"/> at any
        /// <see cref="LogLevel"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="messagePattern">
        /// A regular expression pattern that the message of a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="exception">
        /// The exception instance that a log entry's <see cref="LogEntry.Exception"/> must be a
        /// reference to in order for successful verification to occur. Pass <see langword="null"/>
        /// if <see cref="LogEntry.Exception"/> is expected to be <see langword="null"/>.
        /// </param>
        /// <param name="extendedProperties">
        /// An object representing the extended properties that a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyLog(this Mock<ILogger> mockLogger, string messagePattern, Exception exception, object extendedProperties,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(messagePattern, ex => ReferenceEquals(ex, exception), extendedProperties, null, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with an exception that returns true from the function specified
        /// by <paramref name="hasMatchingException"/> at <see cref="LogLevel.Debug"/> the number of times specified
        /// by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="hasMatchingException">
        /// A function evaluated with a log entry's <see cref="LogEntry.Exception"/> that must
        /// return <see langword="true"/> in order for successful verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyDebug(this Mock<ILogger> mockLogger, Expression<Func<Exception, bool>> hasMatchingException, Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(null, hasMatchingException, null, LogLevel.Debug, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with an exception that returns true from the function specified
        /// by <paramref name="hasMatchingException"/> at <see cref="LogLevel.Info"/> the number of times specified
        /// by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="hasMatchingException">
        /// A function evaluated with a log entry's <see cref="LogEntry.Exception"/> that must
        /// return <see langword="true"/> in order for successful verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyInfo(this Mock<ILogger> mockLogger, Expression<Func<Exception, bool>> hasMatchingException, Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(null, hasMatchingException, null, LogLevel.Info, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with an exception that returns true from the function specified
        /// by <paramref name="hasMatchingException"/> at <see cref="LogLevel.Warn"/> the number of times specified
        /// by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="hasMatchingException">
        /// A function evaluated with a log entry's <see cref="LogEntry.Exception"/> that must
        /// return <see langword="true"/> in order for successful verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyWarn(this Mock<ILogger> mockLogger, Expression<Func<Exception, bool>> hasMatchingException, Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(null, hasMatchingException, null, LogLevel.Warn, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with an exception that returns true from the function specified
        /// by <paramref name="hasMatchingException"/> at <see cref="LogLevel.Error"/> the number of times specified
        /// by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="hasMatchingException">
        /// A function evaluated with a log entry's <see cref="LogEntry.Exception"/> that must
        /// return <see langword="true"/> in order for successful verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyError(this Mock<ILogger> mockLogger, Expression<Func<Exception, bool>> hasMatchingException, Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(null, hasMatchingException, null, LogLevel.Error, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with an exception that returns true from the function specified
        /// by <paramref name="hasMatchingException"/> at <see cref="LogLevel.Fatal"/> the number of times specified
        /// by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="hasMatchingException">
        /// A function evaluated with a log entry's <see cref="LogEntry.Exception"/> that must
        /// return <see langword="true"/> in order for successful verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyFatal(this Mock<ILogger> mockLogger, Expression<Func<Exception, bool>> hasMatchingException, Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(null, hasMatchingException, null, LogLevel.Fatal, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with an exception that returns true from the function specified
        /// by <paramref name="hasMatchingException"/> at <see cref="LogLevel.Audit"/> the number of times specified
        /// by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="hasMatchingException">
        /// A function evaluated with a log entry's <see cref="LogEntry.Exception"/> that must
        /// return <see langword="true"/> in order for successful verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyAudit(this Mock<ILogger> mockLogger, Expression<Func<Exception, bool>> hasMatchingException, Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(null, hasMatchingException, null, LogLevel.Audit, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with an exception that returns true from the function specified
        /// by <paramref name="hasMatchingException"/> at any <see cref="LogLevel"/> the number of times specified
        /// by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="hasMatchingException">
        /// A function evaluated with a log entry's <see cref="LogEntry.Exception"/> that must
        /// return <see langword="true"/> in order for successful verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyLog(this Mock<ILogger> mockLogger, Expression<Func<Exception, bool>> hasMatchingException, Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(null, hasMatchingException, null, null, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the message specified by <paramref name="messagePattern"/>
        /// and an exception that returns true from the function specified by <paramref name="hasMatchingException"/>
        /// at <see cref="LogLevel.Debug"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="messagePattern">
        /// A regular expression pattern that the message of a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="hasMatchingException">
        /// A function evaluated with a log entry's <see cref="LogEntry.Exception"/> that must
        /// return <see langword="true"/> in order for successful verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyDebug(this Mock<ILogger> mockLogger, string messagePattern, Expression<Func<Exception, bool>> hasMatchingException,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(messagePattern, hasMatchingException, null, LogLevel.Debug, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the message specified by <paramref name="messagePattern"/>
        /// and an exception that returns true from the function specified by <paramref name="hasMatchingException"/>
        /// at <see cref="LogLevel.Info"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="messagePattern">
        /// A regular expression pattern that the message of a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="hasMatchingException">
        /// A function evaluated with a log entry's <see cref="LogEntry.Exception"/> that must
        /// return <see langword="true"/> in order for successful verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyInfo(this Mock<ILogger> mockLogger, string messagePattern, Expression<Func<Exception, bool>> hasMatchingException,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(messagePattern, hasMatchingException, null, LogLevel.Info, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the message specified by <paramref name="messagePattern"/>
        /// and an exception that returns true from the function specified by <paramref name="hasMatchingException"/>
        /// at <see cref="LogLevel.Warn"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="messagePattern">
        /// A regular expression pattern that the message of a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="hasMatchingException">
        /// A function evaluated with a log entry's <see cref="LogEntry.Exception"/> that must
        /// return <see langword="true"/> in order for successful verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyWarn(this Mock<ILogger> mockLogger, string messagePattern, Expression<Func<Exception, bool>> hasMatchingException,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(messagePattern, hasMatchingException, null, LogLevel.Warn, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the message specified by <paramref name="messagePattern"/>
        /// and an exception that returns true from the function specified by <paramref name="hasMatchingException"/>
        /// at <see cref="LogLevel.Error"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="messagePattern">
        /// A regular expression pattern that the message of a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="hasMatchingException">
        /// A function evaluated with a log entry's <see cref="LogEntry.Exception"/> that must
        /// return <see langword="true"/> in order for successful verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyError(this Mock<ILogger> mockLogger, string messagePattern, Expression<Func<Exception, bool>> hasMatchingException,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(messagePattern, hasMatchingException, null, LogLevel.Error, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the message specified by <paramref name="messagePattern"/>
        /// and an exception that returns true from the function specified by <paramref name="hasMatchingException"/>
        /// at <see cref="LogLevel.Fatal"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="messagePattern">
        /// A regular expression pattern that the message of a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="hasMatchingException">
        /// A function evaluated with a log entry's <see cref="LogEntry.Exception"/> that must
        /// return <see langword="true"/> in order for successful verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyFatal(this Mock<ILogger> mockLogger, string messagePattern, Expression<Func<Exception, bool>> hasMatchingException,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(messagePattern, hasMatchingException, null, LogLevel.Fatal, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the message specified by <paramref name="messagePattern"/>
        /// and an exception that returns true from the function specified by <paramref name="hasMatchingException"/>
        /// at <see cref="LogLevel.Audit"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="messagePattern">
        /// A regular expression pattern that the message of a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="hasMatchingException">
        /// A function evaluated with a log entry's <see cref="LogEntry.Exception"/> that must
        /// return <see langword="true"/> in order for successful verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyAudit(this Mock<ILogger> mockLogger, string messagePattern, Expression<Func<Exception, bool>> hasMatchingException,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(messagePattern, hasMatchingException, null, LogLevel.Audit, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the message specified by <paramref name="messagePattern"/>
        /// and an exception that returns true from the function specified by <paramref name="hasMatchingException"/>
        /// at any <see cref="LogLevel"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="messagePattern">
        /// A regular expression pattern that the message of a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="hasMatchingException">
        /// A function evaluated with a log entry's <see cref="LogEntry.Exception"/> that must
        /// return <see langword="true"/> in order for successful verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyLog(this Mock<ILogger> mockLogger, string messagePattern, Expression<Func<Exception, bool>> hasMatchingException,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(messagePattern, hasMatchingException, null, null, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with an exception that returns true from the function
        /// specified by <paramref name="hasMatchingException"/> and the extended properties specified by
        /// <paramref name="extendedProperties"/> at <see cref="LogLevel.Debug"/> the number of times
        /// specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="hasMatchingException">
        /// A function evaluated with a log entry's <see cref="LogEntry.Exception"/> that must
        /// return <see langword="true"/> in order for successful verification to occur.
        /// </param>
        /// <param name="extendedProperties">
        /// An object representing the extended properties that a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyDebug(this Mock<ILogger> mockLogger, Expression<Func<Exception, bool>> hasMatchingException, object extendedProperties,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(null, hasMatchingException, extendedProperties, LogLevel.Debug, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with an exception that returns true from the function
        /// specified by <paramref name="hasMatchingException"/> and the extended properties specified by
        /// <paramref name="extendedProperties"/> at <see cref="LogLevel.Info"/> the number of times
        /// specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="hasMatchingException">
        /// A function evaluated with a log entry's <see cref="LogEntry.Exception"/> that must
        /// return <see langword="true"/> in order for successful verification to occur.
        /// </param>
        /// <param name="extendedProperties">
        /// An object representing the extended properties that a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyInfo(this Mock<ILogger> mockLogger, Expression<Func<Exception, bool>> hasMatchingException, object extendedProperties,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(null, hasMatchingException, extendedProperties, LogLevel.Info, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with an exception that returns true from the function
        /// specified by <paramref name="hasMatchingException"/> and the extended properties specified by
        /// <paramref name="extendedProperties"/> at <see cref="LogLevel.Warn"/> the number of times
        /// specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="hasMatchingException">
        /// A function evaluated with a log entry's <see cref="LogEntry.Exception"/> that must
        /// return <see langword="true"/> in order for successful verification to occur.
        /// </param>
        /// <param name="extendedProperties">
        /// An object representing the extended properties that a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyWarn(this Mock<ILogger> mockLogger, Expression<Func<Exception, bool>> hasMatchingException, object extendedProperties,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(null, hasMatchingException, extendedProperties, LogLevel.Warn, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with an exception that returns true from the function
        /// specified by <paramref name="hasMatchingException"/> and the extended properties specified by
        /// <paramref name="extendedProperties"/> at <see cref="LogLevel.Error"/> the number of times
        /// specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="hasMatchingException">
        /// A function evaluated with a log entry's <see cref="LogEntry.Exception"/> that must
        /// return <see langword="true"/> in order for successful verification to occur.
        /// </param>
        /// <param name="extendedProperties">
        /// An object representing the extended properties that a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyError(this Mock<ILogger> mockLogger, Expression<Func<Exception, bool>> hasMatchingException, object extendedProperties,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(null, hasMatchingException, extendedProperties, LogLevel.Error, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with an exception that returns true from the function
        /// specified by <paramref name="hasMatchingException"/> and the extended properties specified by
        /// <paramref name="extendedProperties"/> at <see cref="LogLevel.Fatal"/> the number of times
        /// specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="hasMatchingException">
        /// A function evaluated with a log entry's <see cref="LogEntry.Exception"/> that must
        /// return <see langword="true"/> in order for successful verification to occur.
        /// </param>
        /// <param name="extendedProperties">
        /// An object representing the extended properties that a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyFatal(this Mock<ILogger> mockLogger, Expression<Func<Exception, bool>> hasMatchingException, object extendedProperties,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(null, hasMatchingException, extendedProperties, LogLevel.Fatal, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with an exception that returns true from the function
        /// specified by <paramref name="hasMatchingException"/> and the extended properties specified by
        /// <paramref name="extendedProperties"/> at <see cref="LogLevel.Audit"/> the number of times
        /// specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="hasMatchingException">
        /// A function evaluated with a log entry's <see cref="LogEntry.Exception"/> that must
        /// return <see langword="true"/> in order for successful verification to occur.
        /// </param>
        /// <param name="extendedProperties">
        /// An object representing the extended properties that a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyAudit(this Mock<ILogger> mockLogger, Expression<Func<Exception, bool>> hasMatchingException, object extendedProperties,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(null, hasMatchingException, extendedProperties, LogLevel.Audit, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with an exception that returns true from the function
        /// specified by <paramref name="hasMatchingException"/> and the extended properties specified by
        /// <paramref name="extendedProperties"/> at any <see cref="LogLevel"/> the number of times
        /// specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="hasMatchingException">
        /// A function evaluated with a log entry's <see cref="LogEntry.Exception"/> that must
        /// return <see langword="true"/> in order for successful verification to occur.
        /// </param>
        /// <param name="extendedProperties">
        /// An object representing the extended properties that a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyLog(this Mock<ILogger> mockLogger, Expression<Func<Exception, bool>> hasMatchingException, object extendedProperties,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(null, hasMatchingException, extendedProperties, null, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the message specified by <paramref name="messagePattern"/>,
        /// an exception that returns true from the function specified by <paramref name="hasMatchingException"/>,
        /// and the extended properties specified by <paramref name="extendedProperties"/> at
        /// <see cref="LogLevel.Debug"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="messagePattern">
        /// A regular expression pattern that the message of a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="hasMatchingException">
        /// A function evaluated with a log entry's <see cref="LogEntry.Exception"/> that must
        /// return <see langword="true"/> in order for successful verification to occur.
        /// </param>
        /// <param name="extendedProperties">
        /// An object representing the extended properties that a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyDebug(this Mock<ILogger> mockLogger, string messagePattern, Expression<Func<Exception, bool>> hasMatchingException, object extendedProperties,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(messagePattern, hasMatchingException, extendedProperties, LogLevel.Debug, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the message specified by <paramref name="messagePattern"/>,
        /// an exception that returns true from the function specified by <paramref name="hasMatchingException"/>,
        /// and the extended properties specified by <paramref name="extendedProperties"/> at
        /// <see cref="LogLevel.Info"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="messagePattern">
        /// A regular expression pattern that the message of a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="hasMatchingException">
        /// A function evaluated with a log entry's <see cref="LogEntry.Exception"/> that must
        /// return <see langword="true"/> in order for successful verification to occur.
        /// </param>
        /// <param name="extendedProperties">
        /// An object representing the extended properties that a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyInfo(this Mock<ILogger> mockLogger, string messagePattern, Expression<Func<Exception, bool>> hasMatchingException, object extendedProperties,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(messagePattern, hasMatchingException, extendedProperties, LogLevel.Info, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the message specified by <paramref name="messagePattern"/>,
        /// an exception that returns true from the function specified by <paramref name="hasMatchingException"/>,
        /// and the extended properties specified by <paramref name="extendedProperties"/> at
        /// <see cref="LogLevel.Warn"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="messagePattern">
        /// A regular expression pattern that the message of a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="hasMatchingException">
        /// A function evaluated with a log entry's <see cref="LogEntry.Exception"/> that must
        /// return <see langword="true"/> in order for successful verification to occur.
        /// </param>
        /// <param name="extendedProperties">
        /// An object representing the extended properties that a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyWarn(this Mock<ILogger> mockLogger, string messagePattern, Expression<Func<Exception, bool>> hasMatchingException, object extendedProperties,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(messagePattern, hasMatchingException, extendedProperties, LogLevel.Warn, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the message specified by <paramref name="messagePattern"/>,
        /// an exception that returns true from the function specified by <paramref name="hasMatchingException"/>,
        /// and the extended properties specified by <paramref name="extendedProperties"/> at
        /// <see cref="LogLevel.Error"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="messagePattern">
        /// A regular expression pattern that the message of a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="hasMatchingException">
        /// A function evaluated with a log entry's <see cref="LogEntry.Exception"/> that must
        /// return <see langword="true"/> in order for successful verification to occur.
        /// </param>
        /// <param name="extendedProperties">
        /// An object representing the extended properties that a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyError(this Mock<ILogger> mockLogger, string messagePattern, Expression<Func<Exception, bool>> hasMatchingException, object extendedProperties,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(messagePattern, hasMatchingException, extendedProperties, LogLevel.Error, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the message specified by <paramref name="messagePattern"/>,
        /// an exception that returns true from the function specified by <paramref name="hasMatchingException"/>,
        /// and the extended properties specified by <paramref name="extendedProperties"/> at
        /// <see cref="LogLevel.Fatal"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="messagePattern">
        /// A regular expression pattern that the message of a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="hasMatchingException">
        /// A function evaluated with a log entry's <see cref="LogEntry.Exception"/> that must
        /// return <see langword="true"/> in order for successful verification to occur.
        /// </param>
        /// <param name="extendedProperties">
        /// An object representing the extended properties that a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyFatal(this Mock<ILogger> mockLogger, string messagePattern, Expression<Func<Exception, bool>> hasMatchingException, object extendedProperties,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(messagePattern, hasMatchingException, extendedProperties, LogLevel.Fatal, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the message specified by <paramref name="messagePattern"/>,
        /// an exception that returns true from the function specified by <paramref name="hasMatchingException"/>,
        /// and the extended properties specified by <paramref name="extendedProperties"/> at
        /// <see cref="LogLevel.Audit"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="messagePattern">
        /// A regular expression pattern that the message of a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="hasMatchingException">
        /// A function evaluated with a log entry's <see cref="LogEntry.Exception"/> that must
        /// return <see langword="true"/> in order for successful verification to occur.
        /// </param>
        /// <param name="extendedProperties">
        /// An object representing the extended properties that a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyAudit(this Mock<ILogger> mockLogger, string messagePattern, Expression<Func<Exception, bool>> hasMatchingException, object extendedProperties,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(messagePattern, hasMatchingException, extendedProperties, LogLevel.Audit, times, failMessage);

        /// <summary>
        /// Verifies that the mock logger logged with the message specified by <paramref name="messagePattern"/>,
        /// an exception that returns true from the function specified by <paramref name="hasMatchingException"/>,
        /// and the extended properties specified by <paramref name="extendedProperties"/> at any
        /// <see cref="LogLevel"/> the number of times specified by <paramref name="times"/>.
        /// </summary>
        /// <param name="mockLogger">The mock logger to verify.</param>
        /// <param name="messagePattern">
        /// A regular expression pattern that the message of a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="hasMatchingException">
        /// A function evaluated with a log entry's <see cref="LogEntry.Exception"/> that must
        /// return <see langword="true"/> in order for successful verification to occur.
        /// </param>
        /// <param name="extendedProperties">
        /// An object representing the extended properties that a log must match in order for successful
        /// verification to occur.
        /// </param>
        /// <param name="times">
        /// The number of times the mock logger is expected to have logged. If <see langword="null"/>,
        /// <see cref="Times.Once()"/> is used.
        /// </param>
        /// <param name="failMessage">Message to show if verification fails.</param>
        /// <exception cref="MockException">
        /// The logger did not log according to the specified criteria.
        /// </exception>
        public static void VerifyLog(this Mock<ILogger> mockLogger, string messagePattern, Expression<Func<Exception, bool>> hasMatchingException, object extendedProperties,
            Times? times = null, string failMessage = null) =>
            mockLogger.VerifyLog(messagePattern, hasMatchingException, extendedProperties, null, times, failMessage);

        private static void VerifyLog(this Mock<ILogger> mockLogger, string messagePattern,
            Expression<Func<Exception, bool>> hasMatchingException, object extendedProperties,
            LogLevel? logLevel, Times? times, string failMessage)
        {
            if (mockLogger == null)
                throw new ArgumentNullException(nameof(mockLogger));

            Expression<Func<LogEntry, bool>> hasMatchingMessage = null, hasMatchingExtendedProperties = null, hasMatchingLogLevel = null;

            if (messagePattern != null)
            {
                var logEntryParameter = Expression.Parameter(typeof(LogEntry), "logEntry");
                var isMatchMethod = typeof(Regex).GetMethod(nameof(Regex.IsMatch), new Type[] { typeof(string), typeof(string) });
                var body = Expression.Call(isMatchMethod,
                    Expression.Property(logEntryParameter, nameof(LogEntry.Message)),
                    Expression.Constant(messagePattern));
                hasMatchingMessage = Expression.Lambda<Func<LogEntry, bool>>(body, logEntryParameter);
            }

            if (extendedProperties != null)
            {
                var properties = GetExtendedPropertiesDictionary(extendedProperties);

                foreach (var property in properties.Reverse())
                {
                    var logEntryParameter = Expression.Parameter(typeof(LogEntry), "logEntry");

                    var matcher = new ExtendedPropertyMatcher();
                    var body = Expression.Invoke(
                        Expression.Field(Expression.Constant(matcher), nameof(matcher.HasMatchingExtendedProperty)),
                        logEntryParameter, Expression.Constant(property.Key), Expression.Constant(property.Value, typeof(object)));

                    var hasMatchingProperty = Expression.Lambda<Func<LogEntry, bool>>(body, logEntryParameter);

                    if (hasMatchingExtendedProperties is null)
                        hasMatchingExtendedProperties = hasMatchingProperty;
                    else
                        hasMatchingExtendedProperties = hasMatchingProperty.And(hasMatchingExtendedProperties);
                }
            }

            if (logLevel != null)
            {
                var logEntryParameter = Expression.Parameter(typeof(LogEntry), "logEntry");
                var body = Expression.Equal(Expression.Property(logEntryParameter, nameof(LogEntry.Level)), Expression.Constant(logLevel.Value));
                hasMatchingLogLevel = Expression.Lambda<Func<LogEntry, bool>>(body, logEntryParameter);
            }

            var matchingLogEntry = GetMatchingLogEntryExpression(hasMatchingException, hasMatchingMessage, hasMatchingExtendedProperties, hasMatchingLogLevel);

            mockLogger.Verify(mock => mock.Log(It.Is(matchingLogEntry), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()),
                times ?? Times.Once(), failMessage);
        }

        private static Expression<Func<LogEntry, bool>> GetMatchingLogEntryExpression(Expression<Func<Exception, bool>> hasMatchingException,
            Expression<Func<LogEntry, bool>> hasMatchingMessage, Expression<Func<LogEntry, bool>> hasMatchingExtendedProperties,
            Expression<Func<LogEntry, bool>> hasMatchingLogLevel)
        {
            Expression<Func<LogEntry, bool>> matchingLogEntry = null;

            if (hasMatchingExtendedProperties != null)
                matchingLogEntry = hasMatchingExtendedProperties;
            if (hasMatchingException != null)
                matchingLogEntry = hasMatchingException.And(matchingLogEntry);
            if (hasMatchingLogLevel != null)
                matchingLogEntry = hasMatchingLogLevel.And(matchingLogEntry);
            if (hasMatchingMessage != null)
                matchingLogEntry = hasMatchingMessage.And(matchingLogEntry);

            if (matchingLogEntry is null)
                matchingLogEntry = logEntry => true;

            return matchingLogEntry;
        }

        private static Expression<Func<LogEntry, bool>> And(this Expression<Func<LogEntry, bool>> lhs, Expression<Func<LogEntry, bool>> rhs)
        {
            if (rhs is null)
                return lhs;

            var logEntryParameter = Expression.Parameter(typeof(LogEntry), "logEntry");

            var body = Expression.And(LambdaHelper.RebindBody(lhs, logEntryParameter), LambdaHelper.RebindBody(rhs, logEntryParameter));

            return Expression.Lambda<Func<LogEntry, bool>>(body, logEntryParameter);
        }

        private static Expression<Func<LogEntry, bool>> And(this Expression<Func<Exception, bool>> lhs, Expression<Func<LogEntry, bool>> rhs)
        {
            var logEntryParameter = Expression.Parameter(typeof(LogEntry), "logEntry");
            var logEntryException = Expression.Property(logEntryParameter, nameof(LogEntry.Exception));

            Expression body;
            if (rhs is null)
                body = LambdaHelper.RebindBody(lhs, logEntryException);
            else
                body = Expression.And(LambdaHelper.RebindBody(lhs, logEntryException), LambdaHelper.RebindBody(rhs, logEntryParameter));

            return Expression.Lambda<Func<LogEntry, bool>>(body, logEntryParameter);
        }

        private static bool AreEquivalent(object lhs, object rhs)
        {
            switch (lhs)
            {
                case string pattern:
                    return Regex.IsMatch((string)rhs, pattern);
                default:
                    if (lhs is object[] lhsArray && rhs is object[] rhsArray && lhsArray.Length == rhsArray.Length)
                    {
                        for (int i = 0; i < lhsArray.Length; i++)
                            if (!AreEquivalent(lhsArray[i], rhsArray[i]))
                                return false;
                        return true;
                    }
                    return Equals(lhs, rhs);
            }
        }

        private static Dictionary<string, object> GetExtendedPropertiesDictionary(object extendedProperties)
        {
            var logEntry = new LogEntry();
            logEntry.SetExtendedProperties(extendedProperties);
            return logEntry.ExtendedProperties;
        }

        [CompilerGenerated]
        private class ExtendedPropertyMatcher
        {
            public readonly Func<LogEntry, string, object, bool> HasMatchingExtendedProperty = (logEntry, extendedPropertyName, expectedValue) =>
            {
                if (!logEntry.ExtendedProperties.TryGetValue(extendedPropertyName, out var value)
                        || !value.GetType().IsAssignableFrom(expectedValue.GetType()))
                    return false;

                if (!AreEquivalent(expectedValue, value))
                    return false;

                return true;
            };
        }

        private class LambdaHelper : ExpressionVisitor
        {
            private readonly ParameterExpression _parameterToReplace;
            private readonly Expression _parameterReplacement;

            private LambdaHelper(ParameterExpression parameterToReplace, Expression parameterReplacement)
            {
                _parameterToReplace = parameterToReplace;
                _parameterReplacement = parameterReplacement;
            }

            public static Expression RebindBody<T, TResult>(Expression<Func<T, TResult>> lambdaExpression, Expression parameterReplacement)
            {
                return new LambdaHelper(lambdaExpression.Parameters[0], parameterReplacement).Visit(lambdaExpression.Body);
            }

            protected override Expression VisitParameter(ParameterExpression parameter)
            {
                if (parameter.Equals(_parameterToReplace))
                    return _parameterReplacement;

                return base.VisitParameter(parameter);
            }
        }
    }
}
