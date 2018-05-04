﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace RockLib.Logging
{
    public class ConsoleLogProvider : ILogProvider
    {
        public const string DefaultTemplate = @"----------------------------------------------------------------------------------------------------{newLine}LOG INFO{newLine}{newLine}Message: {message}{newLine}Create Time: {createTime(O)}{newLine}Level: {level}{newLine}Log ID: {uniqueId}{newLine}User Name: {userName}{newLine}Machine Name: {machineName}{newLine}Machine IP Address: {machineIpAddress}{newLine}{newLine}EXTENDED PROPERTY INFO{newLine}{newLine}{extendedProperties({key}: {value})}{newLine}EXCEPTION INFO{newLine}{newLine}{exception}";

        public static readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(1);

        private readonly ILogFormatter _formatter;

        public ConsoleLogProvider(
            string template = DefaultTemplate, LogLevel level = default(LogLevel), TimeSpan? timeout = null)
            : this(new TemplateLogFormatter(template ?? DefaultTemplate), level, timeout)
        {
        }

        public ConsoleLogProvider(
            ILogFormatter formatter, LogLevel level = default(LogLevel), TimeSpan? timeout = null)
        {
            _formatter = formatter ?? throw new ArgumentNullException(nameof(formatter));
            Level = level;
            Timeout = timeout ?? DefaultTimeout;
        }

        public TimeSpan Timeout { get; }

        public LogLevel Level { get; }

        public Task WriteAsync(LogEntry logEntry, CancellationToken cancellationToken)
        {
            var formattedLog = _formatter.Format(logEntry);
            return Console.Out.WriteLineAsync(formattedLog);
        }
    }
}
