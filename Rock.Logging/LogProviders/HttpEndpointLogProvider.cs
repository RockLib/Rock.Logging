﻿using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Rock.Net.Http;
using Rock.Serialization;

namespace Rock.Logging
{
    public class HttpEndpointLogProvider : ILogProvider
    {
        private const string DefaultContentType = "application/json";

        private readonly string _endpoint;
        private readonly LogLevel _loggingLevel;
        private readonly string _contentType;
        private readonly ISerializer _serializer;
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpEndpointLogProvider(
            string endpoint,
            LogLevel loggingLevel,
            string contentType = DefaultContentType,
            ISerializer serializer = null,
            IHttpClientFactory httpClientFactory = null)
        {
            serializer = serializer ?? GetDefaultSerializer();
            httpClientFactory = httpClientFactory ?? GetDefaultHttpClientFactory();

            _endpoint = endpoint;
            _loggingLevel = loggingLevel;
            _contentType = contentType;
            _serializer = serializer;
            _httpClientFactory = httpClientFactory;
        }

        public event EventHandler<ResponseReceivedEventArgs> ResponseReceived;

        public LogLevel LoggingLevel
        {
            get { return _loggingLevel; }
        }

        public async Task WriteAsync(LogEntry entry)
        {
            var serializedEntry = _serializer.SerializeToString(entry);

            var postContent = new StringContent(serializedEntry);
            postContent.Headers.ContentType = new MediaTypeHeaderValue(_contentType);

            using (var httpClient = _httpClientFactory.CreateHttpClient())
            {
                var response = await httpClient.PostAsync(_endpoint, postContent);
                OnResponseReceived(response);
            }
        }

        protected virtual void OnResponseReceived(HttpResponseMessage response)
        {
            var handler = ResponseReceived;
            if (handler != null)
            {
                handler(this, new ResponseReceivedEventArgs(response));
            }
        }

        private static ISerializer GetDefaultSerializer()
        {
            return DefaultJsonSerializer.Current;
        }

        private static IHttpClientFactory GetDefaultHttpClientFactory()
        {
            return DefaultHttpClientFactory.Current;
        }
    }
}
