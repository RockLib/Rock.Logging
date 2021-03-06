﻿using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using RockLib.Logging.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace RockLib.Logging.Tests.DependencyInjection
{
    public class LoggerBuilderExtensionsTests
    {
        private static readonly IServiceProvider _emptyServiceProvider = new ServiceCollection().BuildServiceProvider();

        [Fact(DisplayName = "AddLogProvider method adds log provider of specified type")]
        public void AddLogProviderMethodHappyPath()
        {
            var builder = new TestLoggerBuilder();

            IDependency dependency = new ConcreteDependency();
            int setting = 123;

            var serviceProvider = new ServiceCollection()
                .AddSingleton(dependency)
                .BuildServiceProvider();

            builder.AddLogProvider<TestLogProvider>(setting);

            var registration =
                builder.LogProviderRegistrations.Should().ContainSingle()
                .Subject;

            var logProvider = registration.Invoke(serviceProvider);

            var testLogProvider =
                logProvider.Should().BeOfType<TestLogProvider>()
                .Subject;
            testLogProvider.Setting.Should().Be(setting);
            testLogProvider.Dependency.Should().BeSameAs(dependency);
        }

        [Fact(DisplayName = "AddLogProvider method throws when builder parameter is null")]
        public void AddLogProviderMethodSadPath()
        {
            ILoggerBuilder builder = null;

            Action act = () => builder.AddLogProvider<TestLogProvider>();

            act.Should().ThrowExactly<ArgumentNullException>().WithMessage("*builder*");
        }

        [Fact(DisplayName = "AddContextProvider method adds context provider of specified type")]
        public void AddContextProviderMethodHappyPath()
        {
            var builder = new TestLoggerBuilder();

            IDependency dependency = new ConcreteDependency();
            int setting = 123;

            var serviceProvider = new ServiceCollection()
                .AddSingleton(dependency)
                .BuildServiceProvider();

            builder.AddContextProvider<TestContextProvider>(setting);

            var registration =
                builder.ContextProviderRegistrations.Should().ContainSingle()
                .Subject;

            var contextProvider = registration.Invoke(serviceProvider);

            var testContextProvider =
                contextProvider.Should().BeOfType<TestContextProvider>()
                .Subject;
            testContextProvider.Setting.Should().Be(setting);
            testContextProvider.Dependency.Should().BeSameAs(dependency);
        }

        [Fact(DisplayName = "AddContextProvider method throws when builder parameter is null")]
        public void AddContextProviderMethodSadPath()
        {
            ILoggerBuilder builder = null;

            Action act = () => builder.AddContextProvider<TestContextProvider>();

            act.Should().ThrowExactly<ArgumentNullException>().WithMessage("*builder*");
        }

        #region AddConsoleLogProvider

        [Fact(DisplayName = "AddConsoleLogProvider method 1 adds console log provider with specified template")]
        public void AddConsoleLogProviderMethod1HappyPath()
        {
            var builder = new TestLoggerBuilder();

            var template = "foobar";

            builder.AddConsoleLogProvider(template, LogLevel.Info);

            var registration =
                builder.LogProviderRegistrations.Should().ContainSingle()
                .Subject;

            var logProvider = registration.Invoke(_emptyServiceProvider);

            var consoleLogProvider =
                logProvider.Should().BeOfType<ConsoleLogProvider>()
                .Subject;

            consoleLogProvider.Level.Should().Be(LogLevel.Info);
            consoleLogProvider.Formatter.Should().BeOfType<TemplateLogFormatter>()
                .Which.Template.Should().Be(template);
        }

        [Fact(DisplayName = "AddConsoleLogProvider method 1 throws when template parameter is null")]
        public void AddConsoleLogProviderMethod1SadPath()
        {
            var builder = new Mock<ILoggerBuilder>().Object;

            Action act = () => builder.AddConsoleLogProvider((string)null, LogLevel.Info);

            act.Should().ThrowExactly<ArgumentNullException>().WithMessage("*template*");
        }

        [Fact(DisplayName = "AddConsoleLogProvider method 2 adds console log provider with specified formatter")]
        public void AddConsoleLogProviderMethod2HappyPath()
        {
            var builder = new TestLoggerBuilder();

            var formatter = new Mock<ILogFormatter>().Object;

            builder.AddConsoleLogProvider(formatter, LogLevel.Info);

            var registration =
                builder.LogProviderRegistrations.Should().ContainSingle()
                .Subject;

            var logProvider = registration.Invoke(_emptyServiceProvider);

            var consoleLogProvider =
                logProvider.Should().BeOfType<ConsoleLogProvider>()
                .Subject;

            consoleLogProvider.Level.Should().Be(LogLevel.Info);
            consoleLogProvider.Formatter.Should().BeSameAs(formatter);
        }

        [Fact(DisplayName = "AddConsoleLogProvider method 2 throws when formatter parameter is null")]
        public void AddConsoleLogProviderMethod2SadPath()
        {
            var builder = new Mock<ILoggerBuilder>().Object;

            Action act = () => builder.AddConsoleLogProvider((ILogFormatter)null, LogLevel.Info);

            act.Should().ThrowExactly<ArgumentNullException>().WithMessage("*formatter*");
        }

        [Fact(DisplayName = "AddConsoleLogProvider method 3 adds console log provider with specified formatter")]
        public void AddConsoleLogProviderMethod3HappyPath()
        {
            var builder = new TestLoggerBuilder();

            IDependency dependency = new ConcreteDependency();
            int setting = 123;

            var serviceProvider = new ServiceCollection()
                .AddSingleton(dependency)
                .BuildServiceProvider();

            builder.AddConsoleLogProvider<TestLogFormatter>(LogLevel.Info, logFormatterParameters: setting);

            var registration =
                builder.LogProviderRegistrations.Should().ContainSingle()
                .Subject;

            var logProvider = registration.Invoke(serviceProvider);

            var consoleLogProvider =
                logProvider.Should().BeOfType<ConsoleLogProvider>()
                .Subject;

            consoleLogProvider.Level.Should().Be(LogLevel.Info);
            
            var formatter =
                consoleLogProvider.Formatter.Should().BeOfType<TestLogFormatter>()
                .Subject;
            
            formatter.Dependency.Should().BeSameAs(dependency);
            formatter.Setting.Should().Be(setting);
        }

        [Fact(DisplayName = "AddConsoleLogProvider method 4 adds console log provider with specified formatter registration")]
        public void AddConsoleLogProviderMethod4HappyPath()
        {
            var builder = new TestLoggerBuilder();

            var formatter = new Mock<ILogFormatter>().Object;
            ILogFormatter FormatterRegistration(IServiceProvider sp) => formatter;

            builder.AddConsoleLogProvider(FormatterRegistration, LogLevel.Info);

            var registration =
                builder.LogProviderRegistrations.Should().ContainSingle()
                .Subject;

            var logProvider = registration.Invoke(_emptyServiceProvider);

            var consoleLogProvider =
                logProvider.Should().BeOfType<ConsoleLogProvider>()
                .Subject;

            consoleLogProvider.Level.Should().Be(LogLevel.Info);
            consoleLogProvider.Formatter.Should().BeSameAs(formatter);
        }

        [Fact(DisplayName = "AddConsoleLogProvider method 4 throws when formatterRegistration parameter is null")]
        public void AddConsoleLogProviderMethod4SadPath()
        {
            var builder = new Mock<ILoggerBuilder>().Object;

            Action act = () => builder.AddConsoleLogProvider((Func<IServiceProvider, ILogFormatter>)null, LogLevel.Info);

            act.Should().ThrowExactly<ArgumentNullException>().WithMessage("*formatterRegistration*");
        }

        [Fact(DisplayName = "AddConsoleLogProvider method 5 adds console log provider configured with configureOptions parameter")]
        public void AddConsoleLogProviderMethod5HappyPath()
        {
            var builder = new TestLoggerBuilder();

            var formatter = new Mock<ILogFormatter>().Object;

            var serviceCollection = new ServiceCollection();
            serviceCollection.Configure<ConsoleLogProviderOptions>(options => options.Level = LogLevel.Info);

            builder.AddConsoleLogProvider(options => options.SetFormatter(formatter));

            var registration =
                builder.LogProviderRegistrations.Should().ContainSingle()
                .Subject;

            var logProvider = registration.Invoke(serviceCollection.BuildServiceProvider());

            var consoleLogProvider =
                logProvider.Should().BeOfType<ConsoleLogProvider>()
                .Subject;

            consoleLogProvider.Level.Should().Be(LogLevel.Info);
            consoleLogProvider.Formatter.Should().BeSameAs(formatter);
        }

        [Fact(DisplayName = "AddConsoleLogProvider method 5 throws when builder parameter is null")]
        public void AddConsoleLogProviderMethod5SadPath()
        {
            ILoggerBuilder builder = null;

            Action act = () => builder.AddConsoleLogProvider();

            act.Should().ThrowExactly<ArgumentNullException>().WithMessage("*builder*");
        }

        #endregion

        #region AddFileLogProvider

        [Fact(DisplayName = "AddFileLogProvider method 1 adds file log provider with specified template")]
        public void AddFileLogProviderMethod1HappyPath()
        {
            var builder = new TestLoggerBuilder();

            var template = "foobar";
            var file = "c:\\foobar";

            builder.AddFileLogProvider(template, file, LogLevel.Info);

            var registration =
                builder.LogProviderRegistrations.Should().ContainSingle()
                .Subject;

            var logProvider = registration.Invoke(_emptyServiceProvider);

            var fileLogProvider =
                logProvider.Should().BeOfType<FileLogProvider>()
                .Subject;

            fileLogProvider.Level.Should().Be(LogLevel.Info);
            fileLogProvider.File.Should().Be(file);
            fileLogProvider.Formatter.Should().BeOfType<TemplateLogFormatter>()
                .Which.Template.Should().Be(template);
        }

        [Fact(DisplayName = "AddFileLogProvider method 1 throws when template parameter is null")]
        public void AddFileLogProviderMethod1SadPath()
        {
            var builder = new Mock<ILoggerBuilder>().Object;

            Action act = () => builder.AddFileLogProvider((string)null, "c:\\foobar", LogLevel.Info);

            act.Should().ThrowExactly<ArgumentNullException>().WithMessage("*template*");
        }

        [Fact(DisplayName = "AddFileLogProvider method 2 adds file log provider with specified formatter")]
        public void AddFileLogProviderMethod2HappyPath()
        {
            var builder = new TestLoggerBuilder();

            var formatter = new Mock<ILogFormatter>().Object;
            var file = "c:\\foobar";

            builder.AddFileLogProvider(formatter, file, LogLevel.Info);

            var registration =
                builder.LogProviderRegistrations.Should().ContainSingle()
                .Subject;

            var logProvider = registration.Invoke(_emptyServiceProvider);

            var fileLogProvider =
                logProvider.Should().BeOfType<FileLogProvider>()
                .Subject;

            fileLogProvider.Level.Should().Be(LogLevel.Info);
            fileLogProvider.File.Should().Be(file);
            fileLogProvider.Formatter.Should().BeSameAs(formatter);
        }

        [Fact(DisplayName = "AddFileLogProvider method 2 throws when formatter parameter is null")]
        public void AddFileLogProviderMethod2SadPath()
        {
            var builder = new Mock<ILoggerBuilder>().Object;

            Action act = () => builder.AddFileLogProvider((ILogFormatter)null, "c:\\foobar", LogLevel.Info);

            act.Should().ThrowExactly<ArgumentNullException>().WithMessage("*formatter*");
        }

        [Fact(DisplayName = "AddFileLogProvider method 3 adds file log provider with specified formatter")]
        public void AddFileLogProviderMethod3HappyPath()
        {
            var builder = new TestLoggerBuilder();

            IDependency dependency = new ConcreteDependency();
            int setting = 123;
            var file = "c:\\foobar";

            var serviceProvider = new ServiceCollection()
                .AddSingleton(dependency)
                .BuildServiceProvider();

            builder.AddFileLogProvider<TestLogFormatter>(file, LogLevel.Info, logFormatterParameters: setting);

            var registration =
                builder.LogProviderRegistrations.Should().ContainSingle()
                .Subject;

            var logProvider = registration.Invoke(serviceProvider);

            var fileLogProvider =
                logProvider.Should().BeOfType<FileLogProvider>()
                .Subject;

            fileLogProvider.Level.Should().Be(LogLevel.Info);
            fileLogProvider.File.Should().Be(file);
            
            var formatter =
                fileLogProvider.Formatter.Should().BeOfType<TestLogFormatter>()
                .Subject;
            
            formatter.Dependency.Should().BeSameAs(dependency);
            formatter.Setting.Should().Be(setting);
        }

        [Fact(DisplayName = "AddFileLogProvider method 4 adds file log provider with specified formatter registration")]
        public void AddFileLogProviderMethod4HappyPath()
        {
            var builder = new TestLoggerBuilder();

            var formatter = new Mock<ILogFormatter>().Object;
            ILogFormatter FormatterRegistration(IServiceProvider sp) => formatter;
            var file = "c:\\foobar";

            builder.AddFileLogProvider(FormatterRegistration, file, LogLevel.Info);

            var registration =
                builder.LogProviderRegistrations.Should().ContainSingle()
                .Subject;

            var logProvider = registration.Invoke(_emptyServiceProvider);

            var fileLogProvider =
                logProvider.Should().BeOfType<FileLogProvider>()
                .Subject;

            fileLogProvider.Level.Should().Be(LogLevel.Info);
            fileLogProvider.File.Should().Be(file);
            fileLogProvider.Formatter.Should().BeSameAs(formatter);
        }

        [Fact(DisplayName = "AddFileLogProvider method 4 throws when formatterRegistration parameter is null")]
        public void AddFileLogProviderMethod4SadPath()
        {
            var builder = new Mock<ILoggerBuilder>().Object;

            Action act = () => builder.AddFileLogProvider((Func<IServiceProvider, ILogFormatter>)null, "c:\\foobar", LogLevel.Info);

            act.Should().ThrowExactly<ArgumentNullException>().WithMessage("*formatterRegistration*");
        }

        [Fact(DisplayName = "AddFileLogProvider method 5 adds file log provider configured with configureOptions parameter")]
        public void AddFileLogProviderMethod5HappyPath()
        {
            var builder = new TestLoggerBuilder();

            var formatter = new Mock<ILogFormatter>().Object;
            var file = "c:\\foobar";

            var serviceCollection = new ServiceCollection();
            serviceCollection.Configure<FileLogProviderOptions>(options => options.Level = LogLevel.Info);

            builder.AddFileLogProvider(options =>
            {
                options.File = file;
                options.SetFormatter(formatter);
            });

            var registration =
                builder.LogProviderRegistrations.Should().ContainSingle()
                .Subject;

            var logProvider = registration.Invoke(serviceCollection.BuildServiceProvider());

            var fileLogProvider =
                logProvider.Should().BeOfType<FileLogProvider>()
                .Subject;

            fileLogProvider.Level.Should().Be(LogLevel.Info);
            fileLogProvider.File.Should().Be(file);
            fileLogProvider.Formatter.Should().BeSameAs(formatter);
        }

        [Fact(DisplayName = "AddFileLogProvider method 5 throws when builder parameter is null")]
        public void AddFileLogProviderMethod5SadPath()
        {
            ILoggerBuilder builder = null;

            Action act = () => builder.AddFileLogProvider();

            act.Should().ThrowExactly<ArgumentNullException>().WithMessage("*builder*");
        }

        #endregion

        #region AddRollingFileLogProvider

        [Fact(DisplayName = "AddRollingFileLogProvider method 1 adds rolling file log provider with specified template")]
        public void AddRollingRollingFileLogProviderMethod1HappyPath()
        {
            var builder = new TestLoggerBuilder();

            var template = "foobar";
            var file = "c:\\foobar";

            builder.AddRollingFileLogProvider(template, file, LogLevel.Info,
                maxFileSizeKilobytes: 123, maxArchiveCount: 456, rolloverPeriod: RolloverPeriod.Hourly);

            var registration =
                builder.LogProviderRegistrations.Should().ContainSingle()
                .Subject;

            var logProvider = registration.Invoke(_emptyServiceProvider);

            var rollingFileLogProvider =
                logProvider.Should().BeOfType<RollingFileLogProvider>()
                .Subject;

            rollingFileLogProvider.Level.Should().Be(LogLevel.Info);
            rollingFileLogProvider.File.Should().Be(file);
            rollingFileLogProvider.MaxFileSizeBytes.Should().Be(123 * 1024);
            rollingFileLogProvider.MaxArchiveCount.Should().Be(456);
            rollingFileLogProvider.RolloverPeriod.Should().Be(RolloverPeriod.Hourly);
            rollingFileLogProvider.Formatter.Should().BeOfType<TemplateLogFormatter>()
                .Which.Template.Should().Be(template);
        }

        [Fact(DisplayName = "AddRollingFileLogProvider method 1 throws when template parameter is null")]
        public void AddRollingFileLogProviderMethod1SadPath()
        {
            var builder = new Mock<ILoggerBuilder>().Object;

            Action act = () => builder.AddRollingFileLogProvider((string)null, "c:\\foobar", LogLevel.Info,
                maxFileSizeKilobytes: 123, maxArchiveCount: 456, rolloverPeriod: RolloverPeriod.Hourly);

            act.Should().ThrowExactly<ArgumentNullException>().WithMessage("*template*");
        }

        [Fact(DisplayName = "AddRollingFileLogProvider method 2 adds rolling file log provider with specified formatter")]
        public void AddRollingFileLogProviderMethod2HappyPath()
        {
            var builder = new TestLoggerBuilder();

            var formatter = new Mock<ILogFormatter>().Object;
            var file = "c:\\foobar";

            builder.AddRollingFileLogProvider(formatter, file, LogLevel.Info,
                maxFileSizeKilobytes: 123, maxArchiveCount: 456, rolloverPeriod: RolloverPeriod.Hourly);

            var registration =
                builder.LogProviderRegistrations.Should().ContainSingle()
                .Subject;

            var logProvider = registration.Invoke(_emptyServiceProvider);

            var rollingFileLogProvider =
                logProvider.Should().BeOfType<RollingFileLogProvider>()
                .Subject;

            rollingFileLogProvider.Level.Should().Be(LogLevel.Info);
            rollingFileLogProvider.File.Should().Be(file);
            rollingFileLogProvider.MaxFileSizeBytes.Should().Be(123 * 1024);
            rollingFileLogProvider.MaxArchiveCount.Should().Be(456);
            rollingFileLogProvider.RolloverPeriod.Should().Be(RolloverPeriod.Hourly);
            rollingFileLogProvider.Formatter.Should().BeSameAs(formatter);
        }

        [Fact(DisplayName = "AddRollingFileLogProvider method 2 throws when formatter parameter is null")]
        public void AddRollingFileLogProviderMethod2SadPath()
        {
            var builder = new Mock<ILoggerBuilder>().Object;

            Action act = () => builder.AddRollingFileLogProvider((ILogFormatter)null, "c:\\foobar", LogLevel.Info,
                maxFileSizeKilobytes: 123, maxArchiveCount: 456, rolloverPeriod: RolloverPeriod.Hourly);

            act.Should().ThrowExactly<ArgumentNullException>().WithMessage("*formatter*");
        }

        [Fact(DisplayName = "AddRollingFileLogProvider method 3 adds rolling file log provider with specified formatter")]
        public void AddRollingFileLogProviderMethod3HappyPath()
        {
            var builder = new TestLoggerBuilder();

            IDependency dependency = new ConcreteDependency();
            int setting = 123;
            var file = "c:\\foobar";

            var serviceProvider = new ServiceCollection()
                .AddSingleton(dependency)
                .BuildServiceProvider();

            builder.AddRollingFileLogProvider<TestLogFormatter>(file, LogLevel.Info,
                maxFileSizeKilobytes: 123, maxArchiveCount: 456, rolloverPeriod: RolloverPeriod.Hourly,
                logFormatterParameters: setting);

            var registration =
                builder.LogProviderRegistrations.Should().ContainSingle()
                .Subject;

            var logProvider = registration.Invoke(serviceProvider);

            var rollingFileLogProvider =
                logProvider.Should().BeOfType<RollingFileLogProvider>()
                .Subject;

            rollingFileLogProvider.Level.Should().Be(LogLevel.Info);
            rollingFileLogProvider.File.Should().Be(file);
            rollingFileLogProvider.MaxFileSizeBytes.Should().Be(123 * 1024);
            rollingFileLogProvider.MaxArchiveCount.Should().Be(456);
            rollingFileLogProvider.RolloverPeriod.Should().Be(RolloverPeriod.Hourly);
            
            var formatter =
                rollingFileLogProvider.Formatter.Should().BeOfType<TestLogFormatter>()
                .Subject;
            
            formatter.Dependency.Should().BeSameAs(dependency);
            formatter.Setting.Should().Be(setting);
        }

        [Fact(DisplayName = "AddRollingFileLogProvider method 4 adds rolling file log provider with specified formatter registration")]
        public void AddRollingFileLogProviderMethod4HappyPath()
        {
            var builder = new TestLoggerBuilder();

            var formatter = new Mock<ILogFormatter>().Object;
            ILogFormatter FormatterRegistration(IServiceProvider sp) => formatter;
            var file = "c:\\foobar";

            builder.AddRollingFileLogProvider(FormatterRegistration, file, LogLevel.Info,
                maxFileSizeKilobytes: 123, maxArchiveCount: 456, rolloverPeriod: RolloverPeriod.Hourly);

            var registration =
                builder.LogProviderRegistrations.Should().ContainSingle()
                .Subject;

            var logProvider = registration.Invoke(_emptyServiceProvider);

            var rollingFileLogProvider =
                logProvider.Should().BeOfType<RollingFileLogProvider>()
                .Subject;

            rollingFileLogProvider.Level.Should().Be(LogLevel.Info);
            rollingFileLogProvider.File.Should().Be(file);
            rollingFileLogProvider.MaxFileSizeBytes.Should().Be(123 * 1024);
            rollingFileLogProvider.MaxArchiveCount.Should().Be(456);
            rollingFileLogProvider.RolloverPeriod.Should().Be(RolloverPeriod.Hourly);
            rollingFileLogProvider.Formatter.Should().BeSameAs(formatter);
        }

        [Fact(DisplayName = "AddRollingFileLogProvider method 4 throws when formatterRegistration parameter is null")]
        public void AddRollingFileLogProviderMethod4SadPath()
        {
            var builder = new Mock<ILoggerBuilder>().Object;

            Action act = () => builder.AddRollingFileLogProvider((Func<IServiceProvider, ILogFormatter>)null, "c:\\foobar", LogLevel.Info,
                maxFileSizeKilobytes: 123, maxArchiveCount: 456, rolloverPeriod: RolloverPeriod.Hourly);

            act.Should().ThrowExactly<ArgumentNullException>().WithMessage("*formatterRegistration*");
        }

        [Fact(DisplayName = "AddRollingFileLogProvider method 5 adds rolling file log provider configured with configureOptions parameter")]
        public void AddRollingFileLogProviderMethod5HappyPath()
        {
            var builder = new TestLoggerBuilder();

            var formatter = new Mock<ILogFormatter>().Object;
            var file = "c:\\foobar";

            var serviceCollection = new ServiceCollection();
            serviceCollection.Configure<RollingFileLogProviderOptions>(options => options.Level = LogLevel.Info);

            builder.AddRollingFileLogProvider(options =>
            {
                options.File = file;
                options.MaxFileSizeKilobytes = 123;
                options.MaxArchiveCount = 456;
                options.RolloverPeriod = RolloverPeriod.Hourly;
                options.SetFormatter(formatter);
            });

            var registration =
                builder.LogProviderRegistrations.Should().ContainSingle()
                .Subject;

            var logProvider = registration.Invoke(serviceCollection.BuildServiceProvider());

            var rollingFileLogProvider =
                logProvider.Should().BeOfType<RollingFileLogProvider>()
                .Subject;

            rollingFileLogProvider.Level.Should().Be(LogLevel.Info);
            rollingFileLogProvider.File.Should().Be(file);
            rollingFileLogProvider.MaxFileSizeBytes.Should().Be(123 * 1024);
            rollingFileLogProvider.MaxArchiveCount.Should().Be(456);
            rollingFileLogProvider.RolloverPeriod.Should().Be(RolloverPeriod.Hourly);
            rollingFileLogProvider.Formatter.Should().BeSameAs(formatter);
        }

        [Fact(DisplayName = "AddRollingFileLogProvider method 5 throws when builder parameter is null")]
        public void AddRollingFileLogProviderMethod5SadPath()
        {
            ILoggerBuilder builder = null;

            Action act = () => builder.AddRollingFileLogProvider();

            act.Should().ThrowExactly<ArgumentNullException>().WithMessage("*builder*");
        }

        #endregion

        private class TestLoggerBuilder : ILoggerBuilder
        {
            public string LoggerName => Logger.DefaultName;

            public IList<Func<IServiceProvider, ILogProvider>> LogProviderRegistrations { get; } = new List<Func<IServiceProvider, ILogProvider>>();

            public IList<Func<IServiceProvider, IContextProvider>> ContextProviderRegistrations { get; } = new List<Func<IServiceProvider, IContextProvider>>();

            public ILoggerBuilder AddLogProvider(Func<IServiceProvider, ILogProvider> logProviderRegistration)
            {
                LogProviderRegistrations.Add(logProviderRegistration);
                return this;
            }

            public ILoggerBuilder AddContextProvider(Func<IServiceProvider, IContextProvider> contextProviderRegistration)
            {
                ContextProviderRegistrations.Add(contextProviderRegistration);
                return this;
            }
        }

        private class TestLogProvider : ILogProvider
        {
            public TestLogProvider(IDependency dependency, int setting) => (Dependency, Setting) = (dependency, setting);
            public IDependency Dependency { get; }
            public int Setting { get; }
            public TimeSpan Timeout => throw new NotImplementedException();
            public LogLevel Level => throw new NotImplementedException();
            public Task WriteAsync(LogEntry logEntry, CancellationToken cancellationToken) => throw new NotImplementedException();
        }

        private class TestContextProvider : IContextProvider
        {
            public TestContextProvider(IDependency dependency, int setting) => (Dependency, Setting) = (dependency, setting);
            public IDependency Dependency { get; }
            public int Setting { get; }
            public void AddContext(LogEntry logEntry) => throw new NotImplementedException();
        }

        private class TestLogFormatter : ILogFormatter
        {
            public TestLogFormatter(IDependency dependency, int setting) => (Dependency, Setting) = (dependency, setting);
            public IDependency Dependency { get; }
            public int Setting { get; }
            public string Format(LogEntry logEntry) => throw new NotImplementedException();
        }

        private interface IDependency
        {
        }

        private class ConcreteDependency : IDependency
        {
        }
    }
}
